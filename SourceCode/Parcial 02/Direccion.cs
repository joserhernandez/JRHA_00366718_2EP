namespace Parcial_02
{
    public class Direccion
    {
        public int idAddress { get; set; }
        public int idUser { get; set; }
        public string address { get; set; }
        
       
        public Direccion()
        {
            idAddress = 0;
            idUser = 0;
            address = " ";
        }
    }
}