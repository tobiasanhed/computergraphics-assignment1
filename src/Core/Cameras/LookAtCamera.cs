namespace CG_A1.Core {

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

using Microsoft.Xna.Framework;

/// <summary>Represents a camera</summary>
public class LookAtCamera : Camera {
    public Vector3 Target { get; set; }

    public override Matrix ViewMatrix(){
        return Matrix.CreateLookAt(Position, Target, Up); 
    }

}

}
