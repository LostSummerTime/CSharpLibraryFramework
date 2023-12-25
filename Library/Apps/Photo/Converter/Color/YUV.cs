// ColorHelper
// https://github.com/iamartyom/ColorHelper

using System;

namespace LostSummerTime.Converter.Color {
	public class YUV {
		public double Y;
		public double U;
		public double V;

		public YUV(double Y, double U, double V) {
			this.Y = Y;
			this.U = U;
			this.V = V;
		}

		public override bool Equals(object obj) {
			YUV result = (YUV)obj;

			return (
				result != null &&
				Y == result.Y &&
				U == result.U &&
				V == result.V
			);
		}

		public override string ToString() => $"{Y} {U} {V}";

		public override int GetHashCode() => GetHashCode();

		public static RGB ToRGB(YUV YUV) {
			double[] RGB = new double[3];
			RGB[0] = YUV.Y + YUV.V * 1.13983;
			RGB[1] = YUV.Y - YUV.U * 0.39465 - YUV.V * 0.58060;
			RGB[2] = YUV.Y + YUV.U * 2.03211;

			return new RGB((byte)Math.Round(RGB[0] * 255), (byte)Math.Round(RGB[1] * 255), (byte)Math.Round(RGB[2] * 255));
		}

		public static HEX ToHEX(YUV YUV) => RGB.ToHEX(ToRGB(YUV));
	}
}