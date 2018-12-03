using Newtonsoft.Json;

namespace PolyBlob.glTF {
	public class Node {
		[JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
		public string Name { get; set; }
		
		[JsonProperty("mesh", NullValueHandling=NullValueHandling.Ignore)]
		public int? Mesh { get; set; }
		
		[JsonProperty("children", NullValueHandling=NullValueHandling.Ignore)]
		public int[] Children { get; set; }

		[JsonProperty("rotation", NullValueHandling=NullValueHandling.Ignore)]
		public double[] Rotation { get; set; }

		[JsonProperty("scale", NullValueHandling=NullValueHandling.Ignore)]
		public double[] Scale { get; set; }

		[JsonProperty("translation", NullValueHandling=NullValueHandling.Ignore)]
		public double[] Translation { get; set; }
		
		[JsonProperty("matrix", NullValueHandling=NullValueHandling.Ignore)]
		public double[] Matrix { get; set; }
	}
}