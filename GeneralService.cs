using Helper;

namespace Service
{
	public class GeneralService : BaseService
	{
		private async Task<string> HelloWorldString()
		{
			return await Task.FromResult("Hello World!");
		}
		private async Task<string> HelloName(string name)
		{
			return await Task.FromResult($"Hello {name}!");
		}

		private async Task<int> IntMethod()
		{
			return await Task.FromResult(1);
		}

		private async Task HelloWorldVoid()
		{
			await Task.Run(() => Console.WriteLine("Hello World!"));
		}

	}
}