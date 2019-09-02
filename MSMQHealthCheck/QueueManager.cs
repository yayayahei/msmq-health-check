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
            if (!string.IsNullOrWhiteSpace(_pathName))
            {
                MessageQueue = new MessageQueue(_pathName);
                return;
            }

            if (!string.IsNullOrWhiteSpace(_formatName))
            {
                MessageQueue = new MessageQueue($"FormatName:{_formatName}");
            }
        }

        public override string ToString()
        {
            if (MessageQueue == null) return base.ToString();
            
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Can Read? :{MessageQueue.CanRead}");
            stringBuilder.AppendLine($"Can Write? :{MessageQueue.CanWrite}");
            stringBuilder.AppendLine($"AccessMode? :{MessageQueue.AccessMode}");
            stringBuilder.AppendLine($"DenySharedReceive? :{MessageQueue.DenySharedReceive}");
                
            return stringBuilder.ToString();

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