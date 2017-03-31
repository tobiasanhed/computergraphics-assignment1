namespace CG_A1.Subsystems {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Components;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

/// <summary>Represents a renderingsubsystem.</summary>
public class LogicSubsystem: Subsystem {
    public override void Update(float t, float dt) {
        var entities = Scene.GetEntities<CLogic>();

        foreach (var entity in entities) {
            var logic = entity.GetComponent<CLogic>();

            var timer = logic.UpdateTimer + dt;

            var invUpdateRate = logic.InvUpdateRate;
            while (timer > invUpdateRate) {
                logic.UpdateFunc(t, dt);
                timer -= invUpdateRate;
            }

            logic.UpdateTimer = timer;
        }
    }
}

}
