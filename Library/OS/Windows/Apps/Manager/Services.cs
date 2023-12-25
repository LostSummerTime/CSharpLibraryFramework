namespace LostSummerTime.Windows.Apps.Components {
	internal class Services {
		/** <summary>
			Список служб
		</summary>*/
		private static readonly string[] Services_List = {
			"MapsBroker",													// Диспетчер скачанных карт
			"SysMain",														// SysMain / Superfetch
			"WSearch"														// Windows Search
		};

		public void Default() {
			foreach (string Service in Services_List) { }
		}
	}
}