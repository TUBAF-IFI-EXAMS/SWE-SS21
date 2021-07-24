/** @example ReadSection.cs
 * Shows how to read every Paragraph in the Document "MyDocument.docx" 
 **/

using System;

class Program{
    public static void ParserExample(){
        // A new parser for "MyDocument.docx" is being opened
        var path = "MyDocument.docx";
        XmlParser parser = new XmlParser(path);
        // While the parser is in the text body, it continues to read further
        while(parser.ReadSection(out var Scan)){
            // The content of each read run is written to Console
                foreach(fString fs in Scan) Console.Write(fs.Text);
                Console.WriteLine();
        }
    }
}
