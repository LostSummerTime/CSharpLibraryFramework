using System;
using System.Runtime.InteropServices;

/*
https://www.techiedelight.com/ru/determine-operating-system-csharp/
*/

namespace LostSummerTime.OS {
	public class Check {
		public Check() {
			///
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows)) {
				Console.WriteLine("Windows");
			} else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux)) {
				Console.WriteLine("Linux");
			} else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) {
				Console.WriteLine("MacOS");
			}
		}
	}
}