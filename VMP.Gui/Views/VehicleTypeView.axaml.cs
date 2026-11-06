using Avalonia.Controls;
using Avalonia.Interactivity;
using VMP.Gui.Models;

namespace VMP.Gui.Views;

public partial class VehicleTypeView : UserControl
{
    private Car _car = new();

    public VehicleTypeView()
    {
        InitializeComponent();
    }

    public VehicleTypeView(Car car) : this()
    {
        _car = car;
    }

    private void Motorcycle_Click(object? sender, RoutedEventArgs e)
    {
        _car.VehicleType = VehicleType.Motorcycle;
        Content = new YearMakeModelView();
    }

    private void Car_Click(object? sender, RoutedEventArgs e)
    {
        _car.VehicleType = VehicleType.Car;
        Content = new YearMakeModelView();
    }

    private void Truck_Click(object? sender, RoutedEventArgs e)
    {
        _car.VehicleType = VehicleType.Truck;
        Content = new YearMakeModelView();
    }

    private void Other_Click(object? sender, RoutedEventArgs e)
    {
        _car.VehicleType = VehicleType.Other;
        Content = new YearMakeModelView();
    }
}