namespace BalloonsPops.Common.Actions
{
    using BalloonsPops.Common.Interfaces;

    internal class CommandInvoker
    {
        private readonly IGameEngine engine;

        internal CommandInvoker(IGameEngine engine)
        {
            this.engine = engine;
        }

        public void Execute(string input)
        {
            ICommand command = new BalloonGameCommand(this.engine, input);
            command.Execute();
        }
    }
}