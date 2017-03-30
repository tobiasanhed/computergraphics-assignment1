namespace CG_A1 {

using System;

public static class Program {
    [STAThread]
    private static void Main(string[] args) {
        using (var game = new Game1()) {
            game.Run();
        }
    }
}

}
