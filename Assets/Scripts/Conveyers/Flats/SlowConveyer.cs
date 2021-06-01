using Godot;
using System;

public class SlowConveyer : Conveyer
{
    public override void _Ready()
    {
        base._Ready();
    }
    
    public override Vector3 getForce() {
        return GlobalTransform.basis.z * 5;
    }
}
