using Godot;
using System;

public class MediumConveyer : Conveyer
{
    public override Vector3 getForce() {
        return GlobalTransform.basis.z * 10;
    }
}
