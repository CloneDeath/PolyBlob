using Newtonsoft.Json;

namespace PolyBlob.glTF {
	public class Asset {
		[JsonProperty("copyright", NullValueHandling=NullValueHandling.Ignore)]
		public string Copyright { get; set; }

		[JsonProperty("generator", NullValueHandling=NullValueHandling.Ignore)]
		public string Generator { get; set; } = "PolyBlob";

		[JsonProperty("version")]
		public string Version { get; set; } = "2.0";
	}
}