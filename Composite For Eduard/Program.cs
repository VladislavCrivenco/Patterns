using System;
using System.Collections.Generic;

namespace Composite
{
    public abstract class AbstractItem
    {
        public abstract string Name{get; set;}
        public abstract decimal Price{get;set;}
        public abstract void Print();
        public abstract void Print(int level);
    }

    public class ProductItem : AbstractItem
    {
        private string _name;
        public override string Name{get=>_name;set => _name = value;}

        private decimal _price;
        public override decimal Price{get => _price;set => _price = value;}

        public ProductItem(string name, decimal price)
        {
            this._name = name;
            this._price = price;
        }

        public override void Print(){
            Print(0);
        }

        public override void Print(int level)
        {
            for (int i = 0; i < level; i++)
            {
                Console.Write("--");
            }
            Console.WriteLine(_name + ":" + _price);
        }
    }

    public class CategoryItem : AbstractItem
    {
        private string _name;
        public override string Name{get=>_name;set => _name = value;}

        public override decimal Price
        {
            get
            {
                decimal total = 0;
                foreach (var item in Items){
                    total += item.Price;
                }

                return total;
            }
            set{}
        }
        private List<AbstractItem> Items = new List<AbstractItem>();

        public CategoryItem(string name)
        {
            this._name = name;
        }

        public void add(AbstractItem obj)
        {
            Items.Add(obj);
        }

        public override void Print(){
            Print(0);
        }

         public override void Print(int level)
        {
            for (int i = 0; i < level; i++)
            {
                Console.Write("--");
            }
            Console.WriteLine(Name + ":" + Price);
            foreach (var item in Items)
            {
                item.Print(level + 1);
            }
        }
    }

    public class CategoryBuilder
    {
        CategoryItem root;

        public CategoryBuilder(string name)
        {
            root = new CategoryItem(name);
        }

        public CategoryBuilder Add(AbstractItem file)
        {
            root.add(file);

            return this;
        }

        public AbstractItem Build()
        {
            return root;
        }
    }

    public class CompositeDemo
    {
        public static void Main(String[] args)
        {
            var builder = new CategoryBuilder("Electronics");

            builder.Add(new CategoryBuilder("Wearable")
                            .Add(new ProductItem("Smartwatches", 500))
                            .Add(new ProductItem("VR", 2050))
                            .Build())
                    .Add(new CategoryBuilder("Headphones")
                            .Add(new ProductItem("Beats", 2500))
                            .Add(new ProductItem("Xiomi", 50))
                            .Build());

            builder.Build().Print();
        }
    }
}
