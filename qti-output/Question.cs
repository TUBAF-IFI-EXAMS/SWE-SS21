using System;

interface IScoring {
    string GetOutcome();
}

abstract class Question{
    public uint TestNumber {get;}
    protected static uint NumberCounter = 0;
    protected const string Score = "score";
    protected const string Response = "Response";
    protected const string responseDeclaration = "qti-response-declaration";
    protected const string ID = " identifier= ";
    protected const string valueID = "qti-value";
    protected const string correctResponse = "qti-correct-response";
    
    protected const string baseType = "baseType=";
    protected const string cardinality = "cardinality=";
    public fString[] Text { get;}
    public uint Points { get;}
    public abstract string GetResponseDeclaration();
    //constructor
    public Question(){
        TestNumber = NumberCounter++;
    }

}

abstract class ChoiceQuestion : Question, IScoring{
    protected const string baseValue = "qti-base-value ";
    protected const string ChoiceName = "choice";
    protected const string declaration = "choiceInteraction";
    protected const string responseID = " responseIdentifier=";
    protected const string choice = "simpleChoice";
    public Paragraph[] Options {get;}
    public abstract string Cardinality {get;}
    public override abstract string GetResponseDeclaration();
    public string GetChoices(){

        string result = declaration + " maxChoices=1" + choice + responseID + Response + TestNumber.ToString() + ">";
        for(int i =0; i<Options.Length; i++){
            result += "<" + choice + ID + i.ToString() + ">";
            foreach(fString fs in Options[i]) result += fs.ToQti();
            result += "<" + choice + "/>";    
        }
        result += "<" + declaration + "/>";
        return result;
    }
    public string GetResponse(){
        string condition = "qti-response-condition";
        string variable = "qti-variable";
        string correct = "qti-correct";
        string match = "match";
        string outcome = "qti-set-outcome-value";
        string response_if = "qti-response-if";

        string specificID ="<" + condition + ">" + ID + Response + TestNumber;
        string result = "<" + response_if + "><"+ match + ">";
        result += "<" + variable + specificID + "/>";
        result += "<" + correct + specificID + "/>";
        result += "<" + match + "/>";
        result += "<" + outcome  + specificID + Score + ">";
        result += "<" + baseValue + baseType + "\"float\">" + Points.ToString();
        result += "<" + outcome + "/><qti-response-if>";
        result += "<" + condition + "/>";

        return result;
    }

    public string GetOutcome(){
        string outcomeDeclaration = "<outcomeDeclaration ";
        string result = outcomeDeclaration + ID + Response + TestNumber + cardinality + Cardinality + baseType + "\"float\" />";
        return result;
    }
    
}

class MultipleChoice : ChoiceQuestion{
    public override string Cardinality {get;}
    public uint[] correctAnswers;
    public override string GetResponseDeclaration(){
        
        string result = "<"+responseDeclaration+ID+Response+TestNumber.ToString()+cardinality+Cardinality+baseType+"\"identifier\""+">";
        result += "<" + correctResponse + ">";
        foreach(uint i in correctAnswers){
            result += ("<" + valueID +">" + ChoiceName + i.ToString() + "<" + valueID +"/>");
        }
        result += "<" + correctResponse + "/>";
        result += "<"+responseDeclaration+cardinality+Cardinality+"/>";
        return result;
    }

}

class SingleChoice : ChoiceQuestion{
    public override string Cardinality {get;} = "single";
    public uint correctAnswer;
    public override string GetResponseDeclaration(){
        
        string result = "<"+responseDeclaration+ID+TestNumber.ToString()+cardinality+Cardinality+baseType+"\"identifier\""+">";
        result += "<" + correctResponse + ">";
        result += "<" + valueID +">" + ChoiceName + correctAnswer + "<" + valueID +"/>";
        result += "<" + correctResponse + "/>";
        result += "<"+responseDeclaration+"/>";

        return result;
    }
    

}

/* class LongTextQuestion : Question{
    private const string declaration = "extendedTextInteraction responseIdentifier=";
    private const string height = "qti-height-lines-";
    public string Height {get;}
}

class ShortTextQuestion : Question{
    private const string declaration = "qti-text-entry-interaction class=";
}
*/
