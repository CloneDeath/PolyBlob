using PolyBlob.Models;

namespace PolyBlob {
	public class WorldCache {
		public IndexedResourceCollection<Scene> Scenes { get; } = new IndexedResourceCollection<Scene>();
		public IndexedResourceCollection<Node> Nodes { get; } = new IndexedResourceCollection<Node>();
		public IndexedResourceCollection<Mesh> Meshes { get; } = new IndexedResourceCollection<Mesh>();
		
		public WorldCache(World world) {
			Cache(world);
		}

		private void Cache(World world) {
			foreach (var scene in world.Scenes) {
				Cache(scene);
			}
		}

		private void Cache(Scene scene) {
			Scenes.Register(scene);
			foreach (var node in scene.Nodes) {
				Cache(node);
			}
		}

		private void Cache(Node node) {
			Nodes.Register(node);
			if (node.Mesh != null) Meshes.Register(node.Mesh);
			foreach (var child in node.Children) {
				Cache(child);
			}
		}
	}
}