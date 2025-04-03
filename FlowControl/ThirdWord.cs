
using lex.Helpers;

namespace FlowControl;

internal class ThirdWord
{
    internal void Start()
    {
        Console.Clear();
        Console.WriteLine("Enter a sentence with at least 3 words");

        string sentence = Utils.PromptForString("Sentence", (x) => x.Split(' ').Length >= 3, "Input sentence is too short");
        
        string thirdWord = sentence.Split(' ')[2];

        Console.WriteLine($"The third word in your sentence is {thirdWord}!{Environment.NewLine}");

        Console.WriteLine($"{ConsoleMenuHelpers.PRESS_ANY_TO_RETURN}");

        Console.ReadKey();
    }
}