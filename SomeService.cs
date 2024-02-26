using Helper;

namespace Reflection
{
	public class SomeService : BaseService
	{
		public async Task<string> GetString()
		{
			var result = await CallAsync<string>("HelloName");
			return result;
		}
	}
}