using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.IO;
using System.Net;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace myApp
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class API : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData revit, ref string message, ElementSet elements)
        {
            string url = "https://jsonplaceholder.typicode.com/todos/1";  // sample https://nilo22.herokuapp.com/
            string apiResponse = this.GetRequest(url);

            TaskDialog.Show(url, apiResponse);
            return Autodesk.Revit.UI.Result.Succeeded;
        }
        public string GetRequest(string url = "https://jsonplaceholder.typicode.com/todos/1")
        {
            WebRequest request = WebRequest.Create(url);
            //request.Credentials = CredentialCache.DefaultCredentials;

            WebResponse response = request.GetResponse(); // Get the response.

            string responseFromServer;
            using (Stream dataStream = response.GetResponseStream()) // Get the stream containing content returned by the server. The using block ensures the stream is automatically closed.
            {
                StreamReader reader = new StreamReader(dataStream); // Open the stream using a StreamReader for easy access.                
                responseFromServer = reader.ReadToEnd(); // Read the content.
            }

            response.Close();
            return responseFromServer;
        }

        public string PostRequest(DataParser.Data data, string url = "https://jsonplaceholder.typicode.com/todos/1")
        {
            Debug.WriteLine("\nHello Synchronizing! "+ data.Print());

            var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";

            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = data.ToJSON();
                streamWriter.Write(json);
            }

            string responseFromServer;
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                responseFromServer = streamReader.ReadToEnd();
            }

            httpResponse.Close();
            return responseFromServer;
        }
    }
}
