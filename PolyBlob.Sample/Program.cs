using System.Collections.Generic;
using PolyBlob.Models;
using PolyBlob.Sample.Vehicle;

namespace PolyBlob.Sample
{
    public class Program
    {
        public static void Main() {
            var world = new World {
                Scenes  = new List<Scene> {
                    new Scene {
                        Nodes = new List<Node> {
                            new CarNode()
                        }
                    }
                }
            };
            
            var exporter = new GlTfExporter();
            exporter.SaveAs("car.gltf", world);
        }
    }
}
