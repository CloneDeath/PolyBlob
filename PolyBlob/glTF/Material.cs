using Newtonsoft.Json;

namespace PolyBlob.glTF {
	public class Material {
		[JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
		public string Name { get; set; }
		
		[JsonProperty("doubleSided")]
		public bool DoubleSided { get; set; }
		
		[JsonProperty("pbrMetallicRoughness", NullValueHandling=NullValueHandling.Ignore)]
		public PbrMetallicRoughness PbrMetallicRoughness { get; set; }
	}
}