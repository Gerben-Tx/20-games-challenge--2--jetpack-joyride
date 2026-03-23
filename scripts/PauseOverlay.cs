using Godot;
using System;
using gameschallenge2jetpackjoyride.scripts;

public partial class PauseOverlay : Control {
    [Export] public Label ScoreLabel;
    [Export] public Label BestScoreLabel;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        ProcessMode = ProcessModeEnum.Always; // Ignore pause, so we can handle inputs to restart the game
        Visible = false;
        EventBus.PlayerDied += PlayerDied;
    }

    public override void _ExitTree() {
        EventBus.PlayerDied -= PlayerDied;
    }

    private void PlayerDied() {
        ScoreLabel.Text = GameManager.Instance.Score.ToString();
        BestScoreLabel.Text = GameManager.Instance.BestScore.ToString();
        Visible = true;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(
        double delta
    ) {
        if (Input.IsActionJustPressed("Restart")) {
            EventBus.EmitRestartGame();
        }
    }
}