using Godot;
using System;

public partial class Enemy : CharacterBody2D
{
	AnimatedSprite2D aniSprite;
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;
	Vector2 direction;

	public void _Ready()
	{
		aniSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
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
