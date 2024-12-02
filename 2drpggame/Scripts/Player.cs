using Godot;
using System;
using System.Security.Cryptography.X509Certificates;

//[export] float attacking = false;


public partial class Player : CharacterBody2D
{
	public float Speed = 130.0f;
	AnimatedSprite2D aniSprite;
	bool isAttacking = false;


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
				aniSprite.Play("leftRight");
		}
		else if (direction.X < 0)  //walking left animation
		{
			velocity.X = direction.X * Speed;
			if (isAttacking == false)
				aniSprite.Play("leftRight");
		}
		else if (direction.Y < 0)  //walking upwards animation
		{
			velocity.Y = direction.Y * Speed;
			if (isAttacking == false)
				aniSprite.Play("up");
		}
		else if (Input.IsActionPressed("ui_down"))  //walking downwards animation
		{
			velocity.Y = direction.Y * Speed;
			if (isAttacking == false)
				aniSprite.Play("down");
		}
		else if (direction.X == 0 && direction.Y == 0)
		{
			if (isAttacking == false)
				GetLastMotion(velocity);
					GD.Print(GetLastMotion());

				
			{
				aniSprite.Play("idle");
			}
		}

		
		


		if (Input.IsActionPressed("attack"))
		{

			if (this.isAttacking == false)
			{
				aniSprite.Play("SwordSwingLeftRight");
				isAttacking = true;
				Speed = 65f;
			}

			GD.Print("Sword swing leftRight");



		}

		Velocity = velocity;
		MoveAndSlide();
	}

    private void GetLastMotion(float x, float y)
    {
        throw new NotImplementedException();
    }


    public void GetLastMotion(Vector2 velocity)
    {
        GD.Print(GetLastMotion() + "... is the last motion");
    }

    public void AttackIsOver()
	{
		isAttacking = false;
		Speed = 130f;
	}


}
