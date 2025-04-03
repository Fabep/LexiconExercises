using lex.Helpers;

namespace FlowControl;

class Repeater
{
    public static void InputRepeater()
    {
        string input = Utils.PromptForString("Input");
        Console.Clear();
        for (int i = 0; i < 10; i++)
        {
            Console.Write(input);
        }


        Console.WriteLine($"{Environment.NewLine}{Environment.NewLine}{ConsoleMenuHelpers.PRESS_ANY_TO_RETURN}");
        Console.ReadKey();
    }
}
