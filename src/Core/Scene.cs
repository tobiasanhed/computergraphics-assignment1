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

    private List<Subsystem> m_Subsystems = new List<Subsystem>();
    private List<Entity>    m_Entities   = new List<Entity>();

    public virtual void Cleanup() {
    }

    public virtual void Draw(float t, float dt) {
        foreach (var subsystem in m_Subsystems) {
            subsystem.Draw(t, dt);
        }
    }

    public virtual void Init() {
    }

    public virtual void Update(float t, float dt) {
        foreach (var subsystem in m_Subsystems) {
            subsystem.Update(t, dt);
        }
    }

    public void AddSubsystem(Subsystem s){
        m_Subsystems.Add(s);
    }

    public void AddEntity(Entity e){
        m_Entities.Add(e);
    }

    public void RemoveEntity(Entity e){
        m_Entities.Remove(e);
    }
}

}
