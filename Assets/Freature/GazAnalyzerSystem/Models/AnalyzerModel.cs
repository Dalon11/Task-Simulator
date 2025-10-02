using UnityEngine;

[CreateAssetMenu(fileName = nameof(AnalyzerModel), menuName = "Models/Analyzer/" + nameof(AnalyzerModel))]
public class AnalyzerModel : AbstractAnalyzerModel
{
    [SerializeField] private float _powerToggleTime = 3f;

    public override float PowerToggleTime => _powerToggleTime;
    public override float NearestDistance { get; set; }

    private void OnEnable() => NearestDistance = 0;
}
