using System;
using System.Collections.Generic;

public interface IBuilder
{
    void BuildPartMainboard();

    void BuildPartProcessor();

    void BuildPartVideoCard();

    void BuildPartSoundCard();

    void BuildPartTuner();
}

public class Sony : IBuilder
{
    private Product _product = new Product();

    public Sony()
    {
        this.Reset();
    }

    public void Reset()
    {
        this._product = new Product();
    }

    public void BuildPartMainboard()
    {
        this._product.Add("Mainboard");
    }

    public void BuildPartProcessor()
    {
        this._product.Add("Processor");
    }

    public void BuildPartVideoCard()
    {
        this._product.Add("VideoCard");
    }

    public Product GetProduct()
    {
        Product result = this._product;

        this.Reset();

        return result;
    }

    public void BuildPartSoundCard()
    {
        this._product.Add("SoundCard");
    }

    public void BuildPartTuner()
    {
        this._product.Add("Tuner");
    }
}


public class Dell : IBuilder
{
    private Product _product = new Product();

    public Dell()
    {
        this.Reset();
    }

    public void Reset()
    {
        this._product = new Product();
    }

    public void BuildPartMainboard()
    {
        this._product.Add("Mainboard");
    }

    public void BuildPartProcessor()
    {
        this._product.Add("Processor");
    }

    public void BuildPartVideoCard()
    {
        this._product.Add("VideoCard");
    }

    public Product GetProduct()
    {
        Product result = this._product;

        this.Reset();

        return result;
    }

    public void BuildPartSoundCard()
    {
        this._product.Add("SoundCard");
    }

    public void BuildPartTuner()
    {
        this._product.Add("Tuner");
    }
}

public class Product
{
    private List<object> _parts = new List<object>();

    public void Add(string part)
    {
        this._parts.Add(part);
    }

    public string ListParts()
    {
        string str = string.Empty;

        for (int i = 0; i < this._parts.Count; i++)
        {
            str += this._parts[i] + ", ";
        }

        str = str.Remove(str.Length - 2); 

        return "Product type: " + str + "\n";
    }
}

public class Director
{
    private IBuilder _builder;

    public IBuilder Builder
    {
        set { _builder = value; }
    }

    public void buildBasic()
    {
        this._builder.BuildPartMainboard();
        this._builder.BuildPartProcessor();
    }

    public void buildStandart()
    {
        this._builder.BuildPartMainboard();
        this._builder.BuildPartProcessor();
        this._builder.BuildPartVideoCard();

    }


    public void buildStandartPlus()
    {
        this._builder.BuildPartMainboard();
        this._builder.BuildPartProcessor();
        this._builder.BuildPartVideoCard();
        this._builder.BuildPartSoundCard();       
    }
    public void buildLux()
    {
        this._builder.BuildPartMainboard();
        this._builder.BuildPartProcessor();
        this._builder.BuildPartVideoCard();
        this._builder.BuildPartSoundCard();
        this._builder.BuildPartTuner();
    }

}

class Program
{
    static void Main(string[] args)
    {
        Director director = new Director();
        Sony builder = new Sony();
        director.Builder = builder;

        Console.WriteLine("Basic product:");
        director.buildBasic();
        Console.WriteLine(builder.GetProduct().ListParts());

        Console.WriteLine("Standard product:");
        director.buildStandart();
        Console.WriteLine(builder.GetProduct().ListParts());

        Console.WriteLine("Standard+ product:");
        director.buildStandartPlus();
        Console.WriteLine(builder.GetProduct().ListParts());

        Console.WriteLine("Lux product:");
        director.buildLux();
        Console.WriteLine(builder.GetProduct().ListParts());


        Console.ReadLine();
    }
}


