using General.UI.HTML.Basics.Elements;
using General.UI.HTML.Basics.Elements.Abstracts;


using General.UI.Trees.Views.HTML.Interfaces;

namespace General.UI.Trees.Views.HTML.Basic.Interfaces;

public interface IBasicTreeViewHTMLStyler : ITreeViewHTMLStyler
{
    void StyleRootNodeDescriptionTag(HTMLNodeTag descriptionTag);


    void StyleNodeDescriptionTag(HTMLNodeTag descriptionTag);

    void StyleNodeCollapseTag(HTMLNodeTag nodeCollapseTag);

    void StyleNodePrefixTag(HTMLTag prefixTag);


    void StyleLeafPrefixTag(HTMLTag prefixTag);
}
