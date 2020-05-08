using System;
using System.Collections.Generic;
using System.Text;

namespace EventCounterProofOfConcept
{
	class EventData : Prism.Mvvm.BindableBase
	{
		private string _message;

		public string Message { get => this._message; set => SetProperty(ref this._message, value); }
	}
}