// ColorHelper
// https://github.com/iamartyom/ColorHelper

namespace LostSummerTime.Converter.Color {
	public class RGB {
		public byte R;
		public byte G;
		public byte B;

		public RGB(byte R, byte G, byte B) {
			this.R = R;
			this.G = G;
			this.B = B;
		}

		public override bool Equals(object obj) {
			RGB Result = (RGB)obj;

			return (
				Result != null &&
				R == Result.R &&
				G == Result.G &&
				B == Result.B
			);
		}

		public override string ToString() => $"rgb({R}, {G}, {B})";

		public override int GetHashCode() => GetHashCode();

		public static HEX ToHEX(RGB RGB) => new HEX($"{RGB.R:X2}{RGB.G:X2}{RGB.B:X2}");

		public static YUV ToYUV(RGB RGB) {
			double[] ModifiedRGB = { RGB.R / 255.0, RGB.G / 255.0, RGB.B / 255.0 };

			return new YUV(
				(ModifiedRGB[0] * 0.299 + ModifiedRGB[1] * 0.587 + ModifiedRGB[2] * 0.114),
				(ModifiedRGB[0] * (-0.14713) - ModifiedRGB[1] * 0.28886 + ModifiedRGB[2] * 0.436),
				(ModifiedRGB[0] * 0.615 - ModifiedRGB[1] * 0.51499 - ModifiedRGB[2] * 0.10001)
			);
		}
	}
}