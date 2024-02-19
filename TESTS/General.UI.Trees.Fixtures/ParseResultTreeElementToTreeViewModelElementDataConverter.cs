using General.UI.Trees.Presenters.SequenceParsing.Interfaces;
using General.UI.Trees.ViewModels.ElementsData;


namespace General.UI.Trees.Fixtures;

public class ParseResultTreeElementToTreeViewModelElementDataConverter : IParseResultTreeElementToTreeViewModelElementDataConverter<TreeViewModelElementsData>
{
    public TreeViewModelElementsData Convert(General.SequenceParsing.Generic.RootNode<char> parseResultRootNode, string treeTitle)
    {
        var label = treeTitle;
        var result = new TreeViewModelElementsData
        {
            Depth = parseResultRootNode.Depth,
            Label = $"{label}"
        };
        return result;
    }

    public TreeViewModelElementsData Convert(General.SequenceParsing.Generic.Node<char> parseResultNode, int indexInParent)
    {
        var label = $"{parseResultNode.GetSimplifiedStateAsString()}";
        var result = new TreeViewModelElementsData
        {
            Depth = parseResultNode.Depth,
            Label = $"{label}"
        };
        return result;
    }

    public TreeViewModelElementsData Convert(General.SequenceParsing.Generic.Leaf<char> parseResultLeaf, int indexInParent)
    {
        var label = $"Data{parseResultLeaf.GetDataAsString()}";
        var result = new TreeViewModelElementsData
        {
            Depth = parseResultLeaf.Depth,
            Label = $"{label}"
        };
        return result;
    }
}
