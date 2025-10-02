public interface ICraneMovementModel : IBeamHolderMovementModel, IHoistMovementModel, IHookMovementModel
{
}

public interface IBeamHolderMovementModel : IMovementModel
{
    public float ForwardSpeed { get; }
    public float BackSpeed { get; }
}

public interface IHoistMovementModel : IMovementModel
{
    public float RightSpeed { get; }
    public float LeftSpeed { get; }
}

public interface IHookMovementModel : IMovementModel
{
    public float DownSpeed { get; }
    public float UpSpeed { get; }
    public float RotationSpeed { get; }
}
public interface IMovementModel
{
}