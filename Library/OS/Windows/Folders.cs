using System;

namespace LostSummerTime.Windows {
	public class Folders {
		public static readonly string MyDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
		public static readonly string MyMusic = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
		public static readonly string MyPictures = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
		public static readonly string MyVideos = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);

		public static readonly string TEMP = Environment.GetEnvironmentVariable("TEMP");
		public static readonly string TMP = Environment.GetEnvironmentVariable("TMP");
	}
}