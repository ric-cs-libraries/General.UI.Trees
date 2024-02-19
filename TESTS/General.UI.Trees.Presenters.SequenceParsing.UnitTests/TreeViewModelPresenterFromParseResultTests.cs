using Xunit;

using General.SequenceParsing.Generic;


using General.UI.Trees.Fixtures;

using General.UI.Trees.ViewModels;
using General.UI.Trees.ViewModels.ElementsData;
using General.UI.Trees.Presenters.SequenceParsing.Interfaces;

namespace General.UI.Trees.Presenters.SequenceParsing.UnitTests;

public class TreeViewModelPresenterFromParseResultTests
{
    [Fact]
    public void GetViewModel__ShouldReturnTheCorrectlyFilledTreeViewModel()
    {
        //--- Arrange ---
        ParseResult<char> parseResult = Fixtures.Parsing.GetParseResult();

        IParseResultTreeElementToTreeViewModelElementDataConverter<TreeViewModelElementsData> toDataConverter =
            new Fixtures.ParseResultTreeElementToTreeViewModelElementDataConverter();

        var treeTitle = "Essai1";
        TreeViewModelPresenterFromParseResult<TreeViewModelElementsData> presenter = new(toDataConverter, treeTitle);

        General.Basics.Trees.GenericTree.TreeElement<TreeViewModelElementsData> treeElement;
        General.Basics.Trees.GenericTree.GenericTree<TreeViewModelElementsData> treeRootNode;
        General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData> treeNode, parentElement, parentElement2;


        //--- Act ---
        TreeViewModel<TreeViewModelElementsData> result = presenter.GetViewModel(parseResult);

        //--- Assert ---
        treeRootNode = result.Tree;
        Assert.IsType<General.Basics.Trees.GenericTree.GenericTree<TreeViewModelElementsData>>(treeRootNode);
        Assert.Equal(-1, treeRootNode.Data!.Depth);
        Assert.Equal(0, treeRootNode.Id);
        Assert.Equal($"{treeTitle}", treeRootNode.Data!.Label);
        Assert.Equal(5, treeRootNode.NbChildren);
        {

            treeElement = treeRootNode.GetChildByIndex(0);
            Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(treeElement);
            Assert.Equal(0, treeElement.Data!.Depth);
            Assert.Equal(1, treeElement.Id);
            Assert.Equal(0, treeElement.ParentId);
            Assert.Equal($"Data(3)='xyz'", treeElement.Data!.Label);
            Assert.Equal(0, treeElement.IndexInParent);

            treeNode = (treeRootNode.GetChildByIndex(1) as General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData>)!;
            Assert.IsType<General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData>>(treeNode);
            Assert.Equal(0, treeNode.Data!.Depth);
            Assert.Equal(2, treeNode.Id);
            Assert.Equal(0, treeNode.ParentId);
            Assert.Equal($" StartDelim(2)=`AA`; EndDelim(3)=`AAF`", treeNode.Data!.Label);
            Assert.Equal(1, treeNode.IndexInParent);
            Assert.Equal(1, treeNode.NbChildren);
            {

                parentElement = treeNode;
                treeElement = parentElement.GetChildByIndex(0);
                Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(treeElement);
                Assert.Equal(1, treeElement.Data!.Depth);
                Assert.Equal(3, treeElement.Id);
                Assert.Equal(2, treeElement.ParentId);
                Assert.Equal($"Data(3)='wkt'", treeElement.Data!.Label);
                Assert.Equal(0, treeElement.IndexInParent);
            }

            treeElement = treeRootNode.GetChildByIndex(2);
            Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(treeElement);
            Assert.Equal(0, treeElement.Data!.Depth);
            Assert.Equal(4, treeElement.Id);
            Assert.Equal(0, treeElement.ParentId);
            Assert.Equal($"Data(2)='bz'", treeElement.Data!.Label);
            Assert.Equal(2, treeElement.IndexInParent);

            treeNode = (treeRootNode.GetChildByIndex(3) as General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData>)!;
            Assert.IsType<General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData>>(treeNode);
            Assert.Equal(0, treeNode.Data!.Depth);
            Assert.Equal(5, treeNode.Id);
            Assert.Equal(0, treeNode.ParentId);
            Assert.Equal($" StartDelim(2)=`BB`; EndDelim(3)=`BBF`", treeNode.Data!.Label);
            Assert.Equal(3, treeNode.IndexInParent);
            Assert.Equal(3, treeNode.NbChildren);
            {
                parentElement = treeNode;
                treeElement = parentElement.GetChildByIndex(0);
                Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(treeElement);
                Assert.Equal(1, treeElement.Data!.Depth);
                Assert.Equal(6, treeElement.Id);
                Assert.Equal(5, treeElement.ParentId);
                Assert.Equal($"Data(2)='ej'", treeElement.Data!.Label);
                Assert.Equal(0, treeElement.IndexInParent);

                treeNode = (parentElement.GetChildByIndex(1) as General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData>)!;
                Assert.IsType<General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData>>(treeNode);
                Assert.Equal(1, treeNode.Data!.Depth);
                Assert.Equal(7, treeNode.Id);
                Assert.Equal(5, treeNode.ParentId);
                Assert.Equal($" StartDelim(2)=`AA`; EndDelim(3)=`AAF`", treeNode.Data!.Label);
                Assert.Equal(1, treeNode.IndexInParent);
                Assert.Equal(1, treeNode.NbChildren);
                {
                    parentElement2 = treeNode;
                    treeElement = parentElement2.GetChildByIndex(0);
                    Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(treeElement);
                    Assert.Equal(2, treeElement.Data!.Depth);
                    Assert.Equal(8, treeElement.Id);
                    Assert.Equal(7, treeElement.ParentId);
                    Assert.Equal($"Data(3)='123'", treeElement.Data!.Label);
                    Assert.Equal(0, treeElement.IndexInParent);
                }
                treeElement = parentElement.GetChildByIndex(2);
                Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(treeElement);
                Assert.Equal(1, treeElement.Data!.Depth);
                Assert.Equal(9, treeElement.Id);
                Assert.Equal(5, treeElement.ParentId);
                Assert.Equal($"Data(3)='567'", treeElement.Data!.Label);
                Assert.Equal(2, treeElement.IndexInParent);
            }

            treeElement = treeRootNode.GetChildByIndex(4);
            Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(treeElement);
            Assert.Equal(0, treeElement.Data!.Depth);
            Assert.Equal(10, treeElement.Id);
            Assert.Equal(0, treeElement.ParentId);
            Assert.Equal($"Data(4)='rien'", treeElement.Data!.Label);
            Assert.Equal(4, treeElement.IndexInParent);
        }
    }
}
