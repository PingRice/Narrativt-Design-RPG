using Godot;
using System;

public partial class ForestMan : StaticBody2D
{
	public Area2D Interact1;
	[Export] private string fullText = "";
	private Label textLabel;
	
	public override void _Ready()
	{
		textLabel = GetNode<Label>("TextNode/Control/Label");
		Interact1 = GetNode<Area2D>("TextNode/Interact1");
		Interact1.AreaEntered += OnAreaEntered;
		Interact1.AreaExited += OnAreaExit;
		textLabel.Text = "";
	}
	
	private void OnAreaEntered(Area2D area)
	{
		var textBox = GetNode<TextBox>("TextNode/Control");
		textBox.ShowTextBox2();
		GD.Print("JJJJ");
	}
	
	private void OnAreaExit(Area2D area)
	{
		var textBox = GetNode<TextBox>("TextNode/Control");
		textBox.HideTextBox();
	}
	public override void _Process(double delta)
	{
		
	}
}
