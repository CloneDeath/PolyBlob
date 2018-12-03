using System.Collections.Generic;
using System.Numerics;
using PolyBlob.Models;

namespace PolyBlob.Sample.Vehicle {
	public class CarNode : Node {
		public CarNode() {
			Name = "car";
			Children = new List<Node> {
				new TireNode {
					Position = new Vector3(2, 0, 1)
				},
				new TireNode {
					Position = new Vector3(-2, 0, 1)
				},
				new TireNode {
					Position = new Vector3(2, 0, -1)
				},
				new TireNode {
					Position = new Vector3(-2, 0, -1)
				}
			};
		}
	}
}