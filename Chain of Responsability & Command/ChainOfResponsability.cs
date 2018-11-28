using System;

namespace Patterns
{
    // Receiver
    class Kitchen : ICommandExecutor
    {

        private Chef chef;
        public Kitchen()
        {
            chef = new Chef();
            var senior = new SeniorWorker();
            var junior = new JunioWorker();

            chef.setSuccessor(senior);
            senior.setSuccessor(junior);
        }
        public void Prepare(ICommand command)
        {
            chef.processRequest(command);
        }
    }

    public abstract class KithenWorker
    {
        protected KithenWorker successor;

        abstract protected bool CanExecute(ICommand command);
        abstract protected string getRole();

        public void setSuccessor(KithenWorker successor)
        {
            this.successor = successor;
        }

        public void processRequest(ICommand command)
        {
            if (CanExecute(command))
            {
                Console.WriteLine(this.getRole() + " prepared $" + command.Name + " !");
            }
            else if (successor != null)
            {
                successor.processRequest(command);
            }
        }
    }

    public class Chef : KithenWorker
    {
        protected override bool CanExecute(ICommand command)
        {
            if (command.Name == "Pizza")
            {
                return true;
            }

            return false;
        }
        protected override string getRole()
        {
            return "Main Chef";
        }
    }

    public class SeniorWorker : KithenWorker
    {
        protected override bool CanExecute(ICommand command)
        {
            if (command.Name == "Meat")
            {
                return true;
            }

            return false;
        }
        protected override string getRole()
        {
            return "Senior worker";
        }
    }

    
    public class JunioWorker : KithenWorker
    {
        protected override bool CanExecute(ICommand command)
        {
            return true;
        }
        protected override string getRole()
        {
            return "junior worker";
        }
    }
}