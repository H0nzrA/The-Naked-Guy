using Godot;
using System;

public partial class MainMenu : Control
{
	// Signal for each buttons
	[Signal]
	public delegate void StartPressedEventHandler();
	Button startButton;

    [Signal]
    public delegate void SettingsPressedEventHandler();
    Button settingsButton;

    [Signal]
    public delegate void ExitPressedEventHandler();
    Button exitButton;
    
	public override void _Ready()
	{
		GD.Print("Main menu scene ready");

		// Get buttons
		startButton = GetNode<Button>("Button option/Start");
		startButton.Pressed += OnStartButtonPressed;

        settingsButton = GetNode<Button>("Button option/Settings");
        settingsButton.Pressed += OnSettingsButtonPressed;

        exitButton = GetNode<Button>("Button option/Exit");
        exitButton.Pressed += OnExitButtonPressed;
    }

	public void OnStartButtonPressed()
	{
		GD.Print("Button Start pressed -> signal");
		EmitSignal(SignalName.StartPressed);
	}

    public void OnSettingsButtonPressed()
    {
        GD.Print("Button Settings pressed -> signal");
        EmitSignal(SignalName.SettingsPressed);
    }

    public void OnExitButtonPressed()
    {
        GD.Print("Button Exit pressed -> signal");
        EmitSignal(SignalName.ExitPressed);
        GetTree().Quit();
    }

}
