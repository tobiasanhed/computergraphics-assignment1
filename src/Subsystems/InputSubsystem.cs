namespace CG_A1.Subsystems {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using Microsoft.Xna.Framework.Input;

using Components.Input;
using Core;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

/// <summary>Provides a subsystem for handling input.</summary>
public class InputSubsystem: Subsystem {
    public override void Draw(float t, float dt) {
        base.Draw(t, dt);

        var kb = Keyboard.GetState();

        var entities = Scene.GetEntities<CInput>();
        foreach (var entity in entities) {
            var input = entity.GetComponent<CInput>();

            input.ResetControls?.Invoke();

            foreach (var e in input.KeyMap) {
                if (!kb.IsKeyDown(e.Key)) {
                    continue;
                }

                e.Value();
            }
        }
    }
}

}
