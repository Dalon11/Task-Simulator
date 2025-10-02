using UnityEngine;

[CreateAssetMenu(fileName = nameof(CraneMovementModel), menuName = "Models/" + nameof(CraneMovementModel))]
public class CraneMovementModel : AbstractCraneMovementModel
{
    [Header("Movement Speeds")]
    [SerializeField] private float _upSpeed = 2.0f;
    [SerializeField] private float _downSpeed = 2.0f;
    [SerializeField] private float _eastSpeed = 2.0f;
    [SerializeField] private float _westSpeed = 2.0f;
    [SerializeField] private float _northSpeed = 2.0f;
    [SerializeField] private float _southSpeed = 2.0f;
    [Space]
    [SerializeField] private float _rotationSpeed = 100f;

    public override float UpSpeed => _upSpeed;
    public override float DownSpeed => _downSpeed;
    public override float RightSpeed => _eastSpeed;
    public override float LeftSpeed => _westSpeed;
    public override float ForwardSpeed => _northSpeed;
    public override float BackSpeed => _southSpeed;
    public override float RotationSpeed => _rotationSpeed;
}
