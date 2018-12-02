using Newtonsoft.Json;

namespace PolyBlob.glTF {
	public class Mesh {
		[JsonProperty("name")]
		public string Name { get; set; }
		
		[JsonProperty("primitives")]
		public Primitive[] Primitives { get; set; }
	}
}