using System.Security.Cryptography;

namespace task3
{

    // ======****** Models

    class Student
    {
        public int Id;
        public string Name;
        public int Age;
        public List<Course> Courses = new List<Course>();

        public bool Enroll(Course course)
        {
            if (course == null)

                for (int i = 0; i < Courses.Count; i++)
                {
                    if (Courses[i].Id == course.Id)
                        return false;
                }
            Courses.Add(course);
            return true;
        }

        public string GetDetails()
        {
            string result = $"ID: {Id}, Name: {Name}, Age: {Age} , Courses: ";

            if(Courses.Count == 0)

            
                result += "None";
                else
                {
                    for (int i = 0; i < Courses.Count; i++)
                    {
                        result += Courses[i].Title;
                        if (i < Courses.Count - 1)
                            result += ", ";


                    }
                }
                return result ;
           
        }
    }

    class Instructor
    {
        public int Id;
        public string Name;
        public string Specialization;

        public string GetDetails()
        {
            return $"ID: {Id}, Name: {Name}, Specialization: {Specialization}";
        }
    }

    class Course
    {
        public int Id;
        public string Title;
        public Instructor Instructor;

        public string GetDetails()
        {
            return $"ID: {Id}, Title: {Title}, Instructor: {Instructor?.Name}";
        }
    }

    class School
    {
        public List<Student> Students = new List<Student>();
        public List<Instructor> Instructors = new List<Instructor>();
        public List<Course> Courses = new List<Course>();

        public bool AddStudent(Student student)
        {
            if(student==null)
                return false;
            for(int i = 0;i < Students.Count;i++)
            {
                if (Students[i].Id == student.Id)
                    return false ;
            }
            Students.Add(student);
               return true;
        }
        public bool AddInstructor(Instructor instructor) 
        {
            if (instructor == null)
                return false;
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].Id == instructor.Id)
                    return false;
            }
            Instructors.Add(instructor);
            return true;
        }
        public bool AddCourse(Course course)
        {
            if (course == null)
                return false;
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].Id == course.Id)
                    return false;
            }
            Courses.Add(course);
            return true;
        }

        public bool EnrollStudentIncourse(int studentId , int courseId )
        {
            Student s = FindStudent(studentId);
            Course c = FindCourse(courseId);

            if (s == null || c == null) 
                return false;

            return s.Enroll(c);
            
        }

        public Student FindStudent(int Id)
        {
            for (int i = 0; i < Students.Count; i++)
            {
                if (Students[i].Id == Id)
                    return Students[i];
            }
                    return null;
        }
        public Instructor FindInstructor(int Id)
        {
            for (int i = 0; i < Instructors.Count; i++)
            {
                if (Instructors[i].Id == Id)
                    return Instructors[i];
            }
                    return null;
        }
        public Course FindCourse(int Id)
        {
            for (int i = 0; i < Courses.Count; i++)
            {
                if (Courses[i].Id == Id)
                    return Courses[i];
            }
                    return null;
        }
    }
    internal class Program
    {


        static void Main(string[] args)
        {

            School school = new School();

            while (true)
            {
                Console.WriteLine("\n--- MENU ---");
                Console.WriteLine("1. Add a New Student");
                Console.WriteLine("2. Add an Instructor");
                Console.WriteLine("3. Add a Course");
                Console.WriteLine("4. Enroll Student in Course");
                Console.WriteLine("5. View Students");
                Console.WriteLine("6. View Courses");
                Console.WriteLine("7. View Instructors");
                Console.WriteLine("8. Find a Student by Id");
                Console.WriteLine("9. Find a Course by Id");

                Console.WriteLine("10. Exit");
                Console.Write("Your Choice ==>>: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Write("Student ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Age: ");
                    int age = Convert.ToInt32(Console.ReadLine());

                    school.AddStudent(new Student { Id = id, Name = name, Age = age });
                    Console.WriteLine("Student added.");
                }
                else if (choice == "2")
                {
                    Console.Write("Instructor ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Specialization: ");
                    string spec = Console.ReadLine();

                    school.AddInstructor(new Instructor { Id = id, Name = name, Specialization = spec });
                    Console.WriteLine("Instructor added.");
                }
                else if (choice == "3")
                {
                    Console.Write("Course ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Title: ");
                    string title = Console.ReadLine();

                    Console.Write("Instructor ID: ");
                    int instId = Convert.ToInt32(Console.ReadLine());

                    Instructor instructor = school.FindInstructor(instId);
                    if (instructor != null)
                    {
                        school.AddCourse(new Course { Id = id, Title = title, Instructor = instructor });
                        Console.WriteLine("Course added.");
                    }
                    else
                    {
                        Console.WriteLine("Instructor not found.");
                    }
                }
                else if (choice == "4")
                {
                    Console.Write("Student ID: ");
                    int studentId = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Course ID: ");
                    int courseId = Convert.ToInt32(Console.ReadLine());

                    Student student = school.FindStudent(studentId);
                    Course course = school.FindCourse(courseId);

                    if (student != null && course != null)
                    {
                        student.Enroll(course);
                        Console.WriteLine("Enrolled successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Student or Course not found.");
                    }
                }
                else if (choice == "5")
                {
                    Console.WriteLine("\n--- Students ---");
                   
                    for (int i = 0; i<school.Students.Count; i++)

                        Console.WriteLine(school.Students[i].GetDetails());

                        
                }
                else if (choice == "6")
                {
                    Console.WriteLine("\n--- Courses ---");

                    for (int i = 0; i < school.Courses.Count; i++)

                        Console.WriteLine(school.Courses[i].GetDetails());

                }
                else if (choice == "7")
                {
                    Console.WriteLine("\n--- Instructors ---");
                    for (int i = 0; i < school.Instructors.Count; i++)

                        Console.WriteLine(school.Instructors[i].GetDetails());

                }
                else if (choice == "8")
                {
                    Console.WriteLine("Enter studint Id: ");

                    int sid = Convert.ToInt32(Console.ReadLine());
                    Student s = school.FindStudent(sid);
                    if (s == null)
                        Console.WriteLine("student not found");
                    else
                        Console.WriteLine(s.GetDetails());

                }
                else if (choice == "9")
                {
                    Console.WriteLine("enter courde Id");
                    int cid = Convert.ToInt32(Console.ReadLine());

                    Course c = school.FindCourse(cid);

                    if (c == null)
                        Console.WriteLine("course not found");
                    else
                        Console.WriteLine(c.GetDetails());

                }



                else if (choice == "10")
                {
                    Console.WriteLine("Goodbye!");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
    }
}

