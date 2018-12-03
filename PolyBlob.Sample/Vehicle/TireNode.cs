using PolyBlob.Models;

namespace PolyBlob.Sample.Vehicle {
	public class TireNode : Node {
		public TireNode() {
			Name = "Tire";
			Mesh = new TireMesh(11);
		}
	}
}