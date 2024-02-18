using Xunit;

using General.SequenceParsing.Generic;

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

        General.Basics.Trees.GenericTree.TreeElement<TreeViewModelElementsData> element;
        General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData> rootParentElement, parentElement, parentElement2;

        //--- Act ---
        TreeViewModel<TreeViewModelElementsData> result = presenter.GetViewModel(parseResult);

        //--- Assert ---
        rootParentElement = result.Tree;
        Assert.IsType<General.Basics.Trees.GenericTree.GenericTree<TreeViewModelElementsData>>(rootParentElement);
        Assert.Equal(-1, rootParentElement.Data!.Depth);
        Assert.Equal($"(5) : {treeTitle}", rootParentElement.Data!.Text);
        Assert.Equal($"nbChildren=5; id='0'; descr='{treeTitle}'", rootParentElement.Data!.Hint);
        {

            element = rootParentElement.GetChildByIndex(0);
            Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(element);
            Assert.Equal(0, element.Data!.Depth);
            Assert.Equal($"Data(3)='xyz'", element.Data!.Text);
            Assert.Equal($"id='1'; parentId='0'; indexInParent=0; descr='Data(3)='xyz''", element.Data!.Hint);

            element = rootParentElement.GetChildByIndex(1);
            Assert.IsType<General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData>>(element);
            Assert.Equal(0, element.Data!.Depth);
            Assert.Equal($"(1) :  StartDelim(2)=`AA`; EndDelim(3)=`AAF`", element.Data!.Text);
            Assert.Equal($"nbChildren=1; id='2'; parentId='0'; indexInParent=1; descr=' StartDelim(2)=`AA`; EndDelim(3)=`AAF`'", element.Data!.Hint);
            {

                parentElement = (element as General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData>)!;
                element = parentElement.GetChildByIndex(0);
                Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(element);
                Assert.Equal(1, element.Data!.Depth);
                Assert.Equal($"Data(3)='wkt'", element.Data!.Text);
                Assert.Equal($"id='3'; parentId='2'; indexInParent=0; descr='Data(3)='wkt''", element.Data!.Hint);
            }

            element = rootParentElement.GetChildByIndex(2);
            Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(element);
            Assert.Equal(0, element.Data!.Depth);
            Assert.Equal($"Data(2)='bz'", element.Data!.Text);
            Assert.Equal($"id='4'; parentId='0'; indexInParent=2; descr='Data(2)='bz''", element.Data!.Hint);

            element = rootParentElement.GetChildByIndex(3);
            Assert.IsType<General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData>>(element);
            Assert.Equal(0, element.Data!.Depth);
            Assert.Equal($"(3) :  StartDelim(2)=`BB`; EndDelim(3)=`BBF`", element.Data!.Text);
            Assert.Equal($"nbChildren=3; id='5'; parentId='0'; indexInParent=3; descr=' StartDelim(2)=`BB`; EndDelim(3)=`BBF`'", element.Data!.Hint);
            {
                parentElement = (element as General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData>)!;
                element = parentElement.GetChildByIndex(0);
                Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(element);
                Assert.Equal(1, element.Data!.Depth);
                Assert.Equal($"Data(2)='ej'", element.Data!.Text);
                Assert.Equal($"id='6'; parentId='5'; indexInParent=0; descr='Data(2)='ej''", element.Data!.Hint);

                element = parentElement.GetChildByIndex(1);
                Assert.IsType<General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData>>(element);
                Assert.Equal(1, element.Data!.Depth);
                Assert.Equal($"(1) :  StartDelim(2)=`AA`; EndDelim(3)=`AAF`", element.Data!.Text);
                Assert.Equal($"nbChildren=1; id='7'; parentId='5'; indexInParent=1; descr=' StartDelim(2)=`AA`; EndDelim(3)=`AAF`'", element.Data!.Hint);
                {
                    parentElement2 = (element as General.Basics.Trees.GenericTree.Node<TreeViewModelElementsData>)!;
                    element = parentElement2.GetChildByIndex(0);
                    Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(element);
                    Assert.Equal(2, element.Data!.Depth);
                    Assert.Equal($"Data(3)='123'", element.Data!.Text);
                    Assert.Equal($"id='8'; parentId='7'; indexInParent=0; descr='Data(3)='123''", element.Data!.Hint);
                }
                element = parentElement.GetChildByIndex(2);
                Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(element);
                Assert.Equal(1, element.Data!.Depth);
                Assert.Equal($"Data(3)='567'", element.Data!.Text);
                Assert.Equal($"id='9'; parentId='5'; indexInParent=2; descr='Data(3)='567''", element.Data!.Hint);
            }

            element = rootParentElement.GetChildByIndex(4);
            Assert.IsType<General.Basics.Trees.GenericTree.Leaf<TreeViewModelElementsData>>(element);
            Assert.Equal(0, element.Data!.Depth);
            Assert.Equal($"Data(4)='rien'", element.Data!.Text);
            Assert.Equal($"id='10'; parentId='0'; indexInParent=4; descr='Data(4)='rien''", element.Data!.Hint);
        }
    }
}
