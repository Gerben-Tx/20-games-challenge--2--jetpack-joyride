using Godot;
using System;
using gameschallenge2jetpackjoyride.scripts;

public partial class GameManager : Node {
    public GameState GameState { get; private set; }
    public static GameManager Instance { get; private set; }
    public int Score {
        get => _score;
        private set {
            _score = value;
            EventBus.EmitScoreChanged();
        }
    }
    public int BestScore { get; private set; }

    private int _score = 0;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        Instance = this;
        ProcessMode = ProcessModeEnum.Always;

        EventBus.PlayerDied += EndGame;
        EventBus.RestartGame += RestartGame;

        Timer timer = new();
        timer.WaitTime = 1.0f;
        timer.Timeout += () => {
            if (GameState == GameState.Playing) {
                Score += 1;
            }
        };
        timer.ProcessMode = ProcessModeEnum.Pausable;
        AddChild(timer);
        timer.Start();

        StartGame();
    }

    private void RestartGame() {
        GetTree().ReloadCurrentScene();
        StartGame();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(
        double delta
    ) {
        if (Input.IsActionJustPressed("Pause")) {
            if (GameState == GameState.Playing) {
                PauseGame();
            } else if (GameState == GameState.Paused) {
                UnPauseGame();
            }
        }
    }

    private void UnPauseGame() {
        GameState = GameState.Playing;
        GetTree().Paused = false;
        EventBus.EmitPlaying();
    }

    private void EndGame() {
        GameState = GameState.End;
        GetTree().Paused = true;
        BestScore = Score > BestScore ? Score : BestScore;
    }

    private void PauseGame() {
        GameState = GameState.Paused;
        EventBus.EmitPaused();
        GetTree().Paused = true;
    }

    private void StartGame() {
        GameState = GameState.Playing;
        GetTree().Paused = false;
        Score = 0;
    }
}