namespace BalloonsPop.ConsoleUI
{
    using BalloonsPop.Common.Components.Patterns;
    using BalloonsPop.Common.Interfaces;

    internal class CommandInvoker : ICommandInvoker
    {
        private readonly IGameEngine engine;

        internal CommandInvoker(IGameEngine engine)
        {
            this.engine = engine;
        }

        public void Execute<T>(T input)
        {
            ICommand command = new BalloonGameCommand(this.engine, input.ToString());
            command.Execute();
        }
    }
}