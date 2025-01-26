using Godot;
using System;

public partial class TotemArea : Area2D
{
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
		if (other.Name == "Player" && GetNode<Global>("/root/Global").HasWon() == true) 
		{
			GD.Print("Alle nøgler samlet");
			var textBox = GetNode<TextBox>("TextNode/Control");
			textBox.ShowTextBox();
		}
	}
}
