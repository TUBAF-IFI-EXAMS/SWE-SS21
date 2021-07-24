/** @example GeneralOutput.cs
 * Demonstrates conversion of the first two Paragraphs of "MyDocument.docx" \n
 * into a SingleChoice Test
 **/

using System;
class QtiOutput{
static void QtiExample(string[] args)
    {
        // A minimal Paragraph Array with one entry is
        // created from MyDocument.docx
        var path = "MyDocument.docx";
        var  parser = new XmlParser(path);
        Paragraph[] exampleText = new Paragraph[1];
        parser.ReadSection(out exampleText[0]);

        // The second section creates the "Answer" array
        // for the test
        Paragraph[] Answers = new Paragraph[1];
        parser.ReadSection(out Answers[0]);

        // Both the text and Answers are now committed to the constructor,
        // along with the index of the correct answer (0) and possible
        // points (2.5)
        var TestClass = new SingleChoice(exampleText, Answers, 0, 2.5);

        // Different QTI declarations are now being written to console
        Console.WriteLine(TestClass.GetChoices());
        Console.WriteLine(TestClass.GetOutcome());
        Console.WriteLine(TestClass.GetResponse());
        Console.WriteLine(TestClass.GetResponseDeclaration());
    }
}