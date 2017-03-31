namespace CG_A1.Core {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using Microsoft.Xna.Framework;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

/// <summary>Represents a camera</summary>
public class LookAtCamera : Camera {
    /*--------------------------------------
     * PUBLIC PROPERTIES
     *------------------------------------*/

    public Vector3 Target { get; set; }

    /*--------------------------------------
     * PUBLIC METHODS
     *------------------------------------*/

    public override Matrix ViewMatrix(){
        return Matrix.CreateLookAt(Position, Target, Up);
    }

}

}
