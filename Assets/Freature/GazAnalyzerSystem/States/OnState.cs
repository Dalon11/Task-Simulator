public class OnState : BaseAnalyzerState
{
    private readonly IAnalyzerDistanceModel _model;

    public OnState(IAnalyzerStateMachine controller, IAnalyzerView view, IAnalyzerDistanceModel model) : base(controller, view) =>
        _model = model;

    public override void Enter()
    {
        _view.UpdateDistanceText(_model.NearestDistance);
        _view.PowerOn();
    }

    public override void Update() => _view.UpdateDistanceText(_model.NearestDistance);
}
