using Godot;
using System;

public partial class GameManager : Node
{
	private int score = 0;
	private Label scoreLabel;

	public override void _Ready()
	{
		scoreLabel = GetNode<Label>("%Score Label");
	}
	public void AddScore() {  
		score++;
		GD.Print("+1 score");

		scoreLabel.Text = "Score: " + score;
	}
}
