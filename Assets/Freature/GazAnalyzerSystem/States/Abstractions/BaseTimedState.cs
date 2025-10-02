
using UnityEngine;

public abstract class BaseTimedState : BaseAnalyzerState
{
    protected float _timer;

    protected readonly IAnalyzerDisplayModel _model;
    protected readonly AllAnalyzerStates _nextState;

    protected bool IsTimerComplete => _timer >= _model.PowerToggleTime;

    public BaseTimedState(IAnalyzerStateMachine controller, IAnalyzerView view, IAnalyzerDisplayModel model, AllAnalyzerStates nextState)
        : base(controller, view)
    {
        _model = model;
        _nextState = nextState;
    }

    protected float ProgressTimer()
    {
        _timer += Time.deltaTime;
        return _timer / _model.PowerToggleTime;
    }

    protected void NextState() => _controller.SwitchState(_nextState);
}
