namespace CG_A1.Core {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using System;
using System.Collections.Generic;
using System.Threading;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

/// <summary>Represents a single entity.</summary>
public sealed class Entity {
    /*--------------------------------------
     * PUBLIC PROPERTIES
     *------------------------------------*/

    public int ID { get; }

    /*--------------------------------------
     * PRIVATE FIELDS
     *------------------------------------*/

    private readonly Dictionary<Type, Component> m_Components =
        new Dictionary<Type, Component>();

    private static int s_ID = 1;

    /*--------------------------------------
     * CONSTRUCTOR
     *------------------------------------*/

    public Entity() {
        ID = Interlocked.Increment(ref s_ID);
    }

    /*--------------------------------------
     * PUBLIC METHODS
     *------------------------------------*/

    public void AddComponent<T>(T component) where T : Component {
        m_Components.Add(typeof (T), component);
    }

    public void Destroy() {
        throw new System.NotImplementedException();
    }

    public T GetComponent<T>() where T : Component {
        return (T)m_Components[typeof (T)];
    }

    public bool HasComponent<T>() where T : Component {
        return m_Components.ContainsKey(typeof (T));
    }
}

}
