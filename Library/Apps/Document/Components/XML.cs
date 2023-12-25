using System.Xml.Linq;

namespace LostSummerTime.Apps.Components {
	internal class XML {
		internal static void Read() { }

		internal static void Create() {
			XDocument doc = XDocument.Load("myfile.xml");
			doc.Root.Element("address").Value = "new address";
			doc.Save("myfile.xml");
		}
	}
}