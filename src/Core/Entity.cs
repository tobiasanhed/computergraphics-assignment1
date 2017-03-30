namespace CG_A1 {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using System.Threading;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

/// <summary>Represents a single entity.</summary>
public sealed class Entity {
    public int ID { get; }

    private static int s_ID = 1;

    public Entity() {
        ID = Interlocked.Increment(ref s_ID);
    }
}

}
