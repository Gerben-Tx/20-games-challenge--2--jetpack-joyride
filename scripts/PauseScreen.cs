using Godot;
using System;
using gameschallenge2jetpackjoyride.scripts;

public partial class PauseScreen : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Visible = false;
		
		EventBus.Paused += Paused;
		EventBus.Playing += Playing;
	}

	public override void _ExitTree() {
		EventBus.Paused -= Paused;
		EventBus.Playing -= Playing;
	}

	private void Playing() {
		Visible = false;
	}

	private void Paused() {
		Visible = true;
	}
}
