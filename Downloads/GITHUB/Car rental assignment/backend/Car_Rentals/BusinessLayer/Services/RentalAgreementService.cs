using BusinessLayer.IServices;
using DataAccessLayer.IRepository;
using DataAccessLayer.modals;
using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class RentalAgreementService : IRentalAgreementService
    {
        private readonly IRentalAgreementRepository _rentalAgreementRepository;

        public RentalAgreementService(IRentalAgreementRepository rentalAgreementRepository)
        {
            _rentalAgreementRepository = rentalAgreementRepository;
        }

        public async Task<IEnumerable<RentalAgreementDto>> GetAllRentalAgreements()
        {
            var rentalAgreements = await _rentalAgreementRepository.GetAllRentalAgreements();
            return rentalAgreements.Select(MapRentalAgreementToDto);
        }

        public async Task<RentalAgreementDto> GetRentalAgreementById(Guid id)
        {
            var rentalAgreement = await _rentalAgreementRepository.GetRentalAgreementById(id);
            return MapRentalAgreementToDto(rentalAgreement);
        }

        public async Task<RentalAgreementDto> AddRentalAgreement(RentalAgreementDto rentalAgreementDto)
        {
            // Create a new RentalAgreement entity
            var rentalAgreement = new RentalAgreement
            {
                
                Id = Guid.NewGuid(),
                CarId=rentalAgreementDto.CarId,
                UserId = rentalAgreementDto.UserId,
                RentalStartDate = rentalAgreementDto.RentalStartDate,
                RentalEndDate = rentalAgreementDto.RentalEndDate,
                TotalCost = rentalAgreementDto.TotalCost,
                PhoneNumber = rentalAgreementDto.PhoneNumber,
                Address = rentalAgreementDto.Address,
                IsAccepted = rentalAgreementDto.IsAccepted,
                RequestToReturn = rentalAgreementDto.RequestToReturn
                
            };

            // Add the rental agreement to the repository
            var addedRentalAgreement = await _rentalAgreementRepository.AddRentalAgreement(rentalAgreement);

            // Map the added RentalAgreement entity back to a RentalAgreementDto
            return MapRentalAgreementToDto(addedRentalAgreement);
        }

        public async Task<RentalAgreementDto> EditRentalAgreement(Guid id, RentalAgreementDto rentalAgreementDto)
        {
            var existingRentalAgreement = await _rentalAgreementRepository.GetRentalAgreementById(id);

            if (existingRentalAgreement == null)
            {
                return null; // Handle the case when the rental agreement is not found
            }

            // Update the existing rental agreement entity with data from the rentalAgreementDto
            existingRentalAgreement.CarId = rentalAgreementDto.CarId;
            existingRentalAgreement.UserId = rentalAgreementDto.UserId;
            existingRentalAgreement.RentalStartDate = rentalAgreementDto.RentalStartDate;
            existingRentalAgreement.RentalEndDate = rentalAgreementDto.RentalEndDate;
            existingRentalAgreement.TotalCost = rentalAgreementDto.TotalCost;
            existingRentalAgreement.PhoneNumber = rentalAgreementDto.PhoneNumber;
            existingRentalAgreement.Address = rentalAgreementDto.Address;
            existingRentalAgreement.IsAccepted = rentalAgreementDto.IsAccepted;
            existingRentalAgreement.RequestToReturn = rentalAgreementDto.RequestToReturn;

            // Edit the rental agreement in the repository
            var editedRentalAgreement = await _rentalAgreementRepository.EditRentalAgreement(existingRentalAgreement);

            // Map the edited RentalAgreement entity back to a RentalAgreementDto
            return MapRentalAgreementToDto(editedRentalAgreement);
        }

        public async Task<bool> DeleteRentalAgreement(Guid id)
        {
            // Delete the rental agreement from the repository
            var isDeleted = await _rentalAgreementRepository.DeleteRentalAgreement(id);
            return isDeleted;
        }

        private RentalAgreementDto MapRentalAgreementToDto(RentalAgreement rentalAgreement)
        {
            return new RentalAgreementDto
            {
                Id = rentalAgreement.Id,
                CarId = rentalAgreement.CarId,
                UserId = rentalAgreement.UserId,
                RentalStartDate = rentalAgreement.RentalStartDate,
                RentalEndDate = rentalAgreement.RentalEndDate,
                TotalCost = rentalAgreement.TotalCost,
                PhoneNumber = rentalAgreement.PhoneNumber,
                Address = rentalAgreement.Address,
                IsAccepted = rentalAgreement.IsAccepted,
                RequestToReturn = rentalAgreement.RequestToReturn
            };
        }
        public async Task<IEnumerable<RentalAgreementDto>> GetAllRentalAgreementsByUserId(string userId)
        {
            var rentalAgreements = await _rentalAgreementRepository.GetAllRentalAgreementsByUserId(userId);

            // Map rental agreements to DTOs
            var rentalAgreementDtos = rentalAgreements.Select(ra => MapRentalAgreementToDto(ra));

            return rentalAgreementDtos;
        }

        public async Task<IEnumerable<RentalAgreementDateDto>> GetRentalAgreementDatesByCarIdAndStatus(string carId)
        {
            var rentalAgreements = await _rentalAgreementRepository.GetRentalAgreementsByCarIdAndStatus(carId, true);

            // Map rental agreements to RentalAgreementDateDto if needed
            var rentalAgreementDateDtos = rentalAgreements.Select(ra => new RentalAgreementDateDto
            {
                StartDate = ra.RentalStartDate,
                EndDate = ra.RentalEndDate
            });

            return rentalAgreementDateDtos;
        }




    }
}
