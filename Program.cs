// See https://aka.ms/new-console-template for more information





using Reflection;

SomeService service = new();

Console.WriteLine(await service.GetString());