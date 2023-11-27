using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tools.Docker;
using Nuke.Common.Tools.Unity;
using static Nuke.Common.Tools.Docker.DockerTasks;

public partial class Build
{
    string UnityContainerProjectName => "UnityContainerProject";
    string ServerContainerTag => "server_container";

    AbsolutePath UnityContainerProjectThirdParryDirectory =>
        RootDirectory / UnityContainerProjectName / "Assets" / "ThirdParty";

    Target BuildUnityServer =>
        x =>
            x.Executes(() =>
            {
                UnityTasks.Unity(
                    x =>
                        x.SetBatchMode(true)
                            .SetProjectPath(RootDirectory / UnityContainerProjectName)
                            .SetExecuteMethod("NukeBuildUnityToContainerBuild.BuildServer")
                            //.SetBuildTarget(UnityBuildTarget.standalone)
                            //.SetBuildLinux64Player(OutputDirectory / UnityContainerProjectName)
                            .SetQuit(true)
                );
            });

    public Target CreateUnityServerContainerImage =>
        x =>
            x.DependsOn(BuildUnityServer)
            .Executes(() =>
            {
                DockerBuild(
                    (buildSettings) =>
                        buildSettings
                            .SetFile(RootDirectory / UnityContainerProjectName / "Dockerfile")
                            .SetPath(RootDirectory / UnityContainerProjectName)
                            .SetTag(ServerContainerTag)
                            // unfortunately docker logs to std::err which is annoying...
                            .SetQuiet(true)
                );

                DockerImagePrune();
            });
}
