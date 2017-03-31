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

    /// <summary>Gets the entity ID.</summary>
    public int ID { get; }
    public Scene Scene { get; set; };

    /*--------------------------------------
     * PRIVATE FIELDS
     *------------------------------------*/

    private readonly Dictionary<Type, Component> m_Components =
        new Dictionary<Type, Component>();

    private static int s_ID = 1;

    /*--------------------------------------
     * CONSTRUCTOR
     *------------------------------------*/

    /// <summary>Creates a new <see cref="Entity"/> instance.</summary>
    public Entity() {
        ID = Interlocked.Increment(ref s_ID);
    }

    /*--------------------------------------
     * PUBLIC METHODS
     *------------------------------------*/

    /// <summary>Adds the specified component to the entity.</summary>
    /// <param name="component">The component to add to the entity.</param>
    public void AddComponent<T>(T component) where T : Component {
        m_Components.Add(typeof (T), component);
    }

    /// <summary>Destroys the entity by removing it from the scene.</summary>
    public void Destroy() {
        Scene.RemoveEntity(this);
    }

    /// <summary>Gets the entity component of the specified type.</summary>
    public T GetComponent<T>() where T : Component {
        return (T)m_Components[typeof (T)];
    }

    /// <summary>Checks whether the entity has a component of the specified
    ///          type.</summary>
    /// <returns><see langword="true"/> if the entity has a component of the
    ///          specified type.</returns>
    public bool HasComponent<T>() where T : Component {
        return m_Components.ContainsKey(typeof (T));
    }
}

}
