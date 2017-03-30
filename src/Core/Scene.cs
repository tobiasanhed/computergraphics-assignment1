namespace CG_A1 {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using System.Threading;
using System.Collections.Generic;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

/// <summary>Represents a single scene.</summary>
public abstract class Scene {
    private List<Subsystem> subsystems = new List<Subsystem>();
    private List<Entity> entities      = new List<Entity>();

    public virtual void Init(){ }
    
    public virtual void CleanUp() { }

    public void AddSubsystem(Subsystem s){
        subsystems.Add(s);
    }

    public void AddEntity(int id, Entity e){
        entities.Add(id, e);
        e.Scene = this;
    }

    public void RemoveEntity(Entity e){
        entities.Remove(e);
        e.Scene = null;
    }
}

}
