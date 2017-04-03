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
public class RenderingSubsystem: Subsystem {
    /*--------------------------------------
     * PUBLIC PROPERTIES
     *------------------------------------*/

    /// <summary>Gets or sets the camera used to draw the world.</summary>
    public Camera Camera { get; set; }

    /*--------------------------------------
     * PUBLIC METHODS
     *------------------------------------*/

    private BasicEffect bEffect = new BasicEffect(Game1.Inst.GraphicsDevice);

    /// <summary>Performs draw logic specific to the subsystem.</summary>
    /// <param name="t">The total game time, in seconds.</param>
    /// <param name="dt">The elapsed time since last call, in seconds.</param>
    public override void Draw(float t, float dt) {
        base.Draw(t, dt);

        Game1.Inst.GraphicsDevice.Clear(Color.CornflowerBlue);


        foreach (var entity in Scene.GetEntities<CModel>()) {
            var model = entity.GetComponent<CModel>();
            var m = model.Transform;
            ((LookAtCamera)Camera).Target = new Vector3(m.M41, m.M42, m.M43);


            Matrix[] transforms = new Matrix[model.Model.Bones.Count];
            model.Model.CopyAbsoluteBoneTransformsTo(transforms);

            foreach (var mesh in model.Model.Meshes) {
                foreach (BasicEffect effect in mesh.Effects) {
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index] * model.Transform;
                    effect.View = Camera.ViewMatrix();
                    effect.Projection = Camera.Projection;
                }

                mesh.Draw();
            }
        }

        foreach (var entity in Scene.GetEntities<CHeightmap>()) {
            var heightmap = entity.GetComponent<CHeightmap>();

            Game1.Inst.GraphicsDevice.SetVertexBuffer(heightmap.VertexBuffer);
            Game1.Inst.GraphicsDevice.Indices = heightmap.IndexBuffer;

            //bEffect.EnableDefaultLighting();
            bEffect.LightingEnabled = false;
            bEffect.VertexColorEnabled = true;
            bEffect.World = heightmap.Transform;
            bEffect.View = Camera.ViewMatrix();
            bEffect.Projection = Camera.Projection;

            foreach (var pass in bEffect.CurrentTechnique.Passes) {
                pass.Apply();
                Game1.Inst.GraphicsDevice.DrawIndexedPrimitives(PrimitiveType.TriangleList, 0, 0, heightmap.NumTriangles);
            }
        }
    }

    /// <summary>Performs initialization logic.</summary>
    public override void Init() {
        // Create a default camera.
        Camera = new LookAtCamera {
            Position = new Vector3(0, 12, 8)
        };
    }
}

}
