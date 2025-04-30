using Dal.Api;
using Dal.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Services
{
    internal class RentingService : IPrice, ITime ,IRenting
    {
        public readonly dbClass _context;
        public RentingService(dbClass context)
        {
            _context = context;
        }

        public double GetPriceForHour(int seats, int time)
        {
            var priceEntry = _context.Prices
                .FirstOrDefault(p => p.Seats == seats && p.Time == time);
            return priceEntry?.PriceForHour ?? 0;
        }

        public int GetIdPrice(int seats, int time)
        {
            var priceEntry = _context.Prices
                .FirstOrDefault(p => p.Seats == seats && p.Time == time);
            return priceEntry?.Id ?? -1;
        }

        public double GetPriceForHourById(int id)
        {
            var priceEntry = _context.Prices.Find(id);
            return priceEntry?.PriceForHour ?? 0;
        }

        public int GetSeatsById(int id)
        {
            var priceEntry = _context.Prices.Find(id);
            return priceEntry?.Seats ?? -1;
        }

        public int GetTimeById(int id)
        {
            var priceEntry = _context.Prices.Find(id);
            return priceEntry?.Time ?? -1;
        }

        public List<Price> GetAllPrices()
        {
            try
            {
                return _context.Prices.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving prices: {ex.Message}");
                return new List<Price>();
            }
        }

        public List<int> GetAllIdPrice()
        {
            try
            {
                return _context.Prices.Select(p => p.Id).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving price IDs: {ex.Message}");
                return new List<int>();
            }
        }

        public int GetIdOfDuration(string duration)
        {
            var timeEntry = _context.Times
                .FirstOrDefault(t => t.Duration.Equals(duration, StringComparison.OrdinalIgnoreCase));
            return timeEntry?.Id ?? -1; 
        }

        public string GetIdDuration(int id)
        {
            var timeEntry = _context.Times.Find(id);
            return timeEntry?.Duration ?? string.Empty; 
        }

        public List<string> GetAllDuration()
        {
            try
            {
                return _context.Times.Select(t => t.Duration).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving durations: {ex.Message}");
                return new List<string>(); 
            }
        }

        public List<Time> GetAllTime()
        {
            try
            {
                return _context.Times.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving times: {ex.Message}");
                return new List<Time>(); 
            }
        }

        public List<Renting> GetAllRenting()
        {
            try
            {
                return _context.Rentings.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving rentings: {ex.Message}");
                return new List<Renting>(); 
            }
        }
    }
}

