using General.Basics.Trees.GenericTree;

using General.UI.Trees.ViewModels.ElementsData;

using General.UI.Trees.Views.HTML.Interfaces;


namespace General.UI.Trees.Views.HTML.Basic.DescriptionsMakers;

public class BasicTreeViewHTMLBasicDescriptionsMaker : ITreeViewHTMLDescriptionsMaker<TreeViewModelElementsData>
{
    public string GetDescription(GenericTree<TreeViewModelElementsData> treeViewModelRootNode)
    {
        return $"({treeViewModelRootNode.NbChildren}) : {treeViewModelRootNode.Data!.Label}";
    }

    public string GetDescription(Node<TreeViewModelElementsData> treeViewModelNode)
    {
        return $"({treeViewModelNode.NbChildren}) : {treeViewModelNode.Data!.Label}";
    }

    public string GetDescription(Leaf<TreeViewModelElementsData> treeViewModelLeaf)
    {
        return $"{treeViewModelLeaf.Data!.Label}";
    }
}
