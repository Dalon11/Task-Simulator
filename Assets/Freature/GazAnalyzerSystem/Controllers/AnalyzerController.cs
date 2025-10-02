using UnityEngine;

public class AnalyzerController : MonoBehaviour
{
    [SerializeField] public AnalyzerView _view;
    [SerializeField] private AnalyzerModel _model;

    private AnalyzerStateMachine _stateMachine;

    public float PowerToggleTime => _model._powerToggleTime;
    public bool IsOperational => _stateMachine.CurrentState == AllAnalyzerStates.On;

    private readonly AnalyzerStateFactory _stateFactory = new AnalyzerStateFactory();

    private void Awake() => Init();

    private void Start() => SwitchState(AllAnalyzerStates.Off);

    private void Update() => _stateMachine.Update();

    public void OnButtomStart()
    {
        if (_stateMachine.CurrentState == AllAnalyzerStates.Off)
            SwitchTurningOn();

        else if (_stateMachine.CurrentState == AllAnalyzerStates.On)
            SwitchTurningOff();
    }

    public void OnButtomEnd()
    {
        if (_stateMachine.CurrentState == AllAnalyzerStates.TurningOff
            || _stateMachine.CurrentState == AllAnalyzerStates.TurningOn)
            SwitchPreviousState();
    }

    public void UpdateDistance(float distance) => _model.NearestDistance = distance;

    public void SwitchState(AllAnalyzerStates nextState) => _stateMachine.SwitchState(nextState);

    public void SwitchPreviousState() => _stateMachine.SwitchPreviousState();

    private void Init()
    {
        _stateMachine = new AnalyzerStateMachine(_stateFactory);
        _stateFactory.Construct(_stateMachine, _view, _model);
    }

    private void SwitchTurningOn() => SwitchState(AllAnalyzerStates.TurningOn);

    private void SwitchTurningOff() => SwitchState(AllAnalyzerStates.TurningOff);
}
