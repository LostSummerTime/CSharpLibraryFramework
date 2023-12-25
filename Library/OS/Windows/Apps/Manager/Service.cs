using System.ServiceProcess;

namespace LostSummerTime.Windows.Apps.Components {
	internal class Service {
		internal void Start(string Name) {
			ServiceController NewServiceController = new ServiceController() { ServiceName = Name };
			if (NewServiceController.Status != ServiceControllerStatus.Running && NewServiceController.Status != ServiceControllerStatus.StartPending) {
				NewServiceController.Start(); // Запуск
				NewServiceController.WaitForStatus(ServiceControllerStatus.StartPending); // Дождаться запуска
			} else { }
		}

		internal void Stop(string Name) {
			ServiceController NewServiceController = new ServiceController() { ServiceName = Name };
			if (NewServiceController.Status != ServiceControllerStatus.Stopped && NewServiceController.Status != ServiceControllerStatus.StopPending) {
				NewServiceController.Stop(); // Остановить
				NewServiceController.WaitForStatus(ServiceControllerStatus.Stopped); // Дождаться остановки
			} else { }
		}

		internal void Boot(string Name) {
			ServiceInstaller NewServiceInstaller = new ServiceInstaller() { ServiceName = Name };
			if (NewServiceInstaller.StartType != ServiceStartMode.Boot) {
				NewServiceInstaller.StartType = ServiceStartMode.Boot;
			} else { }
		}

		internal void System(string Name) {
			ServiceInstaller NewServiceInstaller = new ServiceInstaller() { ServiceName = Name };
			if (NewServiceInstaller.StartType != ServiceStartMode.System) {
				NewServiceInstaller.StartType = ServiceStartMode.System;
			} else { }
		}

		internal void Automatic(string Name) {
			ServiceInstaller NewServiceInstaller = new ServiceInstaller() { ServiceName = Name };
			if (NewServiceInstaller.StartType != ServiceStartMode.Automatic) {
				NewServiceInstaller.StartType = ServiceStartMode.Automatic;
			} else { }
		}

		internal void Manual(string Name) {
			ServiceInstaller NewServiceInstaller = new ServiceInstaller() { ServiceName = Name };
			if (NewServiceInstaller.StartType != ServiceStartMode.Manual) {
				NewServiceInstaller.StartType = ServiceStartMode.Manual;
			} else { }
		}

		internal void Disabled(string Name) {
			ServiceInstaller NewServiceInstaller = new ServiceInstaller() { ServiceName = Name };
			if (NewServiceInstaller.StartType != ServiceStartMode.Disabled) {
				NewServiceInstaller.StartType = ServiceStartMode.Disabled;
			} else { }
		}
	}
}