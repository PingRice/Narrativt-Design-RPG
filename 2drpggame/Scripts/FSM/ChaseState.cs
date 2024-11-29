using Godot;
using System;

public partial class ChaseState : State
{
    [Export] public float Speed = 40f;
    [Export] public Node2D player;

    public CharacterBody2D npc;

    public override void Ready()
    {
        this.npc = this.fsm.npc;
        if (player == null) {
            GD.Print("Player not defined for ChaseState");
            return;
        }
            
        GD.Print("ChaseState ready");
    }


    public override void Update(float delta)
    {
        npc.Velocity = this.npc.GlobalPosition.DirectionTo( player.GlobalPosition ) * this.Speed;

        if (npc.GlobalPosition.DistanceTo(player.GlobalPosition) > 50f)
        {
            fsm.TransitionTo("PatrolState");
        }

        if (npc.GlobalPosition.DistanceTo(player.GlobalPosition) < 10)
        {
            GD.Print("Skift til AttackState");
            this.fsm.TransitionTo("AttackState");
        }

        npc.MoveAndSlide();

    }
    

    }
