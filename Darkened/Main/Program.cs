using Darkened.Data;

namespace Darkened.Main;

public static class Program
{
    public static void Main()
    {
        try
        {
            var game = new Game();
            game.Run();
        }
        catch (Exception e)
        {
            Logger.Instance?.Log(e.Message);
            Console.WriteLine(e.Message);
        }
    }
}