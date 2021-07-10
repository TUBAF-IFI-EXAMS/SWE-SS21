using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;


[Flags] enum FormatFlags {
    bold = 1,
    italic = 2,
    underlined = 4,
    crossed = 8,
    math = 16

}      

interface Ixml {
    public string ToString();
}

class fString {
    public String Text{get; protected set;}

    private byte size;
    public double Size{
        get => (float)size/2;
        set {   
             if(value <= 0) throw new ArgumentOutOfRangeException($"Font size of {value} could not be assigned");
             if(value > 127.5) size = 255;
             else size = Convert.ToByte(value*2);     
            }
    }

    private Color highlight;
    private Color textcolor; 

    private string GetColor(Color color){
        int aux = ColorTranslator.ToWin32(color);
        return aux.ToString("X6");
    }
    private Color SetColor(string value){
        int ColorValue = int.Parse(value, System.Globalization.NumberStyles.HexNumber);
        return ColorTranslator.FromWin32(ColorValue);
    }

    public string Highlight {get => GetColor(highlight);
                            protected set => highlight = SetColor(value);
                            } 
    public string TextColor {get => GetColor(textcolor);
                            protected set => textcolor = SetColor(value);
                            } 

    private FormatFlags format=0;
    public string Format {get => format.ToString();
                          set {
                           throw new NotImplementedException("Set not implemented due to dependency on XML-Parse functions");
                          }
    }

                             

}

