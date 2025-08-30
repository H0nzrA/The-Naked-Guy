using Godot;

public partial class Coin : Area2D
{
    private GameManager gameManager;

    [Signal]
    public delegate void CoinPickedUpEventHandler();

    public override void _Ready()
    {
        gameManager = GetNode<GameManager>("%Game Manager");

        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is Player)
        {
            EmitSignal(SignalName.CoinPickedUp);
            gameManager.AddScore();
            QueueFree();
        }
    }
}
