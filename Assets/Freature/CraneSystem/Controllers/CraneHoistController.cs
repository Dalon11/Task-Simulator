using UnityEngine;

public class CraneHoistController : BaseCraneController<IHoistMovementModel>
{
    public void RightMoveStart() => StartMovement(Vector3.right * _model.RightSpeed);

    public void LeftMoveStart() => StartMovement(Vector3.left * _model.LeftSpeed);
}
