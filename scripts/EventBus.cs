using System;

namespace gameschallenge2jetpackjoyride.scripts;

public class EventBus {
    public static Action PlayerDied;
    public static Action RestartGame;
    public static Action ScoreChanged;
    public static Action Paused;
    public static Action Playing;

    public static void EmitPlayerDied() {
        PlayerDied?.Invoke();
    }

    public static void EmitRestartGame() {
        RestartGame?.Invoke();
    }

    public static void EmitScoreChanged() {
        ScoreChanged?.Invoke();
    }

    public static void EmitPaused() {
        Paused?.Invoke();
    }

    public static void EmitPlaying() {
        Playing?.Invoke();
    }
}