using Amazon.Lambda.Core;
using System.Collections;
using Amazon.Lambda.APIGatewayEvents;

[assembly:LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]
namespace AwsDotnetCsharp
{
    public class Handler
    {
       public ArrayList GetTasks(APIGatewayProxyRequest request)
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

          return tasks;
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
