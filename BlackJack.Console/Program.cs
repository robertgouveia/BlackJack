using BlackJack.Business.Managers;
using BlackJack.Console;

var gm = new GameManager(new GameConfiguration(3, 1), new Logger(), new Input());