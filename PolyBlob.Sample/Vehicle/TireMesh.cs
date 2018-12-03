using System;
using System.Collections.Generic;
using System.Numerics;
using PolyBlob.Models;

namespace PolyBlob.Sample.Vehicle {
	public class TireMesh : Mesh {
		public TireMesh(int points) {
			Name = "tire";
			var pointData = new List<Vector3>();
			for (var i = 0; i < points; i++) {
				pointData.AddRange(GetTriangleArc(i, points));
			}
			Primitives = new List<Primitive> {
				new Primitive {
					Points = pointData
				}
			};
		}

		private IEnumerable<Vector3> GetTriangleArc(int start, int total) {
			return new List<Vector3> {
				GetPointOnArc(start, total),
				GetPointOnArc(start + 1, total),
				Vector3.Zero
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