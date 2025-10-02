using UnityEngine;

public class TransformMover : IMovable
{
    private readonly Transform _transform;
    private readonly Space _space;

    private bool _isMove;
    private Vector3 _currentDirection;

    public Vector3 CurrentDirection => _currentDirection;
    public bool IsMove => _isMove;

    public TransformMover(Transform transform, Space space = Space.World)
    {
        _transform = transform;
        _space = space;
    }

    public void StartMove(Vector3 direction)
    {
        _currentDirection = direction;
        _isMove = true;
    }

    public void Stop()
    {
        _isMove = false;
        _currentDirection = Vector3.zero;
    }

    public void Move() => _transform.Translate(_currentDirection * Time.deltaTime, _space);
}
