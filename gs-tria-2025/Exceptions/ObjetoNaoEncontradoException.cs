namespace gs_tria_2025.Exceptions
{
    public class ObjetoNaoEncontradoException : Exception
    {
        public ObjetoNaoEncontradoException(string entidade, string operacao ) : base($"{entidade} não encontrado para {operacao}.")
        {

        }
    }
}
