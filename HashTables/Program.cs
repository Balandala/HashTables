using HashTables.Interface;

namespace Program;

public static class Program
{
    static void Main(string[] args)
    {
        View<int, int> view = new();
        view.MakeView(); 
    }
}
