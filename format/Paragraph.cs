using System;
using System.Drawing;
using System.Collections;
using System.IO;

   
/** @brief Interface for all possible XML media 
 *  @details Could take videos, images, text, tables, ...
 **/
interface Ixml : IEnumerable {

}

/** @brief Contains a read Paragraph 
 *  @details Holds formatted String Array (fString) and corresponding Properties
 **/
public class Paragraph : Ixml {
   
    internal fString[] Content;
    public fString this[int i]
   {
      get { return Content[i]; }
      set { Content[i] = value; }
   }
    public int Length {get => Content.Length;}
    public bool isList{get; private set; } /// States if paragraph is part of a list
                                   
    

    public IEnumerator GetEnumerator() => Content.GetEnumerator();
    public Paragraph(fString[] Content, bool isList){
        /// Constructor allowing list creation
        this.Content = Content;
        this.isList = isList;
    }
    public Paragraph(fString[] Content){
        /// Default constructor without list option
        this.Content = Content;
        this.isList = false;
    }
}

/// Extension class
static class StreamParagraph{
    //writes Qti using a StreamWriter
    static public void WriteQti(this StreamWriter sw, Paragraph p){
        /// Extension method for StreamWriter \n
        /// Writes entire Paragraph as QTI formatted text
        ///
        string result = String.Empty;
        foreach(fString fs in p.Content){
            sw.Write(fs.ToQti());
        }
    }
}