using Godot;
using System;

public partial class Global : Node
{
	public bool harSneNøgle = true;
	public bool harSkovNøgle = true;
	public bool harØrkenNøgle = true;
	
	public bool HasWon() 
	{
		return harSneNøgle && harSkovNøgle && harØrkenNøgle;
		
	}
	
}
