using System.Collections.Generic;
using System.Numerics;

namespace PolyBlob.Models {
	public class Node {
		public string Name { get; set; }
		public Vector3 Position { get; set; } = Vector3.Zero;
		
		public Mesh Mesh { get; set; }
		public List<Node> Children { get; set; } = new List<Node>();
	}
}