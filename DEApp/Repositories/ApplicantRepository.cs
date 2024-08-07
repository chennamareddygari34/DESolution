using System.Collections.Generic;
using System.Linq;
using DEApp.Data;
using DEApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DEApp.Repositories
{
    public class ApplicantRepository : IApplicantRepository
    {
        private readonly DeappContext _context;

        public ApplicantRepository(DeappContext context)
        {
            _context = context;
        }

        public Applicant GetById(int id)
        {
            return _context.Applicants.Find(id);
        }

        public IEnumerable<Applicant> GetAll()
        {
            return _context.Applicants.Include(a => a.Vendor).ToList();
        }

        public void Add(Applicant entity)
        {
            _context.Applicants.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Applicant entity)
        {
            _context.Applicants.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var applicant = _context.Applicants.Find(id);
            if (applicant != null)
            {
                _context.Applicants.Remove(applicant);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Applicant> GetApplicantsByVendorId(int vendorId)
        {
            return _context.Applicants
                .Where(a => a.VendorId == vendorId)
                .Include(a => a.Vendor)
                .Include(a => a.Loans)
                .ToList();
        }

        public List<Applicant> GetAllApplicants()
        {
            return _context.Applicants
                .Include(a => a.Vendor)
                .Include(a => a.Loans)   
                .ToList();
        }
    }
}
