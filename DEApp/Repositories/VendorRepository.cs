using DEApp.Data;
using DEApp.Interfaces;
using DEApp.Models;

namespace DEApp.Repositories
{
    public class VendorRepository : IVendorRepository<int, Vendor>
    {
        private readonly DeappContext _context;
        public VendorRepository(DeappContext context)
        {
            _context = context;
        }

        public Vendor Add(Vendor item)
        {
            _context.Vendors.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Vendor Delete(int key)
        {
            var Vendor = Get(key);
            if (Vendor != null)
            {
                _context.Vendors.Remove(Vendor);
                _context.SaveChanges();
                return Vendor;
            }
            return null;
        }

        public Vendor Get(int key)
        {
            var Vendor = _context.Vendors.FirstOrDefault(v => v.VendorId == key);
            return Vendor;
        }

        public List<Vendor> GetAll()
        {
            return _context.Vendors.ToList();
        }

      

        public Vendor Update(Vendor item)
        {

            _context.Entry<Vendor>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return item;
        }
    }
}
