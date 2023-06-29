using System;
using UnityEngine;

namespace CoinPackage.Debugging {
    /// <summary>
    /// CDebug class is used to replace default Debug logging. It implements the same
    /// functions, but supports debug coloring, easy ON/OFF and disables by
    /// default in production builds.
    /// </summary>
    public class CDebug {

        /// <summary>
        /// Default Color for CDebug.Log and LogType.Log.
        /// </summary>
        public static Colorize DebugInfoColor = Colorize.White;
        /// <summary>
        /// Default Color for CDebug.Warning and LogType.Warning.
        /// </summary>
        public static Colorize DebugWarningColor = Colorize.Yellow;
        /// <summary>
        /// Default Color for CDebug.Error and LogType.Error.
        /// </summary>
        public static Colorize DebugErrorColor = Colorize.Red;

        /// <summary>
        /// Whether to turn on default Unity Debugging (e.g. Debug.Log).
        /// </summary>
        public static bool UnityDebugLogging {
            get => Debug.unityLogger.logEnabled;
            set => Debug.unityLogger.logEnabled = value;
        }

        /// <summary>
        /// Whether to turn on CDebug logs.
        /// </summary>
        /// <remarks>
        /// Note that in production builds logs are disabled regardless of this setting.
        /// </remarks>
        public static bool DebugLogging {
            get => DLogger.logEnabled;
            set => DLogger.logEnabled = value;
        }
        
        private const string Tag = "[CDEBUG] ";
        private static readonly Logger DLogger;
        
        static CDebug() {
            DLogger = new Logger(Debug.unityLogger.logHandler);
            UnityDebugLogging = true;
            DebugLogging = true;
        }
        
        /// <summary>
        /// Logs message to the Unity console using DebugInfoColor.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void Log(object message) {
            DLogger.Log(Tag % DebugInfoColor, message % DebugInfoColor);
        }
        
        /// <summary>
        /// Logs message to the Unity console using specified color.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="color">Color of the message.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void Log(object message, Colorize color) {
            DLogger.Log(Tag % color, message % color);
        }
        
        /// <summary>
        /// Logs message to the Unity console using DebugInfoColor.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="context">Object to which the message applies.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void Log(object message, UnityEngine.Object context) {
            DLogger.Log(Tag % DebugInfoColor, Tag % DebugInfoColor, context);
        }
        
        /// <summary>
        /// Logs message to the Unity console using specified color.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="color">Color of the message.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void Log(object message, UnityEngine.Object context, Colorize color) {
            DLogger.Log(Tag % color, message % color, context);
        }
        
        /// <summary>
        /// Logs warning message to the Unity console using DebugWarningColor.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogWarning(object message) {
            DLogger.LogWarning(Tag % DebugWarningColor, message % DebugWarningColor);
        }
        
        /// <summary>
        /// Logs warning message to the Unity console using specified color.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="color">Color of the message.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogWarning(object message, Colorize color) {
            DLogger.LogWarning(Tag % color, message % color);
        }
        
        /// <summary>
        /// Logs warning message to the Unity console using DebugWarningColor.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="context">Object to which the message applies.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogWarning(object message, UnityEngine.Object context) {
            DLogger.LogWarning(Tag % DebugWarningColor, message % DebugWarningColor, context);
        }
        
        /// <summary>
        /// Logs warning message to the Unity console using specified color.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="color">Color of the message.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogWarning(object message, UnityEngine.Object context, Colorize color) {
            DLogger.LogWarning(Tag % color, message % color, context);
        }
        
        /// <summary>
        /// Logs error message to the Unity console using DebugErrorColor.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogError(object message) {
            DLogger.LogError(Tag % DebugErrorColor, message % DebugErrorColor);
        }
        
        /// <summary>
        /// Logs error message to the Unity console using specified color.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="color">Color of the message.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogError(object message, Colorize color) {
            DLogger.LogError(Tag % color, message % color);
        }
        
        /// <summary>
        /// Logs error message to the Unity console using DebugErrorColor.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="context">Object to which the message applies.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogError(object message, UnityEngine.Object context) {
            DLogger.LogError(Tag % DebugErrorColor, message % DebugErrorColor, context);
        }
        
        /// <summary>
        /// Logs error message to the Unity console using specified color.
        /// </summary>
        /// <param name="message">Message to be logged.</param>
        /// <param name="context">Object to which the message applies.</param>
        /// <param name="color">Color of the message.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogError(object message, UnityEngine.Object context, Colorize color) {
            DLogger.LogError(Tag % color, message % color, context);
        }
        
        /// <summary>
        /// Logs exception message.
        /// </summary>
        /// <param name="exception"></param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogException(Exception exception) {
            DLogger.LogException(exception);
        }
        
        /// <summary>
        /// Logs exception message.
        /// </summary>
        /// <param name="exception">Runtime Exception.</param>
        /// <param name="context">Object to which the exception applies.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogException(Exception exception, UnityEngine.Object context) {
            DLogger.LogException(exception, context);
        }
        
        /// <summary>
        /// Logs formatted message to Unity console. Color depends on LogType supplied.
        /// </summary>
        /// <param name="logType">Type of the log message.</param>
        /// <param name="format">Composite format string.</param>
        /// <param name="args">Format arguments.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogFormat(LogType logType, string format, params object[] args) {
            Colorize color;
            switch (logType) {
                case LogType.Log:
                    color = DebugInfoColor;
                    break;
                case LogType.Warning:
                    color = DebugWarningColor;
                    break;
                case LogType.Error:
                    color = DebugErrorColor;
                    break;
                default:
                    color = DebugInfoColor;
                    break;
            }
            DLogger.LogFormat(logType, (Tag + format) % color, args);
        }
        
        /// <summary>
        /// Logs formatted message to Unity console. Color depends on LogType supplied.
        /// </summary>
        /// <param name="logType">Type of the log message.</param>
        /// <param name="format">Composite format string.</param>
        /// <param name="color">Color of the message.</param>
        /// <param name="args">Format arguments.</param>
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogFormat(LogType logType, string format, Colorize color, params object[] args) {
            DLogger.LogFormat(logType, (Tag + format) % color, args);
        }
    }
}