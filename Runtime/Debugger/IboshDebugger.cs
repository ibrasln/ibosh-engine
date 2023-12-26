using UnityEngine;

namespace IboshEngine.Runtime.Debugger
{
    public static class IboshDebugger
    {
        public enum DebugColor
        {
            Black,
            Blue,
            Cyan,
            Gray,
            Green,
            Grey,
            Magenta,
            Red,
            White,
            Yellow
        }

        public static void LogMessage(string message)
        {
            if (!Debug.isDebugBuild) return;

            Debug.Log(message);
        }

        public static void LogMessage(string message, DebugColor messageColor)
        {
            if (!Debug.isDebugBuild) return;

            Debug.Log($"<color={DebugColorValue(messageColor)}> {message}</color>");
        }

        public static void LogMessage(string message, string header, DebugColor messageColor, DebugColor headerColor)
        {
            if (!Debug.isDebugBuild) return;

            Debug.Log($"<color={DebugColorValue(headerColor)}> [{header}] </color> <color={DebugColorValue(messageColor)}> {message}</color>");
        }

        public static void LogMessage(string[] messages, string header, DebugColor messageColor, DebugColor headerColor)
        {
            if (!Debug.isDebugBuild) return;

            Debug.Log($"<color={DebugColorValue(headerColor)}> [{header}] </color> <color={DebugColorValue(messageColor)}> {string.Join(",", messages)}</color>");
        }

        public static void LogError(string error, string header, DebugColor messageColor, DebugColor headerColor)
        {
            Debug.LogError($"<color={DebugColorValue(headerColor)}> [{header}] </color> <color={DebugColorValue(messageColor)}> {error}</color>");
        }

        public static void LogWarning(string error, string header, DebugColor messageColor, DebugColor headerColor)
        {
            if (!Debug.isDebugBuild) return;

            Debug.LogWarning($"<color={DebugColorValue(headerColor)}> [{header}] </color> <color={DebugColorValue(messageColor)}> {error}</color>");
        }

        private static string DebugColorValue(DebugColor colorEnum)
        {
            return colorEnum switch
            {
                DebugColor.Black => "black",
                DebugColor.Blue => "blue",
                DebugColor.Cyan => "cyan",
                DebugColor.Gray => "gray",
                DebugColor.Green => "green",
                DebugColor.Grey => "grey",
                DebugColor.Magenta => "magenta",
                DebugColor.Red => "red",
                DebugColor.White => "white",
                DebugColor.Yellow => "yellow",

                _ => default
            };
        }
    }

}
