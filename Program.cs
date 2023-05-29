using System;
using System.Collections.Generic;

// ケーキの注文インターフェース
public interface ICakeOrder
{
    void AddCakeOrder(string cakeType, int quantity);
    void DisplayOrderSummary();
}

// ケーキの親クラス
public abstract class Cake
{
    public string Name { get; protected set; }
    public int Price { get; protected set; }
    public int Quantity { get; set; }

    public abstract int CalculateTotalPrice(int quantity);
}

// ショートケーキ
public class Shortcake : Cake
{
    public Shortcake()
    {
        Name = "ショートケーキ";
        Price = 300;
    }

    public override int CalculateTotalPrice(int quantity)
    {
        return Price * quantity;
    }
}

// チーズケーキ
public class Cheesecake : Cake
{
    public Cheesecake()
    {
        Name = "チーズケーキ";
        Price = 400;
    }

    public override int CalculateTotalPrice(int quantity)
    {
        return Price * quantity;
    }
}

// チョコケーキ
public class ChocolateCake : Cake
{
    public ChocolateCake()
    {
        Name = "チョコケーキ";
        Price = 500;
    }

    public override int CalculateTotalPrice(int quantity)
    {
        return Price * quantity;
    }
}

// ロールケーキ
public class RollCake : Cake
{
    public RollCake()
    {
        Name = "ロールケーキ";
        Price = 800;
    }

    public override int CalculateTotalPrice(int quantity)
    {
        return Price * quantity;
    }
}

// 注文クラス
public class Order : ICakeOrder
{
    private Dictionary<string, Cake> cakes;

    public Dictionary<string, Cake> Cakes { get { return cakes; } }

    public Order()
    {
        cakes = new Dictionary<string, Cake>();
        cakes.Add("ショートケーキ", new Shortcake());
        cakes.Add("チーズケーキ", new Cheesecake());
        cakes.Add("チョコケーキ", new ChocolateCake());
        cakes.Add("ロールケーキ", new RollCake());
    }

    public void AddCakeOrder(string cakeType, int quantity)
    {
        if (cakes.ContainsKey(cakeType))
        {
            Cake cake = cakes[cakeType];
            cake.Quantity += quantity;
        }
        else
        {
            Console.WriteLine($"エラー: {cakeType} は存在しないケーキです。");
        }
    }

    public void DisplayOrderSummary()
    {
        int totalPrice = 0;

        Console.WriteLine("注文内容:");

        foreach (var cake in cakes.Values)
        {
            if (cake.Quantity > 0)
            {
                int cakePrice = cake.CalculateTotalPrice(cake.Quantity);
                totalPrice += cakePrice;

                Console.WriteLine($"- {cake.Name}: {cake.Quantity}個 (合計金額: {cakePrice}円)");
            }
        }

        Console.WriteLine($"合計金額: {totalPrice}円");
    }
}

// メインクラス
class Program
{
    static void Main(string[] args)
    {
        Order order = new Order();

        Console.WriteLine("ケーキの注文を入力してください。");
        Console.WriteLine("終了するには、'終了'と入力してください。");

        foreach (var cake in order.Cakes.Values)
        {
            Console.Write($"ケーキの個数 ({cake.Name}): ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            order.AddCakeOrder(cake.Name, quantity);
        }

        order.DisplayOrderSummary();

        Console.ReadLine();
    }
}
