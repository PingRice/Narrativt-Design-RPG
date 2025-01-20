using Godot;
using System;

public partial class AttackState : State
{
	[Export] public Node2D player;
	[Export] public float attackRate = 1;  // numbers of attacks pr. second..
	[Export] public float attackRange = 30; // Range of attack ...
	public CharacterBody2D npc;
	int EnemyAttacking = 0;

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
			EnemyAttacking = 0;
		}

		if(EnemyAttacking == 1)
		{
			npc.MoveAndSlide();
			npc.Velocity = this.npc.GlobalPosition.DirectionTo( player.GlobalPosition ) * 150f;
		}

		if(fsm.npc.GlobalPosition.DistanceTo(player.GlobalPosition) < 2)
		{
			
			EnemyAttacking = 2;	
			
		}
		
		if(EnemyAttacking == 2)
			{
				npc.Velocity = this.npc.GlobalPosition.DirectionTo( player.GlobalPosition ) * -150.0f;
				npc.MoveAndSlide();
			}
	}

	public void Attack() 
	{
		
		
		if(fsm.npc.GlobalPosition.DistanceTo(player.GlobalPosition) > 2)
		{
			EnemyAttacking = 1;
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
