namespace CG_A1.Components {

/*--------------------------------------
 * CLASSES
 *------------------------------------*/
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

/// <summary>Represents a model</summary>
public abstract class ModelComponent {
    public Model Model { get; set; }

    public Matrix Transform { get; set; }
}

}
