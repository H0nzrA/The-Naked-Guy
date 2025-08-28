using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	[Export] public float Speed = 200;
    private AnimatedSprite2D p_sprite;
    private string animationNode = "Enemy_animations";

    public override void _Ready()
    {
        p_sprite = GetNode<AnimatedSprite2D>("Enemy_animations");
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("Front"))
        {
            p_sprite.Animation = "Front";
        }
        else if (Input.IsActionPressed("Back"))
        {
            p_sprite.Animation = "Back";
        }
        else if (Input.IsActionPressed("Right"))
        {
            p_sprite.Animation = "Right";
        }
        else if (Input.IsActionPressed("Left"))
        {
            p_sprite.Animation = "Left";
        }
        else
        {
            p_sprite.Animation = "Idle";
        }
    }
}
