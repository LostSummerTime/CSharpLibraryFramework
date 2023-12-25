using System.Windows.Forms;

namespace LostSummerTime.Windows {
	public class Events {
		/// <summary>
		/// Текущее состояние прокрутки курсора (120 / -120)
		/// </summary>
		public int GetMouseWheel = 0;
		/// <summary>
		/// Путь до файла что был скинут DragDrop
		/// </summary>
		public string GetFilePath = "";

		/// <summary>
		/// Прописать в форме MouseWheel += new MouseEventHandler(MouseWheel);
		/// </summary>
		public void MouseWheel(object sender, MouseEventArgs e) => GetMouseWheel = e.Delta;

		/// <summary>
		/// DragDrop
		/// </summary>
		public void DragDrop(object sender, DragEventArgs e) {
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
			GetFilePath = files[0];
		}

		/// <summary>
		/// DragEnter
		/// </summary>
		public void DragEnter(object sender, DragEventArgs e) {
			if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true) e.Effect = DragDropEffects.All;
		}
	}
}