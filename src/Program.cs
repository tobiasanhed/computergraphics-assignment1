namespace CG_A1 {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using System;

using Scenes;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

public static class Program {

    /*--------------------------------------
     * PRIVATE METHODS
     *------------------------------------*/

    [STAThread]
    private static void Main(string[] args) {
        using (var game = new Game1()) {
            game.Run(new MainScene());
        }
    }
}

}
