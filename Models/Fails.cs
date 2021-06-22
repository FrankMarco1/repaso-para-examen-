using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace repaso_para_examen__1.Models
{
    public class Fails 
    {
        public int Id { get; set; }
        public String UserID {get; set;}

        public String Titulo{ get; set; }


        public String Imagen{get; set;}
        public DateTime FechaRegistro{get; set;}
        public Fails(){
            FechaRegistro=DateTime.Now; 
        }

        public ICollection<Comentario> Comentarios { get; set; }
        
       
    }
}