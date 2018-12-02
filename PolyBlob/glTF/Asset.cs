using Newtonsoft.Json;

namespace PolyBlob.glTF {
	public class Asset {
		[JsonProperty("copyright")]
		public string Copyright { get; set; }

		[JsonProperty("generator")]
		public string Generator { get; set; } = "PolyBlob";

		[JsonProperty("version")]
		public string Version { get; set; } = "2.0";
	}
}