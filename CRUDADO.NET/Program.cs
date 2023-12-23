// See https://aka.ms/new-console-template for more information
using CRUDADO.NET;

Console.WriteLine("Hello, World!");

//Crud crud = new Crud();
//int reslut = crud.Create("Nesir");
//Console.WriteLine(reslut);

////crud.Get();
//Crud.Get();

//Console.WriteLine(crud.Update("Qasim", 3));
//Crud.Get();

//Console.WriteLine(crud.Delete(5));
//Crud.Get();

CrudWithProsedur crudWithProsedur = new CrudWithProsedur();

//bool result = crudWithProsedur.AddActor(new() {Name = "Velwi0"}, "AddActor");

//var resUp = crudWithProsedur.UpdateActor(new() { Id=1007, Name="UpName"}, "UpdateActor");
//var resDel = crudWithProsedur.DeleteActor(1004, "DeleteActor");
//Console.WriteLine(resDel);
var data = crudWithProsedur.GetByIdActorWithoutDataAdapter(3, "GetActorById");
Console.WriteLine(data.Id + " " + data.Name);

//var res = crudWithProsedur.GetActorsWithDataAdapter("GetActors");

//foreach (var actor in res)
//{
//    Console.WriteLine(actor.Id + " " + actor.Name);
//}
//Console.WriteLine(res);
