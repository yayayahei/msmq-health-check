using System;
using System.Messaging;
using System.Text;

namespace MSMQHealthCheck
{
    /// <summary>
    /// manage a queue
    /// </summary>
    public class QueueManager
    {
        private readonly string _pathName;
        private readonly string _formatName;
        private static readonly object _lock = new object();

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
            MessageQueue = new MessageQueue(_pathName);
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

        public void SendHello()
        {
            MessageQueue.Send("Hello");
        }

        public Message GetMessage()
        {
            try
            {
                MessageQueue.Formatter = new XmlMessageFormatter(new Type[] {typeof(string)});
                lock (_lock)
                {
                    var message = MessageQueue.Receive();
                    return message;
                }
            }
            catch (MessageQueueException messageQueueException)
            {
                StringBuilder log = new StringBuilder(messageQueueException.Message);
                log.AppendLine($"MessageQueueErrorCode: {messageQueueException.MessageQueueErrorCode}");
                log.AppendLine($"ErrorCode: {messageQueueException.ErrorCode}");
                log.AppendLine($"InnerException: {messageQueueException.InnerException}");
                log.AppendLine($"StackTrace: {messageQueueException.StackTrace}");
                log.AppendLine($"Exception string: {messageQueueException}");
                
                Console.WriteLine(log.ToString());
            }

            return null;
        }
    }
}