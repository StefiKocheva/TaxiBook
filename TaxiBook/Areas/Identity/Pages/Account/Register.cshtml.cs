namespace TaxiBook.Areas.Identity.Pages.Account
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.RazorPages;
    using Microsoft.Extensions.Logging;
    using TaxiBook.Data.Models;

    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty] 
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Полето е задължително.")]
            [MinLength(2)]
            [MaxLength(30)]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Полето е задължително.")]
            [MinLength(2)]
            [MaxLength(30)]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Полето е задължително.")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Полето е задължително.")]
            [StringLength(100, ErrorMessage = "{0} трябва да бъде поне {2} и максимално {1} символа дълга.",
                MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Паролата")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Потвърждаване на парола")]
            [Compare("Password", ErrorMessage = "Паролите не съвпадат.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "Полето е задължително.")]
            public IFormFile ProfilePicture { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            this.ReturnUrl = returnUrl;
            this.ExternalLogins = (await this._signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            this.ExternalLogins = (await this._signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (this.ModelState.IsValid)
            {
                var imageUrl = string.Empty;

                if (this.Input.ProfilePicture != null && this.Input.ProfilePicture.Length > 0)
                {
                    var fileName = Path.GetFileName(this.Input.ProfilePicture.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", fileName);

                    using var fileStream = new FileStream(filePath, FileMode.Create);

                    await this.Input.ProfilePicture.CopyToAsync(fileStream);

                    var account = new CloudinaryDotNet.Account
                        {ApiKey = "597981955165718", ApiSecret = "YrIRgn7E7ffUnN1kXSJhyGQJS54", Cloud = "hotelcollab"};

                    fileStream.Close();

                    var cloudinary = new Cloudinary(account);

                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(filePath),
                    };

                    var uploadResult = cloudinary.Upload(uploadParams);

                    System.IO.File.Delete(filePath);

                    imageUrl = uploadResult.Url.ToString();
                }

                var user = new ApplicationUser
                {
                    FirstName = Input.FirstName, 
                    LastName = Input.LastName, 
                    UserName = Input.Email, 
                    Email = Input.Email,
                    EmailConfirmed = true,
                    ImageUrl = imageUrl
                };

                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    this._logger.LogInformation("User created a new account with password.");
                    await this._signInManager.SignInAsync(user, isPersistent: false);

                    return this.LocalRedirect(returnUrl);
                }

                foreach (var error in result.Errors)
                {
                    this.ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return this.Page();
        }
    }
}
