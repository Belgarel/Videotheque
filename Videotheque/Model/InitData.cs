using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque
{
    class InitData
    {
        private static InitData _instance { get; set; }
        private InitData() { }
        public static InitData GetInstance()
        {
            if (_instance == null)
            {
                _instance = new InitData();
            }
            return _instance;
        }

        public void createData(VideothequeDbContext context)
        {
            // Create genres
            var genres = new Genre[]
            {
                GenreAction(),
                GenreAdventure(),
                GenreAliens(),
                GenreCartoon(),
                GenreRobots(),
                GenreSf(),
                GenreSpaceOpera()
            };
            List<Genre> genresFightClub = new List<Genre>();
            genresFightClub.Add(genres[0]);
            List<Genre> genresMatrix = new List<Genre>();
            genresMatrix.Add(genres[0]);
            genresMatrix.Add(genres[4]);
            genresMatrix.Add(genres[5]);
            List<Genre> genresBabylon5 = new List<Genre>();
            genresBabylon5.Add(genres[2]);
            genresBabylon5.Add(genres[5]);
            genresBabylon5.Add(genres[6]);

            // Create Medias
            var medias = new Media[]
            {
                MovieMatrix(genresMatrix),
                MovieFightClub(genresFightClub),
                SeriesBabylon5(genresBabylon5)
            };

            // Create Persons
            var persons = new Person[]
            {
                PersonLanaWachowski(),
                PersonLillyWachowski(),
                PersonKeanuReeves(),
                PersonCarrieAnneMoss(),
                PersonLaurenceFishburne(),
                PersonHugoWeaving(),
                PersonDavidFincher(),
                PersonEdwardNorton(),
                PersonBradPitt(),
                PersonHelenaCarter(),
                PersonMeatLoaf(),
                PersonBruceBoxleitner(),
                PersonClaudiaChristian(),
                PersonJerryDoyle(),
                PersonMiraFurlan(),
                PersonAndreasKatsulas(),
                PersonPeterJurasik()
        };
            // Adding their roles
            this.AddRole(medias[0], persons[0], PersonMediaFunction.Director, ""); // Matrix
            this.AddRole(medias[0], persons[1], PersonMediaFunction.Director, ""); // Matrix
            this.AddRole(medias[0], persons[2], PersonMediaFunction.Actor, "Neo"); // Matrix
            this.AddRole(medias[0], persons[3], PersonMediaFunction.Actor, "Trinity"); // Matrix
            this.AddRole(medias[0], persons[4], PersonMediaFunction.Actor, "Morpheus"); // Matrix
            this.AddRole(medias[0], persons[5], PersonMediaFunction.Actor, "Agent Smith"); // Matrix
            this.AddRole(medias[1], persons[6], PersonMediaFunction.Director, ""); // Fight Club
            this.AddRole(medias[1], persons[7], PersonMediaFunction.Actor, "Narrateur"); // Fight Club
            this.AddRole(medias[1], persons[8], PersonMediaFunction.Actor, "Tyler Durden"); // Fight Club
            this.AddRole(medias[1], persons[9], PersonMediaFunction.Actor, "Marla Singer"); // Fight Club
            this.AddRole(medias[1], persons[10], PersonMediaFunction.Actor, "Bob Paulson"); // Fight Club
            this.AddRole(medias[2], persons[11], PersonMediaFunction.Actor, "John Sheridan"); // Babylon 5
            this.AddRole(medias[2], persons[12], PersonMediaFunction.Actor, "Susan Ivanova"); // Babylon 5
            this.AddRole(medias[2], persons[13], PersonMediaFunction.Actor, "Michael Garibaldi"); // Babylon 5
            this.AddRole(medias[2], persons[14], PersonMediaFunction.Actor, "Delenn"); // Babylon 5
            this.AddRole(medias[2], persons[15], PersonMediaFunction.Actor, "G'Kar"); // Babylon 5
            this.AddRole(medias[2], persons[16], PersonMediaFunction.Actor, "Londo Mollari"); // Babylon 5

            // Save changes
            foreach (Genre genre in genres)
                context.Genres.Add(genre);
            foreach (Media media in medias)
                context.Medias.Add(media);
            foreach (Person person in persons)
                context.Persons.Add(person);
            context.SaveChanges();
        }

        private void AddRole(Media media, Person person, PersonMediaFunction function, string role)
        {
            List<PersonMedia> pms = person.PersonMedias;
            if (person.PersonMedias == null || media.PersonMedias == null)
            {
                pms = person.PersonMedias != null ? person.PersonMedias : new List<PersonMedia>();
                person.PersonMedias = pms;
                media.PersonMedias = pms;
            }
            PersonMedia pm = new PersonMedia();
            pm.Person = person;
            pm.Media = media;
            pm.Function = function;
            pm.Role = role;
            pms.Add(pm);
        }
        private void AddGenre(Media media, Genre genre)
        {
            List<GenreMedia> gms = media.GenreMedias;
            if (genre.GenreMedias == null || media.GenreMedias == null)
            {
                gms = genre.GenreMedias != null ? genre.GenreMedias : new List<GenreMedia>();
                genre.GenreMedias = gms;
                media.GenreMedias = gms;
            }
            GenreMedia gm = new GenreMedia();
            gm.Genre = genre;
            gm.Media = media;
            gms.Add(gm);
        }

        private Genre GenreAction()
        {
            Genre action = new Genre();
            action.Libelle = "Action";
            return action;
        }
        private Genre GenreSf()
        {
            Genre sf = new Genre();
            sf.Libelle = "Sf";
            return sf;
        }
        private Genre GenreSpaceOpera()
        {
            Genre spaceOpera = new Genre();
            spaceOpera.Libelle = "Space opera";
            return spaceOpera;
        }
        private Genre GenreRobots()
        {
            Genre robots = new Genre();
            robots.Libelle = "Robots";
            return robots;
        }
        private Genre GenreAliens()
        {
            Genre aliens = new Genre();
            aliens.Libelle = "Aliens";
            return aliens;
        }
        private Genre GenreCartoon()
        {
            Genre cartoon = new Genre();
            cartoon.Libelle = "Cartoon";
            return cartoon;
        }
        private Genre GenreAdventure()
        {
            Genre adventure = new Genre();
            adventure.Libelle = "Adventure";
            return adventure;
        }

        private Media MovieMatrix(List<Genre> genres)
        {
            Media matrix = new Media();
            matrix.Type = TypeMedia.Movie;
            matrix.Seen = true;
            matrix.Title = "Matrix";
            matrix.Comment = "Genius.";
            matrix.Duration = 130;
            matrix.MinAge = 15;
            matrix.LanguageVO = Language.English;
            matrix.LanguageMedia = Language.English;
            matrix.PhysicalSupport = true;
            matrix.GenreMedias = new List<GenreMedia>();
            foreach (Genre genre in genres)
            {
                GenreMedia gm = new GenreMedia();
                gm.Media = matrix;
                gm.Genre = genre;
                matrix.GenreMedias.Add(gm);
            }
            return matrix;
        }
        private Media MovieFightClub(List<Genre> genres)
        {
            Media fightClub = new Media();
            fightClub.Type = TypeMedia.Movie;
            fightClub.Seen = false;
            fightClub.Rated = 2;
            fightClub.Title = "Fight Club";
            fightClub.Comment = "I'd rather not talk about it";
            fightClub.Duration = 300;
            fightClub.MinAge = 9;
            fightClub.LanguageVO = Language.English;
            fightClub.LanguageMedia = Language.Japanese;
            fightClub.PhysicalSupport = false;
            fightClub.NumericalSupport = true;
            fightClub.GenreMedias = new List<GenreMedia>();
            foreach (Genre genre in genres)
            {
                GenreMedia gm = new GenreMedia();
                gm.Media = fightClub;
                gm.Genre = genre;
                fightClub.GenreMedias.Add(gm);
            }
            return fightClub;
        }
                
        private Media SeriesBabylon5(List<Genre> genres)
        {
            Media babylon5 = new Media();
            babylon5.Type = TypeMedia.Series;
            babylon5.Title = "Babylon 5";
            babylon5.Comment = "Londo 4ever";
            babylon5.Seen = true;
            babylon5.Rated = 5;
            babylon5.LanguageVO = Language.English;
            babylon5.LanguageMedia = Language.English;
            babylon5.LanguageSubtitles = Language.French;
            babylon5.NumericalSupport = true;
            babylon5.GenreMedias = new List<GenreMedia>();
            foreach (Genre genre in genres)
            {
                GenreMedia gm = new GenreMedia();
                gm.Media = babylon5;
                gm.Genre = genre;
                babylon5.GenreMedias.Add(gm);
            }
            babylon5.Episodes = new List<Episode>();
            babylon5.Episodes.Add(new Episode()
            {
                NumSeason = 1,
                NumEpisode = 1,
                Title = "Londo il est content",
                Description = "Encore bourré au casino :'-)"
            });
            babylon5.Episodes.Add(new Episode()
            {
                NumSeason = 1,
                NumEpisode = 2,
                Title = "Londo il est triste",
                Description = "Adira elle est mourrue :("
            });
            babylon5.Episodes.Add(new Episode()
            {
                NumSeason = 1,
                NumEpisode = 3,
                Title = "Londo il est en colère",
                Description = "Plein de Narns ils sont mourrus D:"
            });
            return babylon5;
        }

        private Person PersonLanaWachowski()
        {
            Person lanaWachowski = new Person();
            lanaWachowski.LastName = "Wachowski";
            lanaWachowski.FirstName = "Lana";
            lanaWachowski.Nationality = "Americaine";
            lanaWachowski.BirthDate = new DateTime(1965, 6, 21);
            return lanaWachowski;
        }
        private Person PersonLillyWachowski()
        {
            Person lillyWachowski = new Person();
            lillyWachowski.LastName = "Wachowski";
            lillyWachowski.FirstName = "Lilly";
            lillyWachowski.Nationality = "Americaine";
            lillyWachowski.BirthDate = new DateTime(1967, 12, 29);
            return lillyWachowski;
        }
        private Person PersonKeanuReeves()
        {
            Person keanuReeves = new Person();
            keanuReeves.LastName = "Reeves";
            keanuReeves.FirstName = "Keanu";
            keanuReeves.Nationality = "Canadienne";
            keanuReeves.BirthDate = new DateTime(1964, 9, 2);
            return keanuReeves;
        }
        private Person PersonCarrieAnneMoss()
        {
            Person carrieAnneMoss = new Person();
            carrieAnneMoss.LastName = "Moss";
            carrieAnneMoss.FirstName = "Carrie-Anne";
            carrieAnneMoss.Nationality = "Canadienne";
            carrieAnneMoss.BirthDate = new DateTime(1967, 8, 21);
            return carrieAnneMoss;
        }
        private Person PersonLaurenceFishburne()
        {
            Person laurenceFishburne = new Person();
            laurenceFishburne.LastName = "Fishburne";
            laurenceFishburne.FirstName = "Laurence";
            laurenceFishburne.Nationality = "Americaine";
            laurenceFishburne.BirthDate = new DateTime(1960, 7, 30);
            return laurenceFishburne;
        }
        private Person PersonHugoWeaving()
        {
            Person hugoWeaving = new Person();
            hugoWeaving.LastName = "Weaving";
            hugoWeaving.FirstName = "Hugo";
            hugoWeaving.Nationality = "Australienne";
            hugoWeaving.BirthDate = new DateTime(1960, 4, 4);
            return hugoWeaving;
        }
        private Person PersonDavidFincher()
        {
            Person davidFincher = new Person();
            davidFincher.LastName = "Fincher";
            davidFincher.FirstName = "David";
            davidFincher.Nationality = "Américaine";
            davidFincher.BirthDate = new DateTime(1962, 8, 28);
            return davidFincher;
        }
        private Person PersonEdwardNorton()
        {
            Person edwardNorton = new Person();
            edwardNorton.LastName = "Norton";
            edwardNorton.FirstName = "Edward";
            edwardNorton.Nationality = "Américaine";
            edwardNorton.BirthDate = new DateTime(1969, 8, 18);
            return edwardNorton;
        }
        private Person PersonBradPitt()
        {
            Person bradPitt = new Person();
            bradPitt.LastName = "Pitt";
            bradPitt.FirstName = "Brad";
            bradPitt.Nationality = "Américaine";
            bradPitt.BirthDate = new DateTime(1963, 12, 18);
            return bradPitt;
        }
        private Person PersonHelenaCarter()
        {
            Person helenaCarter = new Person();
            helenaCarter.LastName = "Carter";
            helenaCarter.FirstName = "Helena";
            helenaCarter.Nationality = "Britannique";
            helenaCarter.BirthDate = new DateTime(1966, 5, 26);
            return helenaCarter;
        }
        private Person PersonMeatLoaf()
        {
            Person meatLoaf = new Person();
            meatLoaf.LastName = "Loaf";
            meatLoaf.FirstName = "Meat";
            meatLoaf.Nationality = "Américaine";
            meatLoaf.BirthDate = new DateTime(1947, 9, 27);
            return meatLoaf;
        }
        private Person PersonBruceBoxleitner()
        {
            Person bruceBoxleitner = new Person();
            bruceBoxleitner.LastName = "Boxleitner";
            bruceBoxleitner.FirstName = "Bruce";
            bruceBoxleitner.Nationality = "Améicaine";
            bruceBoxleitner.BirthDate = new DateTime(1950, 5, 12);
            return bruceBoxleitner;
        }
        private Person PersonClaudiaChristian()
        {
            Person claudiaChristian = new Person();
            claudiaChristian.LastName = "Christian";
            claudiaChristian.FirstName = "Claudia";
            claudiaChristian.Nationality = "Améicaine";
            claudiaChristian.BirthDate = new DateTime(1965, 8, 10);
            return claudiaChristian;
        }
        private Person PersonJerryDoyle()
        {
            Person jerryDoyle = new Person();
            jerryDoyle.LastName = "Doyle";
            jerryDoyle.FirstName = "Jerry";
            jerryDoyle.Nationality = "Améicaine";
            jerryDoyle.BirthDate = new DateTime(1956, 7, 16);
            return jerryDoyle;
        }
        private Person PersonMiraFurlan()
        {
            Person miraFurlan = new Person();
            miraFurlan.LastName = "Furlan";
            miraFurlan.FirstName = "Furlan";
            miraFurlan.Nationality = "Croate";
            miraFurlan.BirthDate = new DateTime(1955, 9, 7);
            return miraFurlan;
        }
        private Person PersonAndreasKatsulas()
        {
            Person andreasKatsulas = new Person();
            andreasKatsulas.LastName = "Katsulas";
            andreasKatsulas.FirstName = "Andreas";
            andreasKatsulas.Nationality = "Ameéicaine";
            andreasKatsulas.BirthDate = new DateTime(1946, 5, 18);
            return andreasKatsulas;
        }
        private Person PersonPeterJurasik()
        {
            Person peterJurasik = new Person();
            peterJurasik.LastName = "Jurasik";
            peterJurasik.FirstName = "Peter";
            peterJurasik.Nationality = "Ameéicaine";
            peterJurasik.BirthDate = new DateTime(1950, 4, 25);
            return peterJurasik;
        }
    }
}
