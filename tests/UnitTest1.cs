using System;
using Xunit;

namespace tests
{
    public class UnitTest1
    {
        const string directory = "../../../tests/";
        const string TestDocument = "ParserTestFile.docx";

        [Theory]
        [InlineData(TestDocument, 1)]
        [InlineData("LengthTest2.docx", 2)]
        [InlineData("LengthTest3.docx", 3)]
        public void RunLength(string path, int expected)
        {
            int correct = 0; //counts correct runs
            int runs = 0; //counts read runs
            var Scanner = new XmlParser(directory+path);
            while(Scanner.ReadSection(out var Scan)){
                if(Scan.Length == expected) correct++;
                if(Scan.Length != 0) runs++;
                }
            Assert.True(correct == runs);
        }
        [Theory]
        [InlineData("MixedLength1.docx", new int[]{1,2,3,4})]
        [InlineData("MixedLength2.docx", new int[]{1,2,4,1,5,1})]
         public void MixedRunLength(string path, int[] expected)
        {
            var Scanner = new XmlParser(directory+path);
            int correct = 0;
            int i = 0;
            while(Scanner.ReadSection(out var Scan)){
                if(Scan.Length == expected[i]) correct++;
                if(Scan.Length != 0) i++;
                }
            Assert.True(i==correct);
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
            int correct = 0;
            var Scanner = new XmlParser(directory+TestDocument);
            Paragraph Scan;
            FormatFlags[] formats = {FormatFlags.bold, FormatFlags.italic, FormatFlags.underlined, FormatFlags.crossed};
            int i=0;
            while(i<4){
                Scanner.ReadSection(out Scan);
                if(Scan.Length != 0){
                    
                    if(Scan[0].Format == formats[i]) correct++;
                    i++;
                }
            }
            Scanner.ReadSection(out Scan);
            if(Scan[0].GetSize().Equals(40)) correct++;

            Scanner.ReadSection(out Scan);
            if(Scan[0].TextColor == Color) correct++;

            Scanner.ReadSection(out Scan);
            if(Scan[0].Highlight == Highlight) correct++;

            Scanner.ReadSection(out Scan);
            if(Scan.isList) correct++;

            Assert.True(correct==8);
        }
    }
}
