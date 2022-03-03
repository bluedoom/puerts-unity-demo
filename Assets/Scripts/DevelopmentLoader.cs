using Puerts;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DevelopmentLoader : ILoader
{
    static string[] m_searchPath =
    {
        "TsProj/output/",
        "TsProj/JsLib/",
        "TsProj/JsLib/Editor/",
        "Assets/Puerts/Src/Resources",
        "Assets/Puerts/Src/Editor/Resources",
    };

    IEnumerable<string> GetJsFiles(string pathWithoutExtension)
    {
        yield return pathWithoutExtension;
        yield return pathWithoutExtension + ".txt";
        yield return pathWithoutExtension + ".mjs";
    }

    public string GetValidPath(string filepath)
    {
        foreach (var searchPath in m_searchPath)
        {
            var scriptPath = Path.GetFullPath(Path.Combine(searchPath, filepath));
            foreach (var filePath in GetJsFiles(scriptPath))
            {
                if (File.Exists(filePath))
                {
                    return filePath;
                }
            }
        }
        return null;
    }

    public bool FileExists(string filepath)
    {
        return GetValidPath(filepath) != null;
    }

    public string ReadFile(string filepath, out string debugpath)
    {
        debugpath = GetValidPath(filepath);
        // debugpath.Replace('/','\\');
        return File.ReadAllText(debugpath);
    }
}
