using Godot;
using System;

public class CornerSlowConveyer : Conveyer
{
    public override Vector3 getForce()
    {
        return new Vector3(5, 0, 0);
    }
}
