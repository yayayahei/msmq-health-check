namespace MSMQHealthCheck
{
    public class QueueManager
    {
        private readonly string _pathName;

        public QueueManager(string pathName)
        {
            _pathName = pathName;
        }
    }
}