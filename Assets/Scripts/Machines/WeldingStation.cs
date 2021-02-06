using Godot;
using System;

public class WeldingStation : Machine
{
    public static readonly Array TYPE_LIST = Enum.GetValues(typeof(Pickable.Type));
    public static readonly float ITEM_HEIGHT = 6;
    private Pickable askedItem;
    
    private Pickable.Type randomItemType() {
        Random random = new Random();
        return (Pickable.Type)TYPE_LIST.GetValue(random.Next(TYPE_LIST.Length));
    }

    public override void _Ready()
    {
        base._Ready();

        askedItem = Pickable.instanciateItem(randomItemType());
        AddChild(askedItem);
        askedItem.Translation = new Vector3(0, ITEM_HEIGHT, 0);
        askedItem.AxisLockLinearX = true;
        askedItem.AxisLockLinearY = true;
        askedItem.AxisLockLinearZ = true;
    }

    public override void use(Player player)
    {
        Pickable bringedItem = player.getPickedItem();
        if (bringedItem.type == askedItem.type) {
            player.dropItem();
            bringedItem.QueueFree();
            askedItem.QueueFree();
            go();
        }
    }
}
