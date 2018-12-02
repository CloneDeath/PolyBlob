using System.IO;
using Newtonsoft.Json;
using PolyBlob.glTF;

namespace PolyBlob.Sample
{
    public class Program
    {
        public static void Main() {
            var world = new World {
                Scenes = new [] {
                    new Scene {
                        Nodes = new[]{0}
                    }
                },
                Nodes = new [] {
                    new Node {
                        Mesh = 0
                    }
                },
                Meshes = new [] {
                    new Mesh {
                        Primitives = new [] {
                            new Primitive {
                                Attributes = new Attributes {
                                    Position = 1
                                },
                                Indices = 0
                            }
                        }
                    }
                },
                Buffers = new[] {
                    new Buffer {
                        Uri = "data:application/octet-stream;base64,AAABAAIAAAAAAAAAAAAAAAAAAAAAAIA/AAAAAAAAAAAAAAAAAACAPwAAAAA=",
                        ByteLength = 44
                    }
                },
                BufferViews = new[] {
                    new BufferView {
                        Buffer = 0,
                        ByteOffset = 0,
                        ByteLength = 6,
                        Target = BufferViewTarget.ElementArrayBuffer
                    },
                    new BufferView {
                        Buffer = 0,
                        ByteOffset = 8,
                        ByteLength = 36,
                        Target = BufferViewTarget.ArrayBuffer
                    }
                },
                Accessors = new [] {
                    new Accessor {
                        BufferView = 0,
                        ByteOffset = 0,
                        ComponentType = AccessorComponentType.UnsignedShort,
                        Count = 3,
                        Type = AccessorType.SCALAR,
                        Max = new[]{2f},
                        Min = new[]{0f}
                    },
                    new Accessor {
                        BufferView = 1,
                        ByteOffset = 0,
                        ComponentType = AccessorComponentType.Float,
                        Count = 3,
                        Type = AccessorType.VEC3,
                        Max = new[]{1.0f, 1.0f, 0.0f},
                        Min = new[]{0.0f, 0.0f, 0.0f}
                    }
                }
            };

            var data = JsonConvert.SerializeObject(world, Formatting.Indented);
            File.WriteAllText("polyBlobTest.gltf", data);
        }
    }
}
