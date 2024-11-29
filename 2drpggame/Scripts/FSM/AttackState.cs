using Godot;
using System;

public partial class AttackState : State
{
	[Export] public CharacterBody2D player;
	[Export] public float attackRate = 1;  // numbers of attacks pr. second..
	[Export] public float attackRange = 10; // Range of attack ...

	private Timer attackTimer;

	public override void Ready()
	{
		attackTimer = GetNode<Timer>("Timer");
		
		attackTimer.WaitTime = this.attackRate;
		attackTimer.Timeout += Attack;

		GD.Print("AttackState is ready" + this.Name ); // Info ift. fejl i opsætning
	}

	public override void Update(float delta) {

		if (fsm.npc.GlobalPosition.DistanceTo(player.GlobalPosition) > this.attackRange) {
			GD.Print("Skift til PatrolState");
			fsm.TransitionTo("PatrolState");
		}
	}

	public void Attack() {
		GD.Print("Attacking.. WUSH");
	}

	public override void Exit() {
		attackTimer.Stop();
	}

	public override void Enter() {
		attackTimer.Start();
	}
}
