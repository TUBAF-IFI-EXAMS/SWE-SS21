using System;
using System.Globalization;

enum Cardinalities {
    single,
    multiple
} //QTI supports more cardinalities, enum allows future expansion

interface IScoring {
    string GetOutcome();
}

abstract class Question{
    /// Number of the current test: used to identify qti-variables that belong to this test
    public uint TestNumber {get;}
    protected static uint Counter = 0;
    protected const string Score = "score";
    protected const string Response = "Response";
    protected const string responseDeclaration = "qti-response-declaration";
    protected const string ID = " identifier= ";
    protected const string valueID = "qti-value";
    protected const string correctResponse = "qti-correct-response";
    
    protected const string baseType = "baseType=";
    protected const string cardinality = "cardinality=";
    /// Text of the question
    public Paragraph[] Text { get;}
    /// Points that can be achieved for this question
    public double Points { get;}
    //each question needs to declare the response
    public abstract string GetResponseDeclaration();
    //constructor: initiates Text and counts up Question Index (Counter)
    public Question(Paragraph[] Text, double Points){
        TestNumber = Counter++;
        this.Text = Text;
        this.Points = Points;
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
    //GetResponseDeclaration() will be implemented by Single-/MultipleChoice classes
    public override abstract string GetResponseDeclaration();
    public abstract string GetResponse();
    public string GetChoices(){
        /// Generate the possible choices for this question \n
        /// "Qti choice declaration" \n
        /// Returns choice declaration as string
        ///
        string maxChoices = cardinality.Equals("single") ? "1 " : "0 ";
        string result = "<" + declaration + " maxChoices= " + maxChoices + choice + responseID + Response + TestNumber.ToString() + ">";
        for(int i =0; i<Options.Length; i++){
            result += "<" + choice + ID + "\"" + ChoiceName + TestNumber.ToString() + i.ToString() + "\">";
            foreach(fString fs in Options[i]) result += fs.ToQti();
            result += "<" + choice + "/>";    
        }
        result += "<" + declaration + "/>";
        return result;
    }
    

    public string GetOutcome(){
        /// Generates the "Qti Outcome Declaration" : declaration of the result of this question \n
        /// Returns it as a string
        ///

        //local string outcomeDeclaration is only needed here
        string outcomeDeclaration = "<outcomeDeclaration";

        string result = outcomeDeclaration + ID + Response + TestNumber + " " + cardinality + Cardinality + " " + baseType + "\"float\"/>";
        return result;
    }
    public ChoiceQuestion(Paragraph[] Text, Paragraph[] Options, double points) : base(Text, points){
        this.Options = Options;
    }
    
}

class MultipleChoice : ChoiceQuestion{
    /// Carinality : string that saves how many choices can be checked and how checking them behaves
    public override string Cardinality {get;}
    /// Saves indices of all correct answers
    public uint[] correctAnswers {get;}
    public override string GetResponseDeclaration(){
        
        ///Generates the "Response declaration" : declaration of a variable for the test answer \n
        /// Returns it as a string
        ///
        string result = "<" + responseDeclaration + ID + Response + TestNumber.ToString() + cardinality + Cardinality + baseType + "\"identifier\"" + ">";
        result += "<" + correctResponse + ">";
        foreach(uint i in correctAnswers){
            result += ("<" + valueID +">" + "\"" + ChoiceName + TestNumber.ToString() + i.ToString() + "\"<" + valueID +"/>");
        }
        result += "<" + correctResponse + "/>";
        result += "<"+responseDeclaration+cardinality+Cardinality+"/>";
        return result;
    }
    /// Response declaration is not yet implemented for MultipleChoice 
    public override string GetResponse() => throw new NotImplementedException("This feature is WIP :)");

    public MultipleChoice(Paragraph[] Text, Paragraph[] Options, uint[] correctAnswers, double points, Cardinalities card) : base(Text, Options, points){
        /// Constructor assigns all members : \n
        /// Text : question text, saved as an array of Paragraph
        /// Options : all possible answers, as a Paragraph each \n
        /// correctAnswers : indices of correct Answers, in an array  \n
        /// points : max. possible score for this question  \n
        /// Cardinality : Cardinality of this question  \n
        ///

        this.Cardinality = card==Cardinalities.multiple ? "multiple " : "single ";
        this.correctAnswers = correctAnswers; 
        foreach(uint correctAnswer in correctAnswers){
            if(Options.Length <= correctAnswer) throw new IndexOutOfRangeException("Correct Answer out of Option range!");
            }
    }

}

class SingleChoice : ChoiceQuestion{
    public override string Cardinality {get;} = "single";
    public uint correctAnswer;
    public override string GetResponseDeclaration(){
        ///Generates the "Response declaration" : declaration of a variable for the test answer \n
        /// Returns it as a string
        ///
        
        string result = "<" + responseDeclaration + ID + Response + TestNumber.ToString() + " " + cardinality + Cardinality + " " + baseType + "\"identifier\"" + ">";
        result += "<" + correctResponse + ">";
        result += "<" + valueID +">" + "\"" + ChoiceName + TestNumber.ToString() + correctAnswer + "\"<" + valueID +"/>";
        result += "<" + correctResponse + "/>";
        result += "<"+responseDeclaration+"/>";

        return result;
    }
    public override string GetResponse(){
        /// Generates the "Response processing" : the way an answer is being graded \n
        /// Returns Response processing procedure as string
        ///

        //local string definitions we only ever need here
        string condition = "qti-response-condition";
        string variable = "qti-variable";
        string correct = "qti-correct";
        string match = "match";
        string outcome = "qti-set-outcome-value";
        string response_if = "qti-response-if";


        //generate the evaluation for this question
        string specificID = ID + Response + TestNumber;
        string result = "<" + response_if + "><"+ match + ">";
        result += "<" + variable + specificID + "/>";
        result += "<" + correct + specificID + "/>";
        result += "<" + match + "/>";
        result += "<" + outcome  + ID + Score + TestNumber + ">";
        result += "<" + baseValue + baseType + "\"float\">" + Points.ToString(CultureInfo.InvariantCulture);
        result += "<" + outcome + "/><" + response_if + "/>";
        result += "<" + condition + "/>";

        return result;
    }
    public SingleChoice(Paragraph[] Text, Paragraph[] Options, uint correctAnswer, double points) : base(Text, Options, points){
        /// Constructor assigns all members : \n
        /// Text : question text, saved as an array of Paragraph
        /// Options : all possible answers, as a Paragraph each \n
        /// correctAnswer : index of the correct Answer \n
        /// points : max. possible score for this question  \n
        ///

        this.Cardinality = "single";
        this.correctAnswer = correctAnswer;
        if(Options.Length <= correctAnswer) throw new IndexOutOfRangeException("Correct Answer out of Option range!");
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
