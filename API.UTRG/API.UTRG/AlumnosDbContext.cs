using API.UTRG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.UTRG
{
    public class AlumnosDbContext
    {
        public static AlumnosDbContext context { get; } = new AlumnosDbContext();
        public List<AlumnoDto> Alumno { get; set; }

        public AlumnosDbContext()
        {
            Alumno = new List<AlumnoDto>()
            {
                new AlumnoDto{
                    ID =1,
                    Nombre ="willian tapia trujillo",
                    Email ="wilirex@hotmail.com",
                    Telefono ="733167238",
                    FechaNacimiento = new DateTime(1996,03,04),
                    Redes = new List<RedesSociales>()
                    {
                        new RedesSociales{
                            ID =1,
                            Nombre="Facebook",
                            RedSocial="https://www.facebook.com/willirex"
                        },
                        new RedesSociales(){
                            ID=2,
                            Nombre="Twitter",
                            RedSocial="https://twitter.com/willy"
                        }
                    }
                    },               
                new AlumnoDto {
                    ID =2,
                    Nombre ="luis angel castro valladares",
                    Email ="luisito@hotmail.com",
                    Telefono ="733127615",
                    FechaNacimiento = new DateTime(1997,01,17),
                    Redes = new List<RedesSociales>()
                    {
                        new RedesSociales{
                            ID =1,
                            Nombre="Facebook",
                            RedSocial="https://www.facebook.com/luisito"
                        },
                        new RedesSociales(){
                            ID=2,
                            Nombre="Twitter",
                            RedSocial="https://twitter.com/LuisitoCoding"
                        },
                         new RedesSociales(){
                            ID=3,
                            Nombre="Instagram",
                            RedSocial="https://instagram.com/luisitocoding"
                        }
                    }
                    },
                new AlumnoDto {
                    ID =3,
                    Nombre ="Irving Tapia Trujillo",
                    Email ="irving@gmail.com",
                    Telefono ="7331160045",
                    FechaNacimiento = new DateTime(1992,07,13)},
                new AlumnoDto {
                    ID = 4,
                    Nombre = "Neyd Enriquez Quezada",
                    Email = "idyenquezada@gmail.com",
                    Telefono = "7361059676",
                    FechaNacimiento = new DateTime (1996,12,11)},
                new AlumnoDto {
                    ID = 5,
                    Nombre ="Jessica Sanchez Gonzalez",
                    Email = "jess028.jg@gmail.com",
                    Telefono = "7331014065",
                    FechaNacimiento = new DateTime (1997,11,28)},
                new AlumnoDto {
                    ID =6,
                    Nombre ="Erik Camiña Perez",
                    Email ="campe28_08edgar@hotmail.com",
                    Telefono ="7331084567",
                    FechaNacimiento = new DateTime(1995,02,28)},
                new AlumnoDto {
                    ID =7,
                    Nombre ="Jossimar Escobar Barrera",
                    Email ="escjossi@hotmail.com",
                    Telefono ="7331049507",
                    FechaNacimiento = new DateTime(1994,11,23)},
                new AlumnoDto {
                    ID =8,
                    Nombre = "José Guadalupe Hernández Villafuerte",
                    Email ="joseh9412@hotmail.com",
                    Telefono="7331344511",
                    FechaNacimiento =new DateTime(1994,12,12)},
                new AlumnoDto {
                    ID =9,
                    Nombre ="Xochitl Lizbeth Cruz Castro",
                    Email ="lizzy_xrus@outlook.com",
                    Telefono ="7335934448",
                    FechaNacimiento = new DateTime(1996,08,04)},
                new AlumnoDto {
                    ID =10,
                    Nombre ="Erick Alexander Mercado Mazon",
                    Email ="mazon905@gmail.com",
                    Telefono ="7333325529",
                    FechaNacimiento = new DateTime(1996,03,16)},
                new AlumnoDto {
                    ID =11,
                    Nombre ="Agustin Cruz Salgado",
                    Email = "agustin.cruz.salgado@hoymail.com",
                    Telefono ="7331272232",
                    FechaNacimiento = new DateTime(1996,10,14)},
                new AlumnoDto{
                    ID =12,
                    Nombre ="Angelina Gonzalez Quevedo",
                    Email ="angelina.g.quevedo@gmail.com",
                    Telefono ="7332944308",
                    FechaNacimiento = new DateTime(1996, 12,09)},
                new AlumnoDto{
                    ID =13,
                    Nombre = "Liliana Yael Rosas Rodriguez",
                    Email ="lilirosas85@gmail.com",
                    Telefono ="7773531655",
                    FechaNacimiento = new DateTime(1995,11,20) },
                new AlumnoDto {
                    ID = 14,
                    Nombre ="Giovanni",
                    Email = "jhovany33@outlook.com",
                    Telefono ="7331358011",
                    FechaNacimiento = new DateTime(1996,10,14)},
                new AlumnoDto {
                    ID = 15,
                    Nombre ="Crhistopher Resendiz Sierra",
                    Email = "cr.250994@gmail.com",
                    Telefono ="7411244882",
                    FechaNacimiento = new DateTime(1994,09,25)}
            };
        }
    }
}
