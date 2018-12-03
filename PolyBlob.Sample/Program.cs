using System.Collections.Generic;
using System.Numerics;
using PolyBlob.Models;

namespace PolyBlob.Sample
{
    public class Program
    {
        public static void Main() {
            var world = new World {
                Scenes  = new List<Scene> {
                    new Scene {
                        Nodes = new List<Node> {
                            new Node {
                                Mesh = new Mesh {
                                    Primitives = new List<Primitive> {
                                        new Primitive {
                                            Points = new List<Vector3> {
                                                Vector3.Zero,
                                                Vector3.UnitX,
                                                Vector3.UnitY
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            
            var exporter = new GlTfExporter();
            exporter.SaveAs("simpleModel.gltf", world);
        }
    }
}
