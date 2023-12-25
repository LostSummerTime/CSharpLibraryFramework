using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LostSummerTime.Apps.Components {
	internal class LST {
		public string Path;
		public List<string> ListFiles;
		public string Action;

		private static readonly string ExtensionFile = ".LostSummerTimeArchive";
		private static readonly string ExtensionCache = ".LostSummerTimeArchiveCache";

		private static readonly List<byte[]> TestTes = new List<byte[]>() {
			Encoding.UTF8.GetBytes("<NameFile>"),
			Encoding.UTF8.GetBytes("</NameFile>"),
			Encoding.UTF8.GetBytes("<ExtensionFile>"),
			Encoding.UTF8.GetBytes("</ExtensionFile>"),
			Encoding.UTF8.GetBytes("<File>"),
			Encoding.UTF8.GetBytes("</File>")
		};

		private readonly static byte[] NameFile_Byte = Encoding.UTF8.GetBytes("<NameFile>");
		private readonly static byte[] NameFileEnd_Byte = Encoding.UTF8.GetBytes("</NameFile>");

		private readonly static byte[] Extension_Byte = Encoding.UTF8.GetBytes("<ExtensionFile>");
		private readonly static byte[] ExtensionEnd_Byte = Encoding.UTF8.GetBytes("</ExtensionFile>");

		private readonly static byte[] File_Byte = Encoding.UTF8.GetBytes("<File>");
		private readonly static byte[] FileEnd_Byte = Encoding.UTF8.GetBytes("</File>");

		private static byte[] EncodingUTF8GetBytes(string Text) {
			return Encoding.UTF8.GetBytes(Text);
		}

		private static void Decompress(FileStream Archive, FileStream File) {
			using (GZipStream _GZipStream = new GZipStream(Archive, CompressionMode.Decompress)) {
				byte[] Bytes = new byte[4096];

				int Int;

				while ((Int = File.Read(Bytes, 0, Bytes.Length)) != 0) {
					_GZipStream.Write(Bytes, 0, Int);
				}
			}
		}



		public void Welcome() {
			if (Action == null) {
				throw new ArgumentNullException("Archive - Не было указано действие");
			} else {
				if (Action == "create") {
					if (Path == null) throw new ArgumentNullException("Archive - Не был указан путь");
					if (ListFiles == null) throw new ArgumentNullException("Archive - Не был указан список файлов");

					Path = $"{Path}{ExtensionFile}";

					Create();
				}

				if (Action == "open") {
					if (Path == null) {
						throw new ArgumentNullException("Archive - Не был указан путь");
					} else {
						if (new FileInfo(Path).Extension == ExtensionFile) {
							Open();
						} else { }
					}
				}
			}
		}

		public void Create() {
			Console.WriteLine($"Начало работы: {DateTime.Now}");

			for (int i = 0; i < ListFiles.Count; ++i) {
				using (FileStream Archive = new FileStream(Path, FileMode.Append, FileAccess.Write)) {
					FileInfo _FileInfo = new FileInfo(ListFiles[i]);

					Archive.Write(NameFile_Byte, 0, NameFile_Byte.Length);
					Archive.Write(EncodingUTF8GetBytes(_FileInfo.Name), 0, EncodingUTF8GetBytes(_FileInfo.Name).Length);
					Archive.Write(NameFileEnd_Byte, 0, NameFileEnd_Byte.Length);

					Archive.Write(Extension_Byte, 0, Extension_Byte.Length);
					Archive.Write(EncodingUTF8GetBytes(_FileInfo.Extension), 0, EncodingUTF8GetBytes(_FileInfo.Extension).Length);
					Archive.Write(ExtensionEnd_Byte, 0, ExtensionEnd_Byte.Length);

					Archive.Write(File_Byte, 0, File_Byte.Length);

					using (FileStream _File = File.Open(ListFiles[i], FileMode.Open, FileAccess.ReadWrite)) {
						using (GZipStream _GZipStream = new GZipStream(Archive, CompressionMode.Compress)) {
							byte[] Bytes = new byte[4096];
							int Int;

							while ((Int = _File.Read(Bytes, 0, Bytes.Length)) > 0) _GZipStream.Write(Bytes, 0, Bytes.Length);

							Archive.Write(FileEnd_Byte, 0, FileEnd_Byte.Length);
						}
					}
				}
			}

			Console.WriteLine($"Конец работы: {DateTime.Now}");
		}

		public void Open() {
			using (FileStream _File = File.Open(Path, FileMode.Open, FileAccess.Read)) {
				foreach (var Text in TestTes) {
					byte[] Bytes = new byte[Text.Length];
					while (_File.Read(Bytes, 0, Bytes.Length) > 0) {
						for (int i = 0; i < Text.Length; i++) {
							if (Bytes[i] != Text[i]) break;

							if (i == Text.Length) {
								// new AddTextTextBox() { Text = _File.Position - Text.Length, TextBox = TextBox };
								// Console.WriteLine($"{_File.Position - Text.Length}: Найдено в {DateTime.Now}");
								break;
							}
						}
					}
				}
			};
		}
	}
}