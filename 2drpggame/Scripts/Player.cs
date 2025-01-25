using Godot;
using System;
using System.Security.Cryptography.X509Certificates;




public partial class Player : CharacterBody2D
{
	[Export] public float Speed = 120.0f;
	AnimatedSprite2D aniSprite;
	bool isAttacking = false;
	public int DirectionMoved = 1;
	public bool isAttackReady = true;
	bool areaOverlapping = false;
	
	public Area2D HitBox;
	public AttackState attackState;

	[Export] public float StartHealth = 100f;
	private ProgressBar _progressBar;
	[Export] public float Damage = 25f;

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
	
	[Signal]
	public delegate void DamageSignalEventHandler(float Damage);
	
	public override void _Ready()
	{
		attackState = GetNode<AttackState>("/root/World/Enemy/FSM/AttackState");
		GD.Print("player found attackstate: " + attackState);
		attackState.EnemyDamageSignal += HandleHealthChange;
		GD.Print("wasdfedrfhtgresgfrdbgwesdgfvsedfvcvdsvcdvdsvcvsdvsdvsdcvfsdvsdvsdv");
		aniSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		HitBox = GetNode<Area2D>("SwordHitbox");
		GD.Print("this is my sword" + HitBox);
		_progressBar = GetNode<ProgressBar>("CanvasLayer/Control/ProgressBar");
		HitPoints = StartHealth;
	}

	public void HandleHealthChange(float EnemyDamageSignal)
	{
		HitPoints = HitPoints - EnemyDamageSignal;
		GD.Print("Player health is now: " + HitPoints);
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
				hitboxChange(direction.X, direction.Y);
			}
		}
		else if (direction.Y < 0)  //walking upwards animation
		{
			if (isAttacking == false)
			{
				aniSprite.Play("up");
				hitboxChange(direction.X, direction.Y);
			}
		}
		else if (direction.Y > 0)  //walking downwards animation
		{
			if (isAttacking == false)
			{
				aniSprite.Play("down");
				hitboxChange(direction.X, direction.Y);
			}
		}
		else if (direction.X == 0 && direction.Y == 0)
		{
			if (isAttacking == false)
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





		if (Input.IsActionPressed("attack"))
		{
			if (this.isAttacking == false)
			{
				isAttacking = true;
				Speed = Speed - 90f;
				if (isAttackReady == true)
				{
					//GD.Print("Attack was ready..");
					if (areaOverlapping == true)
					{
						GD.Print("SENDER SIGNAL TIL ENEMY : Damage dealt.");
						EmitSignal(SignalName.DamageSignal, this.Damage);
						isAttackReady = false;
					}
				}

				if (direction.X != 0)
				{
					aniSprite.Play("SwordSwingLeftRight");
					// GD.Print("Attacking Left... or Right!");

				}
				else if (direction.Y < 0)
				{
					aniSprite.Play("SwordSwingUp");
					// GD.Print("Attacking upwards!");
				}
				else if (direction.Y > 0)
				{
					aniSprite.Play("SwordSwingDown");
					// GD.Print("Attacking downwards!");
				}
				else if (direction.X == 0 && direction.Y == 0)
				{
					if (DirectionMoved == 1)
					{
						aniSprite.Play("SwordSwingLeftRight");
						// GD.Print("Attacking Left... or Right!");
					}
					if (DirectionMoved == 2)
					{
						aniSprite.Play("SwordSwingUp");
						// GD.Print("Attacking upwards!");
					}
					if (DirectionMoved == 3)
					{
						aniSprite.Play("SwordSwingDown");
						// GD.Print("Attacking downwards!");
					}
				}
			}
		}
		Velocity = velocity;
		MoveAndSlide();
	}

	private void hitboxChange(float posX, float posY)
	{
		if (posX != 0)
		{
			if (posX > 0)
			{
				HitBox.Position = new Vector2(18.5f, 0);
			}
			else if (posX < 0)
			{
				HitBox.Position = new Vector2(-18.5f, 0);
			}
		}

		if (posY != 0)
		{
			if (posY == -1)
			{
				HitBox.Position = new Vector2(0, -12f);
			}
			else if (posY == 1)
			{
				HitBox.Position = new Vector2(0, 9f);
			}
		}
	}




	public void AttackIsOver()
	{
		// GD.Print("Attack is over");
		isAttacking = false;
		Speed = Speed + 90f;
		isAttackReady = true;
	}

	public void AnimationHasChanged()
	{
		if (GetLastMotion().X != 0)
		{
			DirectionMoved = 1;
			// GD.Print("motion recieved: ±X");
		}
		if (GetLastMotion().Y < 0)
		{
			DirectionMoved = 2;
			// GD.Print("motion recieved: -Y");
		}
		if (GetLastMotion().Y > 0)
		{
			DirectionMoved = 3;
			// GD.Print("motion recieved: +Y");
		}
	}

	public void OnAreaEntered(Area2D hitbox)
	{
		areaOverlapping = true;
	}

	public void OnAreaExit(Area2D hitbox)
	{
		areaOverlapping = false;
	}

	public void PlayerHurtboxEntered(Area2D area)
	{
		
	}
	
	//Noden "Player" er subscribed til TotemArea, body_entered. Som følge vil denne metode blive kaldt. 
	public void _OnTotemAreaPlayerEntered(Node2D other) {
		if (other.Name == "Player" && GetNode<Global>("/root/Global").HasWon() == true) 
		{
			GD.Print("Spiller Hastighed lig nul");
			Speed = 0f;
		}
	}
	
	 
}
