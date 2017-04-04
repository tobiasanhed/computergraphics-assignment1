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
    	AddSubsystems(new      BodySubsystem(),
                      new  ControlsSubsystem(),
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
            new CBody {},
            modmod = new CModel {
                Model = model
            },

            cntrls,

            new CInput {
                KeyMap = {
                    { Keys.Up, () => {
                          controls["Up"] = 1.0f;
                      } },
                    { Keys.Down, () => {
                          controls["Up"] = -1.0f;
                      } },
                    { Keys.Left, () => {
                          controls["Turn"] = -1.0f;
                      } },
                    { Keys.Right, () => {
                          controls["Turn"] = 1.0f;
                      } }
                },
                ResetControls = () => {
                    controls["Up"] = 0.0f;
                    controls["Turn"] = 0.0f;
                }
            },

            new CLogic {
                UpdateFunc = (t, dt) => {
                    // TODO: Spin propellah
                    //System.Console.WriteLine("LOL", t);
                }
            });

        AddEntity(chopper);

        LoadHeightmap();

    	base.Init();
    }

    private VertexPositionNormalTexture CreateHeightmapVertex(Color[] pixels, int width, int height, int i, int j) {
        var index = i + j*width;
        var color = pixels[index];

        var x = (float)i / (float)width  - 0.5f;
        var y = (float)j / (float)height - 0.5f;
        var z = color.R / 255.0f         - 0.5f + 0.7f;

        //System.Console.WriteLine("{0}, {1} {2}", x, y, z);

        var ss = 9.0f;
        return new VertexPositionNormalTexture {
            Position = new Vector3(ss*20.0f*x, ss*-4.0f*z, ss*20.0f*y),
        };
    }

    private void LoadHeightmap() {
        var heightmap = Game1.Inst.Content.Load<Texture2D>("Textures/US_Canyon");

        var pixels = new Color[heightmap.Width*heightmap.Height];
        heightmap.GetData<Color>(pixels);

        var indices = new List<int>();
        var vertices = new List<VertexPositionNormalTexture>();

        var k = (int)0;
        var q = 8;
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
                //vertices.Add(v0);
                //vertices.Add(v2);
                vertices.Add(v3);

                int a = k++;
                int b = k++;
                int c = k++;
                int d = k++;
                indices.Add(a);
                indices.Add(b);
                indices.Add(c);
                indices.Add(a);
                indices.Add(c);
                indices.Add(d);
            }
        }

        for(int i = 0; i < indices.Count - 2; i += 3){
            var a = indices[i];
            var b = indices[i+1];
            var c = indices[i+2];
            var N = Vector3.Cross(vertices[b].Position - vertices[a].Position, vertices[c].Position - vertices[a].Position);

            vertices[a]   = new VertexPositionNormalTexture { Position = vertices[a].Position, Normal = vertices[a].Normal + N };
            vertices[b] = new VertexPositionNormalTexture { Position = vertices[b].Position, Normal = vertices[b].Normal + N };
            vertices[c] = new VertexPositionNormalTexture { Position = vertices[c].Position, Normal = vertices[c].Normal + N };
            //vertices[i + 1].Normal += N;
            //vertices[i + 2].Normal += N;
        }
        
        for(int i = 0; i < vertices.Count; i++) { 
            var N = vertices[i].Normal;
            if (N.Length () > 0.0)
            N.Normalize();  
            vertices[i] = new VertexPositionNormalTexture { Position = vertices[i].Position, Normal = N };
        }

        VertexBuffer vb = new VertexBuffer(Game1.Inst.GraphicsDevice, typeof (VertexPositionNormalTexture), vertices.Count, BufferUsage.WriteOnly);
        vb.SetData<VertexPositionNormalTexture>(vertices.ToArray());
        IndexBuffer ib = new IndexBuffer(Game1.Inst.GraphicsDevice, typeof (int), indices.Count, BufferUsage.WriteOnly);
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
