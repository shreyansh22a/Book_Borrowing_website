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
    public class CarService : ICarService
    {
        private readonly ICarRepository _carRepository;

        public CarService(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        public async Task<IEnumerable<CarDto>> GetAllCars()
        {
            var cars = await _carRepository.GetAllCars();
            return cars.Select(c => MapCarToCarDto(c));
        }

        public async Task<CarDto> AddCar(CarDto carDto)
        {
            // Generate a new Guid for the car
            carDto.Id = Guid.NewGuid();

            // Map the CarDto to a Car entity manually
            var car = MapCarDtoToCar(carDto);

            // Add the car to the repository
            var addedCar = await _carRepository.AddCar(car);

            // Map the added Car entity back to a CarDto
            var addedCarDto = MapCarToCarDto(addedCar);
            return addedCarDto;
        }

        public async Task<CarDto> EditCar(Guid carId, CarDto carDto)
        {
            var existingCar = await _carRepository.GetCarById(carId);

            if (existingCar == null)
            {
                return null; // Handle the case when the car is not found
            }

            // Update the existing car entity with data from the carDto manually
            UpdateCarWithCarDto(existingCar, carDto);

            // Edit the car in the repository
            var editedCar = await _carRepository.EditCar(existingCar);

            // Map the edited Car entity back to a CarDto
            var editedCarDto = MapCarToCarDto(editedCar);
            return editedCarDto;
        }

        public async Task<bool> DeleteCar(Guid carId)
        {
            // Delete the car from the repository
            var isDeleted = await _carRepository.DeleteCar(carId);
            return isDeleted;
        }

        public async Task<CarDto> GetCarById(Guid carId)
        {
            var car = await _carRepository.GetCarById(carId);

            if (car == null)
            {
                return null; // Handle the case when the car is not found
            }

            // Map the Car entity to a CarDto
            var carDto = MapCarToCarDto(car);
            return carDto;
        }

        private CarDto MapCarToCarDto(Car car)
        {
            return new CarDto
            {
                Id = car.Id,
                Maker = car.Maker,
                Model = car.Model,
                RentalPrice = car.RentalPrice,
                IsAvailable = car.IsAvailable,
                Color = car.Color,
                ImageUrl = car.ImageUrl
                // Map other properties as needed
            };
        }

        private Car MapCarDtoToCar(CarDto carDto)
        {
            return new Car
            {
                Id = carDto.Id,
                Maker = carDto.Maker,
                Model = carDto.Model,
                RentalPrice = carDto.RentalPrice,
                IsAvailable = carDto.IsAvailable,
                Color = carDto.Color,
                ImageUrl = carDto.ImageUrl
                // Map other properties as needed
            };
        }

        private void UpdateCarWithCarDto(Car car, CarDto carDto)
        {
            car.Maker = carDto.Maker;
            car.Model = carDto.Model;
            car.RentalPrice = carDto.RentalPrice;
            car.IsAvailable = carDto.IsAvailable;
            car.Color = carDto.Color;
            car.ImageUrl = carDto.ImageUrl;
            // Update other properties as needed
        }
    }
}
