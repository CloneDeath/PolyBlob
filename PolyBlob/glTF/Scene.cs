using Newtonsoft.Json;

namespace PolyBlob.glTF {
	public class Scene {
		[JsonProperty("name")]
		public string Name { get; set; }
		
		[JsonProperty("nodes")]
		public int[] Nodes { get; set; }
	}
}