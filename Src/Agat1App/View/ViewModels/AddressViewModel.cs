using System.ComponentModel;

namespace View.ViewModels {
    public class AddressViewModel {
        public int Id { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        [DisplayName("Building number")]
        public string BuildingNumber { get; set; }
        [DisplayName("Appartment number")]
        public string ApartmentNumber { get; set; }
    }
}