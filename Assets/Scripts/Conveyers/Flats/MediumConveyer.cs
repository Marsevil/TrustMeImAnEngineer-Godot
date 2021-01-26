using Godot;
using System;

public class MediumConveyer : Conveyer
{
    public override Vector3 getForce() {
        return new Vector3(0, 0, 10);
    }
}
