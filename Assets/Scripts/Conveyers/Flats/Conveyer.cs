using Godot;
using System;

public abstract class Conveyer : StaticBody
{
    protected void processConstantVelocity()
    {
        // Get rotation angle for each parent.
        Vector3 rota = GlobalTransform.basis.GetEuler();

        ConstantLinearVelocity = getForce();
    }
    public override void _Ready()
    {
        base._Ready();

        processConstantVelocity();
    }

    public abstract Vector3 getForce();
}
