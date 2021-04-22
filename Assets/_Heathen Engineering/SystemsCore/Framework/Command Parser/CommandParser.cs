using System;
using System.Collections.Generic;
using System.Linq;
using HeathenEngineering.Events;
using UnityEngine;
using UnityEngine.Serialization;

namespace HeathenEngineering.CommandSystem
{
    /// <summary>
    ///     Defines a set of commands and the rules for parsing said commands from various strings.
    ///     This is designed to aid the developer in creating emote and other text based command systems such as you might find in MMOs and RPGs.
    /// </summary>
    [CreateAssetMenu(menuName = "System Core/Application/Command Parser")]
    [Serializable]
    public class CommandParser : ScriptableObject
    {
        [FormerlySerializedAs("UseCaseSinsativeCommandNames")]
        public bool UseCaseInsensitiveCommandNames;

        public string CommandStartString = "/";
        public List<GameEvent> DeveloperCommands = new List<GameEvent>();
        public List<GameEvent> UserCommands = new List<GameEvent>();

        /// <summary>
        ///     Attempts to match the input string to a command optionally filtering on user commands only
        /// </summary>
        /// <param name="inputString">The input string to test</param>
        /// <param name="userOnly">Should this only consider user commands</param>
        /// <param name="gameEvent">The command's game event if found</param>
        /// <param name="argument">Any trailing text found after the command</param>
        /// <returns>True if a command was found, False otherwise.</returns>
        public bool TryParseCommand(string inputString, bool userOnly, out GameEvent gameEvent, out string argument)
        {
            if (!inputString.StartsWith(CommandStartString))
            {
                gameEvent = null;
                argument = string.Empty;

                return false;
            }

            if (!userOnly)
            {
                var developerCommand = DeveloperCommands
                    .Where(devGameEvent =>
                        inputString.StartsWith(CommandStartString + devGameEvent.name,
                            UseCaseInsensitiveCommandNames
                                ? StringComparison.InvariantCulture
                                : StringComparison.InvariantCultureIgnoreCase))
                    .FirstOrDefault(devGameEvent =>
                        inputString.Length == CommandStartString.Length + devGameEvent.name.Length
                        || inputString[CommandStartString.Length + devGameEvent.name.Length] == ' ');

                if (developerCommand != null)
                {
                    gameEvent = developerCommand;

                    var working = inputString.Substring(CommandStartString.Length + developerCommand.name.Length).Trim();
                    argument = working.StartsWith(CommandStartString)
                        ? working.Substring(CommandStartString.Length)
                        : working;

                    return true;
                }
            }

            var userCommand = UserCommands
                .Where(userGameEvent =>
                    inputString.StartsWith(CommandStartString + userGameEvent.name,
                        UseCaseInsensitiveCommandNames
                            ? StringComparison.InvariantCulture
                            : StringComparison.InvariantCultureIgnoreCase))
                .FirstOrDefault(userGameEvent =>
                    inputString.Length == CommandStartString.Length + userGameEvent.name.Length
                    || inputString[CommandStartString.Length + userGameEvent.name.Length] == ' ');

            if (userCommand != null)
            {
                gameEvent = userCommand;

                var working = inputString.Substring(CommandStartString.Length + userCommand.name.Length).Trim();
                argument = working.StartsWith(CommandStartString)
                    ? working.Substring(CommandStartString.Length)
                    : working;

                return true;
            }

            gameEvent = null;
            argument = string.Empty;

            return false;
        }

        /// <summary>
        ///     Attempts to match the input string to a command and to raise the matching command event with the provided arguments
        /// </summary>
        /// <param name="inputString">The input string to test</param>
        /// <param name="userOnly">Should this only consider user commands</param>
        /// <param name="errorMessage">Error message if any</param>
        /// <returns>False if an error occurred</returns>
        public bool TryCallCommand(string inputString, bool userOnly, out string errorMessage)
        {
            if (!VerifyCommand(inputString, userOnly, out errorMessage))
            {
                return false;
            }

            if (!TryParseCommand(inputString, userOnly, out var gameEvent, out var argument))
            {
                return false;
            }

            switch (gameEvent)
            {
                case StringGameEvent stringGameEvent:
                    stringGameEvent.Raise(argument);
                    break;
                case IntGameEvent intGameEvent:
                    intGameEvent.Raise(int.Parse(argument));
                    break;
                case FloatGameEvent floatGameEvent:
                    floatGameEvent.Raise(int.Parse(argument));
                    break;
                case BoolGameEvent boolGameEvent:
                    boolGameEvent.Raise(int.Parse(argument));
                    break;
                case DoubleGameEvent doubleGameEvent:
                    doubleGameEvent.Raise(int.Parse(argument));
                    break;
            }

            gameEvent.Raise(this);
            return true;
        }

        /// <summary>
        ///     Returns true if the provided string is a command
        /// </summary>
        /// <param name="inputString">The input string to test</param>
        /// <param name="userOnly">Should this only consider user commands</param>
        /// <param name="errorMessage">Error message if any</param>
        /// <returns>False if an error occurred</returns>
        public bool VerifyCommand(string inputString, bool userOnly, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!TryParseCommand(inputString, userOnly, out var gameEvent, out var argument))
            {
                return errorMessage == string.Empty;
            }

            if (string.IsNullOrEmpty(argument))
            {
                errorMessage = "No argument provided.";
                return false;
            }

            switch (gameEvent)
            {
                case StringGameEvent stringGameEvent:
                    break;
                case IntGameEvent intGameEvent:
                    if (!int.TryParse(argument, out var intResult))
                    {
                        errorMessage = $"Failed to parse \"{argument}\" to an int.";
                    }

                    break;
                case FloatGameEvent floatGameEvent:
                    if (!float.TryParse(argument, out var floatResult))
                    {
                        errorMessage = $"Failed to parse \"{argument}\" to an float.";
                    }

                    break;
                case BoolGameEvent boolGameEvent:
                    if (!bool.TryParse(argument, out var boolResult))
                    {
                        errorMessage = $"Failed to parse \"{argument}\" to an bool.";
                    }

                    break;
                case DoubleGameEvent doubleGameEvent:
                    if (!bool.TryParse(argument, out var doubleResult))
                    {
                        errorMessage = $"Failed to parse \"{argument}\" to an double.";
                    }

                    break;
                case CollisionGameEvent collisionGameEvent:
                case ColliderGameEvent colliderGameEvent:
                    errorMessage = $"Command found but the type \"{gameEvent.GetType()}\" is not valid for call through the parser.";
                    break;
            }

            return errorMessage == string.Empty;
        }
    }
}