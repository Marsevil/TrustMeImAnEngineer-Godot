using Godot;
using System;

public class CornerFastConveyer : Conveyer
{
    public override Vector3 getForce()
    {
        return GlobalTransform.basis.x * 15;
    }
}
