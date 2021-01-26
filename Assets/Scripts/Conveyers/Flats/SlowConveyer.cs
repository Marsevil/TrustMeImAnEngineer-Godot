using Godot;
using System;

public class SlowConveyer : Conveyer
{
    public override Vector3 getForce() {
        return new Vector3(0, 0, 5);
    }
}
