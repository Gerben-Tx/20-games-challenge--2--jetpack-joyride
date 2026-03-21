using System;

namespace gameschallenge2jetpackjoyride.scripts;

public class EventBus {
    public static Action PlayerDied;
    public static Action RestartGame;

    public static void EmitPlayerDied() {
        PlayerDied?.Invoke();
    }

    public static void EmitRestartGame() {
        RestartGame?.Invoke();
    }
}