using Godot;
using System;

public class Pickable : RigidBody
{
    [Export]
    public int pickedHeigth = 5;
    [Export]
    public Type type;

    private CollisionShape hitbox;

    public static readonly string PATH_2_PICKABLE_ITEM = "res://Assets/Prefabs/Items/Pickable";

    public enum Type {
        GRINDER,
        HAMMER,
        PLIERS,
        SCREWDRIVER,
        WRENCH
    }

    public static Pickable instanciateItem(Type type) {
        Pickable newPickable;
        switch(type) {
            case Type.GRINDER:
                newPickable = GD.Load<PackedScene>(PATH_2_PICKABLE_ITEM + "/Grinder.tscn").Instance() as Pickable;
                break;
            case Type.HAMMER:
                newPickable = GD.Load<PackedScene>(PATH_2_PICKABLE_ITEM + "/Hammer.tscn").Instance() as Pickable;
                break;
            case Type.PLIERS:
                newPickable = GD.Load<PackedScene>(PATH_2_PICKABLE_ITEM + "/Pliers.tscn").Instance() as Pickable;
                break;
            case Type.SCREWDRIVER:
                newPickable = GD.Load<PackedScene>(PATH_2_PICKABLE_ITEM + "/Screwdriver.tscn").Instance() as Pickable;
                break;
            default:
                newPickable = GD.Load<PackedScene>(PATH_2_PICKABLE_ITEM + "/Wrench.tscn").Instance() as Pickable;
                break;
        }

        return newPickable;
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
