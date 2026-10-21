using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace EventManager
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Course(int id,string name)
        {
            Id = id;
            Name = name;
        }
    }
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> crse { get; set; }

        public Student(int id, string name)
        {
            Id = id;
            Name = name;
            crse = new List<Course> {
                new Course(1, "java"),
                new Course(2, "c#")};   
        }

    }
    public class Jsonpractise
    {
        //Student s1 = new Student(1, "rex");
        List<Student> studlist = new List<Student>();
        Student s1 = new Student(1, "rex");

        Student s2 = new Student(2, "Naga");

        Student s3 = new Student(3, "sas");

        Student s4 = new Student(4, "asa");

        
        

        public void Dis()
        {
            studlist.Add(s1);
            studlist.Add(s2);
            studlist.Add(s3);
            studlist.Add(s4);
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json1 = JsonSerializer.Serialize(studlist,options);
            Console.WriteLine(json1);
            //string json1 = JsonSerializer.Serialize(s1);
            //Console.WriteLine(json1);
            //Student json2 = JsonSerializer.Deserialize<Student>(json1);
            //Console.WriteLine(json2.Id + " " + json2.Name);

        }

    }
}
