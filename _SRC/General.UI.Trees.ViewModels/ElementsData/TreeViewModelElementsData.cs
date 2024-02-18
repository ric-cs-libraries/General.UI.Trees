namespace General.UI.Trees.ViewModels.ElementsData;

public record TreeViewModelElementsData
{
    public string Id { get; init; }
    public int Depth { get; init; }

    public Dictionary<string, string> StringInfos { get; init; } = null!;
    public Dictionary<string, int> NumericInfos { get; init; } = null!;

    public string? GetStringInfo(string infoKey)
    {
        StringInfos.TryGetValue(infoKey, out string? info);
        return info;
    }
    public int? GetNumericInfo(string infoKey)
    {
        var found = NumericInfos.TryGetValue(infoKey, out int info);
        return (found)? info : null;
    }
}
