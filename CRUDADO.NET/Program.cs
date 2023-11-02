// See https://aka.ms/new-console-template for more information
using CRUDADO.NET;

Console.WriteLine("Hello, World!");

Crud crud = new Crud();
int reslut = crud.Create("Nesir");
Console.WriteLine(reslut);

//crud.Get();
Crud.Get();

Console.WriteLine(crud.Update("Qasim", 3));
Crud.Get();

Console.WriteLine(crud.Delete(5));
Crud.Get();
