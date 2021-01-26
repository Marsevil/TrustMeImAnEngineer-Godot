using Godot;
using System;

public class Pickable : RigidBody
{
    [Export]
    public int pickedHeigth = 5;
    public void pick(Node newParentNode) {
        GetParent().RemoveChild(this);
        newParentNode.AddChild(this);

        //GetChild<CollisionShape>(0).Disabled = true;

        Translation = new Vector3(0, pickedHeigth, 0);
        AxisLockLinearY = true;
    }

    public void drop() {
        Node parent = GetParent();
        Node newParent = parent.GetParent();

        parent.RemoveChild(this);
        newParent.AddChild(this);

        AxisLockLinearY = false;
    }
    public void _on_Area_body_entered(object obj) {
        Player player = obj as Player;
        if (player != null) player.pickable = this;
    }

    public void _on_Area_body_exited(object obj) {
        Player player = obj as Player;
        if (player != null) player.pickable = null;
    }
}
