using ScreenSound.Shared.Modelos.Response;
using System.Net.Http.Json;

namespace ScreenSound.WebAssembly.Services
{
    public class MusicasAPI
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<MusicasAPI> logger;

        public MusicasAPI(IHttpClientFactory factory, ILogger<MusicasAPI> logger)
        {
            _httpClient = factory.CreateClient("API");
            this.logger = logger;
        }

        public async Task<ICollection<MusicaResponse>> GetMusicasAsync()
        {
            try
            {
                logger.LogInformation("Iniciando a chamada para obter as músicas.");

                var result = await _httpClient.GetFromJsonAsync<ICollection<MusicaResponse>>("musicas");
                logger.LogInformation("Chamada concluída com sucesso. Total de músicas obtidas: {Count}", result?.Count ?? 0);

                return result;
            }catch (Exception ex)
            {
                logger.LogError(ex, "Erro ao obter as músicas.");
                throw;
            }
    }
}
