namespace TaxiBook.Areas.Manager.ViewModels.Schedule
{
    using System.Collections.Generic;

    public class AbsenceListingViewModel
    {
        public IEnumerable<AbsenceDetailsViewModel> Absences { get; set; } = new HashSet<AbsenceDetailsViewModel>();

    }
}
