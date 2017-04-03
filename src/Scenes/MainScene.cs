namespace CG_A1.Scenes {

/*--------------------------------------
 * USINGS
 *------------------------------------*/

using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Components;
using Components.Input;
using Core;
using Subsystems;

/*--------------------------------------
 * CLASSES
 *------------------------------------*/

public class MainScene: Scene {
    /*--------------------------------------
     * PUBLIC METHODS
     *------------------------------------*/

    /// <summary>Performs initialization logic.</summary>
    public override void Init() {
    	AddSubsystems(new  ControlsSubsystem(),
                      new     InputSubsystem(),
                      new     LogicSubsystem(),
                      new RenderingSubsystem());

        var chopper = new Entity();

        var model = Game1.Inst.Content.Load<Model>("Models/Chopper");

        // TODO: This is crap.
        CModel modmod;
        var cntrls = new CControls { };
        var controls = cntrls.Controls;
        chopper.AddComponents(
            modmod = new CModel {
                Model = model
            },

            cntrls,

            new CInput {
                KeyMap = {
                    { Keys.Up, () => {
                          controls["Up"] = 1.0f;
                    } }, { Keys.Down, () => {
                          controls["Up"] = -1.0f;
                    } }
                },
                ResetControls = () => {
                    controls["Up"] = 0.0f;
                }
            },

            new CLogic {
                UpdateFunc = (t, dt) => {
                    System.Console.WriteLine("LOL", t);
                }
            });

        AddEntity(chopper);

        LoadHeightmap();

    	base.Init();
    }

    private VertexPositionColor CreateHeightmapVertex(Color[] pixels, int width, int height, int i, int j) {
        var index = i + j*width;
        var color = pixels[index];

        var x = (float)i / (float)width  - 0.5f;
        var y = (float)j / (float)height - 0.5f;
        var z = color.R / 255.0f         - 0.5f;

        //System.Console.WriteLine("{0}, {1} {2}", x, y, z);

        var ss = 1.0f;
        return new VertexPositionColor {
            Position = new Vector3(ss*20.0f*x, ss*-4.0f*z, ss*20.0f*y),
            Color = color
        };
    }

    private void LoadHeightmap() {
        var heightmap = Game1.Inst.Content.Load<Texture2D>("Textures/paga2");

        var pixels = new Color[heightmap.Width*heightmap.Height];
        heightmap.GetData<Color>(pixels);

        var indices = new List<short>();
        var vertices = new List<VertexPositionColor>();

        var k = (short)0;
        var q = 10;
        for (var j = 0; j < heightmap.Height-q; j += q) {
            for (var i = 0; i < heightmap.Width-q; i += q) {
                // skapa triangel med index 0, 1, 2
                var v0 = CreateHeightmapVertex(pixels, heightmap.Width, heightmap.Height, i, j);
                var v1 = CreateHeightmapVertex(pixels, heightmap.Width, heightmap.Height, i+q, j);
                var v2 = CreateHeightmapVertex(pixels, heightmap.Width, heightmap.Height, i+q, j+q);
                var v3 = CreateHeightmapVertex(pixels, heightmap.Width, heightmap.Height, i, j+q);

                vertices.Add(v0);
                vertices.Add(v1);
                vertices.Add(v2);
                vertices.Add(v0);
                vertices.Add(v2);
                vertices.Add(v3);

                indices.Add(k++);
                indices.Add(k++);
                indices.Add(k++);
                indices.Add(k++);
                indices.Add(k++);
                indices.Add(k++);
            }
        }

        VertexBuffer vb = new VertexBuffer(Game1.Inst.GraphicsDevice, typeof (VertexPositionColor), vertices.Count, BufferUsage.WriteOnly);
        vb.SetData<VertexPositionColor>(vertices.ToArray());
        IndexBuffer ib = new IndexBuffer(Game1.Inst.GraphicsDevice, typeof (short), indices.Count, BufferUsage.WriteOnly);
        ib.SetData(indices.ToArray());

        heightmap.Dispose();

        var cmp = new CHeightmap {
            VertexBuffer = vb,
            IndexBuffer = ib,
            NumVertices = vertices.Count,
            NumTriangles = indices.Count
        };

        var e = new Entity();
        e.AddComponents(cmp);

        AddEntity(e);
    }
}

}
