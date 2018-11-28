using System;

namespace DesignPatterns
{
    interface IGraphicalElementsFactory
    {
        IButton CreateButton();

        ITextBox CreateTextBox();
    }

    class LightThemeGraphicalElementsFactory : IGraphicalElementsFactory
    {
        private static LightThemeGraphicalElementsFactory _instance;

        private LightThemeGraphicalElementsFactory(){

        }
        public static LightThemeGraphicalElementsFactory GetInstance(){
            if (_instance == null){
                _instance = new LightThemeGraphicalElementsFactory();
            }

            return _instance;
        }

        public IButton CreateButton()
        {
            return new LightThemeButton();
        }

        public ITextBox CreateTextBox()
        {
            return new LightThemeTextBox();
        }
    }

    class DarkThemeGraphicalElementsFactory : IGraphicalElementsFactory
    {
        private static DarkThemeGraphicalElementsFactory _instance;

        private DarkThemeGraphicalElementsFactory(){
            
        }
        public static DarkThemeGraphicalElementsFactory GetInstance(){
            if (_instance == null){
                _instance = new DarkThemeGraphicalElementsFactory();
            }

            return _instance;
        }

        public IButton CreateButton()
        {
            return new DarkThemeButton();
        }

        public ITextBox CreateTextBox()
        {
            return new DarkThemeTextBox();
        }
    }


    interface IButton
    {
        string Render();
    }

    class LightThemeButton : IButton
    {
        public string Render()
        {
            return "The result of the light theme button render.";
        }
    }

    class DarkThemeButton : IButton
    {
        public string Render()
        {
            return "The result of the dark theme button render.";
        }
    }


    interface ITextBox
    {
        string Render();

        string Submit(IButton collaborator);
    }

    class LightThemeTextBox : ITextBox
    {
        public string Render()
        {
            return "The result of the render of light theme text box.";
        }

        public string Submit(IButton collaborator)
        {
            var result = collaborator.Render();

            return $"The result of the light theme text box collaborating with the ({result})";
        }
    }

    class DarkThemeTextBox : ITextBox
    {
        public string Render()
        {
            return "The result of the render of dark theme text box.";
        }

        public string Submit(IButton collaborator)
        {
            var result = collaborator.Render();

            return $"The result of the dark theme text box collaborating with the ({result})";
        }
    }


    class Client
    {
        public void Main()
        {
            Console.WriteLine("Client: Testing client code with the first factory type...");
            ClientMethod(LightThemeGraphicalElementsFactory.GetInstance());
            Console.WriteLine();

            Console.WriteLine("Client: Testing the same client code with the second factory type...");
            ClientMethod(DarkThemeGraphicalElementsFactory.GetInstance());
        }

        public void ClientMethod(IGraphicalElementsFactory factory)
        {
            var productA = factory.CreateButton();
            var productB = factory.CreateTextBox();

            Console.WriteLine(productB.Render());
            Console.WriteLine(productB.Submit(productA));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            new Client().Main();
        }
    }
}