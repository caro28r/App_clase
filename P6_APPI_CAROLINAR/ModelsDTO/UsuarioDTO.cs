namespace P6_APPI_CAROLINAR.ModelsDTOs
{
    //UN DTO (Data Tranfer Object) es un tipo 
    //de versión "recortada" de un modelo particular
    //donde se pretende quitar todas las complejidades
    //generadas en los modelos a partir del ORM (Entity
    //Framework en nuestro caso). 
    
    //El propósito también puede ser ocultar la estructura 
    //original de los modelos al equipo de desarrollo 
    //Front End ya sea porque no es necesaria visualizar
    //el modelo completo o porque no se debe mostrar la 
    //estructura original de las tablas a nivel de 
    //bases de datos. 

    //en este ejemplo vamos a transformar el modelo a idima español, 
    //ya que el original está en inglés e hipotéticamente el equipo de 
    //desarrollo solo habla español.

    public class UsuarioDTO
    {
        public int UsuarioID { get; set; }

        public string Correo { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string?  Telefono { get; set; }

        public string Contrasennia { get; set; } = null!;

        public int RolID { get; set; }

        //hasta acá todas han sido propiedades que están 
        //en el modelo original, pero además se pueden agregar otras
        //pensando en cuando hacemos consultas tipo inner join 
        //que combinen datos de varias tablas. 
        //siempre es mejor tener versiones lo más "planas" de 
        //los modelos. 

        public string? RolDescripcion { get; set; }

    }
}
