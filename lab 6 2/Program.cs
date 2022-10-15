using System;
using System.Globalization;
using System.Text;

class Book
{
    protected string? title;
    protected string? author;
    protected float? price;

    public string? Title
    {
        get => title;
        set
        {
            while (value?.Length < 3)
            {
                Console.Write("\nTitle not valid!\nTitle: ");
                value = Console.ReadLine();
            }
            title = value;
        }
    }
    public string? Author
    {
        get => author;
        set
        {
            while (!CheckToDigitAuthor(value))
            {
                Console.Write("\nAuthor not valid!\nAuthor: ");
                value = Console.ReadLine();
            }
            author = value;
        }
    }
    public float? Price
    {
        get => price;
        set
        {
            while (value < 0)
            {
                Console.Write("\nPrice not valid!\nPrice: ");
                value = Convert.ToSingle(Console.ReadLine());
            }
            price = value;
        }
    }

    // Перевірка, чи починається ім'я автора з цифри
    static bool CheckToDigitAuthor(string? str)
    {
        if (str == null)
        {
            return false;
        }

        if (str != null)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if ((char.IsDigit(str[i]) && i == 0) || (char.IsDigit(str[i]) && str[i - 1] == ' '))
                {
                    return false;
                }
            }         
        }
        return true;
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append(String.Format("Type: Book \nTitle: {0} \nAuthor: {1} \nPrice: {2:0.00}", this.Title, this.Author, this.Price));

        return stringBuilder.ToString();
    }

    public Book(string? title, string? author, float? price)
    {
        this.Title = title;
        this.Author = author;
        this.Price = price;
    }
}

class EditionBook : Book
{
    public new string? Title { get => title; set => title = value; }
    public new string? Author { get => author; set => author = value; }
    public new float? Price { get => price * (float)1.3; set => price = value; }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append(String.Format("Type: EditionBook \nTitle: {0} \nAuthor: {1} \nPrice: {2:0.00}", Title, Author, Price));

        return stringBuilder.ToString();
    }

    public EditionBook(string? title, string? author, float? price)
        : base(title, author, price)
    {
    }
}

class Ex2
{
    static void Main()
    {
        Console.Write("Author: ");
        string? author = Console.ReadLine();

        Console.Write("Title: ");
        string? title = Console.ReadLine();

        Console.Write("Price: ");
        float? price = Convert.ToSingle(Console.ReadLine());


        Book book = new(title, author, price);
        Console.WriteLine("\n" + book + "\n");


        EditionBook EditionBook = new(book.Title, book.Author, book.Price);
        Console.WriteLine(EditionBook);


        Console.ReadKey();
    }
}

