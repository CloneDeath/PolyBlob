using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using PolyBlob.glTF;
using Mesh = PolyBlob.Models.Mesh;
using Node = PolyBlob.Models.Node;
using Primitive = PolyBlob.Models.Primitive;
using Scene = PolyBlob.Models.Scene;
using World = PolyBlob.Models.World;

namespace PolyBlob {
	public class GlTfFactory {
		private GlTfCache _glTfCache = new GlTfCache();
		private readonly WorldCache _worldCache;
		private readonly World _world;

		public GlTfFactory(World world) {
			_world = world;
			_worldCache = new WorldCache(world);
		}

		public glTF.World GetWorld() {
			_glTfCache = new GlTfCache();
			return new glTF.World {
				Scenes = GetScenes(_world.Scenes),
				Nodes = GetNodes(_worldCache.Nodes),
				Meshes = GetMeshes(_worldCache.Meshes),
				Buffers = GetResourcesInOrder(_glTfCache.Buffers),
				BufferViews = GetResourcesInOrder(_glTfCache.BufferViews),
				Accessors = GetResourcesInOrder(_glTfCache.Accessors)
			};
		}

		public glTF.Scene[] GetScenes(IEnumerable<Scene> scenes) => scenes.Select(Translate).ToArray();

		private glTF.Scene Translate(Scene scene) {
			return new glTF.Scene {
				Name = scene.Name,
				Nodes = GetNodeIndexes(scene.Nodes)
			};
		}

		private int[] GetNodeIndexes(List<Node> sceneNodes) {
			return sceneNodes.Any() ? sceneNodes.Select(n => _worldCache.Nodes.GetId(n)).ToArray() : null;
		}

		private glTF.Node[] GetNodes(IndexedResourceCollection<Node> nodes) {
			var results = new glTF.Node[nodes.Count];
			foreach (var node in nodes) {
				results[node.Id] = Translate(node.Resource);
			}
			return results;
		}

		private glTF.Node Translate(Node node) {
			return new glTF.Node {
				Name = node.Name,
				Children = GetNodeIndexes(node.Children),
				Mesh = node.Mesh == null ? (int?)null : _worldCache.Meshes.GetId(node.Mesh),
				Translation = node.Position == Vector3.Zero ? null : new[] {
					node.Position.X,
					node.Position.Y,
					node.Position.Z
				}
			};
		}

		private glTF.Mesh[] GetMeshes(IndexedResourceCollection<Mesh> meshes) {
			var results = new glTF.Mesh[meshes.Count];
			foreach (var mesh in meshes) {
				results[mesh.Id] = Translate(mesh.Resource);
			}
			return results;
		}

		private glTF.Mesh Translate(Mesh mesh) {
			return new glTF.Mesh {
				Name = mesh.Name,
				Primitives = Translate(mesh.Primitives)
			};
		}

		private glTF.Primitive[] Translate(IEnumerable<Primitive> primitives) {
			return primitives.Select(Translate).ToArray();
		}

		private glTF.Primitive Translate(Primitive primitive) {
			var pointAccessors = _glTfCache.Register(primitive.Points);
			return new glTF.Primitive {
				Indices = pointAccessors.IndiciesId,
				Attributes = new Attributes {
					Position = pointAccessors.PositionsId
				}
			};
		}

		private T[] GetResourcesInOrder<T>(IndexedResourceCollection<T> data) {
			var resources = new T[data.Count];
			foreach (var indexedResource in data) {
				resources[indexedResource.Id] = indexedResource.Resource;
			}
			return resources;
		}
	}
}