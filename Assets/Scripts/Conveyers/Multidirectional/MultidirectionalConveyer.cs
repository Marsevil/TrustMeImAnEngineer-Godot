using Godot;

public abstract class MultidirectionalConveyer : Conveyer {
    public Vector3 MidPoint { get; private set; }
    public Vector3[] PathVector { get; private set; }
    
    public override void _Ready() {
        base._Ready();

        MidPoint = GlobalTransform.origin + GlobalTransform.basis.y * Size;
        PathVector = new Vector3[2];
        PathVector[0] = GlobalTransform.basis.z * Size/2;
        PathVector[1] = GlobalTransform.basis.x * Size/2;
    }
}