namespace gs_tria_2025.Exceptions
{
    public class CampoJaExistenteException : Exception
    {
        public CampoJaExistenteException(string campo) : base($"{campo} já existente.")
        {

        }
    }
}
