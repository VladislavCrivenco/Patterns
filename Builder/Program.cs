using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Builder builder = new EuropeSearchBuilder();
            Director director = new Director(builder);

            Client client = new Client();
            client.ClientCode(director, builder);
        }
    }

    public class Client
    {
        public void ClientCode(Director director, Builder builder)
        {
            Console.WriteLine("Search by rating:");
            director.SearchByRating("5");
            Console.WriteLine(builder.GetFilter());

            Console.WriteLine();

            Console.WriteLine("Search by rating, and min max price");
            director.SearchByRating("4");
            director.SearchByMinMaxPrice("100", "500");
            Console.WriteLine(builder.GetFilter());
        }
    }

    public class Director
    {
        Builder builder;

        public Director(Builder builder)
        {
            this.builder = builder;
        }

        public void SearchByRating(string rating)
        {
            builder.Rating = rating;
        }
        
        public void SearchByMinMaxPrice(string min, string max)
        {
            builder.MaxPrice = max;
            builder.MinPrice = min;
        }
    }

    public abstract class Builder
    {
        public abstract string Location{get;set;}
        public abstract string Rating{get;set;}
        
        public abstract string MinPrice{get;set;}
        
        public abstract string MaxPrice{get;set;}
        
        public abstract SearchFilter GetFilter();
    }

    public class SearchFilter
    {
        private string location;
        public string rating;
        
        private string minPrice;
        
        private string maxPrice;

        public SearchFilter(string location, string rating, string minPrice, string maxPrice){
            this.location = location;
            this.rating = rating;
            this.minPrice = minPrice;
            this.maxPrice = maxPrice;
        }
        
        public override string ToString()
        {
            var result = $"Search filters : {location} with rating {rating}";
            if (minPrice != null){
                result += $", from {minPrice} USD to {maxPrice} USD";
            }

            return result;
        }
    }

    public class EuropeSearchBuilder : Builder
    {
        private string _location = "Europe";
        public override string Location{get => _location; set => _ = value;}
        public override string Rating{get;set;}
        
        public override string MinPrice{get;set;}
        
        public override string MaxPrice{get;set;}

        public override SearchFilter GetFilter()
        {
            return new SearchFilter(Location, Rating, MinPrice, MaxPrice);
        }
    }
}
