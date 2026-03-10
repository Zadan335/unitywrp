using UnityEditor;
using System.IO;

public class BuildScript
{
    public static void BuildAndroid()
    {
        string buildType = GetArgument("-buildType");

        if (string.IsNullOrEmpty(buildType))
            buildType = "both";

        buildType = buildType.Trim().ToLower();

        UnityEngine.Debug.Log("BUILD TYPE: " + buildType);

        string buildPath = "Builds";

        if (!Directory.Exists(buildPath))
            Directory.CreateDirectory(buildPath);

        string[] scenes = new[] { "Assets/Scenes/SampleScene.unity" };

        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = scenes,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        if (buildType == "apk" || buildType == "both")
        {
            UnityEngine.Debug.Log("Building APK");

            EditorUserBuildSettings.buildAppBundle = false;
            options.locationPathName = buildPath + "/app.apk";

            BuildPipeline.BuildPlayer(options);
        }

        if (buildType == "aab" || buildType == "both")
        {
            UnityEngine.Debug.Log("Building AAB");

            EditorUserBuildSettings.buildAppBundle = true;
            options.locationPathName = buildPath + "/app.aab";

            BuildPipeline.BuildPlayer(options);
        }
    }

    static string GetArgument(string name)
    {
        var args = System.Environment.GetCommandLineArgs();

        for (int i = 0; i < args.Length; i++)
        {
            if (args[i] == name && i + 1 < args.Length)
                return args[i + 1];
        }

        return null;
    }
}
