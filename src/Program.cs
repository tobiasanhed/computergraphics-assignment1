namespace CG_A1 {

using System;

using Scenes;

public static class Program {
    [STAThread]
    private static void Main(string[] args) {
        using (var game = new Game1(new MainScene())) {
            game.Run();
        }
    }
}

}
