# Vehicle Maintenance Program
A C# console program that takes your car details and prints a schedule of regular maintenance appointments: when your WOF and rego expire, when to renew them, and when your next services are due. 

I built this after buying a new car. I neglected my last one, partly because I could never remember when services, rego and WOF renewals were due, and I wanted to avoid repeating that.

## Features
- Prompts for vehicle details with input validation and retry on bad input
- Reports WOF and rego status (expired, expires today, or expires on a date)
- Suggests a renewal date for each
- Generates the next four services (two years), alternating between Basic and Comprehensive
- Flags overdue services by scheduling them for today

## Getting started

Requires the [.NET 10 SDK](https://dotnet.microsoft.com/download).

```bash
git clone https://github.com/plantingspade/vmp.git
cd vmp
dotnet run
```

## Example

```
Enter the year of the car:
2006
Enter the make of the car:
Mazda
Enter the model of the car:
Demio
Enter the fuel type of the car (Petrol, Diesel, Electric, Hybrid):
Petrol
Enter the WOF expiry date of the car (YYYY-MM-DD):
2027-01-19
Enter the registration expiry date of the car (YYYY-MM-DD):
2028-06-08
Enter the last service date of the car (YYYY-MM-DD):
2026-08-13
Your WOF expires on 19/01/2027
Your rego expires on 08/06/2028
WOF Renewal Date: 12/01/2027
Rego Renewal Date: 01/06/2028
Next Service: Basic on 13/02/2027
Next Service: Comprehensive on 13/08/2027
Next Service: Basic on 13/02/2028
Next Service: Comprehensive on 13/08/2028
```

## How the schedule works

| Rule | Behaviour |
|------|-----------|
| Renewal date | 7 days before expiry. If expiry is within 7 days or already passed, the renewal date is today. |
| Service interval | 6 months after the last service. If that date is today or earlier, the next service is today. |
| Service type | Alternates between Basic and Comprehensive, starting with Basic. |
| Schedule length | Four services (two years). |

The 6-month interval is a common recommendation; many manufacturers specify 6-12 months or a set distance, whichever comes first. The 7-day renewal window is a buffer I chose so there's time to book.

## Design
- `Car` holds the vehicle's details and the scheduling rules.
- The rule methods (`GetRenewalDate`, `GetDateOfNextService`, `SetNextServiceType`, `GetExpiryMessage`) are static and take today's date as a parameter instead of reading the system clock. This makes them deterministic and easy to test.
- `Program.cs` handles user input, validation, and printing.
- `FuelType` and `ServiceType` are enums, so invalid values can't be stored.

```
VehicleMaintenanceProgram.csproj
Car.cs
Program.cs
VMP.Tests/        xUnit tests
```

## Testing

**Automated:** 13 xUnit tests cover the scheduling logic, including boundary cases such as a WOF expiring exactly today and a service due exactly today.

```bash
dotnet test VMP.Tests
```

**Manual:** I tested input validation by hand with deliberately bad input.

| Field | Inputs tried | Result |
|-------|--------------|--------|
| Year | 1840, 2027, blank, letters, mixed, symbols | Error message and retry |
| Make and model | Blank, fake make/model | Fake names accepted |
| Fuel type | Numbers, mixed, misspelling, not an option, lowercase | Invalid rejected; lowercase accepted |
| WOF, rego, last service dates | Letters, year only, 1840, month above 12, day above 31, future date | Error message and retry; future last-service date rejected |

## Known limitations

- Fake makes and models are accepted, since there are too many real ones to maintain a list.
- Fuel type is collected but doesn't affect the schedule yet.
- The app runs once and exits, and doesn't save anything.
- Service scheduling is time-based only (doesn’t account for kilometres driven).

## Future work

- Persistence (saving vehicles)
- Multiple vehicles and other vehicle types
- Schedules tailored to fuel type or owner manuals
- Export schedule to a file
- A GUI, which is partly built on the [`gui` branch](https://github.com/plantingspade/vmp/tree/gui)
