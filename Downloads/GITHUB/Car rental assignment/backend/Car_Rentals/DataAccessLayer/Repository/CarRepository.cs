
using DataAccessLayer.data;
using DataAccessLayer.IRepository;
using DataAccessLayer.modals;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repository
{
    public class CarRepository : ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            // Retrieve all cars from the database
            var cars = await _context.Cars.ToListAsync();
            return cars;
        }

        public async Task<Car> AddCar(Car car)
        {
            // Add a new car to the database
            _context.Cars.Add(car);
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<Car> EditCar(Car car)
        {
            // Update an existing car in the database
            _context.Entry(car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return car;
        }

        public async Task<bool> DeleteCar(Guid carId)
        {
            // Find the car by ID
            var car = await _context.Cars.FindAsync(carId);

            if (car == null)
                return false; // Car not found

            // Remove the car from the database
            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return true; // Car deleted successfully
        }

        public async Task<Car> GetCarById(Guid carId)
        {
            // Retrieve a car by its ID
            var car = await _context.Cars.FindAsync(carId);
            return car;
        }
    }
}