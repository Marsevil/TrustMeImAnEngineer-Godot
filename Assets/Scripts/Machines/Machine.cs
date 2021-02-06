using Godot;
using System;

public abstract class Machine : SlowConveyer, Usable
{
	protected bool status;

	public override void _Ready()
	{
        base._Ready();

		status = false;
	}

    protected void go() {
        status = true;
        GetChild<CollisionShape>(0).Disabled = true;
    }

    public abstract void use(Player player);
}
