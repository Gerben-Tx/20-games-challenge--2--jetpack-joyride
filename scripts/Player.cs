using Godot;
using System;
using gameschallenge2jetpackjoyride.scripts;

public partial class Player : Node2D
{
	private RigidBody2D _playerBody;
	private float _jumpForce = 500;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_playerBody = GetNode<RigidBody2D>("RigidBody2D");
		
		Area2D playerArea = _playerBody.GetNode<Area2D>("Area2D");
		playerArea.AreaEntered += PlayerBodyOnAreaEntered;
	}

	private void PlayerBodyOnAreaEntered(
		Node area
	) {
		if (area.GetParent() is Obstacle) {
			EventBus.EmitPlayerDied();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GameManager.Instance.GameState != GameState.Playing) {
			return;
		}
		
		if (Input.IsActionPressed("Jump")) {
			_playerBody.ApplyForce(Vector2.Up * _jumpForce);
		}
	}
}
