namespace LostSummerTime.Windows.Apps.Components {
	internal class Registry {
		/** <summary>
			HKEY_LOCAL_MACHINE
		</summary>*/
		private static readonly string HKLM = "HKEY_LOCAL_MACHINE";
		/** <summary>
			HKEY_CURRENT_CONFIG
		</summary>*/
		private static readonly string HKCC = "HKEY_CURRENT_CONFIG";
		/** <summary>
			HKEY_CLASSES_ROOT
		</summary>*/
		private static readonly string HKCR = "HKEY_CLASSES_ROOT";
		/** <summary>
			HKEY_CURRENT_USER
		</summary>*/
		private static readonly string HKCU = "HKEY_CURRENT_USER";

		private static readonly string[] Registry_List = { };
	}
}