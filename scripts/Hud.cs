using Godot;
using System;
using gameschallenge2jetpackjoyride.scripts;

public partial class Hud : Control {
    [Export] private Label _scoreLabel;
    [Export] private Label _bestScoreLabel;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        EventBus.ScoreChanged += ScoreChanged;
        EventBus.PlayerDied += PlayerDied;
        
        UpdateScoreLabel();
        UpdateBestScoreLabel();
    }

    public override void _ExitTree() {
        EventBus.ScoreChanged -= ScoreChanged;
        EventBus.PlayerDied -= PlayerDied;
    }

    private void UpdateBestScoreLabel() {
        _bestScoreLabel.Text = GameManager.Instance.BestScore.ToString();
    }

    private void UpdateScoreLabel() {
        _scoreLabel.Text = GameManager.Instance.Score.ToString();
    }

    private void PlayerDied() {
        UpdateBestScoreLabel();
    }

    private void ScoreChanged() {
        UpdateScoreLabel();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(
        double delta
    ) { }
}