using Newtonsoft.Json;

namespace PolyBlob.glTF {
	public class Mesh {
		[JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
		public string Name { get; set; }
		
		[JsonProperty("primitives")]
		public Primitive[] Primitives { get; set; }
	}
}