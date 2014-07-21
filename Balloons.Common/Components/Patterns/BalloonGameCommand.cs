namespace BalloonsPops.Common.Components.Patterns
{
    using System;
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;
    using BalloonsPops.Common.Utilities;
    using BalloonsPops.Common.Utilities.Extensions;

    internal class BalloonGameCommand : ICommand
    {
        private readonly CommandTypes command;
        private readonly IGameEngine engine;
        private readonly string input;
        private readonly Shootable gameField;

        public BalloonGameCommand(IGameEngine engine, string input)
        {
            this.command = this.TryParseCommand(input);
            this.engine = engine;
            this.input = input;
            this.gameField = engine.GameBoard as Shootable;
        }

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