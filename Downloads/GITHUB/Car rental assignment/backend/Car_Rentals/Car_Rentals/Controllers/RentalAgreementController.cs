using BusinessLayer.IServices;
using Microsoft.AspNetCore.Mvc;
using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalAgreementController : ControllerBase
    {
        private readonly IRentalAgreementService _rentalAgreementService;

        public RentalAgreementController(IRentalAgreementService rentalAgreementService)
        {
            _rentalAgreementService = rentalAgreementService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRentalAgreements()
        {
            var rentalAgreements = await _rentalAgreementService.GetAllRentalAgreements();
            return Ok(rentalAgreements);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalAgreementById(Guid id)
        {
            var rentalAgreement = await _rentalAgreementService.GetRentalAgreementById(id);

            if (rentalAgreement == null)
            {
                return NotFound(new { message = "Rental agreement not found" });
            }

            return Ok(rentalAgreement);
        }

        [HttpPost]
        public async Task<IActionResult> AddRentalAgreement([FromBody] RentalAgreementDto rentalAgreementDto)
        {
            var addedRentalAgreement = await _rentalAgreementService.AddRentalAgreement(rentalAgreementDto);
            return CreatedAtAction(nameof(GetRentalAgreementById), new { id = addedRentalAgreement.Id }, addedRentalAgreement);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditRentalAgreement(Guid id, [FromBody] RentalAgreementDto rentalAgreementDto)
        {
            var updatedRentalAgreement = await _rentalAgreementService.EditRentalAgreement(id, rentalAgreementDto);

            if (updatedRentalAgreement == null)
            {
                return NotFound(new { message = "Rental agreement not found" });
            }

            return Ok(updatedRentalAgreement);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRentalAgreement(Guid id)
        {
            var isDeleted = await _rentalAgreementService.DeleteRentalAgreement(id);

            if (!isDeleted)
            {
                return NotFound(new { message = "Rental agreement not found" });
            }

            return Ok(new { message = "Rental agreement deleted successfully" });
        }
        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetAllRentalAgreementsByUserId(string userId)
        {
            var rentalAgreements = await _rentalAgreementService.GetAllRentalAgreementsByUserId(userId);

            if (rentalAgreements == null)
            {
                return NotFound(new { message = "No rental agreements found for the user" });
            }

            return Ok(rentalAgreements);
        }

        [HttpGet("dates/{carId}")]
        public async Task<IActionResult> GetRentalAgreementDatesByCarId(string carId)
        {
            var rentalAgreementDates = await _rentalAgreementService.GetRentalAgreementDatesByCarIdAndStatus(carId);

            if (rentalAgreementDates == null || !rentalAgreementDates.Any())
            {
                return NotFound(new { message = "No rental agreement dates found for the specified carId." });
            }

            return Ok(rentalAgreementDates);
        }



    }
}
