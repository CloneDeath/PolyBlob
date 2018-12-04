using System.Drawing;
using PolyBlob.Models;

namespace PolyBlob.Sample.Vehicle {
	public class MetalMaterial : Material {
		public MetalMaterial() {
			Name = "metal";
			BaseColor = Color.FromArgb(230, 230, 230);
			MetallicFactor = 0.8f;
			RoughnessFactor = 0.4f;
		}
	}
}