public class OffState : BaseAnalyzerState
{
    public OffState(IAnalyzerStateMachine controller, IAnalyzerView view) : base(controller, view) { }

    public override void Enter()
    {
        _view.PowerOff();
    }
}
