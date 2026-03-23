using Godot;
using System;
using gameschallenge2jetpackjoyride.scripts;

public partial class Player : Node2D {
    [Export] private Texture2D _flyingTexture; 
    [Export] private Texture2D _walking1Texture; 
    // [Export] private Texture _walking2Texture; 
    private RigidBody2D _playerBody;
    private Sprite2D _sprite;
    private float _jumpForce = 500;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() {
        _playerBody = GetNode<RigidBody2D>("RigidBody2D");
        _sprite = _playerBody.GetNode<Sprite2D>("Sprite2D");

        Area2D playerArea = _playerBody.GetNode<Area2D>("Area2D");
        playerArea.AreaEntered += PlayerBodyOnAreaEntered;
        playerArea.AreaExited += PlayerAreaOnAreaExited;
    }

    private void PlayerAreaOnAreaExited(
        Area2D area
    ) {
        if (area.GetParent().Name.ToString() == "floor") {
            _sprite.Texture = _flyingTexture;
        }
    }

    private void PlayerBodyOnAreaEntered(
        Node area
    ) {
        if (area.GetParent() is Obstacle) {
            EventBus.EmitPlayerDied();
        }

        if (area.GetParent().Name.ToString() == "floor") {
            _sprite.Texture = _walking1Texture;
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(
        double delta
    ) {
        if (GameManager.Instance.GameState != GameState.Playing) {
            return;
        }

        if (Input.IsActionPressed("Jump")) {
            _playerBody.ApplyForce(Vector2.Up * _jumpForce);
        }
    }
}