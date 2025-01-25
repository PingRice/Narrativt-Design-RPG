using Godot;
using System;

public partial class TextBox : Control
{
	private string fullText = "Game has ended \n Goodbye";
	private float delay = 0.05f; // Time in seconds between each character
	private Label textLabel;

	public override void _Ready()
	{
		textLabel = GetNode<Label>("Label");
		textLabel.Text = ""; // Start with an empty label
		Hide();
	}
	
	public void ShowTextBox()
	{
		Show();
		ShowText();
	}
	
	private async void ShowText()
	{
		foreach (char c in fullText)
		{
			textLabel.Text += c; // Add one character at a time
			await ToSignal(GetTree().CreateTimer(delay), "timeout"); // Wait for the delay
		}
	}
}
