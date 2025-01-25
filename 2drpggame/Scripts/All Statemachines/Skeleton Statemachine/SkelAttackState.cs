using Godot;
using System;

public partial class SkelAttackState : SkelState
{
	[Export] public Node2D player;
	[Export] public float AttackRate = 1;  // numbers of attacks pr. second..
	[Export] public float AttackRange = 30; // Range of attack ...
	public CharacterBody2D Skeleton;
	string SkeletonAttacking;

	[Export] float SkeletonDamage = 20f;

	[Signal] public delegate void SkeletonDamageSignalEventHandler(float SkeletonDamage);

	private Timer skelAttackTimer;

	public override void SkelReady()
	{
		this.Skeleton = this.skeletonfsm.Skeleton;
		skelAttackTimer = GetNode<Timer>("Timer");
		
		skelAttackTimer.WaitTime = this.AttackRate;
		skelAttackTimer.Timeout += Attack;

		GD.Print("AttackState is ready: " + this.Name ); // Info ift. fejl i opsætning
	}

	public override void SkelUpdate(float delta) 
	{
		
		if (skeletonfsm.Skeleton.GlobalPosition.DistanceTo(player.GlobalPosition) > this.AttackRange) 
		{
			//GD.Print("Skift til PatrolState");
			skeletonfsm.SkelTransitionTo("SkelPatrolState");
		}

		
	}

	public void Attack() 
	{
		
		
		if(skeletonfsm.Skeleton.GlobalPosition.DistanceTo(player.GlobalPosition) > 2)
		{
			
		}
	}

	public void PhysicsUpdate()
	{
		
	}

	public override void SkelExit() 
	{
		skelAttackTimer.Stop();
	}

	public override void SkelEnter() 
	{
		skelAttackTimer.Start();
		GD.Print("skeleton entered attackstate");
	}
}
