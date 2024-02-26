// See https://aka.ms/new-console-template for more information
using Helper;
using Service;

ServiceCall service;

// Instance with Class
var classInfo = new
{
	Class = "SpesificService",
	Method = "CallMe"
};
service = new(classInfo.Class, ["Ahmad"]);

Console.WriteLine(await service.CallMethodAsync<string>(classInfo.Method, ["Farrel"]));

// Instance without Class (Will use GeneralService class)
var method = "CallMe";

service = new();

Console.WriteLine(await service.CallMethodAsync<string>(method, ["Farrel"]));





