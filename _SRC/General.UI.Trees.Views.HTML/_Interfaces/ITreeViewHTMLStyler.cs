using General.UI.HTML.Basics.Elements;
using General.UI.HTML.Basics.Elements.Abstracts;

namespace General.UI.Trees.Views.HTML.Interfaces;

public interface ITreeViewHTMLStyler
{
    int GetMonoIndentationNbPixels();

    void StyleHeadTag(HTMLHeadTag headTag);


    void StyleForIndentation(HTMLTag tag, int nbPixelsOfIndentation);


    void StyleRootNodeTag(HTMLNodeTag nodeTag);

    void StyleLeafTag(HTMLNodeTag leafTag);

    void StyleNodeTag(HTMLNodeTag nodeTag);
}
