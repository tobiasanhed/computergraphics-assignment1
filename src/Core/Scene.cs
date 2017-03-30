namespace CG_A1 {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using System.Threading;
using System.Collections.Generic;

using Core;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

/// <summary>Represents a single scene.</summary>
public abstract class Scene {
    public Scene ParentScene { get; set; }

    private List<Subsystem> subsystems = new List<Subsystem>();
    private List<Entity> entities      = new List<Entity>();

    public virtual void Cleanup() {
    }

    public virtual void Draw(float t, float dt) {
        foreach (var subsystem in subsystems) {
            subsystem.Draw(t, dt);
        }
    }

    public virtual void Init() {
    }

    public virtual void Update(float t, float dt) {
        foreach (var subsystem in subsystems) {
            subsystem.Update(t, dt);
        }
    }

    public void AddSubsystem(Subsystem s){
        subsystems.Add(s);
    }

    public void AddEntity(Entity e){
        entities.Add(e);
    }

    public void RemoveEntity(Entity e){
        entities.Remove(e);
    }
}

}
