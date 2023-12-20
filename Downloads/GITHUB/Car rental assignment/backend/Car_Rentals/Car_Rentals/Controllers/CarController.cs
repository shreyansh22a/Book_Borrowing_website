using BusinessLayer.IServices;
using Microsoft.AspNetCore.Mvc;
using SharedLayer.DTOs;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Car_Rentals.Controllers
{
    [Route("api/cars")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        // GET: api/cars
        [HttpGet]
        public async Task<IActionResult> GetAllCars()
        {
            try
            {
                var cars = await _carService.GetAllCars();
                return Ok(cars);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/cars
        [HttpPost]
        public async Task<IActionResult> AddCar([FromBody] CarDto carDto)
        {
            try
            {
                var addedCar = await _carService.AddCar(carDto);
                return CreatedAtAction(nameof(GetCarById), new { carId = addedCar.Id }, addedCar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/cars/{carId}
        [HttpPut("{carId}")]
        public async Task<IActionResult> EditCar(Guid carId, [FromBody] CarDto carDto)
        {
            try
            {
                var editedCar = await _carService.EditCar(carId, carDto);

                if (editedCar == null)
                {
                    return NotFound(new { message = "Car not found" });
                }

                return Ok(editedCar);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/cars/{carId}
        [HttpDelete("{carId}")]
        public async Task<IActionResult> DeleteCar(Guid carId)
        {
            try
            {
                var isDeleted = await _carService.DeleteCar(carId);

                if (!isDeleted)
                {
                    return NotFound(new { message = "Car not found" });
                }

                return Ok(new { message = "Car deleted successfully" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/cars/{carId}
        [HttpGet("{carId}")]
        public async Task<IActionResult> GetCarById(Guid carId)
        {
            try
            {
                var car = await _carService.GetCarById(carId);

                if (car == null)
                {
                    return NotFound(new { message = "Car not found" });
                }

                return Ok(car);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
