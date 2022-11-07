using AutoMapper;
using tarea1.DTOs;
using tarea1.Entidades;

namespace tarea1.Utilidades
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ClaseDTO, Clase>();
            CreateMap<Clase, GetClaseDTO>();
            CreateMap<Clase, ClaseDTOConProfesores>()
                .ForMember(clasesDTO => clasesDTO.Profesores, opciones => opciones.MapFrom(MapClaseDTOProfesor));
            CreateMap<ProfesorCreacionDTO, Profesor>()
                .ForMember(profesor => profesor.ClaseProfesor, opciones => opciones.MapFrom(MapClaseProfesor));
            CreateMap<Profesor, ProfesorDTO>();
            CreateMap<Profesor, ProfesorDTOConClases>()
                .ForMember(profesorDTO => profesorDTO.Clases, opciones => opciones.MapFrom(MapProfesorDTOClase));
            CreateMap<ProfesorPatchDTO, Clase>().ReverseMap();
        }

        private List<ProfesorDTO> MapClaseDTOProfesor(Clase clase, GetClaseDTO getClaseDTO)
        {
            var result = new List<ProfesorDTO>();

            if (clase.ClaseProfesor == null) { return result; }

            foreach (var claseProfesor in clase.ClaseProfesor)
            {
                result.Add(new ProfesorDTO()
                {
                    Id = claseProfesor.ProfesorId,
                    Nombre = claseProfesor.Profesor.Nombre
                });
            }

            return result;
        }

        private List<GetClaseDTO> MapProfesorDTOClase(Profesor profesor, ProfesorDTO profesorDTO)
        {
            var result = new List<GetClaseDTO>();

            if (profesor.ClaseProfesor == null)
            {
                return result;
            }

            foreach (var claseprofesor in profesor.ClaseProfesor)
            {
                result.Add(new GetClaseDTO()
                {
                    Id = claseprofesor.ClaseId,
                    Nombre = claseprofesor.Clase.Nombre
                });
            }

            return result;
        }

        private List<ClaseProfesor> MapClaseProfesor(ProfesorCreacionDTO profesorCreacionDTO, Profesor profesor)
        {
            var resultado = new List<ClaseProfesor>();

            if (profesorCreacionDTO.ClasesIds == null) { return resultado; }
            foreach (var claseId in profesorCreacionDTO.ClasesIds)
            {
                resultado.Add(new ClaseProfesor() { ClaseId = claseId });
            }
            return resultado;
        }
    }
}