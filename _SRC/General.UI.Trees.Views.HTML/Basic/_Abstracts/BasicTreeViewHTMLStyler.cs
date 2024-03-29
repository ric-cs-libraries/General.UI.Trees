﻿using General.UI.HTML.Basics.Elements.Abstracts;
using General.UI.HTML.Basics.Elements;

using General.UI.Trees.Views.HTML.Abstracts;

namespace General.UI.Trees.Views.HTML.Basic.Abstracts;

public abstract class BasicTreeViewHTMLStyler : TreeViewHTMLStyler
{
    protected const string CSS_CLASS_FOR_NODE_COLLAPSER = "node-collapser";

    protected const string CSS_CLASS_FOR_ROOT_NODE_DESCRIPTION = "root-node-description";
    protected const string CSS_CLASS_FOR_NODE_DESCRIPTION = "node-description";

    protected const string CSS_CLASS_FOR_NODE_PREFIX = "node-prefix";
    protected const string CSS_CLASS_FOR_LEAF_PREFIX = "leaf-prefix";


    public void StyleRootNodeDescriptionTag(HTMLNodeTag descriptionTag)
    {
        descriptionTag.AddStyleClass(CSS_CLASS_FOR_ROOT_NODE_DESCRIPTION);
    }

    public void StyleNodeDescriptionTag(HTMLNodeTag descriptionTag)
    {
        descriptionTag.AddStyleClass(CSS_CLASS_FOR_NODE_DESCRIPTION);
    }

    public void StyleNodeCollapseTag(HTMLNodeTag nodeCollapseTag)
    {
        nodeCollapseTag.AddStyleClass(CSS_CLASS_FOR_NODE_COLLAPSER);
    }

    public void StyleNodePrefixTag(HTMLTag prefixTag)
    {
        prefixTag.AddStyleClass(CSS_CLASS_FOR_NODE_PREFIX);
    }

    public void StyleLeafPrefixTag(HTMLTag prefixTag)
    {
        prefixTag.AddStyleClass(CSS_CLASS_FOR_LEAF_PREFIX);
    }
}
