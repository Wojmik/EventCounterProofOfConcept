using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace EventCounterProofOfConcept
{
	class Słuchaczek : EventListener
	{
		private Dictionary<Guid, EventSource> PodłączoneŹródła = new Dictionary<Guid, EventSource>();

		private bool NasłuszekWłączony;

		private object oLocker = new object();

		protected override void OnEventSourceCreated(EventSource eventSource)
		{
			base.OnEventSourceCreated(eventSource);

			PrzetwarzajŹródło(eventSource);
		}

		private void PrzetwarzajŹródło(EventSource source)
		{
			if(source.Name=="Moje źródełko eventów")
			{
				lock(oLocker)
				{
					if(this.PodłączoneŹródła.TryAdd(source.Guid, source))
					{
						System.Diagnostics.Debug.WriteLine($"Nowe źródełko: {source.Name}, {source.Guid}");

						if(NasłuszekWłączony)
							this.EnableEvents(source, EventLevel.LogAlways, EventKeywords.All);
					}
				}
			}
		}

		public void WłączNasłuszek()
		{
			lock(oLocker)
			{
				if(!NasłuszekWłączony)
				{
					foreach(var source in this.PodłączoneŹródła)
						this.EnableEvents(source.Value, EventLevel.LogAlways, EventKeywords.All);

					NasłuszekWłączony=true;
				}
			}
		}

		public void WyłączNasłuszek()
		{
			lock(oLocker)
			{
				if(NasłuszekWłączony)
				{
					foreach(var source in this.PodłączoneŹródła)
						this.DisableEvents(source.Value);

					NasłuszekWłączony=false;
				}
			}
		}

		protected override void OnEventWritten(EventWrittenEventArgs eventData)
		{
			base.OnEventWritten(eventData);

			System.Diagnostics.Debug.WriteLine($"Coś przyszło: {eventData.EventName}");
		}
	}
}