namespace Service
{
	public class SpesificService(string middleName)
	{
		private async Task<string> CallMe(string name)
		{
			await Task.Delay(1000);
			return $"{GetType().Name}: Hello {name} {middleName}";
		}
		private async Task<int> CallNumber(int number)
		{
			await Task.Delay(1000);
			return number;
		}

		private async Task<string> Hello()
		{
			await Task.Delay(1000);
			return "Hello";
		}

		public async Task<string> PublicMethod()
		{
			return await Task.FromResult("PublicMethod");
		}
	}
}