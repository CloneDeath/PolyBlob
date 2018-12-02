using Newtonsoft.Json;

namespace PolyBlob.glTF {
	public class BufferView {
		[JsonProperty("name")]
		public string Name { get; set; }
		
		[JsonProperty("buffer")]
		public int Buffer { get; set; }
		
		[JsonProperty("byteOffset")]
		public int ByteOffset { get; set; }
		
		[JsonProperty("byteLength")]
		public int ByteLength { get; set; }
		
		[JsonProperty("target")]
		public BufferViewTarget Target { get; set; }
	}
	
	public enum BufferViewTarget {
		ArrayBuffer = 34962,
		ElementArrayBuffer = 34963
	}
}