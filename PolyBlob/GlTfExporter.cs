using System.IO;
using Newtonsoft.Json;
using PolyBlob.Models;

namespace PolyBlob {
	public class GlTfExporter {
		public void SaveAs(string fileName, World world) {
			var factory = new GlTfFactory(world);
			var outWorld = factory.GetWorld();
			var data = JsonConvert.SerializeObject(outWorld, Formatting.Indented);
			File.WriteAllText(fileName, data);
		}
	}
}