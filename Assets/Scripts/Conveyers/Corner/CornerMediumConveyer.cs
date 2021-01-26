using Godot;
using System;

public class CornerMediumConveyer : Conveyer
{
    public override Vector3 getForce()
    {
        return new Vector3(10, 0, 0);
    }
}
