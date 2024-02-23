using General.Basics.Trees.GenericTree;


namespace General.UI.Trees.Views.HTML.Interfaces;

public interface ITreeViewHTMLDescriptionsMaker<TTreeViewModelElementsData>
{
    string GetDescription(GenericTree<TTreeViewModelElementsData> treeViewModelRootNode);

    string GetDescription(Node<TTreeViewModelElementsData> treeViewModelNode);

    string GetDescription(Leaf<TTreeViewModelElementsData> treeViewModelLeaf);
}
