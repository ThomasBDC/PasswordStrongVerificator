// See https://aka.ms/new-console-template for more information
using PasswordStrongVerificator;

Console.WriteLine("Hello, World!");
Console.WriteLine("Entrez votre mot de passe.");
string password = Console.ReadLine();

var robustesse = PasswordVerificator.Evalue(password);
Console.WriteLine(robustesse.ToString());