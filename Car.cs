namespace VehicleMaintenanceProgram
{
    /// <summary>
    /// The different types of fuel that a car can use.
    /// </summary>
    public enum FuelType
    {
        Petrol, Diesel, Electric, Hybrid
    }

    /// <summary>
    /// Types of services for the vehicle
    /// </summary>
    public enum ServiceType
    {
        Basic, Comprehensive
    }

    /// <summary>
    /// Represents a car with its properties and methods.
    /// </summary>
    public class Car
    {
        private int _year; // The year the car was manufactured
        private string _make; // The manufacturer of the car
        private string _model; // The model of the car
        private FuelType _fuelType; // The type of fuel the car uses
        private DateTime _wofExpiryDate; // The expiry date of the car's WOF (Warrant of Fitness)
        private DateTime _regoExpiryDate; // The expiry date of the car's registration
        private DateTime _lastServiceDate; // The date when the car was last serviced
        public DateTime wofRenewalDate; // The renewal date for the car's WOF
        public DateTime regoRenewalDate; // The renewal date for the car's rego

        public Car(int year, string make, string model, FuelType fuelType, DateTime wofExpiryDate, DateTime regoExpiryDate, DateTime lastServiceDate)
        {
            // Initialize the car's properties with the provided values
            _year = year;
            _make = make;
            _model = model;
            _fuelType = fuelType;
            _wofExpiryDate = wofExpiryDate;
            _regoExpiryDate = regoExpiryDate;
            _lastServiceDate = lastServiceDate;
        }

        public void DisplaySchedule()
        {
            // Get renewal dates for WOF & rego
            wofRenewalDate = GetRenewalDate(WofExpiryDate);
            regoRenewalDate = GetRenewalDate(RegoExpiryDate);

            // The next service for the car will be a basic one by default
            ServiceType nextServiceType = ServiceType.Basic;

            // The next service date is six months from the last service date
            DateTime nextServiceDate = GetNextServiceDate(LastServiceDate);

            Console.WriteLine("WOF Renewal Date: " + wofRenewalDate);
            Console.WriteLine("Rego Renewal Date: " + regoRenewalDate);

            // Two years (four services)
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Next Service: " + nextServiceType + " on " + nextServiceDate);

                // Update for next service
                nextServiceType = SetNextServiceType(nextServiceType);
                nextServiceDate = nextServiceDate.AddMonths(6);

            }
        }
        
        /// <summary>
        /// Gets the year the car was manufactured.
        /// </summary>
        public int Year
        {
            get { return _year; }
        }

        /// <summary>
        /// Gets the manufacturer of the car.
        /// </summary>
        public string Make
        {
            get { return _make; }
        }

        /// <summary>
        /// Gets the model of the car.
        /// </summary>
        public string Model
        {
            get { return _model; }
        }

        /// <summary>
        /// Gets the type of fuel the car uses.
        /// </summary>
        public FuelType FuelType
        {
            get { return _fuelType; }
        }

        /// <summary>
        /// Gets the expiry date of the car's WOF (Warrant of Fitness).
        /// </summary>
        public DateTime WofExpiryDate
        {
            get { return _wofExpiryDate; }
        }

        /// <summary>
        /// Gets the expiry date of the car's registration.
        /// </summary>
        public DateTime RegoExpiryDate
        {
            get { return _regoExpiryDate; }
        }

        /// <summary>
        /// Gets the date when the car was last serviced.
        /// </summary>
        public DateTime LastServiceDate
        {
            get { return _lastServiceDate; }
        }

        /// <summary>
        /// Gets the renewal date based off the expiry date passed in
        /// </summary>
        /// <param name="expiry">Expiry date</param>
        /// <returns>Renewal date</returns>
        static DateTime GetRenewalDate(DateTime expiry)
        {
            DateTime renewalDate;

            // If expiry date is in the next 7 days
            if ((expiry.Date - DateTime.Today).Days <= 7)
            {
                // Set the renewal date to today
                renewalDate = DateTime.Today;
            }

            else
            {
                // Set the renewal date to seven days before expiry
                renewalDate = expiry.Date.AddDays(-7);
            }

            return renewalDate;
        }

        /// <summary>
        /// Calculates and sets the date of the next service based on the date of the last service
        /// </summary>
        /// <param name="lastServiceDate">Date of the last service</param>
        /// <returns>Date of the next service</returns>
        static DateTime GetNextServiceDate(DateTime lastServiceDate)
        {
            DateTime nextServiceDate;

            // If last service date is before today
            if (lastServiceDate.AddMonths(6) <= DateTime.Today)
            {
                nextServiceDate = DateTime.Today;
            }

            else
            {
                // Set to six months after last service
                nextServiceDate = lastServiceDate.AddMonths(6);
            }

            return nextServiceDate;
        }

        /// <summary>
        /// Sets the next service type to the opposite of what it is now.
        /// </summary>
        /// <param name="nextServiceType">Current/previous type of service</param>
        /// <returns>Next type of service</returns>
        static ServiceType SetNextServiceType(ServiceType nextServiceType)
        {
            if (nextServiceType == ServiceType.Basic)
            {
                nextServiceType = ServiceType.Comprehensive;
            }

            else
            {
                nextServiceType = ServiceType.Basic;
            }

            return nextServiceType;
        }
    }
}
