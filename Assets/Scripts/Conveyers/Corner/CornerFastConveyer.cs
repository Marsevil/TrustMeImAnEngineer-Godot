using Godot;
using System;

public class CornerFastConveyer : Conveyer
{
    public override Vector3 getForce()
    {
        //return new Vector3(10.61f, 0, 10.61f);
        return new Vector3(15, 0, 0);
    }
}
