using System;
using Godot;

public class UpConveyer : UnidirectionalConveyer {
    public override void _Ready()
    {
        base._Ready();

        PathVector = (0.5f * GlobalTransform.basis.y + 0.5f * GlobalTransform.basis.z) * (float)Math.Sqrt(Math.Pow(Size, 2) * 2);
    }
}