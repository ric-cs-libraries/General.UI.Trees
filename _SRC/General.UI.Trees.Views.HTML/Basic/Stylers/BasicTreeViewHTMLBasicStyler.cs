using General.UI.HTML.Basics.Elements;
using General.UI.HTML.Basics.Attributes.Styles;


using General.UI.Trees.Views.HTML.Basic.Interfaces;
using General.UI.Trees.Views.HTML.Basic.Abstracts;

namespace General.UI.Trees.Views.HTML.Basic.Stylers;

public class BasicTreeViewHTMLBasicStyler : BasicTreeViewHTMLStyler, IBasicTreeViewHTMLStyler
{
    protected override List<HTMLStyleRule> GetStyleRules()
    {
        var boldStyleAttribute = new BoldStyleAttribute();
        var underlineStyleAttribute = new UnderlineStyleAttribute();
        var italicStyleAttribute = new ItalicStyleAttribute();

        var nodeColor = "pink";

        List<HTMLStyleRule> styleRules = new()
        {
            new HTMLStyleRule($".{CSS_CLASS_FOR_ROOT_NODE}", new()
            {
                new StyleAttribute("width", "60%"),
            }),
            new HTMLStyleRule($".{CSS_CLASS_FOR_ROOT_NODE_DESCRIPTION}", new()
            {
                boldStyleAttribute,
                underlineStyleAttribute,
                new StyleAttribute("font-size", "2.5em"),
                new StyleAttribute("margin-bottom", "10px"),
            }),
            new HTMLStyleRule($".{CSS_CLASS_FOR_NODE}", new()
            {
                new StyleAttribute("margin-bottom", "10px"),
                new StyleAttribute("border", $"dotted 2px {nodeColor}")

            }),
            new HTMLStyleRule($".{CSS_CLASS_FOR_LEAF}", new()
            {
                italicStyleAttribute,
                new StyleAttribute("margin-bottom", "6px"),
            }),
            new HTMLStyleRule($".{CSS_CLASS_FOR_NODE_PREFIX}", new()
            {
                boldStyleAttribute,
                new StyleAttribute("font-size", "1.5rem"),
                new StyleAttribute("color", $"{nodeColor}"),
            }),
            new HTMLStyleRule($".{CSS_CLASS_FOR_LEAF_PREFIX}", new()
            {
                new StyleAttribute("font-size", "0.7rem"),
                new StyleAttribute("color", "gray"),
            }),
            new HTMLStyleRule($".{CSS_CLASS_FOR_NODE_COLLAPSER}", new()
            {
                boldStyleAttribute,
                new StyleAttribute("font-size", "1.5rem")
            }),
            new HTMLStyleRule($".{CSS_CLASS_FOR_NODE_DESCRIPTION}", new()
            {
                underlineStyleAttribute,
                boldStyleAttribute
            }),
        };

        return styleRules;
    }
}
