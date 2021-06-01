using Godot;
using System;

public class FastConveyer : Conveyer
{
    public override Vector3 getForce() {
        return GlobalTransform.basis.z * 15;
    }
}
