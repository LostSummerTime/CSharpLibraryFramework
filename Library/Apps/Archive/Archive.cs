using System;

using LostSummerTime.Apps.Components;

namespace LostSummerTime.Apps {
	public class Archive {
		private object Path = new object();
		private Type TString = typeof(string);
		private Type TStringArray = typeof(string[]);

		/// <summary>
		/// Создание и распоковка архивов
		/// </summary>
		/// <param name="Path">Путь до файлов / файла</param>
		/// <exception cref="ArgumentException">Это исключение выбрасывается, если один из передаваемых методу аргументов является недопустимым</exception>
		public Archive(object Path = null) {
			if (Path.GetType() != TString && Path.GetType() == TStringArray) throw new ArgumentException($"\nБыл передан объект не являющимся System.String / System.String[] для переменной Path\nЕго тип {Path.GetType()}");
			else this.Path = Path;
		}

		/// <summary>
		/// 
		/// </summary>
		public static void Decoder(string Path) {
			switch (System.IO.Path.GetExtension(Path)) {
				case ".zip":
					ZIP.Read();
					break;
				default: throw new ArgumentException("Файл не может быть обработан");
			}
		}
		// public static void Read() => Decoder();
		// public static void Repack() => Decoder();
		public static void Unpack(string Path) => Decoder(Path);

		/// <summary>
		/// 
		/// </summary>
		public static void Encoder(string Type, string Path) {
			//
		}
		// public static void Create() => Encoder();
		public static void Pack(string Type, string Path) => Encoder(Type, Path);

		/// <summary>
		/// 
		/// </summary>
		// public static void Window() { }
	}
}