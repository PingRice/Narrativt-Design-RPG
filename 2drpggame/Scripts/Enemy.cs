using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	AnimatedSprite2D aniSprite;
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	Vector2 direction;
	public float StartHealth = 100f;
	private ProgressBar _progressBar;
	
	public float HitPoints
	{
		get { return _HitPoints; }
		set
		{
			_HitPoints = Mathf.Clamp(value,0f,100f);
			_progressBar.Value = _HitPoints;
			if(_HitPoints <= 0f)
			{
				GetTree().ReloadCurrentScene();
			}
		}
	}
	private float _HitPoints = 100f;
	

	public void _Ready()
	{
		aniSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		_progressBar = GetNode<ProgressBar>("CanvasLayer/Control/ProgressBar");
		HitPoints = StartHealth;
	}

	public override void _PhysicsProcess(double delta)
	{
		
	}
 
	public void OnAreaEntered(Area2D PlayerSword)
	{
		if(PlayerSword.Name == "SwordHitbox")
		{
			
		}
	}
}
