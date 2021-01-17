using Amazon.Lambda.Core;
using System.Collections;
using System.Collections.Generic;
using Amazon.Lambda.APIGatewayEvents;
using System.Text.Json;
using System.Text.Json.Serialization;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace AwsDotnetCsharp
{
    public class Handler
    {
       public APIGatewayProxyResponse GetTasks(APIGatewayProxyRequest request)
       {
          string userId = request.PathParameters["userId"];
          LambdaLogger.Log("Getting tasks for: " +userId);

          ArrayList tasks = new ArrayList();

          if(userId == "abc123") {
            Task t1 = new Task("abc1234", "Buy the milk", false);
            tasks.Add(t1);
          }
          else {
            Task t2 = new Task("abc4567", "Pick up newspaper", false);
            tasks.Add(t2);
          }

          return new APIGatewayProxyResponse
          {
            Body = JsonSerializer.Serialize(tasks),
            Headers = new Dictionary<string, string>
            { 
                { "Content-Type", "application/json" }, 
                { "Access-Control-Allow-Origin", "*" } 
            },
            StatusCode = 200,
          };
       }
    }

    public class Task
    {
      public string TaskId {get;}
      public string Description {get;}
      public bool Completed {get;}

      public Task(string taskId, string description, bool completed){
        TaskId = taskId;
        Description = description;
        Completed = completed;
      }
    }

    public class Request
    {
      public string Key1 {get; set;}
      public string Key2 {get; set;}
      public string Key3 {get; set;}
    }
}
