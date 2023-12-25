using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LostSummerTime.Windows.DLL {
	internal class Kernel32 {
		#region GlobalMemoryStatusEx
		// https://stackoverflow.com/questions/105031/how-do-you-get-total-amount-of-ram-the-computer-has
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		private class MEMORYSTATUSEX {
			public uint dwLength;
			public uint dwMemoryLoad;
			public ulong ullTotalPhys;
			public ulong ullAvailPhys;
			public ulong ullTotalPageFile;
			public ulong ullAvailPageFile;
			public ulong ullTotalVirtual;
			public ulong ullAvailVirtual;
			public ulong ullAvailExtendedVirtual;
			public MEMORYSTATUSEX() {
				dwLength = (uint)Marshal.SizeOf(typeof(MEMORYSTATUSEX));
			}
		}

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool GlobalMemoryStatusEx([In, Out] MEMORYSTATUSEX lpBuffer);
		#endregion

		public static int GetMemory(string Is = null) {
			MEMORYSTATUSEX memStatus = new MEMORYSTATUSEX();

			ulong MemoryKB = 0;
			ulong MemoryMB = 0;
			ulong MemoryGB = 0;

			if (GlobalMemoryStatusEx(memStatus)) {
				MemoryKB = memStatus.ullTotalPhys / 1024;
				MemoryMB = MemoryKB / 1024;
				MemoryGB = MemoryMB / 1024;
			}

			if (Is == "KB") {
				return (int)MemoryKB;
			}

			if (Is == "MB") {
				return (int)MemoryMB;
			}

			return (int)MemoryGB;
		}
	}
}