namespace CG_A1.Components {

/*--------------------------------------
 * USINSG
 *------------------------------------*/

using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

using Core;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

/// <summary>Contains state information about a model.</summary>
public class CModel : Component {
    /*--------------------------------------
     * PUBLIC PROPERTIES
     *------------------------------------*/

    /// <summary>Gets or sets the model.</summary>
    public Model Model { get; set; }

    /// <summary>Gets or sets the model transform.</summary>
    public Matrix Transform { get; set; }
}

}
