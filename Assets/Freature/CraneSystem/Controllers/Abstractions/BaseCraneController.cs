using UnityEngine;

public abstract class BaseCraneController<TModel> : MonoBehaviour where TModel : IMovementModel
{
    [SerializeField] protected Transform _targetTransform;
    [Space]
    [SerializeField] protected Transform[] _borderPoints;
    [SerializeField] protected float _offset = 1;

    protected TModel _model;
    protected IMovable _mover;
    protected IBorderChecker _borderChecker;

    private void Awake() => Init();

    protected virtual void Update() => Movement();

    public void Construct(TModel model) => _model = model;

    public virtual void StopMovement() => _mover.Stop();

    protected virtual bool Movement()
    {
        if (!_mover.IsMove)
            return false;

        if (!_borderChecker.CanMove(_mover.CurrentDirection))
        {
            StopMovement();
            return false;
        }

        Move();
        return true;
    }

    protected virtual void Move() => _mover.Move();

    protected virtual bool StartMovement(Vector3 direction)
    {
        if (_mover.IsMove || !_borderChecker.CanMove(direction))
            return false;

        _mover.StartMove(direction);
        return true;
    }

    private void Init()
    {
        _mover = new TransformMover(_targetTransform, Space.Self);
        _borderChecker = new AxisAlignedBorderChecker(_targetTransform, _borderPoints, _offset);
    }
}