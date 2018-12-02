using Newtonsoft.Json;

namespace PolyBlob.glTF {
	public class Node {
		[JsonProperty("name")]
		public string Name { get; set; }
		
		[JsonProperty("mesh")]
		public int Mesh { get; set; }
		
		[JsonProperty("children")]
		public int[] Children { get; set; }

		[JsonProperty("rotation")]
		public double[] Rotation { get; set; }

		[JsonProperty("scale")]
		public double[] Scale { get; set; }

		[JsonProperty("translation")]
		public double[] Translation { get; set; }
		
		[JsonProperty("matrix")]
		public double[] Matrix { get; set; }
	}
}