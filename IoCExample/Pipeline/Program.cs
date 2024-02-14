using System.Net;
using System.Net.Http;
using IoCExample;

var listener = new HttpListener();

listener.Prefixes.Add("http://localhost:8001");

listener.Start();
