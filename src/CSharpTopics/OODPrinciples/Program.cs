// See https://aka.ms/new-console-template for more information
using OODPrinciples.EncapsulateWhatChanges;
using OODPrinciples.LSP;
using OODPrinciples.SRP;

//Console.WriteLine("Hello, World!");

//Membership membership = new Membership();
//membership.CreateAccount("", "", "");

// 
Square square = new Square();
square.Height = 5;
square.Width = 10;

IDataService dataService = new DataService();

BusinessLogic businessLogic = new BusinessLogic(dataService);