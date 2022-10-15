using System;
using System.Text;

class Human
{
    string? firstName;
    string? lastName;

    public string? FirstName
    {
        get => firstName;
        set
        {
            while (value?.Length <= 3 || value == null || value[0] != char.ToUpper(value[0]))
            {
                if (value != null && value[0] != char.ToUpper(value[0]))
                {
                    Console.Write("Expected upper case letter! Argument: {0}\nFirst name: ", value);
                }
                else if (value?.Length <= 3 || value == null)
                {
                    Console.Write("Expected length at least 4 symbols! Argument: {0}\nFirst name: ", value);
                }
                value = Console.ReadLine();
            }

            firstName = value;
        }
    }
    public string? LastName
    {
        get => lastName;
        set
        {
            while (value?.Length < 3 || value == null || value[0] != char.ToUpper(value[0]))
            {
                if (value != null && value[0] != char.ToUpper(value[0]))
                {
                    Console.Write("Expected upper case letter! Argument: {0}\nLast Name: ", value);
                }
                else if (value?.Length <= 3 || value == null)
                {
                    Console.Write("Expected length at least 3 symbols! Argument: {0}\nLast Name: ", value);
                }

                value = Console.ReadLine();
            }

            lastName = value;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append(String.Format("Fist Name: {0}\nLast Name: {1}", FirstName, LastName));


        return stringBuilder.ToString();
    }

    public Human(string? firstName, string? lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}

class Student : Human
{
    string? facultyNumber;

    public string? FacultyNumber
    {
        get => facultyNumber;
        set
        {
            while (value == null || !(value.Length >= 5 && value.Length <= 10))
            {
                Console.Write("Invalid faculty number!\nFaculty number: ");
                value = Console.ReadLine();
            }

            facultyNumber = value;
        }
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append(String.Format("\nFaculty number: {0}", FacultyNumber));


        return base.ToString() + stringBuilder.ToString();
    }


    public Student(string? firstName, string? lastName, string? facultyNumber)
        : base(firstName, lastName)
    {
        FacultyNumber = facultyNumber;
    }
}

class Worker : Human
{
    float? weekSalary;
    float? workingHoursPerDay;
    float? salaryPerHour;

    public float? WeekSalary
    {
        get => weekSalary;
        set
        {
            while (value == null || value <= 10)
            {
                Console.Write("Expected value mismatch! Argument: {0:0.00}\nWeek salary: ", value);
                value = Convert.ToSingle(Console.ReadLine());
            }

            weekSalary = value;
        }
    }
    public float? WorkingHoursPerDay
    {
        get => workingHoursPerDay;
        set
        {
            while (value == null || !(value > 0 && value <= 12))
            {
                Console.Write("Expected value mismatch! Argument: {0:0.00}\nHours per day: ", value);
                value = Convert.ToSingle(Console.ReadLine());
            }

            workingHoursPerDay = value;
        }
    }
    public float? SalaryPerHour 
    { 
        get => salaryPerHour; 
        set => salaryPerHour = value; 
    }

    static float? CaltulateSalaryPerHour(float? weekSalary, float? hourPerDay) => weekSalary / (hourPerDay * 5);

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder.Append(String.Format("\nWeek Salary: {0:0.00}\nHours per day: {1:0.00}\nSalary per hour: {2:0.00}",
            WeekSalary, WorkingHoursPerDay, SalaryPerHour));


        return base.ToString() + stringBuilder.ToString();
    }


    public Worker(string? firstName, string? lastName, float? weekSalary, float? workingHoursPerDay)
        : base(firstName, lastName)
    {
        WeekSalary = weekSalary;
        WorkingHoursPerDay = workingHoursPerDay;
        salaryPerHour = CaltulateSalaryPerHour(WeekSalary, WorkingHoursPerDay);
    }
}

class Ex3
{
    static void Main()
    {
        Student student = new("Mandarun", "PK444", "07665681");
        Console.WriteLine(student + "\n");

        Worker worker = new("Frenk", "Galager", 2340, 15);
        Console.WriteLine(worker);


        Console.ReadKey();
    }
}

