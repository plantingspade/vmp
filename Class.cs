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
    /// Represents a car with its properties and methods.
    /// </summary>
    public class Car
    {
        private int _year; // The year the car was manufactured
        private string _make; // The manufacturer of the car
        private string _model; // The model of the car
        private FuelType _fuelType; // The type of fuel the car uses
        private int _mileage; // The current mileage of the car
        private DateTime _wofExpiry; // The expiry date of the car's WOF (Warrant of Fitness)
        private DateTime _regoExpiry; // The expiry date of the car's registration
        private DateTime _lastServiceDate; // The date when the car was last serviced

        public Car(int year, string make, string model, FuelType fuelType, int mileage, DateTime wofExpiry, DateTime regoExpiry, DateTime lastServiceDate)
        {
            // Initialize the car's properties with the provided values
            _year = year;
            _make = make;
            _model = model;
            _fuelType = fuelType;
            _mileage = mileage;
            _wofExpiry = wofExpiry;
            _regoExpiry = regoExpiry;
            _lastServiceDate = lastServiceDate;
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
        /// Gets the current mileage of the car.
        /// </summary>
        public int Mileage
        {
            get { return _mileage; }
        }

        /// <summary>
        /// Gets the expiry date of the car's WOF (Warrant of Fitness).
        /// </summary>
        public DateTime WofExpiry
        {
            get { return _wofExpiry; }
        }

        /// <summary>
        /// Gets the expiry date of the car's registration.
        /// </summary>
        public DateTime RegoExpiry
        {
            get { return _regoExpiry; }
        }

        /// <summary>
        /// Gets the date when the car was last serviced.
        /// </summary>
        public DateTime LastServiceDate
        {
            get { return _lastServiceDate; }
        }

        public override string ToString()
        {
            return "";
        }
    }
}
