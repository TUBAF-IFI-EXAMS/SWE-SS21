using System;
using System.Drawing;  

/** @brief Main class for saving read formatted Strings 
 *  @details Contains Fields and Properties for formatting, \n
 *           as well as Methods to help with output
 **/
public class fString {
    //constructor

    /// Creates formatted String from Text
    public fString(string Text) => this.Text = Text;
    /// Creates blank formatted String
    public fString(){}                                

    //strings used in the tags for qti 
    const string underline = "span style=\"text-decoration: underline;\"";
    const string italic = "em";
    const string bold = "strong";
    const string color = "<span style=\"color: #";
    const string cross = "span style=\"text-decoration: line-through;\"";
    const string spanEnd = "</span>";
    
    //Size saved as byte, because only small numbers are needed
    private byte size = 22;
    private Color highlight = Color.White; //Color set to black on white by default
    private Color textcolor = Color.Black; 

    /// Property access to fString-Text
    public String Text{get; set;} 

    //Access Colors through Properties

    /// Property access to Highlight Color \n
    /// Takes name or RGB hex code of Color
    ///
    public string Highlight {get => GetColor(highlight);             
                            set => highlight = SetColor(value);     
                            }     
    /// Property access to Highlight Color \n  
    /// Takes name or RGB hex code of Color 
    ///                               
    public string TextColor {get => GetColor(textcolor);            
                            set => textcolor = SetColor(value);    
                            }                                       
    
    /// Get-Method for font size   
    ///                                                                   
    public double GetSize() => (double)(size);                        
    public void SetSize(double value) {
        /// Set-Method for font size \n
        /// Takes positive double, caps size at 255 \n
        /// ArgumentOutOfRangeException() for negative numbers
        ///
        if(value <= 0) throw new ArgumentOutOfRangeException($"Font size of {value} could not be assigned");
         if(value > 255) size = 255;
         else size = Convert.ToByte(value);
    }
    /// Set-Method for font size \n
    /// Parses positive double from string, caps size at 255 \n
    /// ArgumentOutOfRangeException() for negative numbers \n
    /// FormatException() for non-number strings
    ///
    public void SetSize(string value) => SetSize(Convert.ToDouble(value));      

    //Private Get and Set for Colors, because Highlight and Font Color Properties share same pattern
    private string GetColor(Color color){            
        int aux = ColorTranslator.ToWin32(color); 
        return aux.ToString("X6");
    }
    private Color SetColor(string value){
        
        if(int.TryParse(value, System.Globalization.NumberStyles.HexNumber, null, out int ColorValue )){
            return ColorTranslator.FromWin32(ColorValue); 
        }
        Color auxColor = Color.FromName(value);
        //swaps blue and red, since OOXML color order is opposite of Color struct
        return Color.FromArgb(auxColor.B, auxColor.G, auxColor.R); 
    }

 

    //Tools for handling FormatFlags \n    
    //Initializes FormatFlags as 0 for "Normal"

    /// Format of the fString
    public FormatFlags Format{get; private set;} = 0; 
    /// Returns FormatFlags as strings
    public string GetFormat() => Format.ToString();
    //Removal/ addition methods, in case we ever implement an editor

    /// Adds a specific FormatFlags flag
    public void AddFormat(FormatFlags flag) => Format |= flag;   
    /// Removes a specific FormatFlags flag
    public void RemoveFormat(FormatFlags flag) => Format &= ~flag; 
    /// Removes all FormatFlags
    public void RemoveFormat() => Format = 0;                      

    //assigns corresponding tags and end tags, returns paragraph as QTI compatible string
    public string ToQti(){
            /** @brief Conversion method to QTI
            * @details Returns string with QTI tag formatting and Text \n
            * Example @include ReadSection.cs */
            
            string Tags = color + TextColor.ToLower() + ";\">";
            string EndTags = spanEnd;
            if(Format.HasFlag(FormatFlags.crossed)){
                Tags += "<"+cross+">";
                EndTags = spanEnd + EndTags;
            }
            if(Format.HasFlag(FormatFlags.bold)){
                Tags += "<"+bold+">";
                EndTags = "</"+bold+">" + EndTags;
            }
            if(Format.HasFlag(FormatFlags.italic)){
                Tags += "<"+italic+">";
                EndTags = "</"+italic+">" + EndTags;
            }
            if(Format.HasFlag(FormatFlags.underlined)){
                Tags += "<"+underline+">";
                EndTags = spanEnd + EndTags;
            }
            string result = Tags + Text + EndTags;
            return result;
        }

   
}