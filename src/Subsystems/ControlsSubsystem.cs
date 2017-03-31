namespace CG_A1.Subsystems {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


using Components.Input;
using Core;
using Components;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

/// <summary>Provides a subsystem for responding to controls..</summary>
public class ControlsSubsystem: Subsystem {
    public override void Update(float t, float dt) {
        base.Update(t, dt);

        var entities = Scene.GetEntities<CControls>();
        foreach (var entity in entities) {
            var controls = entity.GetComponent<CControls>();

            if (controls.Controls.ContainsKey("Up") && controls.Controls["Up"] != 0.0) {
                var model = entity.GetComponent<CModel>();
                model.Transform *= Matrix.CreateTranslation(0, 0, -dt*10);

            }
        }
    }
}

}
