using System.Collections;
using UnityEngine;

public class GasAnalyzerSystem : MonoBehaviour
{ 
    [SerializeField] private AbstractGazAnalyzerButtonInput _input;
    [Space]
    [SerializeField] private AnalyzerProbeController _probeController;
    [SerializeField] private AnalyzerController _analyzerController;
    [Space]
    [SerializeField] private float _distanceUpdateInterval = 0.1f;

    private Coroutine _distanceUpdateCoroutine;
    private WaitForSeconds _waitForDistanceUpdate;

    private void Awake() => Init();

    private void Start() => _distanceUpdateCoroutine = StartCoroutine(UpdateNearestDistance());

    private void Update() => UpdateNearestDistance();

    private void OnDestroy()
    {
        StopCoroutine(_distanceUpdateCoroutine);
        Unsubscribe();
    }

    private void Init()
    {
        _waitForDistanceUpdate = new WaitForSeconds(_distanceUpdateInterval);
        Subscribe();
    }

    private IEnumerator UpdateNearestDistance()
    {
        while (true)
        {
            if (_analyzerController.IsOperational)
                _analyzerController.UpdateDistance(_probeController.GetNearestDangerZoneDistance());

            yield return _waitForDistanceUpdate;
        }
    }

    private void OnPowerButton(bool value)
    {
        if (value)
            _analyzerController.OnButtomStart();

        else
            _analyzerController.OnButtomEnd();
    }

    #region Subscribe/Unsubscribe
    private void Subscribe() => _input.onPowerButton += OnPowerButton;

    private void Unsubscribe() => _input.onPowerButton -= OnPowerButton;
    #endregion
}