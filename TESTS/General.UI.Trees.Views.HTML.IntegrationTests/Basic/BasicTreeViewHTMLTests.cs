using System.Text;
using Xunit;

using General.SequenceParsing.Generic;


using General.UI.Trees.Fixtures;

using General.UI.Trees.ViewModels;
using General.UI.Trees.ViewModels.ElementsData;
using General.UI.Trees.Presenters.SequenceParsing.Interfaces;
using General.UI.Trees.Presenters.SequenceParsing;

using General.UI.Trees.Views.HTML.Basic.Stylers;
using General.UI.Trees.Views.HTML.Basic.DescriptionsMakers;
using General.UI.Trees.Views.HTML.Basic.HintsMakers;
using General.UI.Trees.Views.HTML.Interfaces;
using General.UI.Trees.Views.HTML.Basic.Interfaces;

namespace General.UI.Trees.Views.HTML.Basic.IntegrationTests;

public class BasicTreeViewHTMLIntegrationTests
{
    private const string ASSETS_SUBPATH = "._Assets";

    [Fact]
    public void GetAsString__ShouldReturnTheCorrectHTMLBasicTree()
    {
        //--- Arrange ---
        ParseResult<char> parseResult = Fixtures.Parsing.GetParseResult();

        IParseResultTreeElementToTreeViewModelElementDataConverter<TreeViewModelElementsData> toDataConverter =
            new Fixtures.ParseResultTreeElementToTreeViewModelElementDataConverter();

        var treeTitle = "Essai1";
        TreeViewModelPresenterFromParseResult<TreeViewModelElementsData> presenter = new(toDataConverter, treeTitle);
        TreeViewModel<TreeViewModelElementsData> treeViewModel = presenter.GetViewModel(parseResult);

        IBasicTreeViewHTMLStyler basicTreeViewHTMLStyler = new BasicTreeViewHTMLBasicStyler();
        ITreeViewHTMLDescriptionsMaker<TreeViewModelElementsData> treeViewHTMLDescriptionsMaker = new BasicTreeViewHTMLBasicDescriptionsMaker();
        ITreeViewHTMLHintsMaker<TreeViewModelElementsData> treeViewHTMLHintsMaker = new BasicTreeViewHTMLBasicHintsMaker();

        BasicTreeViewHTML<TreeViewModelElementsData> basicTreeViewHTML = new(
            treeViewModel, 
            basicTreeViewHTMLStyler, 
            treeViewHTMLDescriptionsMaker, 
            treeViewHTMLHintsMaker
        );


        //--- Act ---
        var result = basicTreeViewHTML.GetAsString();
        //File.WriteAllText($"{ASSETS_SUBPATH}/parsingResultAsBasicTreeViewHTML_Essai1.html", result, Encoding.Latin1);

        //--- Assert ---
        var expected = File.ReadAllText($"{ASSETS_SUBPATH}/parsingResultAsBasicTreeViewHTML_Essai1.html", Encoding.Latin1);
        Assert.Equal(expected, result);
    }
}
