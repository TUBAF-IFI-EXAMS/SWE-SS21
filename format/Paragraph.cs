using System;
using System.Drawing;
using System.Collections;
using System.IO;

   

interface Ixml : IEnumerable {

}

public class Paragraph : Ixml {
   
    private fString[] Content;
    public fString this[int i]
   {
      get { return Content[i]; }
      set { Content[i] = value; }
   }
    public int Length {get => Content.Length;}
    public bool isList{get; private set; }

    //writes Qti using a StreamWriter
    public void WriteQti(StreamWriter sw){
        string result = String.Empty;
        foreach(fString fs in Content){
            sw.Write(fs.ToQti());
        }
    }

    public IEnumerator GetEnumerator() => Content.GetEnumerator();
    public Paragraph(fString[] Content, bool isList){
        this.Content = Content;
        this.isList = isList;
    }
    public Paragraph(fString[] Content){
        this.Content = Content;
        this.isList = false;
    }

   


}
