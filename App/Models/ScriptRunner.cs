using System;
using System.Diagnostics;
using System.IO;

namespace App.Models;

public static class ScriptRunner
{
    public static void Test()
    {
        string scriptDirectory = Path.Combine(AppContext.BaseDirectory, "Models", "AppleScripts");
        string scriptName = "MediaToggler.applescript"; // or .applescript
        string fullScriptPath = Path.Combine(scriptDirectory, scriptName);

        var startInfo = new ProcessStartInfo
        {
            FileName = "osascript",
            Arguments = $"\"{fullScriptPath}\"",
            WorkingDirectory = scriptDirectory, // Sets the working directory if needed
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };

        using var process = Process.Start(startInfo)
            ?? throw new InvalidOperationException("Failed to start osascript.");

        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        process.WaitForExit();

        if (!string.IsNullOrEmpty(output))
            Console.WriteLine("Output: " + output);

        if (!string.IsNullOrEmpty(error))
            Console.WriteLine("Error: " + error);
    }
}