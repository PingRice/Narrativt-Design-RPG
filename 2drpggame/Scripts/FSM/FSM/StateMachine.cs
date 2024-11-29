using Godot;
using System;
using System.Collections.Generic; // For at anvende Dictionary

public partial class StateMachine : Node {
	
	
	[Export] public CharacterBody2D npc; // npc controlled by this FMS

	[Export] public NodePath initialState;

	private Dictionary<string, State> _states;
	private State _currentState;
	
	public override void _Ready() {
		if (npc == null) {
			GD.Print("You forgot to assign an npc to the statemachine..");
		}
		
		_states = new Dictionary<string, State>();
		
		foreach( Node node in this.GetChildren() ){
			if( node is State s) {
				_states[node.Name] = s; // indsaetter State (child) i liste af States.
				s.fsm = this;
				s.Ready();
				s.Exit(); // Reset all states
			}
			
			_currentState = GetNode<State>(initialState);
			_currentState.Enter();
		}	
		GD.Print("StateMachineIsReady...");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta){
		_currentState.Update( (float) delta );
	}
	
	public override void _PhysicsProcess( double delta ){
		_currentState.PhysicsUpdate( (float) delta ); 
	}
	
	public override void _UnhandledInput(InputEvent @event){
		_currentState.HandleInput(@event);
	}
	
	// Skift til en ny tilstand
	public void TransitionTo(string stateName){
		if( !_states.ContainsKey(stateName) || _currentState == _states[stateName])
			return;
		
		_currentState.Exit();
		_currentState = _states[stateName];
		_currentState.Enter();
	}
}
