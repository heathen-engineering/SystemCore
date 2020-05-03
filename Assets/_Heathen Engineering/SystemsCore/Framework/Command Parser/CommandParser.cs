using HeathenEngineering.Events;
using HeathenEngineering.Scriptable;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace HeathenEngineering.CommandSystem
{
    /// <summary>
    /// Defines a set of commands and the rules for parsing said commands from various strings.
    /// This is designed to aid the developer in creating emote and other text based command systems such as you might find in MMOs and RPGs
    /// </summary>
    [CreateAssetMenu(menuName = "System Core/Application/Command Parser")]
    [Serializable]
    public class CommandParser : ScriptableObject
    {
        public bool UseCaseSinsativeCommandNames = false;
        public string CommandStartString = "/";
        public List<GameEvent> DeveloperCommands = new List<GameEvent>();
        public List<GameEvent> UserCommands = new List<GameEvent>();
        
        /// <summary>
        /// Attempts to match the input string to a command optionally filtering on user commands only
        /// </summary>
        /// <param name="inputString">The input string to test</param>
        /// <param name="userOnly">Should this only consider user commands</param>
        /// <param name="gameEvent">The command's game event if found</param>
        /// <param name="argument">Any trailing text found after the command</param>
        /// <returns>True if a command was found, False otherwise.</returns>
        public bool TryParseCommand(string inputString, bool userOnly, out GameEvent gameEvent, out string argument)
        {
            if (inputString.StartsWith(CommandStartString))
            {
                if (!userOnly)
                {
                    foreach (var gEvent in DeveloperCommands)
                    {
                        if (inputString.StartsWith(CommandStartString + gEvent.name, UseCaseSinsativeCommandNames ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase))
                        {
                            //If we have no additional characters or the next character is a space
                            if (inputString.Length == CommandStartString.Length + gEvent.name.Length
                                || inputString[CommandStartString.Length + gEvent.name.Length] == ' ')
                            {
                                //Command found
                                gameEvent = gEvent;
                                var working = inputString.Substring(CommandStartString.Length + gEvent.name.Length).Trim();
                                if (working.StartsWith(CommandStartString))
                                    argument = working.Substring(CommandStartString.Length);
                                else
                                    argument = working;
                                return true;
                            }
                        }
                    }
                    foreach (var gEvent in UserCommands)
                    {
                        if (inputString.StartsWith(CommandStartString + gEvent.name, UseCaseSinsativeCommandNames ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase))
                        {
                            //If we have no additional characters or the next character is a space
                            if (inputString.Length == CommandStartString.Length + gEvent.name.Length
                                || inputString[CommandStartString.Length + gEvent.name.Length] == ' ')
                            {
                                //Command found
                                gameEvent = gEvent;
                                var working = inputString.Substring(CommandStartString.Length + gEvent.name.Length).Trim();
                                if (working.StartsWith(CommandStartString))
                                    argument = working.Substring(CommandStartString.Length);
                                else
                                    argument = working;
                                return true;
                            }
                        }
                    }

                    gameEvent = null;
                    argument = string.Empty;
                    return false;
                }
                else
                {
                    foreach (var gEvent in UserCommands)
                    {
                        if (inputString.StartsWith(CommandStartString + gEvent.name, UseCaseSinsativeCommandNames ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase))
                        {
                            //If we have no additional characters or the next character is a space
                            if (inputString.Length == CommandStartString.Length + gEvent.name.Length
                                || inputString[CommandStartString.Length + gEvent.name.Length] == ' ')
                            {
                                //Command found
                                gameEvent = gEvent;
                                var working = inputString.Substring(CommandStartString.Length + gEvent.name.Length).Trim();
                                if (working.StartsWith(CommandStartString))
                                    argument = working.Substring(CommandStartString.Length);
                                else
                                    argument = working;
                                return true;
                            }
                        }
                    }

                    gameEvent = null;
                    argument = string.Empty;
                    return false;
                }
            }
            else
            {
                gameEvent = null;
                argument = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Attempts to match the input string to a command and to raise the matching command event with the provided arguments
        /// </summary>
        /// <param name="inputString">The input string to test</param>
        /// <param name="userOnly">Should this only consider user commands</param>
        /// <param name="errorMessage">Error message if any</param>
        /// <returns>False if an error occured</returns>
        public bool TryCallCommand(string inputString, bool userOnly, out string errorMessage)
        {
            GameEvent gameEvent;
            string argument;
            if (TryParseCommand(inputString, userOnly, out gameEvent, out argument))
            {
                if (gameEvent.GetType() == typeof(StringGameEvent))
                {
                    if (!string.IsNullOrEmpty(argument))
                    {
                        var gEvent = gameEvent as StringGameEvent;
                        gEvent.Raise(argument);
                        errorMessage = string.Empty;
                        return true;
                    }
                    else
                    {
                        errorMessage = "No argument provided.";
                        return false;
                    }
                }
                else if (gameEvent.GetType() == typeof(IntGameEvent))
                {
                    var gEvent = gameEvent as IntGameEvent;
                    int result;
                    if (string.IsNullOrEmpty(argument))
                    {
                        errorMessage = "No argument provided.";
                        return false;
                    }
                    else if (int.TryParse(argument, out result))
                    {
                        gEvent.Raise(result);
                        errorMessage = string.Empty;
                        return true;
                    }
                    else
                    {
                        errorMessage = "Failed to parse \"" + argument + "\" to an int.";
                        return false;
                    }
                }
                else if (gameEvent.GetType() == typeof(FloatGameEvent))
                {
                    var gEvent = gameEvent as FloatGameEvent;
                    float result;
                    if (string.IsNullOrEmpty(argument))
                    {
                        errorMessage = "Failed: No argument provided.";
                        return false;
                    }
                    else if (float.TryParse(argument, out result))
                    {
                        gEvent.Raise(result);
                        errorMessage = string.Empty;
                        return true;
                    }
                    else
                    {
                        errorMessage = "Failed: to parse \"" + argument + "\" to a float.";
                        return false;
                    }
                }
                else if (gameEvent.GetType() == typeof(BoolGameEvent))
                {
                    var gEvent = gameEvent as BoolGameEvent;
                    bool result;
                    if (string.IsNullOrEmpty(argument))
                    {
                        errorMessage = "Failed: No argument provided.";
                        return false;
                    }
                    else if (bool.TryParse(argument, out result))
                    {
                        gEvent.Raise(result);
                        errorMessage = string.Empty;
                        return true;
                    }
                    else
                    {
                        errorMessage = "Failed: to parse \"" + argument + "\" to a bool.";
                        return false;
                    }
                }
                else if (gameEvent.GetType() == typeof(DoubleGameEvent))
                {
                    var gEvent = gameEvent as DoubleGameEvent;
                    double result;
                    if (string.IsNullOrEmpty(argument))
                    {
                        errorMessage = "Failed: No argument provided.";
                        return false;
                    }
                    else if (double.TryParse(argument, out result))
                    {
                        gEvent.Raise(result);
                        errorMessage = string.Empty;
                        return true;
                    }
                    else
                    {
                        errorMessage = "Failed: to parse \"" + argument + "\" to a double.";
                        return false;
                    }
                }
                else if (gameEvent.GetType() == typeof(CollisionGameEvent)
                    || gameEvent.GetType() == typeof(ColliderGameEvent))
                {
                    errorMessage = "Failed: Command found but the type is not valid for call through the parser.";
                    return false;
                }
                else
                {
                    gameEvent.Raise(this);
                    errorMessage = string.Empty;
                    return true;
                }
            }
            else
            {
                errorMessage = string.Empty;
                return false;
            }
        }

        /// <summary>
        /// Returns true if the provided string is a command
        /// </summary>
        /// <param name="inputString">The input string to test</param>
        /// <param name="userOnly">Should this only consider user commands</param>
        /// <param name="errorMessage">Error message if any</param>
        /// <returns>False if an error occured</returns>
        public bool VerifyCommand(string inputString, bool userOnly, out string errorMessage)
        {
            GameEvent gameEvent;
            string argument;
            if (TryParseCommand(inputString, userOnly, out gameEvent, out argument))
            {
                if (gameEvent.GetType() == typeof(StringGameEvent))
                {
                    if (!string.IsNullOrEmpty(argument))
                    {
                        errorMessage = string.Empty;
                        return true;
                    }
                    else
                    {
                        errorMessage = "No argument provided.";
                        return false;
                    }
                }
                else if (gameEvent.GetType() == typeof(IntGameEvent))
                {
                    var gEvent = gameEvent as IntGameEvent;
                    int result;
                    if (string.IsNullOrEmpty(argument))
                    {
                        errorMessage = "No argument provided.";
                        return false;
                    }
                    else if (int.TryParse(argument, out result))
                    {
                        errorMessage = string.Empty;
                        return true;
                    }
                    else
                    {
                        errorMessage = "Failed to parse \"" + argument + "\" to an int.";
                        return false;
                    }
                }
                else if (gameEvent.GetType() == typeof(FloatGameEvent))
                {
                    var gEvent = gameEvent as FloatGameEvent;
                    float result;
                    if (string.IsNullOrEmpty(argument))
                    {
                        errorMessage = "Failed: No argument provided.";
                        return false;
                    }
                    else if (float.TryParse(argument, out result))
                    {
                        errorMessage = string.Empty;
                        return true;
                    }
                    else
                    {
                        errorMessage = "Failed: to parse \"" + argument + "\" to a float.";
                        return false;
                    }
                }
                else if (gameEvent.GetType() == typeof(BoolGameEvent))
                {
                    var gEvent = gameEvent as BoolGameEvent;
                    bool result;
                    if (string.IsNullOrEmpty(argument))
                    {
                        errorMessage = "Failed: No argument provided.";
                        return false;
                    }
                    else if (bool.TryParse(argument, out result))
                    {
                        errorMessage = string.Empty;
                        return true;
                    }
                    else
                    {
                        errorMessage = "Failed: to parse \"" + argument + "\" to a bool.";
                        return false;
                    }
                }
                else if (gameEvent.GetType() == typeof(DoubleGameEvent))
                {
                    var gEvent = gameEvent as DoubleGameEvent;
                    double result;
                    if (string.IsNullOrEmpty(argument))
                    {
                        errorMessage = "Failed: No argument provided.";
                        return false;
                    }
                    else if (double.TryParse(argument, out result))
                    {
                        errorMessage = string.Empty;
                        return true;
                    }
                    else
                    {
                        errorMessage = "Failed: to parse \"" + argument + "\" to a double.";
                        return false;
                    }
                }
                else if (gameEvent.GetType() == typeof(CollisionGameEvent)
                    || gameEvent.GetType() == typeof(ColliderGameEvent))
                {
                    errorMessage = "Failed: Command found but the type is not valid for call through the parser.";
                    return false;
                }
                else
                {
                    errorMessage = string.Empty;
                    return true;
                }
            }
            else
            {
                errorMessage = string.Empty;
                return false;
            }
        }
    }
}
