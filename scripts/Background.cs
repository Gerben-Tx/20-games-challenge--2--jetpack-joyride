using Godot;
using System;
using gameschallenge2jetpackjoyride.scripts;

public partial class Background : TextureRect {
	private float _originalSpeed;
	private ShaderMaterial _shaderMaterial;
	private float _customTime;
	private const string ShaderParamCustomTime = "CUSTOM_TIME";
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready() {
		_shaderMaterial = (ShaderMaterial)Material;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (GameManager.Instance.GameState == GameState.Playing) {
			_customTime += (float)delta;
			_shaderMaterial.SetShaderParameter(ShaderParamCustomTime, _customTime);
		}
	}
}
