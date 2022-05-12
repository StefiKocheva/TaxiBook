namespace TaxiBook.Areas.TaxiDriver.ViewModels.Taxies
{
    public class TaxiInformationViewModel
    {
        public string Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string NumberPlate { get; set; }

        public UpdateTaxiViewModel UpdateTaxiViewModel { get; set; }
    }
}
