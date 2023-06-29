using System;
using UnityEngine;

namespace CoinPackage.Logging {
    public class CoinLogger {

        public struct TagDecoratorPair {
            public string First;
            public string Second;
        }

        public static bool GlobalLogEnabled = true;
        public static bool ForceAllLoggersEnabled = false;
        public static ILogHandler DefaultLogHandler = Debug.unityLogger.logHandler;
        public static TagDecoratorPair DefaultTagDecorator = new TagDecoratorPair {
            First = "[",
            Second = "]"
        };
        public static Colorize DefaultInfoColor = Colorize.White;
        public static Colorize DefaultWarningColor = Colorize.Yellow;
        public static Colorize DefaultErrorColor = Colorize.Red;
        public static Colorize DefaultExceptionColor = Colorize.DarkRed;

        public static string DebugPrefix = "[DEBUG] ";
        public static Colorize DebugInfoColor = Colorize.White;
        public static Colorize DebugWarningColor = Colorize.Yellow;
        public static Colorize DebugErrorColor = Colorize.Red;
        public static Colorize DebugExceptionColor = Colorize.DarkRed;
        
        public Colorize InfoColor = DefaultInfoColor;
        public Colorize WarningColor = DefaultWarningColor;
        public Colorize ErrorColor = DefaultErrorColor;
        public Colorize ExceptionColor = DefaultExceptionColor;

        public bool LogEnabled {
            get => _logger.logEnabled;
            set {
                if (!GlobalLogEnabled) {
                    _logger.logEnabled = false;
                }else if (ForceAllLoggersEnabled) {
                    _logger.logEnabled = true;
                }
                else {
                    _logger.logEnabled = value;
                }
            }
        }

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

        public CoinLogger(object context) {
            _logger = new Logger(DefaultLogHandler);
            _context = context;
            LogEnabled = true;
            TagDecorator = DefaultTagDecorator;
        }

        public CoinLogger(object context, ILogHandler logHandler) {
            _logger = new Logger(logHandler);
            _context = context;
            LogEnabled = true;
            TagDecorator = DefaultTagDecorator;
        }
        
        // ===== Static Functions =====

        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogDebug(object message) {
            Debug.Log((DebugPrefix + message) % DebugInfoColor);
        }
        
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogDebug(object message, Colorize color) {
            Debug.Log((DebugPrefix + message) % color);
        }

        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogWarningDebug(object message) {
            Debug.LogWarning((DebugPrefix + message) % DebugWarningColor);
        }
        
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogWarningDebug(object message, Colorize color) {
            Debug.LogWarning((DebugPrefix + message) % color);
        }

        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogErrorDebug(object message) {
            Debug.LogWarning((DebugPrefix + message) % DebugWarningColor);
        }
        
        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogErrorDebug(object message, Colorize color) {
            Debug.LogWarning((DebugPrefix + message) % color);
        }

        [System.Diagnostics.Conditional("DEBUG")]
        public static void LogExceptionDebug(Exception exception) {
            Debug.LogException(exception);
        }

        // ===== Info Log =====
        
        public void Log(object message) {
            _logger.Log(_tag % InfoColor, message % InfoColor);
        }
        
        public void Log(object message, Colorize color) {
            _logger.Log(_tag % color, message % color);
        }
        
        public void Log(object message, UnityEngine.Object context) {
            _logger.Log(_tag % InfoColor, message % InfoColor, context);
        }
        
        public void Log(object message, UnityEngine.Object context, Colorize color) {
            _logger.Log(_tag % color, message % color, context);
        }
        
        // ===== Info Warning =====
        
        private string CreateTag(object tag, TagDecoratorPair tagDecorator) {
            return tagDecorator.First + tag + tagDecorator.Second;
        }
    }
}