// See https://aka.ms/new-console-template for more information

// initialization: in the future it should be replaced by a Dependency Injection Service

using System.Text.Json;
using Zadaca.Models;
using Zadaca.Services;
using Zadaca.Services.Implementations;


ISubjectService subjectService = new SubjectService();

Console.WriteLine("Subject Information System");
Console.WriteLine("Enter option");
while (true)
{
    Console.WriteLine("===========================");
    PrintMenu();
    Console.WriteLine("===========================");

    if (!ExecuteOption())
        break;
}

bool ExecuteOption()
{
    var option = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

    switch (option)
    {
        case 0:
            return false;
        case 1:
            ListSubjects();
            break;
        case 2:
            GetSubjectInfo();
            break;
        case 3:
            InsertNewSubjects();
            break;
    }

    return true;
}

void PrintMenu()
{
    Console.WriteLine("1. List subjects");
    Console.WriteLine("2. Get subject info");
    Console.WriteLine("3. Insert new subjects");
    Console.WriteLine("\n0. Exit");

}

void ListSubjects()
{
    var subjects = subjectService.ListSubjects();
    foreach (var subject in subjects)
    {
        Console.WriteLine($"{subject.Id}. {subject.Name}");
    }
}

void GetSubjectInfo()
{
    Console.WriteLine("Insert subject id");
    var subjectId = int.Parse(Console.ReadLine() ?? throw new InvalidOperationException());

    var subject = subjectService.GetSubject(subjectId);
    
    Console.WriteLine($"{subject.Name}\n{subject.Description}\nLiterature used: {subject.LiteratureUsed.Select(literature => GetLiteratureInfo(literature))}");
}

string GetLiteratureInfo(Literature literature)
{
    return
        $"{literature.Name} ({string.Join(',', literature.Authors.Select(author => $"{author.FirstName} {author.LastName}"))})";
}

void InsertNewSubjects()
{
    
    /* vnesuvanje na podatoci vo baza
    
       var subjectfsaf = new List<Subject>
    {
        new Subject
        {
            Name = "Programming",
            Description =
                "The course offers an introduction to programming and covers concepts such as basic data types, arithmetic, operators, input-output commands, conditional structures, loop structures, functions, recursion, algorithms dealing with arrays and matrices, search and sorting algorithms, pointers and pointer operations, declaration of custom data structures.",
            NumberOfWeeklyClasses = 4,
            LiteratureUsed = new List<Literature>
            {
                new Literature
                {
                    Name = "Head First C#",
                    Authors = new List<Author>
                    {
                        new Author
                        {
                            FirstName = "Andrew",
                            LastName = "Stellman"
                        }
                    },
                    ISBN = "9781491976708"
                }
            }
        },
        new Subject
        {
            Name = "Algorithms and Data Structures",
            Description = "Through this course, students will learn about fundamental concepts and principles of algorithm analysis and design, and in using different data structures. It reviews different algorithms for solving the same problem. It reviews in details the time and space complexity of algorithms and establishing criteria for finding the best algorithm. It studies the design of different, well-known data structures (linear and nonlinear) and considers the possibility of creating new data structures, as well as their concrete application. The final part of the course represents an introduction to graphs and reviewing of basic models for graph-algorithms. Students become familiar with different abstract data types and algorithms, which allow further direct involvement in analyzing, designing and application of specific software projects.",
            NumberOfWeeklyClasses = 4,
            LiteratureUsed = new List<Literature>
            {
                new Literature
                {
                    Name = "Introduction to Algorithms",
                    Authors = new List<Author>
                    {
                        new Author
                        {
                            FirstName = "Thoman",
                            LastName = "Corman"
                        },
                        new Author
                        {
                            FirstName = "Ronald",
                            LastName = "Rivest"
                        },
                        new Author
                        {
                            FirstName = "Clifford",
                            LastName = "Stein"
                        },
                    },
                    ISBN = "9780262033848"
                }
            }
        },
        new Subject
        {
            Name = "Software Engineering",
            Description = "The course objective is to provide students with in depth, critical and systematic understanding of principles and techniques of software specification, analysis and design, programming, testing and evaluation, maintenance and management with projecting effective software applications. Students will capture clear understanding of tools and methodology for developing software solutions.",
            NumberOfWeeklyClasses = 2,
            LiteratureUsed = new List<Literature>
            {
                new Literature
                {
                    Name = "Software Engineering",
                    Authors = new List<Author>
                    {
                        new Author
                        {
                            FirstName = "Ian",
                            LastName = "Sommerville"
                        }
                    },
                    ISBN = "0133943038"
                }
            }
        }
    };
  */
    
    
    
    var jsonString = Console.ReadLine();
    
    var subjects = JsonSerializer.Deserialize<List<Subject>>(jsonString ?? throw new InvalidOperationException());
    if (subjects == null) return;
    foreach (var subject in subjects)
    {
        subjectService.InsertSubject(subject);
    }
}