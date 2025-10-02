public interface IAnalyzerModel : IAnalyzerDisplayModel, IAnalyzerDistanceModel
{
}

public interface IAnalyzerDisplayModel
{
    public float PowerToggleTime { get; }
}

public interface IAnalyzerDistanceModel
{
    public float NearestDistance { get; set; }
}