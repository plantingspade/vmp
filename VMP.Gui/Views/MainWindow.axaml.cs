using Avalonia.Controls;
using Avalonia.Interactivity;
using VMP.Gui.Models;
using System;

namespace VMP.Gui.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Content = new VehicleTypeView(new Car());
    }
}