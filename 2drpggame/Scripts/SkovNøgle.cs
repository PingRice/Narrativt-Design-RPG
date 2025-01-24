using Godot;
using System;

public partial class SkovNøgle : Area2D
{
	Sprite2D ani;
	bool pickedUp = false; 
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ani = GetNode<Sprite2D>("Sprite2D");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void _OnBodyEntered(Node2D other) 
	{
		if (other.Name == "Player" && pickedUp == false ) 
		{
			pickedUp = true;
			GD.Print("Key Collected...");
			ani.Visible = false;		
			GetNode<Global>("/root/Global").harSkovNøgle = true;
			GD.Print("SkovNøgle indsamlet...");
			}
			
			
	
	//QueueFree();
	}
}
