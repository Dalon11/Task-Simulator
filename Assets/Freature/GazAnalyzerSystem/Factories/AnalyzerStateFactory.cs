using System.Collections.Generic;

public class AnalyzerStateFactory : IAnalyzerStateFactory
{
    private readonly Dictionary<AllAnalyzerStates, BaseAnalyzerState> _states = new Dictionary<AllAnalyzerStates, BaseAnalyzerState>();

    public void Construct(IAnalyzerStateMachine controller, IAnalyzerView view, IAnalyzerModel model)
    {
        _states[AllAnalyzerStates.Off] = new OffState(controller, view);
        _states[AllAnalyzerStates.TurningOn] = new TurningOnState(controller, view, model, AllAnalyzerStates.On);
        _states[AllAnalyzerStates.On] = new OnState(controller, view, model);
        _states[AllAnalyzerStates.TurningOff] = new TurningOffState(controller, view, model, AllAnalyzerStates.Off);
    }

    public BaseAnalyzerState GetState(AllAnalyzerStates stateEnum)
    {
        BaseAnalyzerState state;
        _states.TryGetValue(stateEnum, out state);
        return state;
    }
}
