using System.Data.Common;
using System.Linq.Expressions;

namespace projet1;

class Student
{
    public string name { get; set; }
    public float average { get; set; }
    public bool isScholarshipHolder { get; set; }
    public static int id { get; set; }

    public Student(){id++;}

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
}

class Course
{
    public int id { get; set; }
    public string name { get; set; }
    public int credits { get; set; }
    public bool isMandatory { get; set; }
 
    public List<Student> students = new List<Student>();

    public Course(string name)
    {
        this.name = name;
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
    }
}
