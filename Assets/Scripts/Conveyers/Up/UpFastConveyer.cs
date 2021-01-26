using Godot;
using System;

public class UpFastConveyer : Conveyer
{
    public override Vector3 getForce()
    {
        //return new Vector3(0, 10.61f, 10.61f);
        return new Vector3(0, 3.54f, 3.54f);
    }
}
