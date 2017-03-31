namespace CG_A1.Core {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading;

using Microsoft.Xna.Framework;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

/// <summary>Represents the base class for a single subsytem.</summary>
public abstract class Subsystem {
    /*--------------------------------------
     * PUBLIC METHODS
     *------------------------------------*/

    /// <summary>Performs draw logic specified to the subsystem.</summary>
    /// <param name="gameTime">The game time to take into consideration when
    ///                        performing draw logic.</param>
    public virtual void Draw(GameTime gameTime) {
    }

    /// <summary>Performs update logic specified to the subsystem.</summary>
    /// <param name="gameTime">The game time to take into consideration when
    ///                        performing update logic.</param>
    public virtual void Update(GameTime gameTime) {
    }
}

}
