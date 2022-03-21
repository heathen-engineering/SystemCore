#if HE_SYSCORE
using System;
using UnityEngine;

namespace HeathenEngineering
{
    /// <summary>
    /// Helper class for command line features
    /// </summary>
    public static class CommandLine
    {
        /// <summary>
        /// Common commands to check for based on Steam and Unity arguments
        /// </summary>
        public static class CommonCommands
        {
            /// <summary>
            /// Used by Steam Client to indicate the lobby a user accepted the invite for, the following value will be a ulong
            /// </summary>
            public static string SteamLobbyConnect = "+connect_lobby";
            /// <summary>
            /// Used by some Steam gamers on Source based games to request windowed mode
            /// </summary>
            public static string SteamStartWindowed = "-windowed";
            /// <summary>
            /// Used by some Steam gamers on Source based games to request reset of graphics and performance settings to auto
            /// </summary>
            public static string SteamAutoConfig = "-autoconfig";
            /// <summary>
            /// Unity engine command to force Graphics to DX11
            /// </summary>
            public static string UnityForceD3D11 = "-force-d3d11";
            /// <summary>
            /// Unity engine command to force Graphics to GL Core
            /// </summary>
            public static string UnityForceGlCore = "-force-glcore";
            /// <summary>
            /// Unity engine command to force Graphics to Vulkan
            /// </summary>
            public static string UnityForceVulkan = "-force-vulkan";
            /// <summary>
            /// Unity engine command to set the Quality Setting to the name specified. The next value will be the string name of the desired quality level as set in the Unity Quality Settings
            /// </summary>
            public static string UnityScreenQuality = "-screen-quality";
            /// <summary>
            /// Unity engine command to set the height of the screen the next value will be the int size desired
            /// </summary>
            public static string UnityScreenWidth = "-screen-height";
            /// <summary>
            /// Unity engine command to set the width of the screen the next value will be the int size desired
            /// </summary>
            public static string UnityScreenHeight = "-screen-width";
        }

        /// <summary>
        /// This returns the argments passed in on the initalization call of the applicaiton
        /// </summary>
        /// <remarks>
        /// <para>
        /// For WebGL and Android platforms this reads the applicaiton absolute URL and parses for URL style variables e.g. 
        /// <code>example.com?arg1=value1&amp;arg2&amp;arg3=77</code>
        /// This will result in an array { arg1, value1, arg2, arg3, 77 }
        /// </para>
        /// <para>
        /// For all other platforms the assumption is Environment.GetCommandLineArgs please review the C# documentaiton for System.Environment.GetCommandLineArgs() for full details.
        /// </para>
        /// </remarks>
        /// <returns></returns>
        public static string[] GetArguments()
        {
#if (UNITY_WEBGL || UNITY_ANDROID)
            string parameters = Application.absoluteURL.Substring(Application.absoluteURL.IndexOf("?") + 1);
            return parameters.Split(new char[] { '&', '=' });
#else
            return Environment.GetCommandLineArgs();
#endif
        }

        public static string GetArgumentLine()
        {
#if (UNITY_WEBGL || UNITY_ANDROID)
            return Application.absoluteURL;
#else
            return Environment.CommandLine;
#endif
        }

        /// <summary>
        /// Checks the command line for the +connect_lobby argument and returns the value if found
        /// </summary>
        /// <returns>The value of +connect_lobby if present else 0</returns>
        public static ulong GetSteamLobbyInvite()
        {
            var args = Environment.GetCommandLineArgs();
            ulong value = 0;
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == CommonCommands.SteamLobbyConnect && i + 1 < args.Length && ulong.TryParse(args[i + 1], out value))
                    return value;
            }

            return value;
        }

        /// <summary>
        /// Returns true if the -autoconfig argument was passed in
        /// </summary>
        /// <remarks>
        /// <para>
        /// This is a common command line argument used by gamers where the intent is to have the game reset quality and performance settings to default/auto.
        /// Its offten used to attempt to recover from bad/erred graphics settings. You should handle this if present and reset the graphics and performance settings of your game.
        /// </para>
        /// </remarks>
        /// <returns></returns>
        public static bool GetAutoConfig()
        {
            var args = GetArguments();
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == CommonCommands.SteamAutoConfig)
                    return true;
            }

            return false;
        }
    }
}
#endif