using System;
using System.Collections.Generic;
using System.Text;

namespace PrototypeFigure
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Factory Method Example for Students
            Console.WriteLine("\nFactory Method Example for Students:");
            StudentCreator creator = new BachelorStudentCreator();
            Student student = creator.CreateStudent();
            student.DisplayInfo();

            creator = new MasterStudentCreator();
            student = creator.CreateStudent();
            student.DisplayInfo();

            // Composite Example for Session Results
            Console.WriteLine("\nComposite Example for Session Results:");
            CompositeResult sessionResults = new CompositeResult();
            sessionResults.Add(new ResultLeaf("Math", "Passed"));
            sessionResults.Add(new ResultLeaf("Physics", "Failed"));
            sessionResults.Add(new ResultLeaf("Chemistry", "Passed"));
            sessionResults.Display();

            Console.Read();
        }
    }

    // Factory Method Pattern for Students
    abstract class StudentCreator
    {
        public abstract Student CreateStudent();
    }

    class BachelorStudentCreator : StudentCreator
    {
        public override Student CreateStudent()
        {
            return new BachelorStudent();
        }
    }

    class MasterStudentCreator : StudentCreator
    {
        public override Student CreateStudent()
        {
            return new MasterStudent();
        }
    }

    abstract class Student
    {
        public abstract void DisplayInfo();
    }

    class BachelorStudent : Student
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("Bachelor Student preparing for exams.");
        }
    }

    class MasterStudent : Student
    {
        public override void DisplayInfo()
        {
            Console.WriteLine("Master Student preparing for exams.");
        }
    }

    // Composite Pattern for Session Results
    interface IResultComponent
    {
        void Display();
    }

    class ResultLeaf : IResultComponent
    {
        string subject;
        string result;

        public ResultLeaf(string subject, string result)
        {
            this.subject = subject;
            this.result = result;
        }

        public void Display()
        {
            Console.WriteLine("Subject: {0}, Result: {1}", subject, result);
        }
    }

    class CompositeResult : IResultComponent
    {
        private List<IResultComponent> _components = new List<IResultComponent>();

        public void Add(IResultComponent component)
        {
            _components.Add(component);
        }

        public void Display()
        {
            Console.WriteLine("Session Results:");
            foreach (var component in _components)
            {
                component.Display();
            }
        }
    }
}
