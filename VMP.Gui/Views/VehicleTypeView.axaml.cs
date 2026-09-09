using Avalonia.Controls;
using Avalonia.Interactivity;
using VMP.Gui.Models;
using System;

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
        // navigate to next screen
    }

    private void Car_Click(object? sender, RoutedEventArgs e)
    {
        _car.VehicleType = VehicleType.Car;
        // navigate to next screen
    }

    private void Truck_Click(object? sender, RoutedEventArgs e)
    {
        _car.VehicleType = VehicleType.Truck;
        // navigate to next screen
        Console.WriteLine(_car.VehicleType);
    }

    private void Other_Click(object? sender, RoutedEventArgs e)
    {
        _car.VehicleType = VehicleType.Other;
        // navigate to next screen
    }
}