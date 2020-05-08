using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EventCounterProofOfConcept
{
	class VM_Main : Prism.Mvvm.BindableBase
	{
		public ObservableCollection<EventData> Events { get; set; }

		public VM_Main()
		{
			this.Events=new ObservableCollection<EventData>();
		}
	}
}