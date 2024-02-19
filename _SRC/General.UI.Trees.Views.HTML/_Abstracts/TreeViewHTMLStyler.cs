using General.UI.HTML.Basics.Elements.Abstracts;
using General.UI.HTML.Basics.Elements;
using General.UI.HTML.Basics.Attributes.Styles;


namespace General.UI.Trees.Views.HTML.Abstracts;

public abstract class TreeViewHTMLStyler
{
    protected const string CSS_CLASS_FOR_ROOT_NODE = "root-node";
    protected const string CSS_CLASS_FOR_NODE = "node";
    protected const string CSS_CLASS_FOR_LEAF = "leaf";

    private StyleAttribute IndentationStyleAttribute(int nbPixelsOfIndentation) => new StyleAttribute("margin-left", $"{nbPixelsOfIndentation}px");

    protected abstract List<HTMLStyleRule> GetStyleRules();

    internal virtual int GetMonoIndentationNbPixels() => 15;

    internal void StyleHeadTag(HTMLHeadTag headTag)
    {
        List<HTMLStyleRule> styleRules = GetStyleRules();
        headTag.AddStyleRules(styleRules);
    }

    internal void StyleForIndentation(HTMLTag tag, int nbPixelsOfIndentation)
    {
        StyleAttribute styleAttribute = IndentationStyleAttribute(nbPixelsOfIndentation);
        tag.AddAttribute(new HTMLStyleAttribute(styleAttribute));
    }

    internal void StyleRootNodeTag(HTMLNodeTag nodeTag)
    {
        nodeTag.AddStyleClass(CSS_CLASS_FOR_ROOT_NODE);
    }

    internal void StyleLeafTag(HTMLNodeTag leafTag)
    {
        leafTag.AddStyleClass(CSS_CLASS_FOR_LEAF);
    }

    internal void StyleNodeTag(HTMLNodeTag nodeTag)
    {
        nodeTag.AddStyleClass(CSS_CLASS_FOR_NODE);
    }
}
