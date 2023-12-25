using System;
using System.Drawing;
using System.IO;
using System.Text;

namespace LostSummerTime.Apps {
	public class Photo : IDisposable {
		private static bool IsDispose = false;

		private static Bitmap BitMap = null;
		private static string[] text = null;
		private static string[] WH = null;
		private static string[] RGB = null;

		public static void Create(string Path, string Text) {
			using (FileStream Photo = File.Create(Path)) {
				byte[] info = new UTF8Encoding(true).GetBytes(Text);
				Photo.Write(info, 0, info.Length);
			}
		}

		public static Bitmap Read(string Path) {
			using (FileStream fstream = new FileStream(Path, FileMode.Open, FileAccess.Read)) {
				byte[] buffer = new byte[fstream.Length];
				fstream.Read(buffer, 0, buffer.Length);
				text = Encoding.UTF8.GetString(buffer).Split('[', ']', ' ');
			}

			WH = text[1].Split('*');

			BitMap = new Bitmap(int.Parse(WH[0]), int.Parse(WH[1]));

			for (int i = 0; i < int.Parse(WH[1]); i++) {
				for (int j = 0; j < int.Parse(WH[0]); j++) {
					if (text[2] == "") {
						RGB = text.Length - 4 > j + i ? text[3 + j + i].Split(':') : text[text.Length - 2].Split(':');
					} else {
						RGB = text[2].Split(':');
					}

					BitMap.SetPixel(j, i, Color.FromArgb(RGB.Length > 3 ? int.Parse(RGB[3]) : 255, int.Parse(RGB[0]), int.Parse(RGB[1]), int.Parse(RGB[2])));
				}
			}

			return BitMap;
		}

		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing) {
			if (!IsDispose) {
				if (disposing) {
					BitMap?.Dispose();
					text = null;
					WH = null;
					RGB = null;
				}
				IsDispose = true;
				BitMap?.Dispose();
				text = null;
				WH = null;
				RGB = null;
			}
		}
	}
}