using Godot;
using System;

public class CornerMediumConveyer : Conveyer
{
    public override Vector3 getForce()
    {
        return GlobalTransform.basis.x * 10;
    }
}
