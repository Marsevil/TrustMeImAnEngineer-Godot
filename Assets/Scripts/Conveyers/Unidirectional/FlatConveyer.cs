using Godot;

public class FlatConveyer : UnidirectionalConveyer {
    public override void _Ready() {
        base._Ready();

        PathVector = GlobalTransform.basis.z * Size;
    }
}