using System.Diagnostics.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace PolyBlob.glTF {
	public class Accessor {
		[JsonProperty("bufferView")]
		public int BufferView { get; set; }
		
		[JsonProperty("byteOffset")]
		public int ByteOffset { get; set; }
		
		[JsonProperty("componentType")]
		public AccessorComponentType ComponentType { get; set; }
		
		[JsonProperty("count")]
		public int Count { get; set; }
		
		[JsonProperty("type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public AccessorType Type { get; set; }
		
		[JsonProperty("max")]
		public int[] Max { get; set; }
		
		[JsonProperty("min")]
		public int[] Min { get; set; }
	}

	public enum AccessorComponentType {
		Byte = 5120,
		UnsignedByte = 5121,
		Short = 5122,
		UnsignedShort = 5123,
		UnsignedInt = 5125,
		Float = 5126
	}

	[SuppressMessage("ReSharper", "InconsistentNaming")]
	public enum AccessorType {
		SCALAR,
		VEC2,
		VEC3,
		VEC4,
		MAT2,
		MAT3,
		MAT4
	}
}