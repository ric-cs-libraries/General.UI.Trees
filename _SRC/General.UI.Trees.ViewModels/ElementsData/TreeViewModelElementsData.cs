namespace General.UI.Trees.ViewModels.ElementsData;

public record TreeViewModelElementsData
{
    public string Label { get; init; } = null!;

    public int Depth { get; init; }
}
