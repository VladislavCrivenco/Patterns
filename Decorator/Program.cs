using System;

namespace Decorator
{
    class Program
    {
   public static void printInfo(Burger b) {
        Console.WriteLine("Cost: " + b.GetCost() + "; Ingredients: " + b.GetIngredients());
    }

    public static void Main(String[] args) {
        Burger veganBurger = new VeganBurger();
        printInfo(veganBurger);

        veganBurger = new WithOnions(new WithMushrooms(veganBurger));
        printInfo(veganBurger);

        Burger americanBurger = new AmericanBurger();
        printInfo(americanBurger);

        americanBurger = new WithOnions(americanBurger);
        printInfo(americanBurger);
    }
    }

    public interface Burger
    {
        double GetCost();
        string GetIngredients();
    }
    public class AmericanBurger : Burger
    {
        public double GetCost()
        {
            return 1;
        }

        public String GetIngredients()
        {
            return "Meat";
        }
    }

    public class VeganBurger : Burger
    {
        public double GetCost()
        {
            return 1;
        }

        public String GetIngredients()
        {
            return "Veggies";
        }
    }

    public abstract class BurgerToppingsDecorator : Burger
    {
        protected Burger decoratedBurger;

        public BurgerToppingsDecorator(Burger burger)
        {
            this.decoratedBurger = burger;
        }

        public virtual double GetCost()
        {
            return decoratedBurger.GetCost();
        }

        public virtual string GetIngredients()
        {
            return decoratedBurger.GetIngredients();
        }
    }

    class WithMushrooms : BurgerToppingsDecorator
    {
        public WithMushrooms(Burger b) : base(b) { }

        public override  double GetCost()
        { 
            return base.GetCost() + 0.5;
        }

        public override string GetIngredients()
        {
            return base.GetIngredients() + ", Mushrooms";
        }
    }

    class WithOnions : BurgerToppingsDecorator
    {
        public WithOnions(Burger b) : base(b) { }

        public override double GetCost()
        { 
            return base.GetCost() + 0.5;
        }

        public override string GetIngredients()
        {
            return base.GetIngredients() + ", Onions";
        }
    }
}