using Serilog;
using Serilog.Sinks.Unity3D;
using UnityEngine;

public class BootstrapServer : MonoBehaviour
{
    private void Awake()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel
            .Information()
            .WriteTo
            .Unity3D()
            .CreateLogger();

        Application.targetFrameRate = 1;
    }
}
