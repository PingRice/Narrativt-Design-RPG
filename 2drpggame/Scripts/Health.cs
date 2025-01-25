/*using Godot;
using System;

public partial class Health : Node
{
	public float StartHealth = 100f;
	
	public float regeneration = 1f;
	
	private ProgressBar _progressBar;
	
	public float HealthPoints
	{
		get { return _HealthPoints; }
		set
		{
			_HealthPoints = Mathf.Clamp(value,0f,100f);
			_progressBar.Value = _HealthPoints;
			if(_HealthPoints <= 0f)
			{
				GetTree().ReloadCurrentScene();
			}
		}
	}
	private float _HealthPoints = 100f;
	
	
	public override void _Ready()
	{ 
		_progressBar = GetNode<ProgressBar>("CanvasLayer/Control/ProgressBar");
		HealthPoints = StartHealth;
	}
}
*/
