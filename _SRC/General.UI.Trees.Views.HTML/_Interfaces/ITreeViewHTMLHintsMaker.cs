using General.Basics.Trees.GenericTree;


namespace General.UI.Trees.Views.HTML.Interfaces;

public interface ITreeViewHTMLHintsMaker<TTreeViewModelElementsData>
{
    string GetHint(GenericTree<TTreeViewModelElementsData> treeViewModelRootNode);

    string GetHint(Node<TTreeViewModelElementsData> treeViewModelNode);

    string GetHint(Leaf<TTreeViewModelElementsData> treeViewModelLeaf);
}