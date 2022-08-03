using Microsoft.Extensions.Logging;
using System;

namespace PowerfulSpace.Facts.Web.Extensions
{

    static class EventIdentifiers
    {

        public static readonly EventId DatabaseSavingErrorId = new EventId(70040001, "DatabaseSavingError");
        public static readonly EventId NotificationAddedId = new EventId(70040002, "NotificationAdded");
        public static readonly EventId NotificationProcessedId = new EventId(70040003, "NotificationProcessed");
    }


    public static class LoggerExtensions
    {


        public static void NotificationProcessed(this ILogger source, string message)
        {
            NotificationProcessedExecute(source, message, null);
        }

        private static readonly Action<ILogger, string, Exception?> NotificationProcessedExecute =
            LoggerMessage.Define<string>(LogLevel.Information, EventIdentifiers.NotificationProcessedId, "Processing for notification started: {message}");




        public static void NotificationAdded(this ILogger source, string subject)
        {
            NotificationAddedExecute(source, subject, null);
        }

        private static readonly Action<ILogger, string, Exception?> NotificationAddedExecute =
            LoggerMessage.Define<string>(LogLevel.Information, EventIdentifiers.NotificationAddedId, "New notification created: {subject}");





        public static void DatabaseSavingError(this ILogger source, string entityName, Exception? exception = null)
        {
            DatabaseSavingErrorExecute(source, entityName, exception);
        }

        private static readonly Action<ILogger, string, Exception?> DatabaseSavingErrorExecute =
            LoggerMessage.Define<string>(LogLevel.Error, EventIdentifiers.DatabaseSavingErrorId, " {entityName}");

    }
}
