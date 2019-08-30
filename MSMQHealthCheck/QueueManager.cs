using System.Messaging;

namespace MSMQHealthCheck
{
    /// <summary>
    /// manage a queue
    /// </summary>
    public class QueueManager
    {
        private readonly string _pathName;
        public MessageQueue MessageQueue { get; set; }

        public QueueManager(string pathName)
        {
            _pathName = pathName;

            if (Exist())
            {
                MessageQueue = new MessageQueue(_pathName);
            }
        }

        /// <summary>
        /// check the queue exists or not
        /// only worked for local msmq
        /// </summary>
        /// <returns></returns>
        public bool Exist()
        {
            return MessageQueue.Exists(_pathName);
        }
    }
}