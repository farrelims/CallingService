using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Helper;

namespace Service
{
	public class SomeService : BaseService
	{

		public async Task<string> CallMeFromSpesificService()
		{
			var classInfo = new
			{
				Class = "SpesificService",
				Method = "CallMe"
			};
			ServiceCall serviceCall = new(classInfo.Class, ["Ahmad"]);

			return await serviceCall.CallMethodAsync<string>(classInfo.Method, ["Farrel"]);
		}

		public async Task<string> CallMeFromGeneralService()
		{
			var method = "CallMe";

			ServiceCall serviceCall = new();

			return await serviceCall.CallMethodAsync<string>(method, ["Farrel"]);
		}

	}
}