using Google.Cloud.Functions.Framework;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using FunctionLogic;

public class Function : IHttpFunction
{
    public async Task HandleAsync(HttpContext context)
    {
        using var reader = new StreamReader(context.Request.Body);
        var input = await reader.ReadToEndAsync();

        var function = new Function();
        var output = function.GetLength(input);

        await context.Response.WriteAsync(output);
    }
}
