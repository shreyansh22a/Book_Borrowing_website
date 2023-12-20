using SharedLayer.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.IServices
{
    public interface ICarService
    {
        Task<IEnumerable<CarDto>> GetAllCars();
        Task<CarDto> AddCar(CarDto carDto);
        Task<CarDto> EditCar(Guid carId, CarDto carDto);
        Task<bool> DeleteCar(Guid carId);
        Task<CarDto> GetCarById(Guid carId);
    }
}
