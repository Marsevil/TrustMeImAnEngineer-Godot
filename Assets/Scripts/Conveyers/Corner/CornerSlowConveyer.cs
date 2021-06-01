using Godot;
using System;

public class CornerSlowConveyer : Conveyer
{
    public override Vector3 getForce()
    {
        return GlobalTransform.basis.x * 5;
    }
}
