using Godot;
using System;

public abstract class Machine : UnidirectionalConveyer, Usable
{
	protected bool status = false;

    private double entryTime = 0.0;

	public override void _Ready()
	{
        base._Ready();
	}

    public override Vector3 GetPosition(double elapsedTime)
    {
        if (elapsedTime < 0.5) {
            return base.GetPosition(elapsedTime);
        } else {
            if (status) return base.GetPosition(elapsedTime - entryTime);
            else {
                entryTime = elapsedTime;
                return GlobalTransform.origin + GlobalTransform.basis.y * Size;
            }
        }
    }

    protected void go() {
        status = true;
    }

    public abstract void use(Player player);
}
