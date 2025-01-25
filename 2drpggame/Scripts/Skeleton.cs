using Godot;
using System;

public partial class Skeleton : CharacterBody2D
{
	AnimatedSprite2D aniSprite;
	public Player player;
	public bool isSkeletonDead = false;
	public float StartHealth = 100f;


	[Signal] public delegate void skelDeathSignalEventHandler(bool isSkeletonDead);

	public float HitPoints
	{
		get { return _HitPoints; }
		set
		{
			_HitPoints = Mathf.Clamp(value, 0f, 100f);
			if (_HitPoints <= 0f)
			{
				aniSprite.Play("Death");
				EmitSignal(SignalName.skelDeathSignal, this.isSkeletonDead);
			}
		}

		
	}

	private float _HitPoints = 100f;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		player = GetNode<Player>("/root/World/Player");
		GD.Print("Player ref: " + player);
	
		player.DamageSignal += HandleHealthChange;
		GD.Print("Skeleton health at start: " + HitPoints);
	}

	public void HandleHealthChange(float DamageSignal)
	{
		HitPoints = HitPoints - DamageSignal;
		GD.Print("SIGNAL FROM PLAYER : Skeleton health: " + HitPoints);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
