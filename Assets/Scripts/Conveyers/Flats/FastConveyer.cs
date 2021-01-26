using Godot;
using System;

public class FastConveyer : Conveyer
{
    public override Vector3 getForce() {
        return new Vector3(0, 0, 15);
    }
}
