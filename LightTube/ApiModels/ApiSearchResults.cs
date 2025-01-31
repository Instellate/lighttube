using InnerTube;
using InnerTube.Renderers;

namespace LightTube.ApiModels;

public class ApiSearchResults
{
	public IEnumerable<IRenderer> SearchResults { get; }
	public long? EstimatedResultCount { get; }
	public SearchParams? SearchParams { get; }
	public string? ContinuationKey { get; }
	public InnerTubeSearchResults.TypoFixer? TypoFixer { get; }

	public ApiSearchResults(InnerTubeSearchResults results, SearchParams searchParams)
	{
		SearchParams = searchParams;
		SearchResults = results.Results;
		ContinuationKey = results.Continuation;
		EstimatedResultCount = results.EstimatedResults;
		TypoFixer = results.DidYouMean;
	}

	public ApiSearchResults(InnerTubeContinuationResponse continuationResults)
	{
		SearchResults = continuationResults.Contents;
		ContinuationKey = continuationResults.Continuation;
		EstimatedResultCount = null;
		TypoFixer = null;
	}
}