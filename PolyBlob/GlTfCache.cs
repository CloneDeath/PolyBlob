using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using PolyBlob.glTF;
using Buffer = PolyBlob.glTF.Buffer;

namespace PolyBlob {
	public class GlTfCache {
		public IndexedResourceCollection<Buffer> Buffers { get; } = new IndexedResourceCollection<Buffer>();
		public IndexedResourceCollection<BufferView> BufferViews { get; } = new IndexedResourceCollection<BufferView>();
		public IndexedResourceCollection<Accessor> Accessors { get; } = new IndexedResourceCollection<Accessor>();

		public class PointsBufferData {
			public int IndiciesId;
			public int PositionsId;
		}
		public PointsBufferData Register(List<Vector3> points) {
			var data = RegisterBufferViews(points);
			var indexAccessor = new Accessor {
				ByteOffset = 0,
				BufferView = data.IndiciesId,
				Count = points.Count,
				Type = AccessorType.SCALAR,
				ComponentType = AccessorComponentType.UnsignedInt,
				Min = new float[] {0},
				Max = new float[] {points.Count - 1}
			};
			var positionAccessor = new Accessor {
				ByteOffset = 0,
				BufferView = data.PositionsId,
				Count = points.Count,
				Type = AccessorType.VEC3,
				ComponentType = AccessorComponentType.Float,
				Min = new[] {
					points.Select(v => v.X).Min(),
					points.Select(v => v.Y).Min(),
					points.Select(v => v.Z).Min()
				},
				Max = new[] {
					points.Select(v => v.X).Max(),
					points.Select(v => v.Y).Max(),
					points.Select(v => v.Z).Max()
				}
			};
			Accessors.Register(indexAccessor);
			Accessors.Register(positionAccessor);
			return new PointsBufferData {
				IndiciesId = Accessors.GetId(indexAccessor),
				PositionsId = Accessors.GetId(positionAccessor)
			};
		}

		private PointsBufferData RegisterBufferViews(List<Vector3> points) {
			var bufferIds = RegisterBuffers(points);
			var indexView = new BufferView {
				Buffer = bufferIds.IndiciesId,
				ByteLength = points.Count * 4,
				ByteOffset = 0,
				Target = BufferViewTarget.ElementArrayBuffer
			};
			var positionView = new BufferView {
				Buffer = bufferIds.PositionsId,
				ByteLength = points.Count * 4 * 3,
				ByteOffset = 0,
				Target = BufferViewTarget.ArrayBuffer
			};
			BufferViews.Register(indexView);
			BufferViews.Register(positionView);
			return new PointsBufferData {
				IndiciesId = BufferViews.GetId(indexView),
				PositionsId = BufferViews.GetId(positionView)
			};
		}

		private PointsBufferData RegisterBuffers(List<Vector3> points) {
			var indexBuffer = new Buffer {
				ByteLength = points.Count * 4,
				Uri = $"data:application/octet-stream;base64,{GetBase64Indexes(points)}"
			};
			var positionBuffer = new Buffer {
				ByteLength = points.Count * 3 * 4,
				Uri = $"data:application/octet-stream;base64,{GetBase64Positions(points)}"
			};
			Buffers.Register(indexBuffer);
			Buffers.Register(positionBuffer);
			return new PointsBufferData {
				IndiciesId = Buffers.GetId(indexBuffer),
				PositionsId = Buffers.GetId(positionBuffer)
			};
		}

		private string GetBase64Indexes(List<Vector3> points) {
			var bytes = new List<byte>();
			for (var i = 0; i < points.Count; i++) {
				bytes.AddRange(BitConverter.GetBytes(i));
			}
			return Convert.ToBase64String(bytes.ToArray());
		}

		private string GetBase64Positions(IEnumerable<Vector3> points) {
			var bytes = new List<byte>();
			foreach (var point in points) {
				bytes.AddRange(BitConverter.GetBytes(point.X));
				bytes.AddRange(BitConverter.GetBytes(point.Y));
				bytes.AddRange(BitConverter.GetBytes(point.Z));
			}
			return Convert.ToBase64String(bytes.ToArray());
		}
	}
}