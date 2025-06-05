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
            Console.WriteLine(e.Message);
        }
    }
}