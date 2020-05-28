namespace Parcial_02
{
    public class Usuario
    {
        public int idUser { get; set; }
        public string fullName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool admin { get; set; }

        public Usuario()
        {
            idUser = 0;
            fullName = "";
            userName = "";
            password = "";
            admin = false;
        }
    }
}