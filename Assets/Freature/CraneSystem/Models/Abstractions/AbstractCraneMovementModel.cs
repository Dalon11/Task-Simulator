using UnityEngine;

public abstract class AbstractCraneMovementModel : ScriptableObject, ICraneMovementModel
{
    public abstract float UpSpeed { get; }
    public abstract float DownSpeed { get; }
    public abstract float RightSpeed { get; }
    public abstract float LeftSpeed { get; }
    public abstract float ForwardSpeed { get; }
    public abstract float BackSpeed { get; }
    public abstract float RotationSpeed { get; }
}