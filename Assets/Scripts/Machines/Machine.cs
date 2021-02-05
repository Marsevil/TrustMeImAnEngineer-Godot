using Godot;
using System;

public abstract class Machine : Usable
{
	protected bool status;

	public override void _Ready()
	{
		status = false;
	}
}
