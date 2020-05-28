namespace Parcial_02
{
    public class Producto
    {
        public int idProduct { get; set; }
        public int idBusiness { get; set; }
        public string name { get; set; }
       
        public Producto()
        {
            idProduct = 0;
            idBusiness = 0;
            name = "";
        }
    }
}