namespace CG_A1.Scenes {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Components;
using Components.Input;
using Core;
using Subsystems;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

public class MainScene: Scene {
    /*--------------------------------------
     * PUBLIC METHODS
     *------------------------------------*/

    /// <summary>Performs initialization logic.</summary>
    public override void Init() {
    	AddSubsystems(new  ControlsSubsystem(),
                      new     InputSubsystem(),
                      new     LogicSubsystem(),
                      new RenderingSubsystem());

        var chopper = new Entity();

        var model = Game1.Inst.Content.Load<Model>("Models/Chopper");

        // TODO: This is crap.
        CModel modmod;
        var cntrls = new CControls { };
        var controls = cntrls.Controls;
        chopper.AddComponents(
            modmod = new CModel {
                Model = model
            },

            cntrls,

            new CInput {
                KeyMap = {
                    { Keys.Up, () => {
                          controls["Up"] = 1.0f;
                    } }
                },
                ResetControls = () => {
                    controls["Up"] = 0.0f;
                }
            },

            new CLogic {
                UpdateFunc = (t, dt) => {
                    System.Console.WriteLine("LOL", t);
                }
            });

        AddEntity(chopper);

    	base.Init();
    }
}

}
