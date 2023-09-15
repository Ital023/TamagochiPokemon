using RestSharp;
using TamagochiPokemon;
using Newtonsoft.Json;

internal class Program
{
    private static void Main(string[] args)
    {
        var cliente = new RestClient("https://pokeapi.co/api/v2/pokemon/");
        RestRequest request = new RestRequest("", Method.Get);
        var response = cliente.Execute(request);

        //Console.WriteLine(response.Content);

        var pokemonEspeciesResposta = JsonConvert.DeserializeObject<PokemonEspecie>(response.Content);

        Console.WriteLine("Escolha um: ");
        int index = 0;
        foreach(var pokemon in pokemonEspeciesResposta.Results)
        {
            Console.WriteLine($"{index + 1}. {pokemon.Name}");
            index++;
        }

        int escolha = 0;
        int loop = 1;
        while (loop != 0)
        {
            Console.WriteLine("\n");
            Console.Write("Escolha um número: ");
            if (int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= pokemonEspeciesResposta.Results.Count)
            {
                loop = 0;
            }
            else
            {
                Console.WriteLine("Tente novamente, Numero invalido!"); ;
            }
                
        }

        cliente = new RestClient($"https://pokeapi.co/api/v2/pokemon/{escolha}");

        request = new RestRequest("", Method.Get);

        response = cliente.Execute(request);

        Console.WriteLine(response.Content);

    }
}