using Godot;
using System;

public partial class Health : Node
{
	public float StartHealth = 100f;
	
	public float HealthPoints
	{
		get { return _HealthPoints; }
		set
		{
			_HealthPoints = Mathf.Clamp(value,0f,100f);
			if(_HealthPoints <= 0f)
			{
				GetTree().ReloadCurrentScene();
			}
		}
	}
	private float _HealthPoints = 100f;
	
	
	public override void _Ready()
	{ 
		HealthPoints = StartHealth;
	}
}
