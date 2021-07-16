using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml;


partial class XmlParse{
//constants for more readible code
    private const string Run = "w:r";
    private const string Paragraph = "w:p";
    //private const string RunProperty = "w:rPr";
    //private const string ParProperty = "w:pPr";
    private const string Color = "w:color";
    private const string Size = "w:sz";
    private const string List = "w:numPr";
    private const string Highlight = "w:highlight";
    

    
    /*private void WaitForText(){
        while(!(reader.NodeType == XmlNodeType.Text || ElementCondition(Run, XmlNodeType.EndElement)) && reader.Read());
    }*/
    private FormatFlags ToFlag(string value) => value switch{
        "w:b" => FormatFlags.bold,
        "w:u" => FormatFlags.underlined,
        "w:i" => FormatFlags.italic,
        "w:strike" => FormatFlags.crossed,
        _ => FormatFlags.normal,
    };
//checks if current element matches a specific name and type
//since it is a Func, it can be handed to the ScanUntil()
    private Func<bool> ElementCondition(string name, XmlNodeType type){         
        return () => (name.Equals(reader.Name) && reader.NodeType == type);
    }
    

    delegate void ScanHandler();

//runs a function (delegate), until a property (in our case ElementCondition) is met
    private void ScanUntil(Func<bool> EndCondition, ScanHandler handler ){
        while(!EndCondition()){
            handler();
        }
    }
    public XmlParse(string path){ 
        SetSource(path);
    }
        
 
    
}