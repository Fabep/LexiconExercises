
using lex.Helpers;

namespace FlowControl;

internal class ThirdWord
{
    internal void Start()
    {
        Console.Clear();
        Console.WriteLine("Enter a sentence with at least 3 words");
        bool finished = false;
        string? thirdWord = null;
        do
        {
            string sentence = Utils.PromptForString("Sentence", (x) => x.Split(' ').Length >= 3, "Input sentence is too short");

            string[] arr = sentence.Split(' ');

            int index = 2;
            while (thirdWord is null && index < arr.Length)
            {
                string temp = arr[index];

                if (string.IsNullOrWhiteSpace(temp))
                {
                    index++;
                    continue;
                }

                thirdWord = arr[index];
                finished = true;
                break;
            }

            if (!finished)
                Console.WriteLine("Invalid input. Input sentence is too short.");

        }
        while (!finished);

        Console.WriteLine($"The third word in your sentence is {thirdWord}!{Environment.NewLine}");

        Console.WriteLine($"{ConsoleMenuHelpers.PRESS_ANY_TO_RETURN}");

        Console.ReadKey();
    }
}