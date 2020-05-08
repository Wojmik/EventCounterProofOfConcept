using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventCounterProofOfConcept
{
	class Zadanko
	{
		public async Task Działaj()
		{
			MójEvent.Instance.Wystartował();

			await Task.Delay(5000)
				.ConfigureAwait(false);


			MójEvent.Instance.Koniec();
		}
	}
}