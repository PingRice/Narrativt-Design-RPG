using Godot;
using System;

public partial class Ghost : StaticBody2D
{
	public Area2D Interact2;
	[Export] private string fullText = "";
	private Label textLabel;
	
	public override void _Ready()
	{
		textLabel = GetNode<Label>("TextNode/Control/Label");
		Interact2 = GetNode<Area2D>("TextNode/Interact2");
		Interact2.AreaEntered += OnAreaEntered;
		Interact2.AreaExited += OnAreaExit;
		textLabel.Text = "";
	}
	
	private void OnAreaEntered(Area2D area)
	{
		var textBox = GetNode<TextBox>("TextNode/Control");
		textBox.ShowTextBox3();
		GD.Print("KKKK");
	}
	
	private void OnAreaExit(Area2D area)
	{
		var textBox = GetNode<TextBox>("TextNode/Control");
		textBox.HideTextBox2();
	}
	public override void _Process(double delta)
	{
		
	}
}
