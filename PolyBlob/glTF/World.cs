using Newtonsoft.Json;

namespace PolyBlob.glTF {
	public class World {
		[JsonProperty("asset")]
		public Asset Asset { get; set; } = new Asset();
		
		[JsonProperty("scenes", NullValueHandling=NullValueHandling.Ignore)]
		public Scene[] Scenes { get; set; }
		
		[JsonProperty("scene", NullValueHandling=NullValueHandling.Ignore)]
		public int DefaultScene { get; set; }
		
		[JsonProperty("nodes", NullValueHandling=NullValueHandling.Ignore)]
		public Node[] Nodes { get; set; }
		
		[JsonProperty("meshes", NullValueHandling=NullValueHandling.Ignore)]
		public Mesh[] Meshes { get; set; }
		
		[JsonProperty("buffers", NullValueHandling=NullValueHandling.Ignore)]
		public Buffer[] Buffers { get; set; }
		
		[JsonProperty("bufferViews", NullValueHandling=NullValueHandling.Ignore)]
		public BufferView[] BufferViews { get; set; }
		
		[JsonProperty("accessors", NullValueHandling=NullValueHandling.Ignore)]
		public Accessor[] Accessors { get; set; }
	}
}