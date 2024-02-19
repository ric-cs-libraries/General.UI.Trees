using General.SequenceParsing.Generic;
using General.SequenceParsing.Char;


namespace General.UI.Trees.Fixtures;


public static class Parsing
{
    public static ParseResult<char> GetParseResult()
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
