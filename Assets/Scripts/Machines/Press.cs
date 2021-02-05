using Godot;
using System;

public class Press : Machine
{
    public static readonly float PROCESS_STEP = 0.5f;
    public static readonly float PROCESS_RESTORE_SPEED = 0.25f;
    public static readonly float MAXIMUM_HEIGHT_DIFFERENCE = 2.77f;
    private float process;
    private Spatial upperPart;
    private Vector3 originalPosition;
    public override void _Ready()
    {
        base._Ready();

        process = 0;
        upperPart = GetChild<Spatial>(0);
        originalPosition = upperPart.Translation;
    }

    public override void _PhysicsProcess(float delta)
    {
        if (!status && process != 0) {
            setProcess(process - PROCESS_RESTORE_SPEED * delta);

            upperPart.Translation = new Vector3(0, originalPosition.y - MAXIMUM_HEIGHT_DIFFERENCE * process, 0);
        }
    }

    public void setProcess(float _process) {
        if (_process > 1) process = 1;
        else if (_process < 0) process = 0;
        else process = _process;
    }

    public float getProcess() {
        return process;
    }

    public override void use()
    {
        if (!status) {
            setProcess(process + PROCESS_STEP);

            if (process >= 1) {
                status = true;
                ConstantLinearVelocity = SlowConveyer.SPEED;
            }
        }
    }
}
