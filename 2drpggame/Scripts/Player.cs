using Godot;
using System;
using System.Security.Cryptography.X509Certificates;




public partial class Player : CharacterBody2D
{
	public float Speed = 120.0f;
	AnimatedSprite2D aniSprite;
	bool isAttacking = false;
	int DirectionMoved = 1;

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


		if (direction.X > 0)
			aniSprite.FlipH = false;

		if (direction.X < 0)
			aniSprite.FlipH = true;


		if (direction != Vector2.Zero)
		{
			velocity = direction * Speed;
		}





		if (direction.X != 0)  //walking left or right animation
		{
			if (isAttacking == false)
			{
				aniSprite.Play("leftRight");
			}
		}
		else if (direction.Y < 0)  //walking upwards animation
		{
			if (isAttacking == false)
			{
				aniSprite.Play("up");
			}
		}
		else if (direction.Y > 0)  //walking downwards animation
		{
			if (isAttacking == false)
			{
				aniSprite.Play("down");
			}
		}
		else if (direction.X == 0 && direction.Y == 0)
		{
			if (isAttacking == false)
			{
				{
					if (GetLastMotion().X != 0)
					{
						aniSprite.Play("IdleLeftRight");
					}
					else if (GetLastMotion().Y < 0)
					{
						aniSprite.Play("IdleFacingUp");
						DirectionMoved = 2;
					}
					else if (GetLastMotion().Y > 0)
					{
						aniSprite.Play("idle");
						DirectionMoved = 3;
					}
				}
			}
		}





		if (Input.IsActionPressed("attack"))
		{
			if (this.isAttacking == false)
			{
				isAttacking = true;
				Speed = 40f;

				if (direction.X != 0)
				{
					aniSprite.Play("SwordSwingLeftRight");
					GD.Print("Attacking Left... or Right!");
				}
				else if (direction.Y < 0)
				{
					aniSprite.Play("SwordSwingUp");
					GD.Print("Attacking upwards!");
				}
				else if (direction.Y > 0)
				{
					aniSprite.Play("SwordSwingDown");
					GD.Print("Attacking downwards!");
				}
				else if (direction.X == 0 && direction.Y == 0)
				{
					if (DirectionMoved == 1)
					{
						aniSprite.Play("SwordSwingLeftRight");
						GD.Print("Attacking Left... or Right!");
					}
					if (DirectionMoved == 2)
					{
						aniSprite.Play("SwordSwingUp");
						GD.Print("Attacking upwards!");
					}
					if (DirectionMoved == 3)
					{
						aniSprite.Play("SwordSwingDown");
						GD.Print("Attacking downwards!");
					}
				}
			}
		}
		Velocity = velocity;
		MoveAndSlide();
	}






	public void AttackIsOver()
	{
		isAttacking = false;
		Speed = 120f;
		GD.Print("Attack is over");
	}

	public void AnimationHasChanged()
	{
		if (GetLastMotion().X != 0)
		{
			DirectionMoved = 1;
			GD.Print("motion recieved: ±X");
		}
		if (GetLastMotion().Y < 0)
		{
			DirectionMoved = 2;
			GD.Print("motion recieved: +Y");
		}
		if (GetLastMotion().Y > 0)
		{
			DirectionMoved = 3;
			GD.Print("motion recieved: -Y");
		}
	}


}
