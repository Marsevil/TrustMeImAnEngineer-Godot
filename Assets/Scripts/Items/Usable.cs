using Godot;
using System;

public abstract class Usable : StaticBody
{
    public abstract void use();

    private void _on_Area_body_entered(object obj) {
        Player player = obj as Player;
        if (player != null) player.usable = this;
    }

    private void _on_Area_body_exited(object obj) {
        Player player = obj as Player;
        if (player != null) player.usable = null;
    }
}
