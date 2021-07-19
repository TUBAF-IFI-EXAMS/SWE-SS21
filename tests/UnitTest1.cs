using System;
using Xunit;

namespace tests
{
    public class UnitTest1
    {
        const string directory = "../../../tests/";
        const string TestDocument = "Parser Test File.docx";
        [Theory]
        [InlineData(TestDocument, 1)]
        [InlineData("LengthTest2.docx", 2)]
        [InlineData("LengthTest3.docx", 3)]
        public void RunLength(string path, int expected)
        {
            var Scanner = new XmlParser(directory+path);
            bool isCorrect = true;
            while(Scanner.ReadSection(out var Scan)){
                if(Scan.Length != expected && Scan.Length != 0) isCorrect = false;
                }
            Assert.True(isCorrect);
        }
        [Theory]
        [InlineData("MixedLength1.docx", new int[]{1,2,3,4})]
        [InlineData("MixedLength2.docx", new int[]{1,2,4,1,5,1})]
         public void MixedRunLength(string path, int[] expected)
        {
            var Scanner = new XmlParser(directory+path);
            bool isCorrect = true;
            int i = 0;
            while(Scanner.ReadSection(out var Scan)){
                if(Scan.Length != expected[i] && Scan.Length != 0) isCorrect = false;
                if(Scan.Length != 0) i++;
                }
            Assert.True(isCorrect);
        }
        [Fact]
        public void ParagraphCount()
        {
            var Scanner = new XmlParser(directory+TestDocument);
            int Paragraphs = 0;
            while(Scanner.ReadSection(out var Scan)){ 
                if(Scan.Length != 0) Paragraphs++;
                }
            Assert.True(Paragraphs == 9);
        }

        private const string Color = "FF0000";
        private const string Highlight = "FFFF00";
        [Fact]
        public void Format(){
            bool isCorrect = true;
            var Scanner = new XmlParser(directory+TestDocument);
            Paragraph Scan;
            FormatFlags[] formats = {FormatFlags.bold, FormatFlags.italic, FormatFlags.underlined, FormatFlags.crossed};
            int i=0;
            while(i<4){
                Scanner.ReadSection(out Scan);
                if(Scan.Length != 0){
                    
                    if(Scan[0].Format != formats[i]) isCorrect = false;
                    i++;
                }
            }
            Scanner.ReadSection(out Scan);
            if(!Scan[0].GetSize().Equals(40)) isCorrect = false;

            Scanner.ReadSection(out Scan);
            if(Scan[0].TextColor != Color) isCorrect = false;

            Scanner.ReadSection(out Scan);
            if(Scan[0].Highlight != Highlight) isCorrect = false;

            Scanner.ReadSection(out Scan);
            if(Scan.isList == false) isCorrect = false;

            Assert.True(isCorrect);
        }
    }
}
