using DEApp.Models.DTOs;

namespace DEApp.Services
{
    public interface IVendorService
    {
        public List<VendorDTO> GetAllVendors();
        public VendorDTO GetVendorById(int vendorId);
        public VendorDTO AddVendor(VendorDTO vendorDTO);
        public VendorDTO UpdateVendor(VendorDTO vendorDTO);
        public VendorDTO DeleteVendorById(int vendorId);
    }
}
