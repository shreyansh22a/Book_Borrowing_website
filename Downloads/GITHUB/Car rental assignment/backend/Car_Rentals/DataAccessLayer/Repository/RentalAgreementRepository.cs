using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.data;
using DataAccessLayer.IRepository;
using DataAccessLayer.modals;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class RentalAgreementRepository : IRentalAgreementRepository
    {
        private readonly ApplicationDbContext _context;

        public RentalAgreementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RentalAgreement>> GetAllRentalAgreements()
        {
            return await _context.RentalAgreements.ToListAsync();
        }

        public async Task<RentalAgreement> GetRentalAgreementById(Guid id)
        {
            return await _context.RentalAgreements.FindAsync(id);
        }
        public async Task<IEnumerable<RentalAgreement>> GetAllRentalAgreementsByUserId(string userId)
        {
            return await _context.RentalAgreements
                .Where(ra => ra.UserId == userId)
                .ToListAsync();
        }

        public async Task<RentalAgreement> AddRentalAgreement(RentalAgreement rentalAgreement)
        {
            _context.RentalAgreements.Add(rentalAgreement);
            await _context.SaveChangesAsync();
            return rentalAgreement;
        }

        public async Task<RentalAgreement> EditRentalAgreement(RentalAgreement rentalAgreement)
        {
            _context.Entry(rentalAgreement).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return rentalAgreement;
        }

        public async Task<bool> DeleteRentalAgreement(Guid id)
        {
            var rentalAgreement = await _context.RentalAgreements.FindAsync(id);
            if (rentalAgreement == null)
            {
                return false;
            }

            _context.RentalAgreements.Remove(rentalAgreement);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RentalAgreement>> GetRentalAgreementsByCarIdAndStatus(string carId, bool isAccepted)
        {
            return await _context.RentalAgreements
                .Where(ra => ra.CarId == carId && ra.IsAccepted == isAccepted)
                .ToListAsync();
        }





    }
}
