using Godot;
using System;

public class Pickable : RigidBody
{
    [Export]
    public int pickedHeigth = 5;
    [Export]
    public Type type;

    public enum Type {
        GRINDER,
        HAMMER,
        PLIERS,
        SCREWDRIVER,
        WRENCH
    }

    public Pickable pick(Node newParentNode) {
        GetParent().RemoveChild(this);
        newParentNode.AddChild(this);

        //GetChild<CollisionShape>(0).Disabled = true;

        Translation = new Vector3(0, pickedHeigth, 0);
        AxisLockLinearY = true;

        return this;
    }

    public void drop() {
        Node parent = GetParent();
        Node newParent = parent.GetParent();

        parent.RemoveChild(this);
        newParent.AddChild(this);

        Vector3 parentTranslation = (parent as Spatial).Translation;
        Translation = parentTranslation;

        AxisLockLinearY = false;
    }
}
