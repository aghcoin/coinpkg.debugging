using UnityEngine;

namespace CoinPackage.Debugging {
    /// <summary>
    /// Used to colorize text.
    /// </summary>
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

        /// <summary>
        /// Colorize text using specified Colorize object.
        /// </summary>
        /// <param name="message">Object, which string representation will be colorized.</param>
        /// <param name="color">Colorize object, specifies color to colorize with.</param>
        /// <returns>Colorized string.</returns>
        public static string ColorizeText(object message, Colorize color) {
            return message.ToString() % color;
        }
        
        /// <summary>
        /// Colorize text using specified Color.
        /// </summary>
        /// <param name="message">Object, which string representation will be colorized.</param>
        /// <param name="color">Unity's Color object, specifies color to colorize with.</param>
        /// <returns></returns>
        public static string ColorizeText(object message, Color color) {
            return message.ToString() % new Colorize(color);
        }
        
        /// <summary>
        /// Colorize text using specified hex string of a color.
        /// </summary>
        /// <param name="message">Object, which string representation will be colorized.</param>
        /// <param name="hexColor">Hex representation of the color to colorize with.</param>
        /// <returns></returns>
        public static string ColorizeText(object message, string hexColor) {
            return message.ToString() % new Colorize(hexColor);
        }
        
        /// <summary>
        /// Returns Colorize class created from supplied Color class.
        /// </summary>
        /// <param name="color">Unity's Color object.</param>
        public Colorize(Color color) {
            _prefix = $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>";
        }

        /// <summary>
        /// Returns Colorize class created from supplied hex color representation.
        /// </summary>
        /// <param name="hexColor">Hex representation of the color.</param>
        public Colorize(string hexColor) {
            _prefix = $"<color={hexColor}>";
        }

        // /// <summary>
        // /// Colorize text supplied on left-side of the operator with color specified by
        // /// Colorize object on the right-side of the operator.
        // /// </summary>
        // /// <param name="text">Text to be colorized.</param>
        // /// <param name="color">Colorize object to colorize with.</param>
        // /// <returns>Colorized string.</returns>
        // /// <example>This example will colorize 'this' word to be red.
        // /// <code>
        // /// CDebug.Log($"I want {"this" % Colorize.Red} to be red.");
        // /// </code>
        // /// </example>
        // public static string operator %(string text, Colorize color) {
        //     return color._prefix + text + Suffix;
        // }
        
        /// <summary>
        /// Colorize string representation of the object supplied on left-side of
        /// the operator with color specified by
        /// Colorize object on the right-side of the operator.
        /// </summary>
        /// <param name="text">Text to be colorized.</param>
        /// <param name="color">Colorize object to colorize with.</param>
        /// <returns>Colorized string.</returns>
        /// <example>This example will colorize 'this' word to be red.
        /// <code>
        /// CDebug.Log($"I want {"this" % Colorize.Red} to be red.");
        /// </code>
        /// </example>
        public static string operator %(object text, Colorize color) {
            return color._prefix + text + Suffix;
        }
    }
}