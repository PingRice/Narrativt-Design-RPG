using Godot;
using System;

public partial class AttackState : State
{
	[Export] public Node2D player;
	[Export] public float attackRate = 1;  // numbers of attacks pr. second..
	[Export] public float attackRange = 30; // Range of attack ...
	public CharacterBody2D npc;
	string EnemyAttacking;

	float EnemyDamage = 12.5f;

	[Signal]
	public delegate void EnemyDamageSignalEventHandler(float EnemyDamage);

	private Timer attackTimer;

	public override void Ready()
	{
		this.npc = this.fsm.npc;
		attackTimer = GetNode<Timer>("Timer");
		
		attackTimer.WaitTime = this.attackRate;
		attackTimer.Timeout += Attack;

		GD.Print("AttackState is ready" + this.Name ); // Info ift. fejl i opsætning
	}

	public override void Update(float delta) 
	{
		
		if (fsm.npc.GlobalPosition.DistanceTo(player.GlobalPosition) > this.attackRange) 
		{
			//GD.Print("Skift til PatrolState");
			fsm.TransitionTo("PatrolState");
			EnemyAttacking = "not in range";
		}

		if(EnemyAttacking == "Ready to tackle")
		{
			npc.MoveAndSlide();
			npc.Velocity = this.npc.GlobalPosition.DirectionTo( player.GlobalPosition ) * 150f;
		}

		if(fsm.npc.GlobalPosition.DistanceTo(player.GlobalPosition) < 2)
		{
			EmitSignal(SignalName.EnemyDamageSignal, this.EnemyDamage);
			EnemyAttacking = "Bounce from recoil";	
			
			
		}
		
		if(EnemyAttacking == "Bounce from recoil")
			{
				npc.Velocity = this.npc.GlobalPosition.DirectionTo( player.GlobalPosition ) * -150.0f;
				npc.MoveAndSlide();
			}
	}

	public void Attack() 
	{
		
		
		if(fsm.npc.GlobalPosition.DistanceTo(player.GlobalPosition) > 2)
		{
			EnemyAttacking = "Ready to tackle";
		}
	}

	public void PhysicsUpdate()
	{
		
	}

	public override void Exit() 
	{
		attackTimer.Stop();
	}

	public override void Enter() 
	{
		attackTimer.Start();
	}
}
