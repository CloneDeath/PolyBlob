using System.Collections.Generic;
using PolyBlob.Models;

namespace PolyBlob.Sample.Vehicle {
	public class CarNode : Node {
		public CarNode() {
			Children = new List<Node> {
				new TireNode()
			};
		}
	}
}