namespace CG_A1.Scenes {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Components;
using Core;
using Subsystems;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

public class MainScene: Scene {
    /*--------------------------------------
     * PUBLIC METHODS
     *------------------------------------*/

    public override void Init(){
    	AddSubsystems(new LogicSubsystem(),
                      new RenderingSubsystem());

        var chopper = new Entity();

        var model = Game1.Inst.Content.Load<Model>("Models/Chopper");

        chopper.AddComponents(
            new CModel {
                Model = model
            },
            new CLogic {
                UpdateFunc = (t, dt) => {
                    System.Console.WriteLine("LOL", t);
                }
            });

        AddEntity(chopper);

    	base.Init();
    }

    public override void Cleanup(){
        base.Cleanup();
    }
}

}
