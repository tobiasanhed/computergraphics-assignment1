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

	public override void Init(){
		Game1.Inst.Content.Load<Model>("Models/Chopper");
	}

	public override void Draw(float t, float dt){
		base.Draw(t, dt);

		Game1.Inst.GraphicsDevice.Clear(Color.CornflowerBlue);
	}
}


}
