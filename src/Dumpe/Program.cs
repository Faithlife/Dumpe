using System.Diagnostics;

if (args.Length != 1)
{
	Console.Error.WriteLine("Usage: dumpe assembly.dll");
	return 1;
}

var filePath = args[0];
try
{
	File.OpenHandle(filePath);
}
catch (FileNotFoundException)
{
	Console.Error.WriteLine("File not found");
	return 1;
}
catch (UnauthorizedAccessException)
{
	Console.Error.WriteLine("Permission denied");
	return 1;
}
catch (IOException ex)
{
	Console.Error.WriteLine($"Cannot open file: {ex}");
	return 1;
}

var versionInfo = FileVersionInfo.GetVersionInfo(filePath);
Console.WriteLine(versionInfo);

return 0;
