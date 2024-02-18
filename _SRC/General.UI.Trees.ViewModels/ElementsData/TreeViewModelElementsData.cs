namespace General.UI.Trees.ViewModels.ElementsData;

public record TreeViewModelElementsData
{
    public string Text { get; set; } = null!;
    public string? Hint { get; set; }

    public int Depth { get; set; }
}
