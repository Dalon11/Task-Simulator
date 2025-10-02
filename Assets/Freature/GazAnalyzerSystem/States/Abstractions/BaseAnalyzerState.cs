public abstract class BaseAnalyzerState
{
    protected IAnalyzerStateMachine _controller;
    protected IAnalyzerView _view;

    public BaseAnalyzerState(IAnalyzerStateMachine controller, IAnalyzerView view)
    {
        _controller = controller;
        _view = view;
    }

    public virtual void Enter() { }

    public virtual void Update() { }

    public virtual void Exit() { }

    public virtual void OnPowerButtonPressed(bool pressed) { }
}
