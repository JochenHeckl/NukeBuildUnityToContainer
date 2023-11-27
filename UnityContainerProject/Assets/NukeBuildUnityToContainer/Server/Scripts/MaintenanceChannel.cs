using System.Threading;
using System.Threading.Tasks;
using Serilog;
using UnityEngine;

public class MaintenanceChannel : MonoBehaviour
{
    private CancellationTokenSource cancellationTokenSource;
    private Task sendHeartbeatTask;

    private void Start()
    {
        cancellationTokenSource = new CancellationTokenSource();
        sendHeartbeatTask = Task.Run(() => SendHeartbeat(cancellationTokenSource.Token));
    }

    private async void OnDestroy()
    {
        cancellationTokenSource.Cancel();
        await sendHeartbeatTask;
    }

    private static async Task SendHeartbeat(CancellationToken cancellationToken)
    {
        while (!cancellationToken.IsCancellationRequested)
        {
            // send Heartbeat to maintenance server
            Log.Information("Sending Server Heartbeat.");
            await Task.Delay(5000, cancellationToken);
        }
    }
}
