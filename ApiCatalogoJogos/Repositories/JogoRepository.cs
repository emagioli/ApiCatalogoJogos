using ApiCatalogoJogos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCatalogoJogos.Repositories
{
    public class JogoRepository : IJogoRepository
    {
        private static Dictionary<Guid, Jogo> jogos = new Dictionary<Guid, Jogo>()
        {
            {Guid.Parse("07ed7c90-585f-42c7-8207-8bbac86c9ce7"), new Jogo{ Id = Guid.Parse("07ed7c90-585f-42c7-8207-8bbac86c9ce7"), Nome = "Dark Souls", Produtora = "FromSoftware", Preco = 150} },
            {Guid.Parse("d498ba7f-14a3-4f13-97a6-0a37bca6e70c"), new Jogo{ Id = Guid.Parse("d498ba7f-14a3-4f13-97a6-0a37bca6e70c"), Nome = "Fifa 21", Produtora = "EA", Preco = 200} },
            {Guid.Parse("819f0c54-d81c-4321-bf31-b7047bee3558"), new Jogo{ Id = Guid.Parse("819f0c54-d81c-4321-bf31-b7047bee3558"), Nome = "Death Stranding", Produtora = "Kojima Productions", Preco = 250} },
            {Guid.Parse("eb845b1d-7398-48f2-8cdb-42df2d460dc2"), new Jogo{ Id = Guid.Parse("eb845b1d-7398-48f2-8cdb-42df2d460dc2"), Nome = "Tomb Raider", Produtora = "Square Enix", Preco = 180} },
            {Guid.Parse("5f9c50e3-e9b7-4be5-946e-5e2e59cbb1ab"), new Jogo{ Id = Guid.Parse("5f9c50e3-e9b7-4be5-946e-5e2e59cbb1ab"), Nome = "Hollow Knight", Produtora = "Team Cherry", Preco = 100} },
            {Guid.Parse("5dd64f1e-0855-416f-b6fc-cecbf65b828b"), new Jogo{ Id = Guid.Parse("5dd64f1e-0855-416f-b6fc-cecbf65b828b"), Nome = "Bloodborne", Produtora = "FromSoftware", Preco = 80} }
        };

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(jogos.Values.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }

        public Task<Jogo> Obter(Guid id)
        {
            if (!jogos.ContainsKey(id))
                return null;

            return Task.FromResult(jogos[id]);
        }

        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
            return Task.FromResult(jogos.Values.Where(jogo => jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora)).ToList());
        }

        public Task<List<Jogo>> ObterSemLamda(string nome, string produtora)
        {
            var retorno = new List<Jogo>();

            foreach (var jogo in jogos.Values)
            {
                if (jogo.Nome.Equals(nome) && jogo.Produtora.Equals(produtora))
                    retorno.Add(jogo);
            }

            return Task.FromResult(retorno);
        }

        public Task Inserir(Jogo jogo)
        {
            jogos.Add(jogo.Id, jogo);
            return Task.CompletedTask;
        }

        public Task Atualizar(Jogo jogo)
        {
            jogos[jogo.Id] = jogo;
            return Task.CompletedTask;
        }

        public Task Remover(Guid id)
        {
            jogos.Remove(id);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            //Fechar conexão com o banco
        }
    }
}
