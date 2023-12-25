// ColorHelper
// https://github.com/iamartyom/ColorHelper

using System;

namespace LostSummerTime.Converter.Color {
	public class HEX {
		private string _Value;

		public string Value {
			get { return _Value; }
			set { _Value = (value.IndexOf('#') == 0) ? value.Substring(1) : value; }
		}

		public HEX(string Value) { this.Value = Value; }

		public override bool Equals(object obj) => Value == (obj as HEX)?.Value;

		public override string ToString() => $"{Value}";

		public override int GetHashCode() => GetHashCode();

		public static RGB ToRGB(HEX HEX) {
			int Value = Convert.ToInt32(HEX.Value, 16);

			return new RGB(
				(byte)((Value >> 16) & 255),
				(byte)((Value >> 8) & 255),
				(byte)(Value & 255)
			);
		}

		public static YUV ToYUV(HEX HEX) => RGB.ToYUV(ToRGB(HEX));
	}
}