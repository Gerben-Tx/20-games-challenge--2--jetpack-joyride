using Godot;
using System;

public partial class Obstacle : Node2D {
    [Export] private float _rotationSpeed = 450;
    [Export] private float _movementSpeed = 200;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready() { }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(
        double delta
    ) {
        SetRotationDegrees(GetRotationDegrees() + _rotationSpeed * (float)delta);
        Translate(Vector2.Left * _movementSpeed * (float)delta);
    }
}