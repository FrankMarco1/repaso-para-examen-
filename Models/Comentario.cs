namespace repaso_para_examen__1.Models
{
    public class Comentario
    {
        public int id { get; set; }

        public string comentario { get; set; }

        public Fails Fails{get;set;}
        
    }
}