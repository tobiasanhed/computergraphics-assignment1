namespace CG_A1.Subsystems {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Components;
using Core;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

/// <summary>Represents a renderingsubsystem.</summary>
public class RenderingSubsystem : Subsystem {
    public Camera Camera { get; set; }

    public override void Draw(float t, float dt) {
        base.Draw(t, dt);

        Game1.Inst.GraphicsDevice.Clear(Color.CornflowerBlue);

        var entities = Scene.GetEntities<CModel>();

        foreach (var entity in entities) {
            var model = entity.GetComponent<CModel>();

            Matrix[] transforms = new Matrix[model.Model.Bones.Count];
            model.Model.CopyAbsoluteBoneTransformsTo(transforms);

            foreach(var mesh in model.Model.Meshes){
                foreach(BasicEffect effect in mesh.Effects){
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] * model.Transform;
                    effect.View = Camera.ViewMatrix();
                    effect.Projection = Camera.Projection;
                }
                mesh.Draw();
            }
        }
    }

    public override void Init() {
        Camera = new LookAtCamera();
        Camera.Position = new Vector3(-3, 5, 10);
    }
}

}
