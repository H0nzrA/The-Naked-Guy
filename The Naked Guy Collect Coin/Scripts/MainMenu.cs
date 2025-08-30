using Godot;

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

    [Export] public PackedScene GameScene;
    
	public override void _Ready()
	{
		// Get buttons
		startButton = GetNode<Button>("Button option/Start");
		startButton.Pressed += OnStartButtonPressed;

        settingsButton = GetNode<Button>("Button option/Settings");
        settingsButton.Pressed += OnSettingsButtonPressed;

        exitButton = GetNode<Button>("Button option/Exit");
        exitButton.Pressed += OnExitButtonPressed;
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("Enter"))
        {
            EmitSignal(SignalName.StartPressed);
            if (GameScene != null)
            {
                GetTree().ChangeSceneToPacked(GameScene);
            }
            else
            {
                GD.PrintErr("GameScene not assign!!");
            }   
        }
        else if (Input.IsActionPressed("Exit"))
        {
            EmitSignal(SignalName.ExitPressed);
            GetTree().Quit();
        }
    }
	public void OnStartButtonPressed()
	{
		GD.Print("Button Start pressed -> signal");
		EmitSignal(SignalName.StartPressed);

        if (GameScene != null)
        {
            GetTree().ChangeSceneToPacked(GameScene);
        }
        else
        {
            GD.PrintErr("GameScene not assign!!");
        }
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
