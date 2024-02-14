// See https://aka.ms/new-console-template for more information

using IoCExample;

var cnt = new Container();

cnt.Register<I3, Three>();
cnt.Register<ITwo, Two>();
cnt.Register<IOne, One>();


cnt.Resolve<IOne>();

Console.WriteLine("Пока");