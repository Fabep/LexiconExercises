using lex.Helpers;

namespace FlowControl;

internal class Cinema
{
    private readonly Dictionary<int, string> _menu;
    private bool GoingToTheCinema;
    private string? PreviousAction;

    private List<Cinemagoer> CinemaGoers { get; set; }
    public Cinema()
    {
        _menu = new()
        {
            {1, "Add cinemagoer"},
            {2, "Calculate total"},
            {0, "Go back to main menu"},
        };
        CinemaGoers = [];
    }
    
    public void GoToCinema() 
    {
        GoingToTheCinema = true;
        do
        {
            Console.Clear();
            if (PreviousAction is not null)
                Console.WriteLine($"{PreviousAction}{Environment.NewLine}");
            ConsoleMenuHelpers.DisplayMenu(_menu);

            int option = Utils.PromptForInt("Option", _menu.ContainsKey, "Input is not a valid option.");

            Action action = HandleMenu(option);

            action();
        }
        while (GoingToTheCinema);
    }

    private Action HandleMenu(int option) =>
        option switch
        {
            1 => AddCinemagoer,
            2 => DisplayTotal,
            0 => () => { GoingToTheCinema = false; },
            _ => throw new ArgumentException($"Something went wrong when handling option: {option}"),
        };

    private void DisplayTotal()
    {
        int totalPrice = CinemaGoers.Sum(x => x.TicketPrice);


        PreviousAction = $"{CinemaGoers.Count} Tickets for a total price of {totalPrice} money units.";
    }

    private void AddCinemagoer()
    {
        int age = Utils.PromptForInt("Age", x => x >= 0, "");

        Cinemagoer cg = new()
        {
            Age = age,
        };

        CinemaGoers.Add(cg);

        PreviousAction = $"Added Cinemagoer with age: {age}";
    }
}