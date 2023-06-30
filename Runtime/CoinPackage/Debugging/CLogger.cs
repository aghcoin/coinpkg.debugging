using System;
using UnityEngine;

namespace CoinPackage.Debugging {
    /// <summary>
    /// Replaces default logger. Supports automatic Tag handling, log colouring,
    /// easy on/off and different log handlers.
    /// </summary>
    public class CLogger {

        /// <summary>
        /// Represents pair of strings surrounding log tag.
        /// </summary>
        public struct TagDecoratorPair {
            public string First;
            public string Second;
        }

        /// <summary>
        /// Whether to enable loggers. When set to false, it overrides each logger
        /// instance settings and disables them.
        /// </summary>
        public static bool GlobalLogEnabled = true;
        
        /// <summary>
        /// Whether to force all loggers to be enabled. When set to true, it overrides
        /// each logger settings and enables them. Will not work if `GlobalLogEnabled` is
        /// set to false.
        /// </summary>
        public static bool ForceAllLoggersEnabled = false;
        
        /// <summary>
        /// Defines default log handler for newly created loggers.
        /// </summary>
        public static ILogHandler DefaultLogHandler = Debug.unityLogger.logHandler;
        
        /// <summary>
        /// Defines default tag decorator for newly created loggers.
        /// </summary>
        public static TagDecoratorPair DefaultTagDecorator = new TagDecoratorPair {
            First = "[",
            Second = "]"
        };
        
        /// <summary>
        /// Default color of normal log messages for newly created loggers.
        /// </summary>
        public static Colorize DefaultInfoColor = Colorize.White;
        
        /// <summary>
        /// Default color of warning messages for newly created loggers.
        /// </summary>
        public static Colorize DefaultWarningColor = Colorize.Yellow;
        
        /// <summary>
        /// Default color of error messages for newly created loggers.
        /// </summary>
        public static Colorize DefaultErrorColor = Colorize.Red;

        /// <summary>
        /// Color of normal log messages.
        /// </summary>
        public Colorize InfoColor = DefaultInfoColor;
        
        /// <summary>
        /// Color of warning messages.
        /// </summary>
        public Colorize WarningColor = DefaultWarningColor;
        
        /// <summary>
        /// Color of error messages.
        /// </summary>
        public Colorize ErrorColor = DefaultErrorColor;

        /// <summary>
        /// Whether this instance of logger should be enabled. This setting might
        /// be overwritten by class fields `GlobalLogEnabled` and `ForceAllLoggersEnabled`.
        /// </summary>
        public bool LogEnabled {
            get => _logger.logEnabled;
            set {
                if (!GlobalLogEnabled) {
                    _logger.logEnabled = false;
                }else if (ForceAllLoggersEnabled) {
                    _logger.logEnabled = true;
                }else {
                    _logger.logEnabled = value;
                }
            }
        }

        /// <summary>
        /// Sets tag decorators for this instance of logger.
        /// </summary>
        public TagDecoratorPair TagDecorator {
            get => _tagDecorator;
            set {
                _tagDecorator = value;
                _tag = CreateTag(_context, _tagDecorator);
            }
        }

        private readonly Logger _logger;
        private readonly object _context;
        private string _tag;
        private TagDecoratorPair _tagDecorator;

        /// <summary>
        /// Creates default logger.
        /// </summary>
        /// <param name="tag">Tag wich will distinguish this logger.</param>
        public CLogger(object tag) {
            _logger = new Logger(DefaultLogHandler);
            _context = tag;
            LogEnabled = true;
            TagDecorator = DefaultTagDecorator;
        }

        /// <summary>
        /// Creates logger with specified log handler.
        /// </summary>
        /// <param name="tag">Tag wich will distinguish this logger.</param>
        /// <param name="logHandler">Log handler to be used by this logger.</param>
        public CLogger(object tag, ILogHandler logHandler) {
            _logger = new Logger(logHandler);
            _context = tag;
            LogEnabled = true;
            TagDecorator = DefaultTagDecorator;
        }

        // ===== Info Log =====
        
        /// <summary>
        /// Logs message to the Unity console using InfoColor.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        public void Log(object message) {
            _logger.Log(_tag % InfoColor, message % InfoColor);
        }
        
        /// <summary>
        /// Logs message to the Unity console using specified color.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="color">Color of the message.</param>
        public void Log(object message, Colorize color) {
            _logger.Log(_tag % color, message % color);
        }
        
        /// <summary>
        /// Logs message to the Unity console using InfoColor.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="context">Object to which the message applies.</param>
        public void Log(object message, UnityEngine.Object context) {
            _logger.Log(_tag % InfoColor, message % InfoColor, context);
        }
        
        /// <summary>
        /// Logs message to the Unity console using specified color.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="color">Color of the message.</param>
        public void Log(object message, UnityEngine.Object context, Colorize color) {
            _logger.Log(_tag % color, message % color, context);
        }
        
        // ===== Warning =====
        
        /// <summary>
        /// Logs warning message to the Unity console using WarningColor.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        public void LogWarning(object message) {
            _logger.LogWarning(_tag % WarningColor, message % WarningColor);
        }
        
        /// <summary>
        /// Logs warning message to the Unity console using specified color.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="color">Color of the message.</param>
        public void LogWarning(object message, Colorize color) {
            _logger.LogWarning(_tag % color, message % color);
        }
        
        /// <summary>
        /// Logs warning message to the Unity console using WarningColor.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="context">Object to which the message applies.</param>
        public void LogWarning(object message, UnityEngine.Object context) {
            _logger.LogWarning(_tag % WarningColor, message % WarningColor, context);
        }
        
        // <summary>
        /// Logs warning message to the Unity console using specified color.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="color">Color of the message.</param>
        public void LogWarning(object message, UnityEngine.Object context, Colorize color) {
            _logger.LogWarning(_tag % color, message % color, context);
        }
        
        // ===== Error =====
        
        /// <summary>
        /// Logs error message to the Unity console using ErrorColor.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        public void LogError(object message) {
            _logger.LogWarning(_tag % ErrorColor, message % ErrorColor);
        }
        
        /// <summary>
        /// Logs error message to the Unity console using specified color.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="color">Color of the message.</param>
        public void LogError(object message, Colorize color) {
            _logger.LogWarning(_tag % color, message % color);
        }
        
        /// <summary>
        /// Logs error message to the Unity console using ErrorColor.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="context">Object to which the message applies.</param>
        public void LogError(object message, UnityEngine.Object context) {
            _logger.LogWarning(_tag % ErrorColor, message % ErrorColor, context);
        }
        
        /// <summary>
        /// Logs error message to the Unity console using specified color.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="color">Color of the message.</param>
        public void LogError(object message, UnityEngine.Object context, Colorize color) {
            _logger.LogWarning(_tag % color, message % color, context);
        }
        
        // ===== Exception =====
        
        /// <summary>
        /// Logs exception message.
        /// </summary>
        /// <param name="exception"></param>
        public void LogException(Exception exception) {
            _logger.LogException(exception);
        }
        
        /// <summary>
        /// Logs exception message.
        /// </summary>
        /// <param name="exception">Runtime Exception.</param>
        /// <param name="context">Object to which the exception applies.</param>
        public void LogException(Exception exception, UnityEngine.Object context) {
            _logger.LogException(exception, context);
        }
        
        // ===== Format =====
        
        /// <summary>
        /// Logs formatted message to Unity console. Color depends on LogType supplied.
        /// </summary>
        /// <param name="logType">Type of the log message.</param>
        /// <param name="format">Composite format string.</param>
        /// <param name="args">Format arguments.</param>
        public void LogFormat(LogType logType, string format, params object[] args) {
            Colorize color;
            switch (logType) {
                case LogType.Log:
                    color = InfoColor;
                    break;
                case LogType.Warning:
                    color = WarningColor;
                    break;
                case LogType.Error:
                    color = ErrorColor;
                    break;
                default:
                    color = InfoColor;
                    break;
            }
            _logger.LogFormat(logType, (_tag + format) % color, args);
        }
        
        /// <summary>
        /// Logs formatted message to Unity console using specified color.
        /// </summary>
        /// <param name="logType">Type of the log message.</param>
        /// <param name="format">Composite format string.</param>
        /// <param name="color">Color of the message.</param>
        /// <param name="args">Format arguments.</param>
        public void LogFormat(LogType logType, string format, Colorize color, params object[] args) {
            _logger.LogFormat(logType, (_tag + format) % color, args);
        }
        
        private string CreateTag(object tag, TagDecoratorPair tagDecorator) {
            return tagDecorator.First + tag + tagDecorator.Second;
        }
    }
}