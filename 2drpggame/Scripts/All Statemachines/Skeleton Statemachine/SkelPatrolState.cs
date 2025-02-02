using Godot;
using System;

public partial class SkelPatrolState : SkelState
{
	[Export] public float Speed = 40f;
	//[Export] public Node2D target;
	[Export] public float VisibilityRange = 200f;

	[Export] public CharacterBody2D Skeleton;

	[Export]
	public Node2D[] Waypoints;
	[Export] public CharacterBody2D player;

	public int skelCurrentWaypointIndex = 0;
	public Vector2 skelTargetPosition;
	public Vector2 playerPosition;
	public AnimatedSprite2D Anim;
	//	private AnimationController aniCtrl;


	public override void SkelReady()
	{
		// target = GetNode<CharacterBody2D>("/root/Player");
		// aniCtrl = GetNode<AnimationController>("/Skeleton/AnimationController");
		Skeleton = this.skeletonfsm.Skeleton;
		GD.Print("Skeleton PatrolState target: " + player);
		playerPosition = player.GlobalPosition;
		skelTargetPosition = Waypoints[0].GlobalPosition;
		GD.Print("Skeleton PatrolState ready");
	}

	public override void SkelUpdate(float delta)
	{
		
		Skeleton.Velocity = Skeleton.GlobalPosition.DirectionTo(skelTargetPosition) * this.Speed;

		if (Skeleton.GlobalPosition.DistanceTo(skelTargetPosition) < 1.2f)
		{
			skelCurrentWaypointIndex++;

			if (skelCurrentWaypointIndex > Waypoints.Length - 1)
			{
				skelCurrentWaypointIndex = 0;
			}
			skelTargetPosition = Waypoints[skelCurrentWaypointIndex].GlobalPosition;
			
		}

		// Check if Player is in range..
		if (Skeleton.GlobalPosition.DistanceTo(player.GlobalPosition) < VisibilityRange)
		{
			GD.Print("Skift til ChaseState");
			skeletonfsm.SkelTransitionTo("SkelChaseState");
		}



		//		aniCtrl.PlayAnimation( Skeleton.Velocity );

		Skeleton.MoveAndSlide();

	}


}
