namespace CG_A1.Scenes {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using Microsoft.Xna.Framework;

using Core;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

public class MainScene : Scene {
    /*--------------------------------------
     * PUBLIC METHODS
     *------------------------------------*/

    public override void Draw(float t, float dt) {
        // TODO: Draw logic should not be done here.
        Game1.Inst.GraphicsDevice.Clear(Color.CornflowerBlue);

        base.Draw(t, dt);
    }
}

}
