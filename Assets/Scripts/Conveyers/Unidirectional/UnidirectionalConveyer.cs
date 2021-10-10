using Godot;

public class UnidirectionalConveyer : Conveyer {
    public Vector3 PathVector { get; protected set; }

    public override void _Ready()
    {
        base._Ready();
    }

    public override Vector3 GetPosition(double elapsedTime) {
        double t = elapsedTime / TravelDuration;

        return EntryPoint + PathVector * (float)t;
    }
}