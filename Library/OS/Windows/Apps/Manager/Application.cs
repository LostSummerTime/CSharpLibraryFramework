using System.Collections.Generic;

namespace LostSummerTime.Windows.Apps.Components {
	internal class Application {
		internal void Install(string Type = null, string Path = null, string Name = null) {
			PowerShell.Command(new List<string> { $"Get-Package -Name {Name} | Uninstall-Package" });
		}

		internal void Uninstall(string Type = null, string Name = null) {
			/*
				https://lazyadmin.nl/it/uninstall-microsoft-store-and-default-apps/
				https://lazyadmin.nl/it/install-microsoft-store-apps-without-store/
			*/

			PowerShell.Command(new List<string> {
				$"Get-AppxPackage -Name {Name} | Remove-AppxPackage -AllUsers",
				$"Get-AppXProvisionedPackage -Online | Where-Object DisplayName -EQ {Name} | Remove-AppxProvisionedPackage -Online",
				$"Remove-Item \"$Env:LOCALAPPDATA\\Packages\\{Name}*\" -Recurse -Force -ErrorAction 0"
			});
		}
	}
}