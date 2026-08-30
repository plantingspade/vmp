namespace VehicleMaintenanceProgram
{
    public enum FuelType
    {
        Petrol, Diesel, Electric, Hybrid
    }

    public enum ServiceType
    {
        Basic, Comprehensive
    }

    public class Car
    {
        private int _year; // The year the car was manufactured
        private string _make; // The manufacturer of the car
        private string _model; // The model of the car
        private FuelType _fuelType; // The type of fuel the car uses
        private DateTime _wofExpiryDate; // The expiry date of the car's WOF (Warrant of Fitness)
        private DateTime _regoExpiryDate; // The expiry date of the car's registration
        private DateTime _dateOfLastService; // The date when the car was last serviced
        private DateTime _wofRenewalDate; // The renewal date for the car's WOF
        private DateTime _regoRenewalDate; // The renewal date for the car's rego

        public Car(int year, string make, string model, FuelType fuelType, DateTime wofExpiryDate, DateTime regoExpiryDate, DateTime dateOfLastService)
        {
            _year = year;
            _make = make;
            _model = model;
            _fuelType = fuelType;
            _wofExpiryDate = wofExpiryDate;
            _regoExpiryDate = regoExpiryDate;
            _dateOfLastService = dateOfLastService;
        }

        public void DisplaySchedule()
        {
            _wofRenewalDate = GetRenewalDate(WofExpiryDate);
            _regoRenewalDate = GetRenewalDate(RegoExpiryDate);
            Console.WriteLine(GetExpiryMessage("WOF", WofExpiryDate));
            Console.WriteLine(GetExpiryMessage("rego", RegoExpiryDate));
            Console.WriteLine("WOF Renewal Date: " + _wofRenewalDate.ToShortDateString());
            Console.WriteLine("Rego Renewal Date: " + _regoRenewalDate.ToShortDateString());

            ServiceType nextServiceType = ServiceType.Basic;
            DateTime dateOfNextService = GetDateOfNextService(DateOfLastService);

            // Two years (four services)
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"Next Service: {nextServiceType} on {dateOfNextService.ToShortDateString()}");
                nextServiceType = SetNextServiceType(nextServiceType);
                dateOfNextService = dateOfNextService.AddMonths(6);
            }
        }
        
        public int Year
        {
            get { return _year; }
        }

        public string Make
        {
            get { return _make; }
        }

        public string Model
        {
            get { return _model; }
        }

        public FuelType FuelType
        {
            get { return _fuelType; }
        }

        public DateTime WofExpiryDate
        {
            get { return _wofExpiryDate; }
        }

        public DateTime RegoExpiryDate
        {
            get { return _regoExpiryDate; }
        }

        public DateTime DateOfLastService
        {
            get { return _dateOfLastService; }
        }
        
        /// <summary>
        /// Returns a renewal date that's 7 days before expiry or today if expiry
        /// is within 7 days / already passed
        /// </summary>
        /// <param name="expiry">Expiry date</param>
        /// <returns>Renewal date</returns>
        public static DateTime GetRenewalDate(DateTime expiry)
        {
            DateTime renewalDate;

            if ((expiry.Date - DateTime.Today).Days <= 7)
            {
                renewalDate = DateTime.Today;
            }

            else
            {
                renewalDate = expiry.Date.AddDays(-7);
            }

            return renewalDate;
        }

        /// <summary>
        /// Returns a date six months from the date of the last service
        /// or today if service is overdue
        /// </summary>
        /// <param name="dateOfLastService">Date of last service</param>
        /// <returns>Date of next service</returns>
        public static DateTime GetDateOfNextService(DateTime dateOfLastService)
        {
            DateTime dateOfNextService;

            // If date of the next service is today or before
            if (dateOfLastService.AddMonths(6) <= DateTime.Today)
            {
                dateOfNextService = DateTime.Today;
            }

            else
            {
                dateOfNextService = dateOfLastService.AddMonths(6);
            }

            return dateOfNextService;
        }

        public static ServiceType SetNextServiceType(ServiceType nextServiceType)
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

        /// <summary>
        /// Returns a message with what is expiring and when 
        /// </summary>
        /// <param name="label">What is expiring</param>
        /// <param name="expiryDate">Date of expiry</param>
        /// <returns>A message saying what is expiring and when</returns>
        public static string GetExpiryMessage(string label, DateTime expiryDate)
        {
            if (expiryDate.Date < DateTime.Today)
            {
                return $"Your {label} expired on {expiryDate.ToShortDateString()}";
            }

            else if (expiryDate.Date == DateTime.Today)
            {
                return $"Your {label} expires today";
            }

            else
            {
                return $"Your {label} expires on {expiryDate.ToShortDateString()}";
            }
        }
    }
}
