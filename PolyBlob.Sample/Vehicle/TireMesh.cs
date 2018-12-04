using System;
using System.Collections.Generic;
using System.Numerics;
using PolyBlob.Models;

namespace PolyBlob.Sample.Vehicle {
	public class TireMesh : Mesh {
		public TireMesh(int points) {
			Name = "tire";
			
			Primitives = new List<Primitive> {
				new Primitive {
					Points = GetCircle(points, 1f, 1.1f),
					Material = new RubberMaterial()
				},
				new Primitive {
					Points = GetCircle(points, 0, 1),
					Material = new MetalMaterial()
				}
			};
		}

		private List<Vector3> GetCircle(int points, float min, float max) {
			var pointData = new List<Vector3>();
			for (var i = 0; i < points; i++) {
				pointData.AddRange(GetTriangleArc(i, points, min, max));
			}
			return pointData;
		}

		private IEnumerable<Vector3> GetTriangleArc(int start, int total, float min, float max) {
			return new List<Vector3> {
				GetPointOnArc(start, total) * max,
				GetPointOnArc(start + 1, total) * max,
				GetPointOnArc(start, total) * min
			};
		}

		private Vector3 GetPointOnArc(int start, int total) {
			return new Vector3 {
				X = MathF.Cos(CirclesToRadians(start * 1.0f / total)),
				Y = MathF.Sin(CirclesToRadians(start * 1.0f / total)),
				Z = 0
			};
		}

		protected float CirclesToRadians(float circles) {
			return circles * MathF.PI * 2;
		}
	}
}