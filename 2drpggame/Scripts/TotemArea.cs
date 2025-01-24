using Godot;
using System;

public partial class TotemArea : Area2D
{
	//Global global; 
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void _OnBodyEntered(Node2D other) 
	{
		/*
		if (other.Name == "Player" && GetNode<Area2D>("SneNøgle").Visible == false && GetNode<Area2D>("SkovNøgle").Visible == false && GetNode<Area2D>("SneNøgle").Visible == false) 
		{
			pickedUp = true;
			GD.Print("Key Collected...");
			ani.Visible = false;		
			Ørken = 1; 
		}
		*/
		if (other.Name == "Player" && GetNode<Global>("/root/Global").HasWon() == true) 
		{
			GD.Print("Alle nøgler samlet");
			//SPILLETS ENDING HEREFTER 
			
		}
		
	}
}
