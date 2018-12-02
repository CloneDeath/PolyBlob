using Newtonsoft.Json;

namespace PolyBlob.glTF {
	public class Buffer {
		[JsonProperty("name", NullValueHandling=NullValueHandling.Ignore)]
		public string Name { get; set; }
		
		[JsonProperty("uri")]
		public string Uri { get; set; }
		
		[JsonProperty("byteLength")]
		public int ByteLength { get; set; }
	}
}