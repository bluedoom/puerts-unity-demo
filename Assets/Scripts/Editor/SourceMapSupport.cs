using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using UnityEditor;

[InitializeOnLoad]
public static class SourceMapSupport
{
    static SourceMapSupport()
    {
        var m = typeof(EditorGUI).GetMethod("add_hyperLinkClicked",BindingFlags.NonPublic|BindingFlags.Static);
        m.Invoke(null, new[] { new EventHandler(HandleHyperLinkClick) });
    }
    public static void HandleHyperLinkClick(object sender, EventArgs e)
    {
		var hyperlinkInfos = e.GetType().GetProperty("hyperlinkInfos").GetValue(e) as Dictionary<string,string>;

		if (hyperlinkInfos.TryGetValue("path", out var path))
		{
			if (!string.IsNullOrEmpty(path))
			{
				using (var p = new Process())
                {
					p.StartInfo.FileName = "code";
					p.StartInfo.Arguments = $"-g {path}";
					p.StartInfo.CreateNoWindow = true;
					p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					p.Start();
				}
			}
		}
	}
}
