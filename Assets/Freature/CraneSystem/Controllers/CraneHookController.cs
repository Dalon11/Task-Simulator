using UnityEngine;

public class CraneHookController : BaseCraneController<IHookMovementModel>
{
    [Space]
    [SerializeField] private CraneHookView _view;
    [Space]
    [SerializeField] private Transform _winchDrum;

    private float _currentRotationSpeed;

    public override void StopMovement()
    {
        base.StopMovement();
        _view.StopSoundMove();
    }

    public void UpMoveStart()
    {
        if (!StartMovement(Vector3.up * _model.UpSpeed))
            return;

        WinchRotation();
        _view.PlaySoundMove();
    }

    public void DownMoveStart()
    {
        if (!StartMovement(Vector3.down * _model.DownSpeed))
            return;

        ReversWinchRotation();
        _view.PlaySoundMove();
    }

    protected override bool Movement()
    {
        if (!base.Movement())
            return false;

        Rotation();
        return true;
    }

    private void WinchRotation() => _currentRotationSpeed = _model.RotationSpeed;

    private void ReversWinchRotation() => _currentRotationSpeed = -_model.RotationSpeed;

    private void Rotation() => _winchDrum.Rotate(Vector3.right, _currentRotationSpeed * Time.deltaTime);
}
