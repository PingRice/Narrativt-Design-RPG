using Godot;
using System;

public partial class TotemArea : Area2D
{
	[Export] private string fullText = "";
	private Label textLabel;
	
	public override void _Ready()
	{
		textLabel = GetNode<Label>("TextNode/Control/Label");
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
			textBox.ShowTextBox1();
			GetNode<AudioStreamPlayer>("/root/MusicPlayer").Stop();
		}
	}
}
