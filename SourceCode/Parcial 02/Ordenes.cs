using System;

namespace Parcial_02
{
    public class Ordenes
    {
        public int idOrder { get; set; }
        public DateTime createDate { get; set; }
        public string name { get; set; }
        public string fullName { get; set; }
        public string address { get; set; }
        
       
        public Ordenes()
        {
            idOrder = 0;
            createDate = DateTime.Now;
            name = "";
            fullName = "";
            address = "";
        }
    }
}