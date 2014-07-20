namespace BalloonsPops.Common.Actions
{
    using BalloonsPops.Common.Entities;
    using BalloonsPops.Common.Interfaces;

    internal class CommandInvoker
    {
        private readonly BalloonGameEngine engine;

        internal CommandInvoker(BalloonGameEngine engine)
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