using System.Reflection;

namespace Service
{
	public class GeneralService
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