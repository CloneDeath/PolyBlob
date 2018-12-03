using System.Collections.Generic;

namespace PolyBlob.Models {
	public class Node {
		public string Name { get; set; }
		public Mesh Mesh { get; set; }
		public List<Node> Children { get; set; } = new List<Node>();
	}
}