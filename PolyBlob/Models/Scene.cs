using System.Collections.Generic;

namespace PolyBlob.Models {
	public class Scene {
		public string Name { get; set; }
		public List<Node> Nodes { get; set; } = new List<Node>();
	}
}