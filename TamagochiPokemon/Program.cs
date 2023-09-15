using RestSharp;

internal class Program
{
    private static void Main(string[] args)
    {
        var cliente = new RestClient("https://pokeapi.co/api/v2/pokemon/");
        RestRequest request = new RestRequest("", Method.Get);
        var response = cliente.Execute(request);

        Console.WriteLine(response.Content);


    }
}