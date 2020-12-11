namespace Infrastructure.Handlers.LogHandler
{
    public interface ILogHandler
    {
        public void LogHandler(object sender, PingHandlerArgs eventArgs);
    }
}