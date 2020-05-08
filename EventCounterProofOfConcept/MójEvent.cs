using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace EventCounterProofOfConcept
{
	[EventSource(Name = "Moje źródełko eventów")]
	class MójEvent : EventSource
	{
		public static MójEvent Instance { get; } = new MójEvent();


		[Event(1, Message = "To jest sobie start")]
		public void Wystartował()
		{
			this.Write("Początek");
		}

		[Event(2, Message = "To jest sobie koniec")]
		public void Koniec()
		{
			this.Write("Koniec");
		}
	}
}