using System.Data.Common;
using System.IO.Compression;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace projet1;

class Student
{
    public string name { get; set; }
    public float average { get; set; }
    public bool isScholarshipHolder { get; set; }
    private static int nextId = 0;
    private int id { get; set; }

    public Student(){nextId++; id = nextId;}

    public Student(string name, float average)
    {
        this.name = name;
        this.average = average;
        id++;
    }

    public Student(string name, float average, bool isScholarshipHolder)
    {
        this.name = name;
        this.average = average;
        this.isScholarshipHolder = isScholarshipHolder;
        id++;
    }

    public int idStudent()
    {
        return id;
    }

    public void Display()
    {
        string boursier = isScholarshipHolder == true ? "Oui" : "Non";
        Console.WriteLine($"name : {name}, average : {average}, Boursier : {boursier}, ID : {id}");
    }
}

class Course
{
    private static int nextId = 0;
    private int id { get; set; }
    public string name { get; set; }
    public int credits { get; set; }
    public bool isMandatory { get; set; }
 
    public List<Student> students = new List<Student>();

    public int idCourse()
    {
        return id;
    }

    public Course(string name)
    {
        this.name = name;
        nextId++;
        id=nextId;
    }

    public void addStudent(Student student)
    {
        students.Add(student);
    }

    public void removeStudent(Student student)
    {
        students.Remove(student);
    }

    public void Display()
    {
        string mandatory = isMandatory == true ? "Oui" : "Non";
        Console.WriteLine($"Cour : {name}\nID : {idCourse()}\nCredit : {credits}\nEst Obligatoire ? {mandatory}\nIl y a {students.Count} Etudiants");
    }

    public void DisplayStudents()
    {
        Console.WriteLine($"Cour : {name}");
        Console.WriteLine($"Etudiants : ");
        foreach(var student in students)
        {
            Console.WriteLine($"- {student.name} qui possède une moyenne de {student.average}.");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student s1 = new Student();
        s1.name = "Alice";
        s1.average = 23;
        s1.isScholarshipHolder = true;

        Student s2 = new Student();
        s2.name = "Bernard";
        s2.average = 5;
        s2.isScholarshipHolder = false;

        Student s3 = new Student();
        s3.name = "Emma";
        s3.average = 3;
        s3.isScholarshipHolder = true;

        Student s4 = new Student();
        s4.name = "Lucas";
        s4.average = 5;
        s4.isScholarshipHolder = false;

        Student s5 = new Student();
        s5.name = "Sarah";
        s5.average = 6;
        s5.isScholarshipHolder = true;

        Course c1 = new Course("Mathematiques");
        c1.credits = 4;
        c1.isMandatory = true;
        c1.addStudent(s1);
        c1.addStudent(s5);

        Course c2 = new Course("Informatique");
        c2.credits = 5;
        c2.isMandatory = false;
        c2.addStudent(s3);
        c2.addStudent(s4);

        Course c3 = new Course("Anglais");
        c3.credits = 9;
        c3.isMandatory = false;
        c3.addStudent(s3);
        c3.addStudent(s5);

        Course c4 = new Course("Histoire");
        c4.credits = 4;
        c4.isMandatory = false;
        c4.addStudent(s5);
        c4.addStudent(s1);

        c1.Display();
        c1.DisplayStudents();

        c2.Display();
        c2.DisplayStudents();

        c3.Display();
        c3.DisplayStudents();

        c4.Display();
        c4.DisplayStudents();

        List<Course> courses = new List<Course>();
        List<Student> students = new List<Student>();
        courses.Add(c1);
        courses.Add(c2);
        courses.Add(c3);
        courses.Add(c4);

        students.Add(s1);
        students.Add(s2);
        students.Add(s3);
        students.Add(s4);
        students.Add(s5);

        Console.WriteLine("\n\nLes cours obligatoires :");
        foreach (var course in courses)
        {
            if(course.isMandatory == true)
            {
                course.Display();
            }
        }


        Console.WriteLine("\n\nLes Etudiants boursiers : ");
        foreach(var student in students)
        {
            if(student.isScholarshipHolder == true)
            {
                student.Display();
            }
        }

        Console.WriteLine("\n\nLes Etudiants dont la moyenne est supérieur a 15 : ");
        foreach(var student in students)
        {
            if(student.average >= 15)
            {
                student.Display();
            }
        }

        Console.WriteLine($"Supprimé {s1.name} du cour de {c1.name} : \n");
        c1.removeStudent(s1);
        c1.DisplayStudents();
    }
}

//Q.1 Pour permettre l'identification de chaque objet
//Q.2 Ca permet de pouvoir attribué une variable a la classe dirrectement et pas un objet précis.