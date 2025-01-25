using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	AnimatedSprite2D aniSprite;
	public Player player;
	

	
	Vector2 direction;
	public float StartHealth = 100f;
	private ProgressBar _progressBar;
	public bool Dead = false;


	[Signal] public delegate void DeathSignalEventHandler(bool Dead);

	public float HitPoints
	{
		get { return _HitPoints; }
		set
		{
			_HitPoints = Mathf.Clamp(value, 0f, 100f);
			if (_HitPoints <= 0f)
			{
				aniSprite.Play("Death");
				EmitSignal(SignalName.DeathSignal, this.Dead);
			}
		}

		
	}

	public void AniEnd()
	{
		QueueFree();
	}

	private float _HitPoints = 100f;


public override void _Ready()
{
	aniSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	HitPoints = StartHealth;

	player = GetNode<Player>("/root/World/Player");
	GD.Print("Player ref: " + player);
	
	player.DamageSignal += HandleHealthChange;
	GD.Print("Enemy health at start: " + HitPoints);
}

public void HandleHealthChange(float DamageSignal)
{
	HitPoints = HitPoints - DamageSignal;
}

public override void _PhysicsProcess(double delta)
{
	
}

public void OnAreaEntered(Area2D PlayerSword)
{
	
	if (PlayerSword.Name == "SwordHitbox")
	{
		
	}
}
}
