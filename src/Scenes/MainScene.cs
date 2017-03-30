namespace CG_A1.Scenes {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using Microsoft.Xna.Framework;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

public class MainScene : Scene {
    /*--------------------------------------
     * PUBLIC METHODS
     *------------------------------------*/

    public override void Draw(float t, float dt) {
        Game1.Inst.GraphicsDevice.Clear(Color.CornflowerBlue);
    }
}

}
