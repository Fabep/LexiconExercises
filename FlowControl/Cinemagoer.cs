namespace FlowControl;

internal class Cinemagoer
{
    internal int Age { get; set; }
    internal int TicketPrice 
    {
        get => Age switch
        {
            > 100 or < 5 => 0,
            < 20 => 80,
            > 64 => 90,
            _ => 120,
        };
    }

}