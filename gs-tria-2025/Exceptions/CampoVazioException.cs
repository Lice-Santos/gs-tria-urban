using static System.Net.Mime.MediaTypeNames;

namespace gs_tria_2025.Exceptions
{
    public class CampoVazioException : Exception
    {
        public CampoVazioException(string nome) : base($"{nome} não pode estar vazio.")
        { 
            
        }
    }
}
