using Godot;

public partial class Enemy : Node2D
{
	[Export] public float Speed = 90;
    public int direction = 1;

    public RayCast2D rayCast_left;
    public RayCast2D rayCast_right;
    public AnimatedSprite2D enemy_animation;

    public override void _Ready()
    {

        rayCast_right = GetNode<RayCast2D>("RayCast_right");
        rayCast_left = GetNode<RayCast2D>("RayCast_left");
        enemy_animation = GetNode<AnimatedSprite2D>("Enemy_animations");

        if (rayCast_right == null || rayCast_left == null)
        {
            GD.PrintErr("RayCast Enemy no identified");
        }
    }

    public override void _Process(double delta)
    {
        if (rayCast_left.IsColliding())
        {
            direction = 1;
            enemy_animation.FlipH = false;
        }
        else if (rayCast_right.IsColliding())
        {
            direction = -1;
            enemy_animation.FlipH = true;
        }

        Vector2 pos = Position;
        pos.X += direction * Speed * (float)delta;
        Position = pos;
    }
}
