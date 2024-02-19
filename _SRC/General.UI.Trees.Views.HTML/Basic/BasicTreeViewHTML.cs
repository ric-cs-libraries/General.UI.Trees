using General.Basics.Extensions;
using General.Basics.Trees.GenericTree;


using General.UI.HTML.Basics.Elements.Abstracts;
using General.UI.HTML.Basics.Elements;
using General.UI.HTML.Basics.Attributes;

using General.UI.Trees.ViewModels.ElementsData;

using General.UI.Trees.Views.HTML.Abstracts;
using General.UI.Trees.Views.HTML.Basic.Stylers;
using General.UI.Trees.Views.HTML.Basic.HintsMakers;
using General.UI.Trees.Views.HTML.Basic.DescriptionsMakers;


namespace General.UI.Trees.Views.HTML.Basic;

public class BasicTreeViewHTML : TreeViewHTML<TreeViewModelElementsData>
{
    private const int LEAF_TEXT_MAX_LENGTH = 160;
    private const int ROOT_NODE_DESCRIPTION_TEXT_MAX_LENGTH = 180;
    private const int NODE_DESCRIPTION_TEXT_MAX_LENGTH = 180;

    private const string LEAF_PREFIX = "*";
    private const string NODE_PREFIX = "/";
    private const string NODE_UNCOLLAPSED_SYMB = "-";
    private const string NODE_COLLAPSED_SYMB = "+";
    private const string JS_CODE_NODE_COLLAPSE_FUNCTION_NAME = "handleNodeCollapse";

    private readonly BasicTreeViewHTMLBasicDescriptionsMaker htmlTreeViewDescriptionsMaker;
    private readonly BasicTreeViewHTMLBasicHintsMaker htmlTreeViewHintsMaker;
    private readonly BasicTreeViewHTMLBasicStyler htmlBasicTreeViewStyler;

    public BasicTreeViewHTML
    (
        TreeViewModel<TreeViewModelElementsData> model,
        BasicTreeViewHTMLBasicStyler htmlBasicTreeViewStyler,
        BasicTreeViewHTMLBasicDescriptionsMaker htmlTreeViewDescriptionsMaker,
        BasicTreeViewHTMLBasicHintsMaker htmlTreeViewHintsMaker
    ) : base(model, htmlBasicTreeViewStyler)
    {
        this.htmlBasicTreeViewStyler = htmlBasicTreeViewStyler;
        this.htmlTreeViewDescriptionsMaker = htmlTreeViewDescriptionsMaker;
        this.htmlTreeViewHintsMaker = htmlTreeViewHintsMaker;
    }

    protected override HTMLNodeTag GetTreeRootNodeAsHTMLNodeTag(GenericTree<TreeViewModelElementsData> treeViewModelRootNode)
    {
        var rootTag = new HTMLDivTag();
        SetHint(rootTag, htmlTreeViewHintsMaker.GetHint(treeViewModelRootNode));

        var descriptionTag = GetRootNodeDescriptionTag(treeViewModelRootNode);

        rootTag.AddChild(descriptionTag);

        return rootTag;
    }

    protected override HTMLNodeTag GetTreeNodeAsHTMLNodeTag(Node<TreeViewModelElementsData> treeViewModelNode)
    {
        var nodeTag = new HTMLDivTag();
        SetHint(nodeTag, htmlTreeViewHintsMaker.GetHint(treeViewModelNode));

        var descriptionTag = GetNodeDescriptionTag(treeViewModelNode);

        nodeTag.AddChild(descriptionTag);

        return nodeTag;
    }

    protected override HTMLNodeTag GetTreeLeafAsHTMLNodeTag(Leaf<TreeViewModelElementsData> treeViewModelLeaf)
    {
        var tag = new HTMLDivTag();
        SetHint(tag, htmlTreeViewHintsMaker.GetHint(treeViewModelLeaf));

        var prefixTag = GetPrefixTag(LEAF_PREFIX);
        htmlBasicTreeViewStyler.StyleLeafPrefixTag(prefixTag);

        var text = $"{htmlTreeViewDescriptionsMaker.GetDescription(treeViewModelLeaf)}";
        var htmlText = new HTMLText(GetFormattedLeaftText(text));

        tag.AddChildren(new() { prefixTag, htmlText });

        return tag;
    }

    //------------------------------------------------------------------------------------------------------------

    private HTMLDivTag GetRootNodeDescriptionTag(GenericTree<TreeViewModelElementsData> treeViewModelRootNode)
    {
        var descriptionTag = new HTMLDivTag();
        htmlBasicTreeViewStyler.StyleRootNodeDescriptionTag(descriptionTag);

        descriptionTag.AddAttribute(new HTMLOnClickAttribute(GetJsCodeForNodeDescriptionClick(treeViewModelRootNode)));

        var prefixTag = GetPrefixTag(NODE_PREFIX);
        htmlBasicTreeViewStyler.StyleNodePrefixTag(prefixTag);

        var nodeCollapseTag = GetNodeCollapseTag(treeViewModelRootNode);

        var description = $"   {htmlTreeViewDescriptionsMaker.GetDescription(treeViewModelRootNode)}";
        var descriptionHTMLText = new HTMLText(GetFormattedRootNodeDescriptionText(description));

        descriptionTag.AddChildren(new() { prefixTag, nodeCollapseTag, descriptionHTMLText });

        return descriptionTag;
    }

    private HTMLDivTag GetNodeDescriptionTag(Node<TreeViewModelElementsData> treeViewModelNode)
    {
        var descriptionTag = new HTMLDivTag();
        htmlBasicTreeViewStyler.StyleNodeDescriptionTag(descriptionTag);

        descriptionTag.AddAttribute(new HTMLOnClickAttribute(GetJsCodeForNodeDescriptionClick(treeViewModelNode)));

        var prefixTag = GetPrefixTag(NODE_PREFIX);
        htmlBasicTreeViewStyler.StyleNodePrefixTag(prefixTag);

        var nodeCollapseTag = GetNodeCollapseTag(treeViewModelNode);

        var description = $"   {htmlTreeViewDescriptionsMaker.GetDescription(treeViewModelNode)}";
        var descriptionHTMLText = new HTMLText(GetFormattedNodeDescriptionText(description));

        descriptionTag.AddChildren(new() { prefixTag, nodeCollapseTag, descriptionHTMLText });

        return descriptionTag;
    }

    private HTMLSpanTag GetNodeCollapseTag(Node<TreeViewModelElementsData> treeViewModelNode)
    {
        var nodeCollapseTag = new HTMLSpanTag();
        htmlBasicTreeViewStyler.StyleNodeCollapseTag(nodeCollapseTag);

        var nodeCollpaseText = new HTMLText(NODE_UNCOLLAPSED_SYMB);

        nodeCollapseTag.AddChild(nodeCollpaseText);

        return nodeCollapseTag;
    }

    private static HTMLTag GetPrefixTag(string prefix)
    {
        var tag = new HTMLSpanTag();

        var prefixText = new HTMLText($"{prefix} ");

        tag.AddChild(prefixText);

        return tag;
    }

    //----------------------------------------------------------------------------------------------------------------------

    private static string GetFormattedLeaftText(string text)
    {
        var result = text.GetWithHtmlEntities_().GetAsShorten_(LEAF_TEXT_MAX_LENGTH);
        return result;
    }

    private static string GetFormattedRootNodeDescriptionText(string text)
    {
        var result = text.GetWithHtmlEntities_().GetAsShorten_(ROOT_NODE_DESCRIPTION_TEXT_MAX_LENGTH);
        return result;
    }

    private static string GetFormattedNodeDescriptionText(string text)
    {
        var result = text.GetWithHtmlEntities_().GetAsShorten_(NODE_DESCRIPTION_TEXT_MAX_LENGTH);
        return result;
    }

    //----------------------------------------------------------------------------------------------------------------------

    private string GetJsCodeForNodeDescriptionClick(Node<TreeViewModelElementsData> treeViewModelNode)
    {
        return $"var nodeTag = window.document.getElementById('{treeViewModelNode.Id}'); window.{JS_CODE_NODE_COLLAPSE_FUNCTION_NAME}(nodeTag);";
    }

    protected override string GetJsCodeForNodeCollapseFunction()
    {
        var jsCode = """
                window.JS_CODE_NODE_COLLAPSE_FUNCTION_NAME = (nodeTag) => {
                    let nodeCollapseTag = nodeTag.firstChild.childNodes[1];
                    let childrenDisplay;
                    if (nodeTag.getAttribute("collapsed") !== null){
                        childrenDisplay = 'block';
                        nodeTag.removeAttribute("collapsed");
                        nodeCollapseTag.innerHTML = "NODE_UNCOLLAPSED_SYMB";
                    } else {
                        childrenDisplay = "none";
                        nodeTag.setAttribute("collapsed", "1");
                        nodeCollapseTag.innerHTML = "NODE_COLLAPSED_SYMB";
                    }
                    for(let i = 1; i < nodeTag.childNodes.length; i++){
                        nodeTag.childNodes[i].style.display = childrenDisplay;
                    }
                };
            """;
        jsCode = jsCode.Replace("NODE_UNCOLLAPSED_SYMB", NODE_UNCOLLAPSED_SYMB)
                       .Replace("NODE_COLLAPSED_SYMB", NODE_COLLAPSED_SYMB)
                       .Replace("JS_CODE_NODE_COLLAPSE_FUNCTION_NAME", JS_CODE_NODE_COLLAPSE_FUNCTION_NAME)
                       ;
        return jsCode;
    }
}
