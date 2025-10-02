public class AnalyzerStateMachine : IAnalyzerStateMachine
{
    private BaseAnalyzerState _currentState;

    private readonly IAnalyzerStateFactory _stateFactory;

    public AllAnalyzerStates CurrentState { get; private set; }
    public AllAnalyzerStates PreviousState { get; private set; }

    public AnalyzerStateMachine(IAnalyzerStateFactory stateFactory) => _stateFactory = stateFactory;

    public void Update() => _currentState?.Update();

    public void SwitchState(AllAnalyzerStates nextState)
    {
        if (CurrentState == nextState)
            return;

        _currentState?.Exit();
        PreviousState = CurrentState;
        CurrentState = nextState;
        _currentState = _stateFactory.GetState(nextState);
        _currentState.Enter();
    }

    public void SwitchPreviousState() => SwitchState(PreviousState);

    public bool IsOperational => CurrentState == AllAnalyzerStates.On;
}