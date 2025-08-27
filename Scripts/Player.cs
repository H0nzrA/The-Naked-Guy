using Godot;
using System;

public partial class Player : CharacterBody2D
{
	// Priority variables
	[Export] float Speed = 200;
	private AnimatedSprite2D p_sprite;

	// Player child node name
	string animationNode = "Player_animations";
	public override void _Ready()
	{
		GD.Print("Player scene ready");
		p_sprite = GetNode<AnimatedSprite2D>(animationNode);
		if (p_sprite == null) GD.PrintErr("AnimatedSprite2D missing: " + animationNode);
	}

    public override void _Process(double delta)
    {
		Vector2 velocity = Vector2.Zero;

		// Player controler movement
		if (Input.IsActionPressed("Front"))
		{
			velocity.Y -= 1;
			p_sprite.Animation = "Front";
		}
		else if (Input.IsActionPressed("Back"))
		{
			velocity.Y += 1;
			p_sprite.Animation = "Back";
		}
		else if (Input.IsActionPressed("Right"))
		{
			velocity.X += 1;
			p_sprite.Animation = "Right";
		}
		else if (Input.IsActionPressed("Left"))
		{
			velocity.X -= 1;
			p_sprite.Animation = "Left";
		}
		else
		{
			p_sprite.Animation = "Idle";
		}

		// Update player position
		Position += velocity.Normalized() * Speed * (float)delta;
    }
}
