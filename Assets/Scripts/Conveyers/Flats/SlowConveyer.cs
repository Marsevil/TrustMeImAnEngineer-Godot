using Godot;
using System;

public class SlowConveyer : Conveyer
{
    public static readonly Vector3 SPEED = new Vector3(0, 0, 5);
    public override Vector3 getForce() {
        return SPEED;
    }
}
