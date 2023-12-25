namespace LostSummerTime.Windows.Apps.Components {
	internal class Applications {
		// Get-AppXProvisionedPackage -online | Remove-AppxProvisionedPackage -online

		public void Default() {
			foreach (string App in UWP_List) { }
		}
	}
}