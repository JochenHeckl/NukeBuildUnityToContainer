using System;
using UnityEditor;
using UnityEngine;

[Serializable]
[CreateAssetMenu(fileName = "NewBuildSettings", menuName = "Build/Create Build Settings")]
public class BuildSettings : ScriptableObject
{
    public SceneAsset[] scenes = { };
    public BuildTarget target;
    public StandaloneBuildSubtarget subtarget;
    public BuildOptions buildOptions;
    public BuildTargetGroup targetGroup;
    public ScriptingImplementation scriptingImplementation;
    public BuildTargetGroup namedBuildTarget;
    public ApiCompatibilityLevel apiCompatibilityLevel;
}
