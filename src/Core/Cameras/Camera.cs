namespace CG_A1.Core {

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

using Microsoft.Xna.Framework;

/// <summary>Represents a camera</summary>
public abstract class Camera {
    public Vector3 Up        { get; set; } = Vector3.Up;
    public Vector3 Position  { get; set; }
    public Matrix Projection { get; set; } = Matrix.CreatePerspectiveFieldOfView(
                                                MathHelper.ToRadians(45.0f),
                                                1.6f, 1.0f, 1000.0f);
    
    public abstract Matrix ViewMatrix();

}

}
