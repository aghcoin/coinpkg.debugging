using System;
using UnityEngine;

namespace CoinPackage.Debugging {
    public class CLogger {

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

        public Colorize InfoColor = DefaultInfoColor;
        public Colorize WarningColor = DefaultWarningColor;
        public Colorize ErrorColor = DefaultErrorColor;

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

        public CLogger(object context) {
            _logger = new Logger(DefaultLogHandler);
            _context = context;
            LogEnabled = true;
            TagDecorator = DefaultTagDecorator;
        }

        public CLogger(object context, ILogHandler logHandler) {
            _logger = new Logger(logHandler);
            _context = context;
            LogEnabled = true;
            TagDecorator = DefaultTagDecorator;
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
        
        // ===== Warning =====
        public void LogWarning(object message) {
            _logger.LogWarning(_tag % WarningColor, message % WarningColor);
        }
        
        public void LogWarning(object message, Colorize color) {
            _logger.LogWarning(_tag % color, message % color);
        }
        
        public void LogWarning(object message, UnityEngine.Object context) {
            _logger.LogWarning(_tag % WarningColor, message % WarningColor, context);
        }
        
        public void LogWarning(object message, UnityEngine.Object context, Colorize color) {
            _logger.LogWarning(_tag % color, message % color, context);
        }
        
        // ===== Error =====
        public void LogError(object message) {
            _logger.LogWarning(_tag % ErrorColor, message % ErrorColor);
        }
        
        public void LogError(object message, Colorize color) {
            _logger.LogWarning(_tag % color, message % color);
        }
        
        public void LogError(object message, UnityEngine.Object context) {
            _logger.LogWarning(_tag % ErrorColor, message % ErrorColor, context);
        }
        
        public void LogError(object message, UnityEngine.Object context, Colorize color) {
            _logger.LogWarning(_tag % color, message % color, context);
        }
        
        // ===== Exception =====
        public void LogException(Exception exception) {
            _logger.LogException(exception);
        }
        
        public void LogException(Exception exception, UnityEngine.Object context) {
            _logger.LogException(exception, context);
        }
        
        // ===== Format =====
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
        
        public void LogFormat(LogType logType, string format, Colorize color, params object[] args) {
            _logger.LogFormat(logType, (_tag + format) % color, args);
        }
        
        private string CreateTag(object tag, TagDecoratorPair tagDecorator) {
            return tagDecorator.First + tag + tagDecorator.Second;
        }
    }
}