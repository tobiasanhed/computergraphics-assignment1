namespace CG_A1.Subsystems {

/*--------------------------------------
 * CLASSES
 *------------------------------------*/
using Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>Represents a renderingsubsystem.</summary>
public  class RenderingSubsystem : Subsystem {
    public Camera Camera { get; set; }
    private Model model;

    public override void Draw(float t, float dt) {
        base.Draw(t, dt);

        Game1.Inst.GraphicsDevice.Clear(Color.CornflowerBlue);

        Matrix[] transforms = new Matrix[model.Bones.Count];
        model.CopyAbsoluteBoneTransformsTo(transforms);

        foreach(var mesh in model.Meshes){
            foreach(BasicEffect effect in mesh.Effects){
                effect.EnableDefaultLighting();
                effect.World = transforms[mesh.ParentBone.Index];
                effect.View = Camera.ViewMatrix();
                effect.Projection = Camera.Projection;
            }
            mesh.Draw();
        }
    }

    public override void Init() {
        model = Game1.Inst.Content.Load<Model>("Models/Chopper");
        Camera = new LookAtCamera();
        Camera.Position = new Vector3(-3, 5, 10);
    }
}

}
