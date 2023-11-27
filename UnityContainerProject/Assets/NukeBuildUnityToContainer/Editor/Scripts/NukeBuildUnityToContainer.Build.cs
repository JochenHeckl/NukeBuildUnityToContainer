using System.IO;
using System.Linq;
using Unity.Logging;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;
using Application = UnityEngine.Device.Application;

public static class NukeBuildUnityToContainerBuild
{
    public static string ProjectPath => Path.Combine(Application.dataPath, "..");

    public static string OutputDir => Path.Combine(ProjectPath, "bin", "UnityContainerProject");

    [MenuItem("Build/Build Server")]
    public static void BuildServer()
    {
        Directory.CreateDirectory(OutputDir);

        var serverBuildSettings = Resources.Load<BuildSettings>("ServerBuildSettings");
        ApplyPlayerSettings(serverBuildSettings);

        var serverBuildOptions = new BuildPlayerOptions
        {
            scenes = serverBuildSettings
                .scenes
                .Select(x => AssetDatabase.GetAssetPath(x))
                .ToArray(),
            locationPathName = Path.Combine(OutputDir, "Server"),
            target = serverBuildSettings.target,
            subtarget = (int)serverBuildSettings.subtarget,
            options = serverBuildSettings.buildOptions,
            targetGroup = serverBuildSettings.targetGroup
        };

        var buildReport = BuildPipeline.BuildPlayer(serverBuildOptions);

        Log.Info("BuildResult: {BuildResult}", buildReport.summary.result);

        if (buildReport.summary.result == BuildResult.Succeeded)
        {
            Log.Info("Artifacts written to: {OutPutPath}", buildReport.summary.outputPath);
        }
    }

    private static void ApplyPlayerSettings(BuildSettings buildSettings)
    {
        PlayerSettings.SetScriptingBackend(
            NamedBuildTarget.FromBuildTargetGroup(buildSettings.namedBuildTarget),
            buildSettings.scriptingImplementation
        );

        PlayerSettings.SetApiCompatibilityLevel(
            NamedBuildTarget.FromBuildTargetGroup(buildSettings.namedBuildTarget),
            buildSettings.apiCompatibilityLevel
        );
    }
}
