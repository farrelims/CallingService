using System.Reflection;
using Helper;

namespace Service
{
	public class GeneralService : BaseService
	{
		private async Task<string> CallMe(string name)
		{
			await Task.Delay(1000);
			return $"{GetType().Name}: Hello " + name + "!";
		}

		public async Task<string> PublicMethod()
		{
			return await Task.FromResult("PublicMethod");
		}
	}
}