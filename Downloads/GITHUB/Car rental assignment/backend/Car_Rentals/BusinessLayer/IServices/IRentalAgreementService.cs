using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.IServices
{
    public interface IRentalAgreementService
    {
        Task<IEnumerable<RentalAgreementDto>> GetAllRentalAgreements();
        Task<RentalAgreementDto> GetRentalAgreementById(Guid id);
        Task<RentalAgreementDto> AddRentalAgreement(RentalAgreementDto rentalAgreementDto);
        Task<RentalAgreementDto> EditRentalAgreement(Guid id, RentalAgreementDto rentalAgreementDto);
        Task<bool> DeleteRentalAgreement(Guid id);
        Task<IEnumerable<RentalAgreementDto>> GetAllRentalAgreementsByUserId(string userId);

        Task<IEnumerable<RentalAgreementDateDto>> GetRentalAgreementDatesByCarIdAndStatus(string carId);


    }
}
