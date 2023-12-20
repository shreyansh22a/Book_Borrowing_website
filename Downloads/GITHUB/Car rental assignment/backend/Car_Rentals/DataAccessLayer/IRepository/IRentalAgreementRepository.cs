using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataAccessLayer.modals;

namespace DataAccessLayer.IRepository
{
    public interface IRentalAgreementRepository
    {
        Task<IEnumerable<RentalAgreement>> GetAllRentalAgreements();
        Task<RentalAgreement> GetRentalAgreementById(Guid id);
        Task<RentalAgreement> AddRentalAgreement(RentalAgreement rentalAgreement);
        Task<RentalAgreement> EditRentalAgreement(RentalAgreement rentalAgreement);
        Task<bool> DeleteRentalAgreement(Guid id);

        Task<IEnumerable<RentalAgreement>> GetAllRentalAgreementsByUserId(string userId);

        Task<IEnumerable<RentalAgreement>> GetRentalAgreementsByCarIdAndStatus(string carId, bool isAccepted);



    }
}
