using System;
using System.Text;

class Person
{
    protected string? name;
    protected int? age;

    public string? Name
    {
        get => name;
        set
        {
            if (value?.Length < 3)
            {
                Console.WriteLine("Name's length should not be less than 3 symbols!");
            }
            name = value;
        }
    }
    public int? Age
    {
        get => age;
        set
        {
            while (value < 0 || value > 15)
            {
                if (value < 0)
                {
                    Console.WriteLine("Age must be positive!");
                }

                else if (value > 15)
                {
                    Console.WriteLine("Child's age must be less than 15!");
                }

                value = Convert.ToInt32(Console.ReadLine());
            }

            age = value;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append(String.Format("Name: {0}, Age: {1}", this.Name, this.Age));

        return stringBuilder.ToString();
    }


    public Person(string? name, int? age)
    {
        Name = name;
        Age = age;
    }
}


class Child : Person
{
    public new int? Age { get => base.Age; set => base.Age = value; }
    public new string? Name { get => base.Name; set => base.Name = value; }

    public override string ToString() 
    { 
        return base.ToString(); 
    }


    public Child(string? name, int? age) 
        : base(name, age) { }
}



class Ex1
{
    static void Main()
    {

        string? temp = "";

        while (temp?.ToLower() != "end")
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            Console.Write("Age: ");
            int age = Convert.ToInt32(Console.ReadLine());



            Child child = new(name, age);
            Console.WriteLine(child);

            temp = Console.ReadLine();
        }


        Console.ReadKey();
    }
}

