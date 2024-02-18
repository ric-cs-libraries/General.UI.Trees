namespace General.UI.Trees.ViewModels;

public class TreeViewModel<TTreeViewModelElementsData>
{
    public GenericTree<TTreeViewModelElementsData> Tree { get; } = GenericTree<TTreeViewModelElementsData>.Create();
}