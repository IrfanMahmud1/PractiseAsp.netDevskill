using Reflection;
using System.Reflection;

Course _course = new Course();
_course.Title = "Asp.net";
_course.Fees = 30000;
_course.Teacher = new Instructor()
{
    Name = "Jalaluddin"
};
Address presentAddress = new Address();
presentAddress.Street = "101";
presentAddress.City = "Dhaka";
presentAddress.Country = "Bangladesh";

Address permanentAddress = new Address();
permanentAddress.Street = "102";
permanentAddress.City = "Rangpur";
permanentAddress.Country = "Bangladesh";

_course.Teacher.PresentAddress = presentAddress;
_course.Teacher.PermanentAddress = permanentAddress;
_course.StartDate = new DateTime(2022, 12, 1);

_course.Tests = new List<AdmissionTest>();
_course.Tags = new string[] { "C#", "HTML", "CSS" };

string[] stringArray = new string[] { "Hello", "World" };

List<Course> CourseList = new List<Course>();
CourseList.Add(_course);
CourseList.Add(_course);
CourseList.Add(_course);
CourseList.Add(_course);

AdmissionTest admissionTest1 = new AdmissionTest
{
    StartDateTime = new DateTime(2022, 10, 3, 9, 9, 9),
    EndDateTime = new DateTime(2022, 10, 3, 11, 11, 11),
    TestFees = 100
};
AdmissionTest admissionTest2 = new AdmissionTest
{
    StartDateTime = new DateTime(2022, 11, 3, 9, 9, 9),
    EndDateTime = new DateTime(2022, 11, 3, 10, 10, 10),
    TestFees = 150
};

_course.Tests = new List<AdmissionTest>();
_course.Tests.Add(admissionTest1);
_course.Tests.Add(admissionTest2);

Console.WriteLine(Test.Convert(_course));

//Type t = typeof(string);


//Type[] types = t.GetInterfaces();

//foreach (var c in types)
//{
//    Console.WriteLine(c.Name);
//}
//Console.WriteLine(t.Name);

List<string> tages = new List<string>()
{
    "Irfan","Mahmud"
};
//Array a = new Array[20];
//List<int> list = new List<int>();

//int cnt = (int)t.GetProperty("Count").GetValue(tages);

//PropertyInfo? itemPro = t.GetProperty("Item");
//Console.WriteLine(itemPro.GetType().Name);
//for (int i = 0; i < cnt; i++)
//{
//    string s = (string)itemPro.GetValue(tages, new object[] { i });
//    Console.WriteLine(s);
//}
//Console.WriteLine(cnt);

//List<int> s = new List<int>();
//Type t = s.GetType();
//Console.WriteLine(t.Name);