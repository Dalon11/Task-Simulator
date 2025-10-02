using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = nameof(AnalyzerProbeModel), menuName = "Models/Analyzer/" + nameof(AnalyzerProbeModel))]
public class AnalyzerProbeModel : AbstractAnalyzerProbeModel 
{
    [SerializeField] private string _dangerZoneTag = "DangerZone";

    private readonly List<Transform> _dangerZones = new List<Transform>();

    public override string DangerZoneTag => _dangerZoneTag;

    public override List<Transform> DangerZones => _dangerZones;

    private void OnEnable() => _dangerZones.Clear();
}
