using lex.Helpers;

namespace FlowControl;

class App
{
    private readonly Dictionary<int, string> _menu;
    private readonly Cinema _cinema;
    private readonly ThirdWord _thirdWord;
    private bool isAlive;
    public App(Cinema cinema, ThirdWord thirdWord)
    {
        _menu = new()
        {
            { 1, "Go to the cinema" },
            { 2, "Input Repeater" },
            { 3, "Third Word" },
            { 0, "Exit" },
        };
        _cinema = cinema;
        _thirdWord = thirdWord;
    }
    public void Run()
    {

        isAlive = true;
        do
        {
            Console.Clear();
            ConsoleMenuHelpers.DisplayMenu(_menu);

            int option = Utils.PromptForInt("Option", _menu.ContainsKey, "Input is not a valid menu option");

            Action action = HandleMenu(option);

            action();
        }
        while (isAlive);
    }

    public Action HandleMenu(int option) =>
        option switch
        {
            1 => _cinema.GoToCinema,
            2 => Repeater.InputRepeater,
            3 => _thirdWord.Start,
            0 => () => { isAlive = false; },
            _ => throw new Exception(),
        };
}
