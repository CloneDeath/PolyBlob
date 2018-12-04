using PolyBlob.Models;
using System.Drawing;

namespace PolyBlob.Sample.Vehicle {
	public class RubberMaterial : Material {
		public RubberMaterial() {
			Name = "rubber";
			BaseColor = Color.FromArgb(10, 10, 10);
			MetallicFactor = 0.03f;
			RoughnessFactor = 0.83f;
		}
	}
}