using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace VehicleMaintenanceProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get car details from the user
            int year = GetYear();
            string make = GetMake();
            string model = GetModel();
            FuelType fuelType = GetFuelType();
            DateTime wofExpiryDate = GetWOFExpiryDate();
            DateTime regoExpiryDate = GetRegoExpiryDate();
            DateTime lastServiceDate = GetLastServiceDate();

            // Create a new Car object with the provided details
            Car car = new Car(year, make, model, fuelType, wofExpiryDate, regoExpiryDate, lastServiceDate);

            // Display schedule
            car.DisplaySchedule();

        }

        /// <summary>
        /// Gets the year of the car from user input.
        /// </summary>
        /// <returns>The year of the car.</returns>
        static int GetYear()
        {
            while (true)
            {
                Console.WriteLine("Enter the year of the car:");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int year) && year > 1885 && year <= DateTime.Now.Year) // Cars were invented around 1886
                {
                    return year;
                }

                Console.WriteLine("Invalid input. Please enter a valid year.");
            }
        }

        /// <summary>
        /// Gets the make of the car from user input.
        /// </summary>
        /// <returns>The make of the car.</returns>
        static string GetMake()
        {
            while (true)
            {
                Console.WriteLine("Enter the make of the car:");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.WriteLine("Invalid input. Please enter a valid make.");
            }
        }

        /// <summary>
        /// Gets the model of the car from user input.
        /// </summary>
        /// <returns>The model of the car.</returns>
        static string GetModel()
        {
            while (true)
            {
                Console.WriteLine("Enter the model of the car:");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    return input;
                }

                Console.WriteLine("Invalid input. Please enter a valid model.");
            }
        }

        /// <summary>
        /// Gets the fuel type of the car from user input.
        /// </summary>
        /// <returns>The fuel type of the car.</returns>
        static FuelType GetFuelType()
        {
            while (true)
            {
                Console.WriteLine("Enter the fuel type of the car (Petrol, Diesel, Electric, Hybrid):");
                string input = Console.ReadLine();

                if (Enum.TryParse(input, true, out FuelType fuelType))
                {
                    return fuelType;
                }

                Console.WriteLine("Invalid input. Please enter a valid fuel type.");
            }
        }

        /// <summary>
        /// Gets the WOF expiry date of the car from user input.
        /// </summary>
        /// <returns>The WOF expiry date of the car.</returns>
        static DateTime GetWOFExpiryDate()
        {
            while (true)
            {
                Console.WriteLine("Enter the WOF expiry date of the car (YYYY-MM-DD):");
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime wofExpiryDate))
                {
                    return wofExpiryDate;
                }

                Console.WriteLine("Invalid input. Please enter a valid date in the format YYYY-MM-DD.");
            }
        }

        /// <summary>
        /// Gets the registration expiry date of the car from user input.
        /// </summary>
        /// <returns>The registration expiry date of the car.</returns>
        static DateTime GetRegoExpiryDate()
        {
            while (true)
            {
                Console.WriteLine("Enter the registration expiry date of the car (YYYY-MM-DD):");
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime regoExpiryDate))
                {
                    return regoExpiryDate;
                }

                Console.WriteLine("Invalid input. Please enter a valid date in the format YYYY-MM-DD.");
            }
        }

        /// <summary>
        /// Gets the last service date of the car from user input.
        /// </summary>
        /// <returns>The last service date of the car.</returns>
        static DateTime GetLastServiceDate()
        {
            while (true)
            {
                Console.WriteLine("Enter the last service date of the car (YYYY-MM-DD):");
                string input = Console.ReadLine();

                if (DateTime.TryParse(input, out DateTime lastServiceDate) & lastServiceDate.Date <= DateTime.Today)
                {
                    return lastServiceDate;
                }

                Console.WriteLine("Invalid input. Please enter a valid date in the format YYYY-MM-DD that is today or earlier.");
            }
        }
    }
}