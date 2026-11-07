using System.Text.RegularExpressions;

namespace VehicleMaintenanceProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            int year = GetYear();
            string make = GetMake();
            string model = GetModel();
            FuelType fuelType = GetFuelType();
            DateTime wofExpiryDate = GetWOFExpiryDate();
            DateTime regoExpiryDate = GetRegoExpiryDate();
            DateTime dateOfLastService = GetDateOfLastService();

            Car car = new Car(year, make, model, fuelType, wofExpiryDate, regoExpiryDate, dateOfLastService);
            car.DisplaySchedule();
        }

        static int GetYear()
        {
            while (true)
            {
                Console.WriteLine("Enter the year of the car:");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int year) && year > 1885 && year <= DateTime.Now.Year) // Cars were invented around 1886
                {
                    return year;
                }

                Console.WriteLine("Invalid input. Please enter a valid year.");
            }
        }

        static string GetMake()
        {
            while (true)
            {
                Console.WriteLine("Enter the make of the car:");
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"\d"))
                {
                    return input;
                }

                Console.WriteLine("Invalid input. Please enter a valid make.");
            }
        }

        static string GetModel()
        {
            while (true)
            {
                Console.WriteLine("Enter the model of the car:");
                string? input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input) && !Regex.IsMatch(input, @"\d"))
                {
                    return input;
                }

                Console.WriteLine("Invalid input. Please enter a valid model.");
            }
        }

        static FuelType GetFuelType()
        {
            while (true)
            {
                Console.WriteLine("Enter the fuel type of the car (Petrol, Diesel, Electric, Hybrid):");
                string? input = Console.ReadLine();

                if (Enum.TryParse(input, true, out FuelType fuelType) && !Regex.IsMatch(input, @"\d"))
                {
                    return fuelType;
                }

                Console.WriteLine("Invalid input. Please enter a valid fuel type.");
            }
        }

        static DateTime GetWOFExpiryDate()
        {
            while (true)
            {
                Console.WriteLine("Enter the WOF expiry date of the car (YYYY-MM-DD):");
                string? input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime wofExpiryDate) && wofExpiryDate.Year > 1885)
                {
                    return wofExpiryDate;
                }

                Console.WriteLine("Invalid input. Please enter a valid date in the format YYYY-MM-DD.");
            }
        }

        static DateTime GetRegoExpiryDate()
        {
            while (true)
            {
                Console.WriteLine("Enter the registration expiry date of the car (YYYY-MM-DD):");
                string? input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime regoExpiryDate) && regoExpiryDate.Year > 1885)
                {
                    return regoExpiryDate;
                }

                Console.WriteLine("Invalid input. Please enter a valid date in the format YYYY-MM-DD.");
            }
        }

        static DateTime GetDateOfLastService()
        {
            while (true)
            {
                Console.WriteLine("Enter the last service date of the car (YYYY-MM-DD):");
                string? input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime lastServiceDate) && lastServiceDate.Year > 1885 && lastServiceDate.Date <= DateTime.Today)
                {
                    return lastServiceDate;
                }

                Console.WriteLine("Invalid input. Please enter a valid date in the format YYYY-MM-DD that is today or earlier.");
            }
        }
    }
}