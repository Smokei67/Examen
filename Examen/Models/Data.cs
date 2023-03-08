
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace Examen.Models
{
    public class Data
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }

        public string nombres { get; set; }

        public string apellidos { get; set; }
        public string edad { get; set; }

        public string nota { get; set; }


        public string latitud { get; set; }

        public string longitud { get; set; }

    }
}
