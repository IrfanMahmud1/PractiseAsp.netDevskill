// See https://aka.ms/new-console-template for more information
using CreationalPattern.Builder;
using CreationalPattern.AbstractFactory;
using CreationalPattern.Prototype;
using CreationalPattern.Singleton;
using System.Text;

//Console.WriteLine("Hello, World!");

//Logger logger1 = Logger.GetLogger();
//Logger logger2 = Logger.GetLogger();

//Car car1 = new Car();
//car1.Fuel = 20;
//car1.Model = "BMW";
//car1.Speed = 1800;

//Car car2 = car1.Copy();

//ItemBuilder itemBuilder1 = new ItemBuilder();
//itemBuilder1.SetValue3("password");
//itemBuilder1.SetValue1("username");

//Item item = itemBuilder1.GetItem();

//StringBuilder sb = new StringBuilder();
//sb.AppendLine("Hello!");
//sb.AppendLine("Irfan Mah0mud");

//string text =  sb.ToString();

//CarFactory carFactory = new CarFactory();
//CreationalPattern.Factory.Car car3 = carFactory.CreateCar("CreationalPattern.Factory.Toyota", "AXIO", "Red", 1000);

CarFactory abstractCarFactory = new NissanFactory();
Engine nissanEngine = abstractCarFactory.EngineFactory.CreateEngine();
HeadLight nissanHeadLight = abstractCarFactory.HeadLIghtFactory.CreateHeadLight(); 
