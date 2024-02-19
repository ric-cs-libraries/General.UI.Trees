using System.Text;


using General.UI.HTML.Basics.Elements.Abstracts;
using General.UI.HTML.Basics.Elements;
using General.UI.HTML.Basics.Attributes;

using General.Basics.Trees.GenericTree;


namespace General.UI.Trees.Views.HTML.Abstracts;

public abstract class TreeViewHTML<TTreeViewModelElementsData>
{
    public string Charset { get; init; } = Encoding.Latin1.WebName;
    public string ContentType { get; init; } = "text/html";

    private readonly TreeViewModel<TTreeViewModelElementsData> model;
    protected readonly TreeViewHTMLStyler htmlTreeViewStyler;

    private int monoIndentationNbPixels;

    protected TreeViewHTML
    (
        TreeViewModel<TTreeViewModelElementsData> model,
        TreeViewHTMLStyler htmlTreeViewStyler
    )
    {
        this.model = model;
        this.htmlTreeViewStyler = htmlTreeViewStyler;

        monoIndentationNbPixels = htmlTreeViewStyler.GetMonoIndentationNbPixels();
    }

    public string GetAsString()
    {
        HTMLHeadTag htmlHeadTag = GetHTMLHead();
        HTMLBodyTag htmlBodyTag = GetHTMLBody();

        var result = htmlHeadTag.GetAsString() + htmlBodyTag.GetAsString();
        return result;
    }

    private HTMLHeadTag GetHTMLHead()
    {
        HTMLHeadTag headTag = new();
        AddMetaTags(headTag);

        htmlTreeViewStyler.StyleHeadTag(headTag);

        AddScriptsTag(headTag);

        return headTag;
    }

    private void AddMetaTags(HTMLHeadTag headTag)
    {
        var charsetMetaTag = new HTMLMetaTag(Charset, ContentType);
        headTag.AddChild(charsetMetaTag);
    }

    private void AddScriptsTag(HTMLHeadTag headTag)
    {
        HTMLScriptTag scriptTag = new(null, GetJsCodeForNodeCollapseFunction());
        headTag.AddChild(scriptTag);
    }

    private HTMLBodyTag GetHTMLBody()
    {
        var treeViewModelRootNode = model.Tree;

        HTMLBodyTag htmlBodyTag = new HTMLBodyTag();
        var rootNodeTag = GetTreeRootNodeAsHTMLNodeTag(treeViewModelRootNode);
        AddTreeRootNodeAttributes(rootNodeTag, treeViewModelRootNode);
        StyleRootNodeTag(rootNodeTag);

        htmlBodyTag.AddChild(rootNodeTag);

        AddChildrenHTMLTagsTo(rootNodeTag, treeViewModelRootNode, nodeNbPixelsOfIdentation: 0);

        return htmlBodyTag;
    }


    private void AddChildrenHTMLTagsTo(HTMLNodeTag parentHTMLTag, Node<TTreeViewModelElementsData> treeViewModelParentNode, int nodeNbPixelsOfIdentation)
    {
        HTMLNodeTag subTag;
        TreeElement<TTreeViewModelElementsData> childElement;

        int childNbPixelsOfIdentation = nodeNbPixelsOfIdentation + monoIndentationNbPixels;
        for (var index = 0; index < treeViewModelParentNode.NbChildren; index++)
        {
            childElement = treeViewModelParentNode.GetChildByIndex(index);
            if (childElement is Leaf<TTreeViewModelElementsData> treeViewModelLeaf)
            {
                subTag = GetTreeLeafAsHTMLNodeTag(treeViewModelLeaf);
                AddTreeElementAttributes(subTag, treeViewModelLeaf);
                StyleLeafTag(subTag, childNbPixelsOfIdentation);
            }
            else
            {
                var treeViewModelSubNode = (childElement as Node<TTreeViewModelElementsData>)!;
                subTag = GetTreeNodeAsHTMLNodeTag(treeViewModelSubNode);
                AddTreeElementAttributes(subTag, treeViewModelSubNode);
                StyleNodeTag(subTag, childNbPixelsOfIdentation);

                AddChildrenHTMLTagsTo(subTag, treeViewModelSubNode, childNbPixelsOfIdentation);
            }
            parentHTMLTag.AddChild(subTag!);
        }
    }

    private void AddTreeRootNodeAttributes(HTMLNodeTag rootNodeTag, GenericTree<TTreeViewModelElementsData> treeViewModelRootNode)
    {
        AddTreeElementIdAttribute(rootNodeTag, treeViewModelRootNode);
    }

    private void AddTreeElementAttributes(HTMLNodeTag tag, TreeElement<TTreeViewModelElementsData> treeElement)
    {
        AddTreeElementIdAttribute(tag, treeElement);
        AddTreeElementParentNodeIdAttribute(tag, treeElement);
        AddTreeElementIndexInParentAttribute(tag, treeElement);
    }

    private void StyleRootNodeTag(HTMLNodeTag rootNodeTag)
    {
        htmlTreeViewStyler.StyleRootNodeTag(rootNodeTag);
    }

    private void StyleNodeTag(HTMLNodeTag nodeTag, int nodeNbPixelsOfIdentation)
    {
        htmlTreeViewStyler.StyleForIndentation(nodeTag, nodeNbPixelsOfIdentation);
        htmlTreeViewStyler.StyleNodeTag(nodeTag);
    }

    private void StyleLeafTag(HTMLNodeTag leafTag, int childNbPixelsOfIdentation)
    {
        htmlTreeViewStyler.StyleForIndentation(leafTag, childNbPixelsOfIdentation);
        htmlTreeViewStyler.StyleLeafTag(leafTag);
    }

    protected abstract HTMLNodeTag GetTreeRootNodeAsHTMLNodeTag(GenericTree<TTreeViewModelElementsData> treeViewModelRootNode);

    protected abstract HTMLNodeTag GetTreeNodeAsHTMLNodeTag(Node<TTreeViewModelElementsData> treeViewModelNode);

    protected abstract HTMLNodeTag GetTreeLeafAsHTMLNodeTag(Leaf<TTreeViewModelElementsData> treeViewModelLeaf);


    //------------------------------------------------------------------------------------------------------------
    protected static void SetHint(HTMLTag tag, string hint)
    {
        tag.SetTitleAttribute(hint);
    }

    protected static void AddTreeElementIdAttribute(HTMLTag tag, TreeElement<TTreeViewModelElementsData> treeViewModelElement)
    {
        var idAttribute = new HTMLAttribute("id", $"{treeViewModelElement.Id}");
        tag.AddAttribute(idAttribute);
    }

    protected static void AddTreeElementParentNodeIdAttribute(HTMLTag tag, TreeElement<TTreeViewModelElementsData> treeViewModelElement)
    {
        var parentNodeIdAttribute = new HTMLAttribute("parentNodeId", $"{treeViewModelElement.ParentId}");
        tag.AddAttribute(parentNodeIdAttribute);
    }
    protected static void AddTreeElementIndexInParentAttribute(HTMLTag tag, TreeElement<TTreeViewModelElementsData> treeViewModelElement)
    {
        var indexInParentAttribute = new HTMLAttribute("indexInParent", $"{treeViewModelElement.IndexInParent}");
        tag.AddAttribute(indexInParentAttribute);
    }

    //------------------------------------------------------------------------------------------------------------
    protected abstract string GetJsCodeForNodeCollapseFunction();
}