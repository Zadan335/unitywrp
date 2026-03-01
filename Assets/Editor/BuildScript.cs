using UnityEditor;
using System.IO;

public class BuildScript
{
    public static void BuildAndroid()
    {
        string buildPath = "Builds";
        if (!Directory.Exists(buildPath))
            Directory.CreateDirectory(buildPath);

        // Use the existing scene
        string[] scenes = new[] { "Assets/Scenes/SampleScene.unity" };

        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = scenes,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        // Build APK
        EditorUserBuildSettings.buildAppBundle = false;
        options.locationPathName = buildPath + "/app.apk";
        BuildPipeline.BuildPlayer(options);

        // Build AAB
        EditorUserBuildSettings.buildAppBundle = true;
        options.locationPathName = buildPath + "/app.aab";
        BuildPipeline.BuildPlayer(options);
    }
}
