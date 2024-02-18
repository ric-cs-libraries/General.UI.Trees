using General.SequenceParsing.Generic;
using General.SequenceParsing.Char;

using General.UI.Trees.Presenters.SequenceParsing.Interfaces;
using General.UI.Trees.ViewModels.ElementsData;


namespace General.UI.Trees.Presenters.SequenceParsing.UnitTests;

internal static class Fixtures
{
    internal static class Parsing
    {
        internal static ParseResult<char> GetParseResult()
        {
            string stringToParse = "xyzAAwktAAFbzBBejAA123AAF567BBFrien";
            CharSequenceParser parser = GetParser(stringToParse);

            StringMatchingEvaluator stringMatchingEvaluator = new StringMatchingEvaluatorByEquality();

            CharBlockDelimiter blockAStartDelimiter = CharBlockDelimiter.Create("AA", stringMatchingEvaluator);
            CharBlockDelimiter blockAEndDelimiter = CharBlockDelimiter.Create("AAF", stringMatchingEvaluator);
            CharBlock blockA = CharBlock.Create(blockAStartDelimiter, blockAEndDelimiter);

            CharBlockDelimiter blockBStartDelimiter = CharBlockDelimiter.Create("BB", stringMatchingEvaluator);
            CharBlockDelimiter blockBEndDelimiter = CharBlockDelimiter.Create("BBF", stringMatchingEvaluator);
            CharBlock blockB = CharBlock.Create(blockBStartDelimiter, blockBEndDelimiter, expectedInnerBlocks: CharBlocks.Create(new List<CharBlock> { blockA }));

            CharBlocks expectedInnerBlocks = CharBlocks.Create(new List<CharBlock> { blockA, blockB });


            ParseResult<char> parseResult = parser.Parse(expectedInnerBlocks);

            return parseResult;
        }

        private static CharSequenceParser GetParser(string stringToParse)
        {
            CharSequence charSequenceToParse = CharSequence.Create(stringToParse);
            CharSequenceParser parser = GetParser(charSequenceToParse);
            return parser;
        }

        private static CharSequenceParser GetParser(CharSequence charSequenceToParse)
        {
            CharSequenceParser parser = CharSequenceParser.Create(charSequenceToParse);
            return parser;
        }
    }

    internal class ParseResultTreeElementToTreeViewModelElementDataConverter : IParseResultTreeElementToTreeViewModelElementDataConverter<TreeViewModelElementsData>
    {
        public TreeViewModelElementsData Convert(General.SequenceParsing.Generic.RootNode<char> parseResultRootNode, string treeTitle)
        {
            var description = treeTitle;
            var nbChildren = parseResultRootNode.Elements.Count;
            var result = new TreeViewModelElementsData
            {
                Depth = parseResultRootNode.Depth,
                Text = $"({nbChildren}) : {description}",
                Hint = $"nbChildren={nbChildren}; id='{parseResultRootNode.Id}'; descr='{description}'"
            };
            return result;
        }

        public TreeViewModelElementsData Convert(General.SequenceParsing.Generic.Node<char> parseResultNode, int indexInParent)
        {
            var description = $"{parseResultNode.GetSimplifiedStateAsString()}";
            var nbChildren = parseResultNode.Elements.Count;
            var result = new TreeViewModelElementsData
            {
                Depth = parseResultNode.Depth,
                Text = $"({nbChildren}) : {description}",
                Hint = $"nbChildren={nbChildren}; id='{parseResultNode.Id}'; parentId='{parseResultNode.ParentId}'; indexInParent={indexInParent}; descr='{description}'"
            };
            return result;
        }

        public TreeViewModelElementsData Convert(General.SequenceParsing.Generic.Leaf<char> parseResultLeaf, int indexInParent)
        {
            var description = $"Data{parseResultLeaf.GetDataAsString()}";
            var result = new TreeViewModelElementsData
            {
                Depth = parseResultLeaf.Depth,
                Text = $"{description}",
                Hint = $"id='{parseResultLeaf.Id}'; parentId='{parseResultLeaf.ParentId}'; indexInParent={indexInParent}; descr='{description}'"
            };
            return result;
        }
    }
}
