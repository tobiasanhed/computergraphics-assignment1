namespace CG_A1.Core {

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

using Microsoft.Xna.Framework;

/// <summary>Represents a camera</summary>
public abstract class Camera {
    public Matrix Projection { get; set; }

    public Matrix View { get; set; }
}

}
