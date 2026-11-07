using VehicleMaintenanceProgram;
using Xunit;

public class CarTests
{
    private static readonly DateTime Today = new DateTime(2026, 6, 15); // Fixed date for testing purposes
    [Fact]



    // ---- Tests for GetRenewalDate method ----

    public void TestGetRenewalDate_ExpiryFarAway() // Should return 7 days before the expiry date
    {
        DateTime expiry = new DateTime(2026, 12, 1);
        DateTime result = Car.GetRenewalDate(expiry, Today);

        Assert.Equal(new DateTime(2026, 11, 24), result);
    }

    [Theory]
    [InlineData(2026, 6, 22)] // exactly 7 days away
    [InlineData(2026, 6, 18)] // within the week
    [InlineData(2026, 6, 15)] // expires today
    [InlineData(2026, 6, 1)]  // already expired
    public void TestGetRenewalDate_ExpiryWithinSevenDaysOrPast(int y, int m, int d) // Should return today
    {
        DateTime result = Car.GetRenewalDate(new DateTime(y, m, d), Today);

        Assert.Equal(Today, result);
    }



    // ---- Tests for GetDateOfNextService method ----

    [Fact]
    public void TestGetDateOfNextService_RecentService() // Should return 6 months from the last service date
    {
        DateTime lastService = new DateTime(2026, 3, 1);
        DateTime result = Car.GetDateOfNextService(lastService, Today);

        Assert.Equal(new DateTime(2026, 9, 1), result);
    }

    [Fact]
    public void TestGetDateOfNextService_Overdue() // Should return today
    {
        DateTime lastService = new DateTime(2025, 1, 1);
        DateTime result = Car.GetDateOfNextService(lastService, Today);

        Assert.Equal(Today, result);
    }

    [Fact]
    public void TestGetDateOfNextService_DueExactlyToday() // Should return today
    {
        DateTime lastService = new DateTime(2025, 12, 15); // +6 months = 15 Jun 2026
        DateTime result = Car.GetDateOfNextService(lastService, Today);

        Assert.Equal(Today, result);
    }



    // ---- Tests for SetNextServiceType ----

    [Fact]
    public void TestSetNextServiceType_Basic() // Should return Comprehensive
    {
        Assert.Equal(ServiceType.Comprehensive, Car.SetNextServiceType(ServiceType.Basic));
    }

    [Fact]
    public void TestSetNextServiceType_Comprehensive() // Should return Basic
    {
        Assert.Equal(ServiceType.Basic, Car.SetNextServiceType(ServiceType.Comprehensive));
    }



    // ---- Tests for GetExpiryMessage ----

    [Fact]
    public void TestGetExpiryMessage_Expired() // Should say "expires on" with the correct date
    {
        DateTime expiry = new DateTime(2026, 6, 1);
        string result = Car.GetExpiryMessage("WOF", expiry, Today);

        Assert.Equal($"Your WOF expired on {expiry.ToShortDateString()}", result);
    }

    [Fact]
    public void TestGetExpiryMessage_ExpiresToday() // Should say "expires today"
    {
        string result = Car.GetExpiryMessage("rego", Today, Today);

        Assert.Equal("Your rego expires today", result);
    }

    [Fact]
    public void TestGetExpiryMessage_Future() // Should say "expires on" with the correct date
    {
        DateTime expiry = new DateTime(2026, 12, 1);
        string result = Car.GetExpiryMessage("WOF", expiry, Today);

        Assert.Equal($"Your WOF expires on {expiry.ToShortDateString()}", result);
    }
}

