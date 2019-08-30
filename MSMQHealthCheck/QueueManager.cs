using System.Messaging;

namespace MSMQHealthCheck
{
    /// <summary>
    /// manage a queue
    /// </summary>
    public class QueueManager
    {
        private readonly string _pathName;
        private readonly string _formatName;

        public MessageQueue MessageQueue { get; set; }

        public QueueManager(string pathName, string formatName)
        {
            _pathName = pathName;
            _formatName = formatName;
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

        /// <summary>
        /// this can be used to check remote queue existence
        /// </summary>
        /// <returns></returns>
        public bool CanWrite()
        {
            MessageQueue = new MessageQueue($"FormatName:{_formatName}");
            return MessageQueue.CanWrite;
        }
    }
}