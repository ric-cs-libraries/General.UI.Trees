namespace General.UI.Trees.Presenters.SequenceParsing.Interfaces;

public interface IParseResultTreeElementToTreeViewModelElementDataConverter<TTreeViewModelElementsData>
{
    TTreeViewModelElementsData Convert(General.SequenceParsing.Generic.RootNode<char> parseResultRootNode, string treeTitle);

    TTreeViewModelElementsData Convert(General.SequenceParsing.Generic.Node<char> parseResultNode, int indexInParent);

    TTreeViewModelElementsData Convert(General.SequenceParsing.Generic.Leaf<char> parseResultLeaf, int indexInParent);
}
