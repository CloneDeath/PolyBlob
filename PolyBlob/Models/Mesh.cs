using System.Collections.Generic;

namespace PolyBlob.Models {
	public class Mesh {
		public string Name { get; set; }
		public List<Primitive> Primitives { get; set; } = new List<Primitive>();
	}
}