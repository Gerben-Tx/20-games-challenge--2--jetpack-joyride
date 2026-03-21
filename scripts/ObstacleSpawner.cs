using Godot;
using System;

public partial class ObstacleSpawner : Node2D
{
	[Export] private PackedScene _obstacleScene;
	[Export] private float _spawnRate = 3;
	
	private Area2D _obstacleSpawnArea;
	private Area2D _obstacleDespawnArea;
	private Random _random = new Random();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		_obstacleSpawnArea = GetNode<Area2D>("spawn_area");
		_obstacleDespawnArea = GetNode<Area2D>("despawn_area");
		_obstacleDespawnArea.AreaEntered += ObstacleDespawnAreaOnAreaEntered;
		
		Timer timer = new();
		timer.WaitTime = _spawnRate;
		timer.Timeout += SpawnObstacle;
		timer.ProcessMode = ProcessModeEnum.Pausable;
		AddChild(timer);
		timer.Start();
	}

	private void ObstacleDespawnAreaOnAreaEntered(
		Area2D area
	) {
		if (area.GetParent() is Obstacle) {
			area.GetParent().QueueFree();
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta) {
	}

	private void SpawnObstacle() {
		Node2D obstacleNode = _obstacleScene.Instantiate<Node2D>();

		Rect2 spawnArea = _obstacleSpawnArea.GetNode<CollisionShape2D>("CollisionShape2D").Shape.GetRect();
		float randomX = _random.Next(0, (int)spawnArea.Size.X) + spawnArea.Position.X;
		float randomY = _random.Next(0, (int)spawnArea.Size.Y) + spawnArea.Position.Y;
		obstacleNode.Position = new Vector2(randomX, randomY);
		
		AddChild(obstacleNode);
	}
}
