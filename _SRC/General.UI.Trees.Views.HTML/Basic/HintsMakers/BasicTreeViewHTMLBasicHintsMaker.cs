using General.Basics.Trees.GenericTree;

using General.UI.Trees.ViewModels.ElementsData;


namespace General.UI.Trees.Views.HTML.Basic.HintsMakers;

public class BasicTreeViewHTMLBasicHintsMaker
{
    internal string GetHint(GenericTree<TreeViewModelElementsData> treeViewModelRootNode)
    {
        return $"nbChildren={treeViewModelRootNode.NbChildren}; id='{treeViewModelRootNode.Id}'; descr='{treeViewModelRootNode.Data!.Label}'";
    }

    internal string GetHint(Node<TreeViewModelElementsData> treeViewModelNode)
    {
        return $"nbChildren={treeViewModelNode.NbChildren}; id='{treeViewModelNode.Id}'; parentNodeId='{treeViewModelNode.ParentId}'; indexInParent={treeViewModelNode.IndexInParent} ; descr='{treeViewModelNode.Data!.Label}'";
    }

    internal string GetHint(Leaf<TreeViewModelElementsData> treeViewModelLeaf)
    {
        return $"id='{treeViewModelLeaf.Id}'; parentNodeId='{treeViewModelLeaf.ParentId}'; indexInParent={treeViewModelLeaf.IndexInParent}; descr='{treeViewModelLeaf.Data!.Label}'";
    }
}
