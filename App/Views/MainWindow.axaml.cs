using Avalonia.Controls;
using SharpHook;
using SharpHook.Data;
using SharpHook.Simulation;
using System;
using System.Diagnostics;
using App.Models;

namespace App.Views;

public partial class MainWindow : Window
{
    private readonly EventSimulator _simulator = EventSimulator.Create("MyAvaloniaInputSimulator");

    public MainWindow()
    {
        InitializeComponent();
        Closed += (_, _) => _simulator.Dispose();
    }

    private void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        ScriptRunner.Test();
        //TriggerEmulation();
    }

    private void TriggerEmulation()
    {
        _simulator.SimulateKeyPress(KeyCode.VcVolumeMute);
        _simulator.SimulateKeyRelease(KeyCode.VcVolumeMute);
    }
}