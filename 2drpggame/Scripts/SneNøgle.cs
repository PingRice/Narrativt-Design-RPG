using Godot;
using System;

public partial class SneNøgle : Area2D
{
	Sprite2D ani;
	bool pickedUp = false; 
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ani = GetNode<Sprite2D>("Sprite2D");
		GD.Print( ani );
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void _OnBodyEntered(Node2D other) 
	{
		GD.Print("Player entered");
		if (other.Name == "Player" && pickedUp == false ) {
			pickedUp = true;
			GD.Print("Coin collected..");
			ani.Visible = false;
			}
	
	//GetNode<Sprite2D>.hide();
	//QueueFree();
	/*
	GetNode<Global>("/root/Global").ScoreAdd(100);
	
	GetNode<AudioStreamPlayer2D>("PickupCoin").Play();
	*/
	}
}
