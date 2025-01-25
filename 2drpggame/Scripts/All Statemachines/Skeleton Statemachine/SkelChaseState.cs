using Godot;
using System;

public partial class SkelChaseState : SkelState
{
	[Export] public float Speed = 40f;
	[Export] public Node2D player;
	[Export] public float VisibilityRange = 200f;
	[Export] public float AttackRange = 30f;
	[Export] public CharacterBody2D Skeleton;

	public override void SkelReady()
	{
		this.Skeleton = this.skeletonfsm.Skeleton;
		if (player == null) {
			GD.Print("Player not defined for ChaseState");
			return;
		}
			
		GD.Print("ChaseState ready");
	}


	public override void SkelUpdate(float delta)
	{
		Skeleton.Velocity = this.Skeleton.GlobalPosition.DirectionTo( player.GlobalPosition ) * this.Speed;

		if(Skeleton.GlobalPosition.DistanceTo(player.GlobalPosition) > VisibilityRange)
		{
			skeletonfsm.SkelTransitionTo("SkelPatrolState");
			GD.Print("Skift til SkelPatrolState");
		}

		if(Skeleton.GlobalPosition.DistanceTo(player.GlobalPosition) < AttackRange)
		{
			GD.Print("Skift til SkelAttackState");
			this.skeletonfsm.SkelTransitionTo("SkelAttackState");
			
		}

		Skeleton.MoveAndSlide();

	}
	
	

	}
