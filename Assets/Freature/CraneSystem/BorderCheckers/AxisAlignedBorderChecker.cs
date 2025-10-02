using UnityEngine;

public class AxisAlignedBorderChecker : IBorderChecker
{
    private const float DirectionThreshold = 0.9f;

    private readonly Transform _target;
    private readonly Transform[] _borders;
    private readonly float _offset;

    private enum MovementAxis
    {
        None,
        X,
        Y,
        Z
    }

    public AxisAlignedBorderChecker(Transform target, Transform[] borders, float offset)
    {
        _target = target;
        _borders = borders;
        _offset = offset;
    }

    public bool CanMove(Vector3 direction)
    {
        if (_borders == null || _borders.Length == 0)
            return true;

        foreach (Transform border in _borders)
        {
            if (border == null)
                continue;

            if (IsBlocksMovement(border, direction))
                return false;
        }

        return true;
    }

    private bool IsBlocksMovement(Transform border, Vector3 direction)
    {
        Vector3 toBorder = CalculateToBorderVector(border);
        MovementAxis movementAxis = DetectMovementAxis(direction);

        return movementAxis switch
        {
            MovementAxis.X => CheckXAxisBlock(toBorder, direction),
            MovementAxis.Y => CheckYAxisBlock(toBorder, direction),
            MovementAxis.Z => CheckZAxisBlock(toBorder, direction),
            _ => false
        };
    }

    private Vector3 CalculateToBorderVector(Transform border) => border.position - _target.position;

    private MovementAxis DetectMovementAxis(Vector3 direction)
    {
        if (Mathf.Abs(direction.x) > DirectionThreshold)
            return MovementAxis.X;

        if (Mathf.Abs(direction.y) > DirectionThreshold)
            return MovementAxis.Y;

        if (Mathf.Abs(direction.z) > DirectionThreshold)
            return MovementAxis.Z;

        return MovementAxis.None;
    }

    private bool CheckXAxisBlock(Vector3 toBorder, Vector3 direction) => IsSameDirection(toBorder.x, direction.x) && IsWithinOffset(toBorder.x);

    private bool CheckYAxisBlock(Vector3 toBorder, Vector3 direction) => IsSameDirection(toBorder.y, direction.y) && IsWithinOffset(toBorder.y);

    private bool CheckZAxisBlock(Vector3 toBorder, Vector3 direction) => IsSameDirection(toBorder.z, direction.z) && IsWithinOffset(toBorder.z);

    private bool IsSameDirection(float borderDistance, float directionComponent) => Mathf.Sign(borderDistance) == Mathf.Sign(directionComponent);

    private bool IsWithinOffset(float distance) => Mathf.Abs(distance) <= _offset;
}