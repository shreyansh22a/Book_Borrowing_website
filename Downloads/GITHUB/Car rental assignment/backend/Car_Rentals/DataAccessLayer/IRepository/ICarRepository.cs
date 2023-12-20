using DataAccessLayer.modals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepository
{
    public interface ICarRepository
    {
        Task<IEnumerable<Car>> GetAllCars();
        Task<Car> AddCar(Car car);
        Task<Car> EditCar(Car car);
        Task<bool> DeleteCar(Guid carId);
        Task<Car> GetCarById(Guid carId);
    }
}
