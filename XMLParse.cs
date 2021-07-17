

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Xml;



partial class XmlParse{

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
//waits until a run
        ScanUntil(ElementCondition(Run, XmlNodeType.Element), ()=> {reader.Read();
                                                                    if(reader.Name == List) isList = true;});
//Until the paragraph ends, the reader will scan every run        
        ScanUntil(ElementCondition(Paragraph, XmlNodeType.EndElement), ()=>{
            if(Run.Equals(reader.Name)){
                fString word = ScanRun();
                if(word != null) fStringList.Add(word);
            }
              reader.Read();
        });

        resultParagraph = new Paragraph(fStringList.ToArray(), isList);
        reader.Read();
        return reader.NodeType == XmlNodeType.Element;
  
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
//Legacy code that will be removed in final draft

 /* private void WaitForParagraph(){
        while(!(reader.Name == "w:p" && reader.NodeType == XmlNodeType.Element) && reader.Read());
    }

    private void WaitForRun(){
        while(!(reader.Name == "w:r" && reader.NodeType == XmlNodeType.Element) && reader.Read());
    }

    private void WaitForProperties(){
        while(!(reader.Name == "w:rPr" && reader.NodeType == XmlNodeType.Element) && reader.Read());
    } */ //Legacy code, generalized as WaitForElement()

   /* private void WaitForText(){
        while(!(reader.NodeType == XmlNodeType.Text || (reader.NodeType == XmlNodeType.EndElement && reader.Name == "w:r")) && reader.Read());
    } */
        
        
   /* private void WaitForElement(string name){
        ReadWhile((name) => !(name.Equals(reader.Name) && reader.NodeType == XmlNodeType.Element));
    } */

    /*   while(!((reader.Name == Run && reader.NodeType == XmlNodeType.EndElement) || reader.NodeType == XmlNodeType.Text)){
        
        switch(reader.Name){
            case Color : result.TextColor = reader[0]; break;
            case Size : result.SetSize(reader[0]) ; break;
            default : {
                         FormatFlags flag = ToFlag(reader.Name);
                         if(flag != 0) result.AddFormat(flag);
                      } break;
        }
        
        

            reader.Read();
            } */

    	    
            //if(reader.NodeType != XmlNodeType.Text) return null;