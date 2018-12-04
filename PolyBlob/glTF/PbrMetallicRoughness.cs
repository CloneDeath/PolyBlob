using Newtonsoft.Json;

namespace PolyBlob.glTF {
	public class PbrMetallicRoughness {
		[JsonProperty("baseColorFactor")]
		public float[] BaseColorFactor { get; set; } = {1, 1, 1, 1};
		
		[JsonProperty("metallicFactor")]
		public float MetallicFactor { get; set; }
		
		[JsonProperty("roughnessFactor")]
		public float RoughnessFactor { get; set; }
	}
}