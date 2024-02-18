using General.SequenceParsing.Generic;
using General.UI.Trees.Presenters.SequenceParsing.Interfaces;
using General.UI.Trees.ViewModels;


namespace General.UI.Trees.Presenters.SequenceParsing;

public class TreeViewModelPresenterFromParseResult<TTreeViewModelElementsData>
{
    private readonly IParseResultTreeElementToTreeViewModelElementDataConverter<TTreeViewModelElementsData> converter;
    private readonly string treeTitle;

    public TreeViewModelPresenterFromParseResult(IParseResultTreeElementToTreeViewModelElementDataConverter<TTreeViewModelElementsData> converter, string treeTitle = "")
    {
        this.converter = converter;
        this.treeTitle = treeTitle;
    }

    public TreeViewModel<TTreeViewModelElementsData> GetViewModel(ParseResult<char> parseResult)
    {
        var treeViewModel = new TreeViewModel<TTreeViewModelElementsData>();

        BuildViewModel(parseResult.RootNode, treeViewModel.Tree);

        return treeViewModel;
    }

    private void BuildViewModel(General.SequenceParsing.Generic.RootNode<char> parseResultRootNode, GenericTree<TTreeViewModelElementsData> treeViewModelRootNode)
    {
        treeViewModelRootNode.Data = converter.Convert(parseResultRootNode, treeTitle);
        BuildViewModel(parseResultRootNode, treeViewModelRootNode as Basics.Trees.GenericTree.Node<TTreeViewModelElementsData>);
    }
    private void BuildViewModel(General.SequenceParsing.Generic.Node<char> parseResultParentNode, Basics.Trees.GenericTree.Node<TTreeViewModelElementsData> parentNodeInTreeViewModel)
    {
        var indexInParent = 0;
        foreach (var parseResultChildElement in parseResultParentNode.Elements)
        {
            if (parseResultChildElement is General.SequenceParsing.Generic.Node<char> parseResultChildNode)
            {
                var treeChildNode = Basics.Trees.GenericTree.Node<TTreeViewModelElementsData>.Create();
                parentNodeInTreeViewModel.Add(treeChildNode);
                treeChildNode.Data = converter.Convert(parseResultChildNode, indexInParent);

                BuildViewModel(parseResultChildNode, treeChildNode);
            }
            else //General.SequenceParsing.Generic.Leaf<char>
            {
                var treeChildLeaf = Basics.Trees.GenericTree.Leaf<TTreeViewModelElementsData>.Create();
                parentNodeInTreeViewModel.Add(treeChildLeaf);
                treeChildLeaf.Data = converter.Convert((parseResultChildElement as General.SequenceParsing.Generic.Leaf<char>)!, indexInParent);
            }
            indexInParent++;
        }
    }
}
