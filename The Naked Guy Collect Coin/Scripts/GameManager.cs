using Godot;

public partial class GameManager : Node
{
	private int score = 0;
	private const int targetScore = 30;
	private Label scoreLabel;
	private Control congratulation_scene;

	public override void _Ready()
	{
		scoreLabel = GetNode<Label>("%Score Label");
		congratulation_scene = GetNode<Control>("%Congratulation");
	}

    public override void _Process(double delta)
    {
        if (Input.IsActionPressed("Enter") && congratulation_scene.Visible)
		{
            congratulation_scene.Visible = false;
			GetTree().ChangeSceneToFile("res://Scenes/Main_menu.tscn");
        }
    }
	public void AddScore() {  
		score++;
		GD.Print("+1 score");

		scoreLabel.Text = "Score: " + score;

		if (score == targetScore)
		{
            scoreLabel.Text = "Max score attempt";
			congratulation_scene.Visible = true;
        }
	}
}
