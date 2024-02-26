using System.Reflection;
using Service;

namespace Helper
{
	public class BaseService
	{
		public static async Task<T> CallAsync<T>(string methodName, object?[]? parameters = null)
		{
			return await (Task<T>)Invoke(methodName, parameters)!;
		}
		public static async Task CallAsync(string methodName, object?[]? parameters = null)
		{
			await (Task)Invoke(methodName, parameters)!;
		}

		public static T Call<T>(string methodName, object?[]? parameters = null)
		{
			return (T)Invoke(methodName, parameters)!;
		}

		public static void Call(string methodName, object?[]? parameters = null)
		{
			Invoke(methodName, parameters);
		}

		private static object? Invoke(string methodName, object?[]? parameters)
		{
			Type generalService = typeof(GeneralService);

			var methodInfo = generalService.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance) ?? throw new Exception($"{methodName} not found in {generalService.Name}.");

			ParameterInfo[] requiredParameters = methodInfo.GetParameters();

			if (requiredParameters.Length != parameters?.Length || (parameters != null && requiredParameters.Length != 0))
			{
				var givenParametersLength = parameters == null ? default : parameters.Length;
				throw new Exception($"Parameter count mismatch. Required: {requiredParameters.Length}, Given: {givenParametersLength}");
			}

			for (int i = 0; i < requiredParameters.Length; i++)
			{
				if (parameters?[i] != null && requiredParameters[i].ParameterType != parameters?[i]?.GetType())
				{
					var givenParameters = parameters == null || parameters[i] == null ? "null" : parameters[i]?.GetType().ToString();

					throw new Exception($"Parameter type mismatch on index {i}. Required: {requiredParameters[i].ParameterType}, Given: {givenParameters}");
				}
			}

			object? instance = Activator.CreateInstance(generalService, null);

			return methodInfo.Invoke(instance, parameters);
		}
	}
}