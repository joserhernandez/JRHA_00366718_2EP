namespace Parcial_02
{
    public class Negocio
    {
        public int idBusiness { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        
        public Negocio()
        {
            idBusiness = 0;
            name = "";
            description = "";
        }
    }
}