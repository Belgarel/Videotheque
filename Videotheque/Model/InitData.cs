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

            foreach (Genre genre in genres)
                context.Genres.Add(genre);

            // Create Medias
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

            var medias = new Media[]
            {
                MovieMatrix(genresMatrix),
                MovieFightClub(genresFightClub),
                SeriesBabylon5(genresBabylon5)
            };

            foreach (Media media in medias)
                context.Medias.Add(media);

            // Create Persons
            var persons = new Person[]
            {
                PersonLanaWachowski(medias[0]),
                PersonLillyWachowski(medias[0]),
                PersonKeanuReeves(medias[0]),
                PersonCarrieAnneMoss(medias[0]),
                PersonLaurenceFishburne(medias[0]),
                PersonHugoWeaving(medias[0]),
                PersonDavidFincher(medias[1]),
                PersonEdwardNorton(medias[1]),
                PersonBradPitt(medias[1]),
                PersonHelenaCarter(medias[1]),
                PersonMeatLoaf(medias[1]),
                PersonBruceBoxleitner(medias[2]),
                PersonClaudiaChristian(medias[2]),
                PersonJerryDoyle(medias[2]),
                PersonMiraFurlan(medias[2]),
                PersonAndreasKatsulas(medias[2]),
                PersonPeterJurasik(medias[2]),
                PersonJosephStalin(),
                PersonDonaldTrump(),
                PersonMaggyThatcher(),
                PersonMaoZedung(),
                PersonToujouHideki(),
                PersonPolPot()
        };
            /*/ Adding their roles
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
            this.AddRole(medias[2], persons[16], PersonMediaFunction.Actor, "Londo Mollari"); // Babylon 5 */

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

        private Person PersonLanaWachowski(Media media)
        {
            Person lanaWachowski = new Person();
            lanaWachowski.Type = TypePerson.Other;
            lanaWachowski.LastName = "Wachowski";
            lanaWachowski.FirstName = "Lana";
            lanaWachowski.Nationality = "Americaine";
            lanaWachowski.BirthDate = new DateTime(1965, 6, 21);

            lanaWachowski.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = lanaWachowski;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Director;
            pm.Role = "";
            lanaWachowski.PersonMedias.Add(pm);
            PersonMedia pm2 = new PersonMedia();
            pm2.Person = lanaWachowski;
            pm2.Media = media;
            pm2.Function = PersonMediaFunction.Producer;
            pm2.Role = "Productrice exécutive";
            lanaWachowski.PersonMedias.Add(pm2);
            return lanaWachowski;
        }
        private Person PersonLillyWachowski(Media media)
        {
            Person lillyWachowski = new Person();
            lillyWachowski.Type = TypePerson.Other;
            lillyWachowski.LastName = "Wachowski";
            lillyWachowski.FirstName = "Lilly";
            lillyWachowski.Nationality = "Americaine";
            lillyWachowski.BirthDate = new DateTime(1967, 12, 29);

            lillyWachowski.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = lillyWachowski;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Director;
            pm.Role = "";
            lillyWachowski.PersonMedias.Add(pm);
            PersonMedia pm2 = new PersonMedia();
            pm2.Person = lillyWachowski;
            pm2.Media = media;
            pm2.Function = PersonMediaFunction.Producer;
            pm2.Role = "Productrice exécutive";
            lillyWachowski.PersonMedias.Add(pm2);
            return lillyWachowski;
        }
        private Person PersonKeanuReeves(Media media)
        {
            Person keanuReeves = new Person();
            keanuReeves.Type = TypePerson.Other;
            keanuReeves.LastName = "Reeves";
            keanuReeves.FirstName = "Keanu";
            keanuReeves.Nationality = "Canadienne";
            keanuReeves.BirthDate = new DateTime(1964, 9, 2);

            keanuReeves.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = keanuReeves;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "Neo";
            keanuReeves.PersonMedias.Add(pm);
            return keanuReeves;
        }
        private Person PersonCarrieAnneMoss(Media media)
        {
            Person carrieAnneMoss = new Person();
            carrieAnneMoss.Type = TypePerson.Other;
            carrieAnneMoss.LastName = "Moss";
            carrieAnneMoss.FirstName = "Carrie-Anne";
            carrieAnneMoss.Nationality = "Canadienne";
            carrieAnneMoss.BirthDate = new DateTime(1967, 8, 21);

            carrieAnneMoss.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = carrieAnneMoss;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "Trinity";
            carrieAnneMoss.PersonMedias.Add(pm);
            return carrieAnneMoss;
        }
        private Person PersonLaurenceFishburne(Media media)
        {
            Person laurenceFishburne = new Person();
            laurenceFishburne.Type = TypePerson.Other;
            laurenceFishburne.LastName = "Fishburne";
            laurenceFishburne.FirstName = "Laurence";
            laurenceFishburne.Nationality = "Americaine";
            laurenceFishburne.BirthDate = new DateTime(1960, 7, 30);

            laurenceFishburne.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = laurenceFishburne;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "Morpheus";
            laurenceFishburne.PersonMedias.Add(pm);
            return laurenceFishburne;
        }
        private Person PersonHugoWeaving(Media media)
        {
            Person hugoWeaving = new Person();
            hugoWeaving.Type = TypePerson.Other;
            hugoWeaving.LastName = "Weaving";
            hugoWeaving.FirstName = "Hugo";
            hugoWeaving.Nationality = "Australienne";
            hugoWeaving.BirthDate = new DateTime(1960, 4, 4);

            hugoWeaving.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = hugoWeaving;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "Agent Smith";
            hugoWeaving.PersonMedias.Add(pm);
            return hugoWeaving;
        }
        private Person PersonDavidFincher(Media media)
        {
            Person davidFincher = new Person();
            davidFincher.Type = TypePerson.Other;
            davidFincher.LastName = "Fincher";
            davidFincher.FirstName = "David";
            davidFincher.Nationality = "Américaine";
            davidFincher.BirthDate = new DateTime(1962, 8, 28);

            davidFincher.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = davidFincher;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Director;
            pm.Role = "";
            davidFincher.PersonMedias.Add(pm);
            return davidFincher;
        }
        private Person PersonEdwardNorton(Media media)
        {
            Person edwardNorton = new Person();
            edwardNorton.Type = TypePerson.Other;
            edwardNorton.LastName = "Norton";
            edwardNorton.FirstName = "Edward";
            edwardNorton.Nationality = "Américaine";
            edwardNorton.BirthDate = new DateTime(1969, 8, 18);

            edwardNorton.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = edwardNorton;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "Narrateur";
            edwardNorton.PersonMedias.Add(pm);
            return edwardNorton;
        }
        private Person PersonBradPitt(Media media)
        {
            Person bradPitt = new Person();
            bradPitt.Type = TypePerson.Other;
            bradPitt.LastName = "Pitt";
            bradPitt.FirstName = "Brad";
            bradPitt.Nationality = "Américaine";
            bradPitt.BirthDate = new DateTime(1963, 12, 18);

            bradPitt.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = bradPitt;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "Tyler Durden";
            bradPitt.PersonMedias.Add(pm);
            return bradPitt;
        }
        private Person PersonHelenaCarter(Media media)
        {
            Person helenaCarter = new Person();
            helenaCarter.Type = TypePerson.Other;
            helenaCarter.LastName = "Carter";
            helenaCarter.FirstName = "Helena";
            helenaCarter.Nationality = "Britannique";
            helenaCarter.BirthDate = new DateTime(1966, 5, 26);

            helenaCarter.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = helenaCarter;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "Marla Singer";
            helenaCarter.PersonMedias.Add(pm);
            return helenaCarter;
        }
        private Person PersonMeatLoaf(Media media)
        {
            Person meatLoaf = new Person();
            meatLoaf.Type = TypePerson.Other;
            meatLoaf.LastName = "Loaf";
            meatLoaf.FirstName = "Meat";
            meatLoaf.Nationality = "Américaine";
            meatLoaf.BirthDate = new DateTime(1947, 9, 27);

            meatLoaf.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = meatLoaf;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "Bob Paulson";
            meatLoaf.PersonMedias.Add(pm);
            return meatLoaf;
        }
        private Person PersonBruceBoxleitner(Media media)
        {
            Person bruceBoxleitner = new Person();
            bruceBoxleitner.Type = TypePerson.Other;
            bruceBoxleitner.LastName = "Boxleitner";
            bruceBoxleitner.FirstName = "Bruce";
            bruceBoxleitner.Nationality = "Américaine";
            bruceBoxleitner.BirthDate = new DateTime(1950, 5, 12);

            bruceBoxleitner.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = bruceBoxleitner;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "John Sherridan";
            bruceBoxleitner.PersonMedias.Add(pm);
            return bruceBoxleitner;
        }
        private Person PersonClaudiaChristian(Media media)
        {
            Person claudiaChristian = new Person();
            claudiaChristian.Type = TypePerson.Other;
            claudiaChristian.LastName = "Christian";
            claudiaChristian.FirstName = "Claudia";
            claudiaChristian.Nationality = "Américaine";
            claudiaChristian.BirthDate = new DateTime(1965, 8, 10);

            claudiaChristian.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = claudiaChristian;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "Susan Ivanova";
            claudiaChristian.PersonMedias.Add(pm);
            return claudiaChristian;
        }
        private Person PersonJerryDoyle(Media media)
        {
            Person jerryDoyle = new Person();
            jerryDoyle.Type = TypePerson.Other;
            jerryDoyle.LastName = "Doyle";
            jerryDoyle.FirstName = "Jerry";
            jerryDoyle.Nationality = "Américaine";
            jerryDoyle.BirthDate = new DateTime(1956, 7, 16);

            jerryDoyle.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = jerryDoyle;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "Michael Garibaldi";
            jerryDoyle.PersonMedias.Add(pm);
            return jerryDoyle;
        }
        private Person PersonMiraFurlan(Media media)
        {
            Person miraFurlan = new Person();
            miraFurlan.Type = TypePerson.Other;
            miraFurlan.LastName = "Furlan";
            miraFurlan.FirstName = "Furlan";
            miraFurlan.Nationality = "Croate";
            miraFurlan.BirthDate = new DateTime(1955, 9, 7);

            miraFurlan.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = miraFurlan;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "Delenn";
            miraFurlan.PersonMedias.Add(pm);
            return miraFurlan;
        }
        private Person PersonAndreasKatsulas(Media media)
        {
            Person andreasKatsulas = new Person();
            andreasKatsulas.Type = TypePerson.Other;
            andreasKatsulas.LastName = "Katsulas";
            andreasKatsulas.FirstName = "Andreas";
            andreasKatsulas.Nationality = "Ameéicaine";
            andreasKatsulas.BirthDate = new DateTime(1946, 5, 18);

            andreasKatsulas.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = andreasKatsulas;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "G'kar";
            andreasKatsulas.PersonMedias.Add(pm);
            return andreasKatsulas;
        }
        private Person PersonPeterJurasik(Media media)
        {
            Person peterJurasik = new Person();
            peterJurasik.Type = TypePerson.Other;
            peterJurasik.LastName = "Jurasik";
            peterJurasik.FirstName = "Peter";
            peterJurasik.Nationality = "Ameéicaine";
            peterJurasik.BirthDate = new DateTime(1950, 4, 25);

            peterJurasik.PersonMedias = new List<PersonMedia>();
            PersonMedia pm = new PersonMedia();
            pm.Person = peterJurasik;
            pm.Media = media;
            pm.Function = PersonMediaFunction.Actor;
            pm.Role = "Londo Mollari";
            peterJurasik.PersonMedias.Add(pm);
            return peterJurasik;
        }

        private Person PersonJosephStalin()
        {
            Person f = new Person();
            f.Type = TypePerson.Friend;
            f.LastName = "Staline";
            f.FirstName = "Joseph";
            f.Nationality = "Russe";
            f.BirthDate = new DateTime(1878, 12, 18);
            return f;
        }
        private Person PersonDonaldTrump()
        {
            Person f = new Person();
            f.Type = TypePerson.Friend;
            f.LastName = "Trump";
            f.FirstName = "Donald";
            f.Nationality = "Américaine";
            f.BirthDate = new DateTime(1946, 6, 14);
            return f;
        }
        private Person PersonMaggyThatcher()
        {
            Person f = new Person();
            f.Type = TypePerson.Friend;
            f.LastName = "Thatcher";
            f.FirstName = "Margaret";
            f.Nationality = "Britannique";
            f.BirthDate = new DateTime(1925, 10, 13);
            return f;
        }
        private Person PersonMaoZedung()
        {
            Person f = new Person();
            f.Type = TypePerson.Friend;
            f.LastName = "Zedung";
            f.FirstName = "Mao";
            f.Nationality = "Chinoise";
            f.BirthDate = new DateTime(1893, 12, 26);
            return f;
        }
        private Person PersonToujouHideki()
        {
            Person f = new Person();
            f.Type = TypePerson.Friend;
            f.LastName = "Hideki";
            f.FirstName = "Tojo";
            f.Nationality = "Japonaise";
            f.BirthDate = new DateTime(1884);
            return f;
        }
        private Person PersonPolPot()
        {
            Person f = new Person();
            f.Type = TypePerson.Friend;
            f.LastName = "Pot";
            f.FirstName = "Pol";
            f.Nationality = "Cambodgienne";
            f.BirthDate = new DateTime(1925, 5, 19);
            return f;
        }
    }
}
