using Godot;
using System;
using gameschallenge2jetpackjoyride.scripts;

public partial class GameManager : Node {
    public GameState GameState { get; private set; }
    public static GameManager Instance { get; private set; }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        Instance = this;
        
        EventBus.PlayerDied += EndGame;
        EventBus.RestartGame += RestartGame;
        
        StartGame();
    }

    private void RestartGame() {
        GetTree().ReloadCurrentScene();
        StartGame();
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(
        double delta
    ) { }

    public void EndGame() {
        GameState = GameState.End;
        GetTree().Paused = true;
    }

    public void PauseGame() {
        GameState = GameState.Paused;
        GetTree().Paused = true;
    }

    public void StartGame() {
        GameState = GameState.Playing;
        GetTree().Paused = false;
    }
}