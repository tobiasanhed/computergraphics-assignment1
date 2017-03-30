namespace CG_A1 {

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Core;

public class Game1 : Game {

    public GraphicsDeviceManager Graphics { get; }
    public static Game1 Inst { get; private set; }

    private Scene m_Scene;

    public Game1(Scene scene) {
        Inst = this;

        Graphics = new GraphicsDeviceManager(this);

        Content.RootDirectory = "Content";

        EnterScene(scene);
    }

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

    protected override void Draw(GameTime gameTime) {
        if (m_Scene != null) {
            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float t  = (float)gameTime.TotalGameTime.TotalSeconds;
            m_Scene.Draw(t, dt);
        }

        base.Draw(gameTime);
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
