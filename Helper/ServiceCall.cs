using System.Reflection;
using Service;

namespace Helper
{
	public class ServiceCall
	{
		private readonly object? _classInstance;
		private readonly Type _classType;
		private readonly string _className;

		public ServiceCall(string className, object?[]? dependencies)
		{
			var assembly = Assembly.GetExecutingAssembly();
			_className = className.Contains('.') ? className : $"Service.{className}";

			_classType = assembly.GetType(_className) ?? throw new Exception($"{_className} not found");

			_classInstance = Activator.CreateInstance(_classType, dependencies);
		}
		public ServiceCall()
		{
			_classType = typeof(GeneralService);

			_className = _classType.Name;

			_classInstance = Activator.CreateInstance(_classType, null);
		}

		public async Task<T> CallMethodAsync<T>(string methodName, object?[]? parameters)
		{
			return await (Task<T>)Invoke(methodName, parameters)!;
		}
		public async Task CallMethodAsync(string methodName, object?[]? parameters)
		{
			await (Task)Invoke(methodName, parameters)!;
		}

		public T CallMethod<T>(string methodName, object?[]? parameters)
		{
			return (T)Invoke(methodName, parameters)!;
		}

		public void CallMethod(string methodName, object?[]? parameters)
		{
			Invoke(methodName, parameters);
		}
		private object? Invoke(string methodName, object?[]? parameters)
		{
			var methodInfo = _classType.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance) ?? throw new Exception($"{methodName} not found in {_className}");

			ParameterInfo[] requiredParameters = methodInfo.GetParameters();

			if (requiredParameters.Length != parameters?.Length && parameters != null)
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

			return methodInfo.Invoke(_classInstance, parameters);
		}
	}
}