using Godot;
using System;

public partial class Killzone : Area2D
{
	[Signal]
	public delegate void OnBodyEnteredEventHandler();

    [Signal]
    public delegate void OnTimerTimeOutEventHandler();
    public Timer timer;

    public override void _Ready()
    {
        BodyEntered += OnBodyEnterdLocal;
        timer = GetNode<Timer>("Timer");

        timer.Timeout += OnTimerTimeOutLocal;
    }

    private void OnBodyEnterdLocal(Node2D body)
    {
        if (body is Player player)
        {
            GD.Print("Player died!");
            Engine.TimeScale = 0.5;

            // Supprimer seulement le joueur
            player.QueueFree();

            timer.Start();
            EmitSignal(SignalName.OnBodyEntered, body);
        }
    }

    private void OnTimerTimeOutLocal()
    {
        Engine.TimeScale = 1.0;
        GetTree().ReloadCurrentScene();
        EmitSignal(SignalName.OnTimerTimeOut);
    }
}
