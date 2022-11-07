namespace tarea1.Entidades
{
    public class ClaseProfesor
    {
        public int ClaseId { get; set; }
        public int ProfesorId { get; set; }
        public int Orden { get; set; }
        public Clase Clase { get; set; }
        public Profesor Profesor { get; set; }
    }
}
