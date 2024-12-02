using Godot;
using System;

public partial class Player : CharacterBody2D
{
	public const float Speed = 130.0f;
	AnimatedSprite2D aniSprite;


	public override void _Ready() 
	{
		aniSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
	}



	public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Vector2.Zero;

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		//GD.Print(direction);
		//Højre
		if (direction.X > 0) //right
		{
			velocity.X = direction.X * Speed;
			aniSprite.FlipH = false;
			aniSprite.Play("leftRight");
		} 
		else if (direction.X < 0)//left 
		{
			velocity.X = direction.X * Speed;
			aniSprite.FlipH = true;
			aniSprite.Play("leftRight");
		} 
		else if (direction.Y < 0)
		{
			velocity.Y = direction.Y * Speed;
			aniSprite.Play("up");
		}  
		else if (Input.IsActionPressed("ui_down"))
		{
			velocity.Y = direction.Y * Speed;
			aniSprite.Play("down");
		} else if (direction.X == 0 && direction.Y == 0) 
		{
			aniSprite.Play("idle");
		}
		

		Velocity = velocity;
		MoveAndSlide();
	}
}
