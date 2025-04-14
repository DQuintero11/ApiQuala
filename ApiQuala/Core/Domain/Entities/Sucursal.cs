namespace ApiQuala.Core.Domain.Entities
{
    public class Sucursal
    {
        public int? Id { get; set; }

        public int Codigo { get; set; }

        public string Descripcion { get; set; }

        public string Direccion { get; set; }

        public string Identificacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int IdMoneda { get; set; }




    }

    public class SucursalDto
    {
        public int? Id { get; set; }

        public int Codigo { get; set; }

        public string Descripcion { get; set; }

        public string Direccion { get; set; }

        public string Identificacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        public int IdMoneda { get; set; }

        public string NombreMoneda { get; set; }




    }
}

