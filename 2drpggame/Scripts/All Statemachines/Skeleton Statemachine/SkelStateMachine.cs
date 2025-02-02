using Godot;
using System;
using System.Collections.Generic; // For at anvende Dictionary

public partial class SkelStateMachine : Node
{
	public Node SkelState;

	[Export] public CharacterBody2D Skeleton; // skeleton controlled by this FMS

	[Export] public NodePath skelInitialState;

	private Dictionary<string, SkelState> _skelStates;
	private SkelState _skelCurrentState;
	public Skeleton skeleton;

	public override void _Ready()
	{
		if (Skeleton == null)
		{
			GD.Print("You forgot to assign a skeleton to the statemachine...");
		}

		_skelStates = new Dictionary<string, SkelState>();




		_skelCurrentState = GetNode<SkelState>(skelInitialState);
		_skelCurrentState.SkelEnter();
		GD.Print("Skeleton's StateMachineIsReady...9999999999999999999999999999999999999999999999999999999999999999999999999999999");

		skeleton = GetNode<Skeleton>("/root/World/Skeleton");
		skeleton.skelDeathSignal += HandleSkelDeath;

		foreach (Node node in GetChildren())
		{
			if (node is SkelState s)
			{
				//_skelStates[node.Name] = s; // indsaetter State (child) i liste af States.
				//s.skeletonfsm = this;
				//s.SkelReady();
				//s.SkelExit(); // Reset all states
			}
		}
	}

	public void HandleSkelDeath(bool skelDeathSignal)
	{
		GD.Print("Skeleton has died");
		QueueFree();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		_skelCurrentState.SkelUpdate((float)delta);
	}

	public override void _PhysicsProcess(double delta)
	{
		_skelCurrentState.SkelPhysicsUpdate((float)delta);
	}

	public override void _UnhandledInput(InputEvent @event)
	{
		_skelCurrentState.SkelHandleInput(@event);
	}

	// Skift til en ny tilstand
	public void SkelTransitionTo(string SkelStateName)
	{
		if (!_skelStates.ContainsKey(SkelStateName) || _skelCurrentState == _skelStates[SkelStateName])
			return;

		_skelCurrentState.SkelExit();
		_skelCurrentState = _skelStates[SkelStateName];
		_skelCurrentState.SkelEnter();
	}
}
