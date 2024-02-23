using General.Basics.Trees.GenericTree;

using General.UI.Trees.ViewModels.ElementsData;
using General.UI.Trees.Views.HTML.Interfaces;


namespace General.UI.Trees.Views.HTML.Basic.HintsMakers;

public class BasicTreeViewHTMLBasicHintsMaker : ITreeViewHTMLHintsMaker<TreeViewModelElementsData>
{
    public string GetHint(GenericTree<TreeViewModelElementsData> treeViewModelRootNode)
    {
        return $"nbChildren={treeViewModelRootNode.NbChildren}; id='{treeViewModelRootNode.Id}'; descr='{treeViewModelRootNode.Data!.Label}'";
    }

    public string GetHint(Node<TreeViewModelElementsData> treeViewModelNode)
    {
        return $"nbChildren={treeViewModelNode.NbChildren}; id='{treeViewModelNode.Id}'; parentNodeId='{treeViewModelNode.ParentId}'; indexInParent={treeViewModelNode.IndexInParent} ; descr='{treeViewModelNode.Data!.Label}'";
    }

    public string GetHint(Leaf<TreeViewModelElementsData> treeViewModelLeaf)
    {
        return $"id='{treeViewModelLeaf.Id}'; parentNodeId='{treeViewModelLeaf.ParentId}'; indexInParent={treeViewModelLeaf.IndexInParent}; descr='{treeViewModelLeaf.Data!.Label}'";
    }
}
