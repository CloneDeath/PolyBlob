using Newtonsoft.Json;

namespace PolyBlob.glTF {
	public class Primitive {
		[JsonProperty("attributes")]
		public Attributes Attributes { get; set; }
		
		[JsonProperty("indices")]
		public int Indices { get; set; }
		
		[JsonProperty("material", NullValueHandling=NullValueHandling.Ignore)]
		public int? Material { get; set; }
	}
}