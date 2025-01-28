using Godot;
using System;

public partial class HoodMan : StaticBody2D
{
	public Area2D Interact3;
	[Export] private string fullText = "";
	private Label textLabel;
	
	public override void _Ready()
	{
		textLabel = GetNode<Label>("TextNode/Control/Label");
		Interact3 = GetNode<Area2D>("TextNode/Interact3");
		Interact3.AreaEntered += OnAreaEntered;
		Interact3.AreaExited += OnAreaExit;
		textLabel.Text = "";
	}
	
	private void OnAreaEntered(Area2D area)
	{
		var textBox = GetNode<TextBox>("TextNode/Control");
		textBox.ShowTextBox4();
		GD.Print("KKKK");
	}
	
	private void OnAreaExit(Area2D area)
	{
		var textBox = GetNode<TextBox>("TextNode/Control");
		textBox.HideTextBox3();
	}
	public override void _Process(double delta)
	{
		
	}
}
