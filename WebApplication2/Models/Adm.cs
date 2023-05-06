namespace WebApplication2.Models
{
    public class Administrador : Pessoa
    {
        private int idAdmin { get; set; }
        public int getIdAdmin
        {
            get { return idAdmin; }
        }
        public void setIdAdmin(int id)
        {
            idAdmin = id;
        }
    }
}

