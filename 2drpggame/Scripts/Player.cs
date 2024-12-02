using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

//[export] float attacking = false;


public partial class Player : CharacterBody2D
{
	public float Speed = 120.0f;
	AnimatedSprite2D aniSprite;
	bool isAttacking = false;
	int DirectionMoved;

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







		if (direction.X > 0)  //walking right animation
		{
			velocity.X = direction.X * Speed;
			if (isAttacking == false)
			{
				aniSprite.Play("leftRight");
				//aniIsPlaying = true;
			}
		}
		else if (direction.X < 0)  //walking left animation
		{
			velocity.X = direction.X * Speed;
			if (isAttacking == false)
			{
				aniSprite.Play("leftRight");
				//aniIsPlaying = true;
			}
		}
		else if (direction.Y < 0)  //walking upwards animation
		{
			velocity.Y = direction.Y * Speed;
			if (isAttacking == false)
			{
				aniSprite.Play("up");
				//aniIsPlaying = true;
			}
		}
		else if (Input.IsActionPressed("ui_down"))  //walking downwards animation
		{
			velocity.Y = direction.Y * Speed;
			if (isAttacking == false)
			{
				aniSprite.Play("down");
				//aniIsPlaying = true;
			}
		}
		else if (direction.X == 0 && direction.Y == 0)
		{
			if (isAttacking == false)
			{
				//if (aniIsPlaying == false)
				{
					if (GetLastMotion().Y < 0)
					{
						aniSprite.Play("IdleFacingUp");
						GD.Print(GetLastMotion() + "... is the last motion (its upwards)");
						DirectionMoved = 1;
					}
					else if (GetLastMotion().Y > 0)
					{
						aniSprite.Play("idle");
						DirectionMoved = 2;
					}
					else if (GetLastMotion().X != 0)
					{
						aniSprite.Play("IdleLeftRight");
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

				if (DirectionMoved == 1)
				{
					aniSprite.Play("SwordSwingUp");
					GD.Print("Attacking upwards!");
				}
				else if (DirectionMoved == 2)
				{
					aniSprite.Play("SwordSwingDown");
					GD.Print("Attacking downwards!");
				}
				else if (DirectionMoved == 3)
				{
					aniSprite.Play("SwordSwingLeftRight");
					GD.Print("Attacking Left... or Right!");
				}

			}

		}

		Velocity = velocity;
		MoveAndSlide();
	}




	public void GetLastMotion(Vector2 velocity)
	{

	}

	public void AttackIsOver()
	{
		isAttacking = false;
		Speed = 120f;
	}



}
