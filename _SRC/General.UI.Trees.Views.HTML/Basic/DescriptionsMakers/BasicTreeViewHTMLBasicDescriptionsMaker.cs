using General.Basics.Trees.GenericTree;

using General.UI.Trees.ViewModels.ElementsData;


namespace General.UI.Trees.Views.HTML.Basic.DescriptionsMakers;

public class BasicTreeViewHTMLBasicDescriptionsMaker
{
    internal string GetDescription(GenericTree<TreeViewModelElementsData> treeViewModelRootNode)
    {
        return $"({treeViewModelRootNode.NbChildren}) : {treeViewModelRootNode.Data!.Label}";
    }

    internal string GetDescription(Node<TreeViewModelElementsData> treeViewModelNode)
    {
        return $"({treeViewModelNode.NbChildren}) : {treeViewModelNode.Data!.Label}";
    }

    internal string GetDescription(Leaf<TreeViewModelElementsData> treeViewModelLeaf)
    {
        return $"{treeViewModelLeaf.Data!.Label}";
    }
}
