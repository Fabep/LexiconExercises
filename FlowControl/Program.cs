using FlowControl;

Cinema cinema = new();
ThirdWord thirdWord = new();

App app = new(cinema, thirdWord);

app.Run();