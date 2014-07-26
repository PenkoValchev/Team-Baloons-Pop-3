namespace BalloonsPop.Common.Components.Patterns
{
    using System;
    using BalloonsPop.Common.Contracts;
    using BalloonsPop.Common.Utilities;
    using BalloonsPop.Common.Utilities.Extensions;

    public class BalloonGameCommand : ICommand
    {
        private readonly CommandTypes command;
        private readonly IGameEngine engine;
        private readonly string input;
        private readonly Shootable gameField;

        /// <summary>
        /// Constructor creating specific BalloonGameCommand
        /// </summary>
        /// <param name="engine">Instance of game engine which is used</param>
        /// <param name="input">User input</param>
        public BalloonGameCommand(IGameEngine engine, string input)
        {
            this.command = this.TryParseCommand(input);
            this.engine = engine;
            this.input = input;
            this.gameField = engine.GameBoard as Shootable;
        }

        /// <summary>
        /// Execute method calls the specific realization of passed input
        /// </summary>
        public void Execute()
        {
            bool isShootCommand = Utils.IsShootCommand(this.input);

            if (isShootCommand)
            {
                this.gameField.Action(this.engine, CommandTypes.Shoot, this.input);
            }
            else
            {
                this.gameField.Action(this.engine, this.command);
            }
        }

        private CommandTypes TryParseCommand(string input)
        {
            CommandTypes commandType;
            Enum.TryParse(input, true, out commandType);

            return commandType;
        }
    }
}