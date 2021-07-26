/** @example StringToQti.cs
 * Demonstrates the conversion of a plain fString to QTI formatted text 
 **/

using System;

class StringConversion{
    static void StringToQti(){
        // Create a new fString with some FormatFlags
        var example = new fString("Hello World!");
        example.AddFormat(FormatFlags.bold);
        example.AddFormat(FormatFlags.italic);
        example.TextColor = "red";

        // Write corresponding QTI Text to Console
        Console.WriteLine(example.ToQti());

        // Output:
        //<span style="color: #ff0000;"><strong><em>Hello World!</em></strong></span>
    }
}