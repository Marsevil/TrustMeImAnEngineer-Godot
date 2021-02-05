using Godot;
using System;

public abstract class Conveyer : StaticBody
{
    protected void processConstantVelocity() {
        // Get rotation angle for each parent.
        Vector3 rota = new Vector3();
        for (Spatial node = this; node != null; node = node.GetParent() as Spatial) {
            rota += node.Rotation;
        }

        // Create vector for each axis.
        Vector3 rotaX = new Vector3();
        Vector3 rotaY = new Vector3();
        Vector3 rotaZ = new Vector3();
        if (rota.x < -1 || rota.x > 1) rotaX.x = 1;
        if (rota.y < -1 || rota.y > 1) rotaY.y = 1;
        if (rota.z < -1 || rota.z > 1) rotaZ.z = 1;
        Vector3 force = getForce();

        // Apply rotation
        if (rotaX.IsNormalized()) force = force.Rotated(rotaX, rota.x);
        if (rotaY.IsNormalized()) force = force.Rotated(rotaY, rota.y);
        if (rotaZ.IsNormalized()) force = force.Rotated(rotaZ, rota.z);

        // Vector is applied.
        ConstantLinearVelocity = force;
    }
    public override void _Ready()
    {
        base._Ready();
        
        processConstantVelocity();
    }

    public abstract Vector3 getForce();
}
