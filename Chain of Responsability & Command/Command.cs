using System;

namespace Patterns{

    public interface ICommandExecutor
    {
        void Prepare(ICommand command);
    }
    public abstract class ICommand
    {
        public abstract string Name{get;}
        public abstract void Prepare();
    }

    public class PizzaCommand : ICommand
    {
        private ICommandExecutor executor;

        public override string Name{get=> "Pizza";}
        public PizzaCommand(ICommandExecutor executor)
        {
            this.executor = executor;
        }

        public override void Prepare()
        {
            executor.Prepare(this);
        }
    }

        public class MeatCommand : ICommand
    {
        private ICommandExecutor executor;

        public override string Name{get=> "Meat";}
        public MeatCommand(ICommandExecutor executor)
        {
            this.executor = executor;
        }

        public override void Prepare()
        {
            executor.Prepare(this);
        }
    }


    // Invoker - инициатор
    public class Client
    {
        ICommand command;

        public void SetCommand(ICommand com)
        {
            command = com;
        }

        public void Order()
        {
            command.Prepare();
        }
    }
}