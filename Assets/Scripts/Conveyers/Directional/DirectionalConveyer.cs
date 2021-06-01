using Godot;
using System;

public class DirectionalConveyer : Conveyer
{
    [Export]
    public int position = 0;
    private Vector3[] forces = new Vector3[2];
    private Vector3 ROTA_Y = new Vector3(0, 1, 0);
    private Spatial arrow;
    private Spatial wall;
    private const float SQUARE_ANGLE = (float)(Math.PI/2);

    public override void _Ready()
    {
        base._Ready();

        arrow = GetChildren()[1] as Spatial;
        wall = GetChildren()[3] as Spatial;

        arrow.Rotate(ROTA_Y, SQUARE_ANGLE * position);
        wall.Rotate(ROTA_Y, SQUARE_ANGLE * position);

        forces[0] = GlobalTransform.basis.z * 10;
        forces[1] = GlobalTransform.basis.x * 10;
    }

    public void switchPosition() {
        position = (position + 1) % 2;
        processConstantVelocity();

        // Apply visual effect.
        switch(position) {
            case 0:
                arrow.Rotate(ROTA_Y, -SQUARE_ANGLE);
                wall.Rotate(ROTA_Y, -SQUARE_ANGLE);
                break;
            default:
                arrow.Rotate(ROTA_Y, SQUARE_ANGLE);
                wall.Rotate(ROTA_Y, SQUARE_ANGLE);
                break;
        }
    }

    public override Vector3 getForce()
    {
        return forces[position];
    }
}
