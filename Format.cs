using System;
using System.Drawing;
using System.Collections;

   

interface Ixml : IEnumerable {

}

class Paragraph : Ixml {
    private fString[] Content;
    public fString this[int i]
   {
      get { return Content[i]; }
      set { Content[i] = value; }
   }
    public int Length {get => Content.Length;}
    public bool isList{get; private set; }
    public string Print(){
        throw new NotImplementedException();


    }

    public Paragraph(fString[] Content, bool isList){
        this.Content = Content;
        this.isList = isList;
    }
    public Paragraph(fString[] Content){
        this.Content = Content;
        this.isList = false;
    }

    public IEnumerator GetEnumerator() => Content.GetEnumerator();


}

class fString {
    public String Text{get; set;}

//Size saved as byte, because only small numbers are needed
//Division allows use of 0.5 increments in size
    private byte size = 20;

    public double GetSize() => (double)(size/2);
    public void SetSize(double value) {
        if(value <= 0) throw new ArgumentOutOfRangeException($"Font size of {value} could not be assigned");
         if(value > 127.5) size = 255;
         else size = Convert.ToByte(value*2);
    }
    public void SetSize(string value) => SetSize(Convert.ToDouble(value));


   /* public double Size{
        get => (double)(size/2);
        set {   
             if(value <= 0) throw new ArgumentOutOfRangeException($"Font size of {value} could not be assigned");
             if(value > 127.5) size = 255;
             else size = Convert.ToByte(value*2);     
            }
    } */ //Legacy implementation as property; new Get-/ Set-Method to allow overload

    private Color highlight = Color.White; //Color set to black on white by default
    private Color textcolor = Color.Black; 

//Private Get and Set for Colors, because Highlight and Font Color Properties share same pattern
    private string GetColor(Color color){            
        int aux = ColorTranslator.ToWin32(color);
        return aux.ToString("X6");
    }
    private Color SetColor(string value){
        int ColorValue;
        if(int.TryParse(value, System.Globalization.NumberStyles.HexNumber, null, out ColorValue )){
            return ColorTranslator.FromWin32(ColorValue); 
        }
        return Color.FromName(value);
    }
//Access through Properties
    public string Highlight {get => GetColor(highlight);
                            set => highlight = SetColor(value);
                            } 
    public string TextColor {get => GetColor(textcolor);
                            set => textcolor = SetColor(value);
                            } 
//Initializes FormatFlags as 0 for "Normal"
    private FormatFlags format=0;
    public string GetFormat() => format.ToString();

    public void AddFormat(FormatFlags flag) => format |= flag;
         
    public void RemoveFormat(FormatFlags flag) => format &= ~flag; //In case we ever implement an editor, this can remove formatting
    public void RemoveFormat() => format = 0;

   
}

