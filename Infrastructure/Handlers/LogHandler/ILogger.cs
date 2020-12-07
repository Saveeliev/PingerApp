namespace Infrastructure.Handlers.LogHandler
{
    public interface ILogger
    {
        public void LogHandler(object sender, PingHandlerArgs eventArgs);
    }
}