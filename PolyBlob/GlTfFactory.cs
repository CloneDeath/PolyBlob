using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using PolyBlob.Models;

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
				Accessors = GetResourcesInOrder(_glTfCache.Accessors),
				Materials = GetResourcesInOrder(_glTfCache.Materials)
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
			var result = new glTF.Primitive {
				Indices = pointAccessors.IndiciesId,
				Attributes = new glTF.Attributes {
					Position = pointAccessors.PositionsId
				}
			};
			if (primitive.Material != null) {
				var material = Translate(primitive.Material);
				_glTfCache.Materials.Register(material);
				result.Material = _glTfCache.Materials.GetId(material);
			}
			return result;
		}

		private glTF.Material Translate(Material material) {
			return new glTF.Material {
				Name = material.Name,
				DoubleSided = material.DoubleSided,
				PbrMetallicRoughness = new glTF.PbrMetallicRoughness {
					BaseColorFactor = GetBaseColorFactor(material.BaseColor),
					MetallicFactor = material.MetallicFactor,
					RoughnessFactor = material.RoughnessFactor
				}
			};
		}

		private float[] GetBaseColorFactor(Color color) {
			return new[] {
				color.R / 255.0f,
				color.G / 255.0f,
				color.B / 255.0f,
				color.A / 255.0f
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