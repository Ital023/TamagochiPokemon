
using Newtonsoft.Json;
using RestSharp;
using System;
using Tamagotchi;

public class Program
{
    public static void Main(string[] args)
    {

        var client = new RestClient("https://pokeapi.co/api/v2/pokemon-species/");
        var request = new RestRequest("",Method.Get);
        var response = client.Execute(request);

        var pokemonEspeciesResposta = JsonConvert.DeserializeObject<PokemonSpeciesResult>(response.Content);

        Console.WriteLine("Escolha um Tamagotchi:");
        for (int i = 0; i < pokemonEspeciesResposta.Results.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {pokemonEspeciesResposta.Results[i].Name}");
        }

        int escolha;


        while (true)
        {
            Console.WriteLine("\n");
            Console.Write("Escolha um número: ");
            if (!int.TryParse(Console.ReadLine(), out escolha) && escolha >= 1 && escolha <= pokemonEspeciesResposta.Results.Count)
            {
                Console.WriteLine("Escolha inválida. Tente novamente.");
            }
            else
                break;
        }

        client = new RestClient($"https://pokeapi.co/api/v2/pokemon/{escolha}");
        request = new RestRequest("", Method.Get);
        response = client.Execute(request);

        var pokemonDetalhes = JsonConvert.DeserializeObject<PokemonDetailsResult>(response.Content);

        var pokemonEscolhido = pokemonEspeciesResposta.Results[escolha - 1];

        Console.WriteLine("\n");
        Console.WriteLine($"Você escolheu {pokemonEscolhido.Name}!");
        Console.WriteLine($"Detalhes:");
        Console.WriteLine($"- Nome: {pokemonEscolhido.Name}");
        Console.WriteLine($"- Peso: {pokemonDetalhes.Weight}");
        Console.WriteLine($"- Altura: {pokemonDetalhes.Height}");

        Console.WriteLine("\n Habilidades do Mascote: ");

        foreach (var abilityDetail in pokemonDetalhes.Abilities)
        {
            Console.WriteLine("Nome da Habilidade: " + abilityDetail.Ability.Name);
        }

        Console.WriteLine("\n");
    }
}