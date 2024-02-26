using Service;

SomeService service = new();

Console.WriteLine(await service.CallMeFromSpesificService());
Console.WriteLine(await service.CallMeFromGeneralService());