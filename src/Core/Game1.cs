namespace CG_A1 {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Core;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

public class Game1 : Game {
    /*--------------------------------------
     * PUBLIC PROPERTIES
     *------------------------------------*/

    public GraphicsDeviceManager Graphics { get; }

    /// <summary>Gets the <see cref="Game1"/> singleton instance.</summary>
    public static Game1 Inst { get; private set; }

    /*--------------------------------------
     * PRIVATE FIELDS
     *------------------------------------*/

    private Scene m_Scene;

    /*--------------------------------------
     * CONSTRUCTORS
     *------------------------------------*/

    public Game1() {
        Inst = this;

        Graphics = new GraphicsDeviceManager(this);
    }

    /*--------------------------------------
     * PUBLIC METHODS
     *------------------------------------*/

    public void EnterScene(Scene scene) {
        scene.ParentScene = m_Scene;
        m_Scene = scene;
        m_Scene.Init();
    }

    public void LeaveScene() {
        if (m_Scene != null) {
            m_Scene.Cleanup();
            m_Scene = m_Scene.ParentScene;
        }
    }

    public void Run(Scene scene) {
        EnterScene(scene);

        Run();
    }

    /*--------------------------------------
     * PROTECTED METHODS
     *------------------------------------*/

    protected override void Draw(GameTime gameTime) {
        if (m_Scene != null) {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float t  = (float)gameTime.TotalGameTime.TotalSeconds;
            m_Scene.Draw(t, dt);
        }

        base.Draw(gameTime);
    }

    protected override void Initialize() {
        base.Initialize();

        Content.RootDirectory = "Content";
        Window.Title = "Computer Graphics - Assignment 1";
    }

    protected override void Update(GameTime gameTime) {
        if (m_Scene != null) {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float t  = (float)gameTime.TotalGameTime.TotalSeconds;
            m_Scene.Update(t, dt);
        }

        base.Update(gameTime);
    }
}

}
