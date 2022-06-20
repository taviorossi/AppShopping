using AppShopping.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppShopping.Services
{
    public class CinemaService
    {
        public List<Film> GetFilms()
        {
            return new List<Film>()
            {
                new Film(){
                    Cover = "https://upload.wikimedia.org/wikipedia/pt/f/ff/1917_poster.jpg",
                    Name = "1917",
                    Description = "Na Primeira Guerra Mundial, dois soldados devem atravessar terrtório inimigo e entregar uma menssage e salvar 1600 de seus companheiros.",
                    SessionGroups = new List<SessionGroup>{
                        new SessionGroup("Legendadas", new List<string>(){
                            "10:30h",
                            "14:30h",
                            "16:30h",
                            "17:30h",
                            "19:30h",
                        }),
                        new SessionGroup("Dublado", new List<string>(){
                            "15:30h",
                            "16:30h",
                            "17:30h",
                            "19:30h",
                        }),
                    }
                },
                new Film(){
                    Cover = "https://img.elo7.com.br/product/zoom/2C04FB4/big-poster-filme-aves-de-rapina-lo007-tamanho-90x60-cm-aves-de-rapina-dc-poster.jpg",
                    Name = "Arlequina em aves de rapina",
                    Description = "Filme que passa no universo da DC e é chato...",
                    SessionGroups = new List<SessionGroup>{
                        new SessionGroup("Legendadas", new List<string>(){
                            "10:30h",
                            "14:30h",
                            "16:30h",
                            "17:30h",
                            "19:30h",
                        }),
                        new SessionGroup("Dublado", new List<string>(){
                            "15:30h",
                            "16:30h",
                            "17:30h",
                            "19:30h",
                        }),
                    }
                },
            };
        }
    }
}
