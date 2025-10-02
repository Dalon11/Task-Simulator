public class TurningOnState : BaseTimedState
{
    public TurningOnState(IAnalyzerStateMachine controller, IAnalyzerView view, IAnalyzerDisplayModel model, AllAnalyzerStates nextState)
        : base(controller, view, model, nextState) { }

    public override void Enter()
    {
        _timer = 0f;
        _view.ShowDisplayImage();
    }

    public override void Update()
    {
        _view.UpdatePowerOn(ProgressTimer());
        if (IsTimerComplete)
            NextState();
    }
}
