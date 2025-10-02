using UnityEngine;

public class CraneBeamHolderController : BaseCraneController<IBeamHolderMovementModel>
{
    public void ForwardMoveStart() => StartMovement(Vector3.forward * _model.ForwardSpeed);

    public void BackMoveStart() => StartMovement(Vector3.back * _model.BackSpeed);
}
