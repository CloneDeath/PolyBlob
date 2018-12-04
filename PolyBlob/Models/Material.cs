using System.Drawing;

namespace PolyBlob.Models {
	public class Material {
		public string Name { get; set; }
		public Color BaseColor { get; set; } = Color.White;
		public float MetallicFactor { get; set; } = 0.5f;
		public float RoughnessFactor { get; set; } = 0.5f;
		public bool DoubleSided { get; set; } = false;
	}
}