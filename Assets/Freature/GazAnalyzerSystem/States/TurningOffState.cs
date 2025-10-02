public class TurningOffState : BaseTimedState
{
    public TurningOffState(IAnalyzerStateMachine controller, IAnalyzerView view, IAnalyzerDisplayModel model, AllAnalyzerStates nextState)
        : base(controller, view, model, nextState) { }

    public override void Enter()
    {
        _timer = 0f;
        _view.HideDisplayText();
    }

    public override void Update()
    {
        _view.UpdatePowerOff(ProgressTimer());
        if (IsTimerComplete)
            NextState();
    }
}