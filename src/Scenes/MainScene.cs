namespace CG_A1.Scenes {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using Microsoft.Xna.Framework;
using Subsystems;

using Core;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

public class MainScene : Scene {
    /*--------------------------------------
     * PUBLIC METHODS
     *------------------------------------*/

	public override void Init(){    	
    	AddSubsystem(new RenderingSubsystem());

    	base.Init();
    }

	public override void Cleanup(){
        
        base.Cleanup();
    }
}

}
