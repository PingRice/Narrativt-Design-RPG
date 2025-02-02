using Godot;
using System;

public partial class PatrolState : State
{
	[Export] public float Speed = 40f;
	//[Export] public Node2D target;
	[Export] public float visibilityRange = 200f;
	
	public CharacterBody2D npc;
	
	[Export] 
	public Node2D[] waypoints;
	[Export] public CharacterBody2D player;
	
	public int currentWaypointIndex = 0;
	public Vector2 targetPosition;
	public Vector2 playerPosition;
	public AnimatedSprite2D anim;
//	private AnimationController aniCtrl;
	
	
	public override void Ready()
	{
		// target = GetNode<CharacterBody2D>("/root/Player");
		// aniCtrl = GetNode<AnimationController>("/Skeleton/AnimationController");
		npc = this.fsm.npc;
		GD.Print("PatrolState target:" + player);
		playerPosition = player.GlobalPosition;
		targetPosition = waypoints[0].GlobalPosition;
		GD.Print("PatrolSteate ready");
	}
	
	public override void Update(float delta)
	{
				
		npc.Velocity = this.npc.GlobalPosition.DirectionTo( targetPosition ) * this.Speed;
		
		if( npc.GlobalPosition.DistanceTo( targetPosition ) < 1.2f )
		{
			currentWaypointIndex++;

			if ( currentWaypointIndex > waypoints.Length-1 ) 
			{
				currentWaypointIndex = 0;
			}
			targetPosition = waypoints[currentWaypointIndex].GlobalPosition;
		}
		
		// Check if Player is in range..
		if ( npc.GlobalPosition.DistanceTo( player.GlobalPosition ) < this.visibilityRange )
		{
			//GD.Print("Skift til ChaseState");
			this.fsm.TransitionTo("ChaseState");
		}
		


		//		aniCtrl.PlayAnimation( npc.Velocity );

		npc.MoveAndSlide();

	}
	
	
}
