using Godot;
using System;

public class UpFastConveyer : Conveyer
{
    public override Vector3 getForce()
    {
        return GlobalTransform.basis.y * 3.54f + GlobalTransform.basis.z * 3.54f;
    }
}
