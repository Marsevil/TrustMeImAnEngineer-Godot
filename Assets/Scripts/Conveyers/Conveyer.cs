using Godot;
using System;
using System.Collections.Generic;

public abstract class Conveyer : StaticBody {
    public enum ConveyerType {
        FAST,
        MEDIUM,
        SLOW
    }

    public struct ConveyerTravelDuration {
        public const double FAST = 1.0;
        public const double MEDIUM = 2.0;
        public const double SLOW = 3.0;
    }

    private Dictionary<Teapot, double> ElapsedTimes { get; } = new Dictionary<Teapot, double>();
    [Export] public ConveyerType type;
    [Export] public float Size = 4;

    public Vector3 EntryPoint { get; private set; }

    public double TravelDuration {
        get {
            switch (type) {
                case ConveyerType.FAST:
                    return ConveyerTravelDuration.FAST;
                case ConveyerType.MEDIUM:
                    return ConveyerTravelDuration.MEDIUM;
                case ConveyerType.SLOW:
                    return ConveyerTravelDuration.SLOW;
                default:
                    throw new InvalidOperationException("type must be a variant of " + type.GetType().Name);
            }
        }
    }

    public abstract Vector3 GetPosition(double elapsedTime);
    
    public override void _Ready()
    {
        base._Ready();

        EntryPoint = GlobalTransform.origin + GlobalTransform.basis.y * Size - GlobalTransform.basis.z * (Size / 2);
    }
}
