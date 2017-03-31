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

public class MainScene : Scene {
    /*--------------------------------------
     * PUBLIC METHODS
     *------------------------------------*/

    public override void Init(){
    	AddSubsystems(new LogicSubsystem(),
                      new RenderingSubsystem());

        var chopper = new Entity();

        chopper.AddComponents(
            new ModelComponent {
                Model = Game1.Inst.Content.Load<Model>("Models/Chopper")
            },
            new LogicComponent {
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
