using Godot;

public class CornerConveyer : MultidirectionalConveyer {
    public override void _Ready()
    {
        base._Ready();
    }
    
    public override Vector3 GetPosition(double elapsedTime) {
        double t = elapsedTime / TravelDuration;

        if (t < 0.5) {
            return EntryPoint + (float)(t / 0.5) * PathVector[0];
        } else {
            return MidPoint + (float)((t - 0.5)  / 0.5) * PathVector[1];
        }
    }
}