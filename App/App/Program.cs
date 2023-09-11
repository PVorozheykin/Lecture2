using Serilog;


namespace App;

internal class Program
{
    static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Console()
            .WriteTo.File("log/log.log")
            .CreateLogger();

        Log.Debug("Application start");

        // Run



        Log.Debug("Application stop");
        Log.CloseAndFlush();
    }
}