using Godot;
using System;

public partial class SkelState : Node
{

	public SkelStateMachine skeletonfsm; // FSM som denne state er en del af.

	public virtual void SkelReady()
	{ 
		
	}

	public virtual void SkelEnter()
	{ }
	public virtual void SkelExit()
	{ }
	public virtual void SkelUpdate(float delta)
	{ }

	public virtual void SkelPhysicsUpdate(float delta)
	{ }
	public virtual void SkelHandleInput(InputEvent @event)
	{ }
}
