using Godot;
using System;

public class Player : KinematicBody
{
    [Export]
    public NodePath cameraPath = null;
    [Export]
    public int speed;
    [Export]
    public int gravity;

    private Camera camera = null;

    private Usable usable = null;
    private Pickable pickable = null;
    private Pickable pickedItem = null;

    public override void _Ready()
    {
        if (cameraPath != null) camera = GetNode<Camera>(cameraPath);
    }

    public override void _PhysicsProcess(float delta)
    {
        Vector3 force = new Vector3();

        // Apply input
        force.z = Input.GetActionStrength("ui_up") - Input.GetActionStrength("ui_down");
        force.x = Input.GetActionStrength("ui_left") - Input.GetActionStrength("ui_right");

        if (Input.IsActionJustPressed("use")) use();
        if (Input.IsActionJustPressed("pick")) pick();

        // Constant speed in diagonal.
        force.Normalized();
        force *= speed;

        // Apply camera rotation
        if (camera != null) force = force.Rotated(new Vector3(0, 1, 0), camera.Rotation.y + (float)Math.PI);

        // Apply gravity.
        force.y += gravity;
        MoveAndSlide(force * delta);
    }

    public void use() {
        if (usable != null) usable.use(this);
    }

    public Pickable getPickedItem() {
        return pickedItem;
    }

    public void dropItem() {
        pickedItem.drop();
        pickedItem = null;
    }

    public void pick() {
        if (pickedItem != null) {
            dropItem();
        }
        if (pickable != null) {
            pickedItem = pickable.pick(this);
            pickable = null;
        }
    }

    public void bodyEnteredInteractionArea(Node body) {
        if (body is Usable) usable = body as Usable;
        else if (body is Pickable) pickable = body as Pickable;
    }

    public void bodyExitedInteractionArea(Node body) {
        if (body is Usable) usable = null;
        else if (body is Pickable) pickable = null;
    }
}
