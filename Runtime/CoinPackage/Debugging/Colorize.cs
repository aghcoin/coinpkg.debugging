using UnityEngine;

namespace CoinPackage.Debugging {
    public class Colorize {
        public static Colorize Default = new Colorize(Color.gray);

        public static Colorize White = new Colorize(Color.white);
        public static Colorize Red = new Colorize(Color.red);
        public static Colorize Yellow = new Colorize(Color.yellow);
        public static Colorize Green = new Colorize(Color.green);
        public static Colorize Blue = new Colorize(Color.blue);
        public static Colorize Cyan = new Colorize(Color.cyan);
        public static Colorize Magenta = new Colorize(Color.magenta);
        
        public static Colorize Orange = new Colorize("#FFA500");
        public static Colorize Olive  = new Colorize("#808000");
        public static Colorize Purple  = new Colorize("#800080");
        public static Colorize DarkRed  = new Colorize("#8B0000");
        public static Colorize DarkGreen  = new Colorize("#006400");
        public static Colorize DarkOrange  = new Colorize("#FF8C00");
        public static Colorize Gold  = new Colorize("#FFD700");

        private readonly string _prefix;
        private const string Suffix = "</color>";

        public static string ColorizeText(object message, Colorize color) {
            return message.ToString() % color;
        }
        
        public static string ColorizeText(object message, Color color) {
            return message.ToString() % new Colorize(color);
        }
        
        public static string ColorizeText(object message, string hexColor) {
            return message.ToString() % new Colorize(hexColor);
        }
        
        public Colorize(Color color) {
            _prefix = $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>";
        }

        public Colorize(string hexColor) {
            _prefix = $"<color={hexColor}>";
        }

        public static string operator %(string text, Colorize color) {
            return color._prefix + text + Suffix;
        }
        
        public static string operator %(object text, Colorize color) {
            return color._prefix + text + Suffix;
        }
    }
}