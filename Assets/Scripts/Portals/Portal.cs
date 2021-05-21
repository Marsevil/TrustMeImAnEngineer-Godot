using Godot;
using System;

public class Portal : StaticBody
{
    [Export]
    public NodePath otherPortalPath;
    private Portal otherPortal = null;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        if (otherPortal == null) otherPortal = GetNode<Portal>(otherPortalPath);
    }

    public void onCollide(Node body) {
        if (body is Player) otherPortal.teleport((Player)body);
    }

    public void teleport(Player player) {
        GD.Print(Name);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
