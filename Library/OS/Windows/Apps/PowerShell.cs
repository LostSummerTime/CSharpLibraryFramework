using System.Collections.Generic;
using System.Management.Automation.Runspaces;

/*
	Microsoft.PowerShell.5.ReferenceAssemblies | 1.1.0
*/

namespace LostSummerTime.Windows.Apps {
	public class PowerShell {
		public static void Command(List<string> Commands) {
			Runspace NewRunspace = RunspaceFactory.CreateRunspace();
			NewRunspace.Open();

			Pipeline NewPipeline = NewRunspace.CreatePipeline();

			foreach (string Command in Commands) NewPipeline.Commands.AddScript(Command);

			NewRunspace.Close();
		}
	}
}