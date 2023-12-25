using System;
using System.IO;

namespace LostSummerTime.Windows.Apps.Components {
	internal class Clear {
		// private readonly static string TMP = Environment.GetEnvironmentVariable("TMP");
		private readonly static string TEMP = Environment.GetEnvironmentVariable("TEMP");
		// private readonly static string Temp = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

		/** <summary>
			Куда все будет записываться
		</summary>*/
		// public TextBox TextBox;

		/** <summary>
			Действие по умолчанию
		</summary>*/
		public Clear() {
			Delete(new DirectoryInfo(TEMP));
		}

		/** <summary>
			Удаление всего по передаваемому пути
		</summary>*/
		private void Delete(DirectoryInfo NewDirectoryInfo) {
			foreach (FileSystemInfo FolderFile in NewDirectoryInfo.EnumerateFileSystemInfos()) {
				try {
					//if (TextBox != null) TextBox.Text += $"\r\n{DateTime.Now:HH:mm:ss tt}: Удаление {FolderFile.Name} по пути {FolderFile.FullName}";
					FolderFile.Delete();
					//if (TextBox != null) TextBox.Text += $"\r\n{DateTime.Now:HH:mm:ss tt}: Удаление {FolderFile.Name} по пути {FolderFile.FullName} завершео";
				} catch {
					//if (TextBox != null) TextBox.Text += $"\r\n{DateTime.Now:HH:mm:ss tt}: Возникла внутренняя ошибка - Не вышло удалить {FolderFile.Name} по пути {FolderFile.FullName}";
				}
			}
		}
	}
}