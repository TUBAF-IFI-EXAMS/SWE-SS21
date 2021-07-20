

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml;



partial class XmlParser{

    private XmlReader reader;

    public void SetSource(string path) { //opens FileStream from document.xml in the ZIP archive
        ZipArchive Source = ZipFile.OpenRead(path);
        string bodyPath = "word/document.xml";
        ZipArchiveEntry entry = Source.GetEntry(bodyPath);
        if(entry is null) throw new DirectoryNotFoundException($"Could not find {bodyPath}");
        reader = XmlReader.Create(entry.Open());
    }

    public bool ReadSection(out Paragraph resultParagraph) {
        bool isList = false;
        List<fString> fStringList = new List<fString>();

//waits until a beginning paragraph
        ScanUntil(ElementCondition(Paragraph, XmlNodeType.Element), ()=> reader.Read());
        
//Until the paragraph ends, the reader will scan every run        
        ScanUntil(ElementCondition(Paragraph, XmlNodeType.EndElement), ()=>{
            if(Run.Equals(reader.Name)){
                fString word = ScanRun();
                if(word.Text != null) fStringList.Add(word);
            }
            //if a List tag (w:numPr) is detected, isList is set to true
              if(List.Equals(reader.Name)) isList = true;
              reader.Read();
        });
//if the paragraph has no text, the new fString array in class Paragraph will be empty

        resultParagraph = new Paragraph(fStringList.ToArray(), isList);
        reader.Read();

        if(reader.Name == SecPr){
            ScanUntil(ElementCondition(SecPr, XmlNodeType.EndElement), ()=> reader.Read());
            reader.Read();
        }
        
        return (reader.NodeType == XmlNodeType.Element);
  
    }
//seperate function to make code more readible
    private fString ScanRun(){
        
        fString result = new fString();

        ScanUntil(ElementCondition(Run, XmlNodeType.Element), () => reader.Read());

        ScanUntil(ElementCondition(Run, XmlNodeType.EndElement), ()=>{
            if(reader.NodeType == XmlNodeType.Text) result.Text = reader.Value; //if Node contains Text, this text is added to result

            else
            switch(reader.Name){                                                //checks if the Node is an Attribute
            case Color : result.TextColor = reader[0];  break;
            case Highlight : result.Highlight = reader[0];  break;
            case Size : result.SetSize(reader[0]) ;     break;
            default : {                                                         //default tries to match using the switch in Toflag()
                         FormatFlags flag = ToFlag(reader.Name);
                         if(flag != 0) result.AddFormat(flag);                  //if flag contributes to formatting, its format is added
                      }                                 break;
            }
            reader.Read();
        });
        return result;  
        }
        
    } 
