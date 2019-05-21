using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque
{
    class TestData
    {
        public TestData() { }

        public async void createData()
        {
            var context = await VideothequeDbContext.getInstance();

            await createGenre();
            await createMedia();
            await createPerson();
            //await createGenreMedia();

          
        }

        public async Task createGenre()
        {
            var context = await VideothequeDbContext.getInstance();

            //Creating genres
            Genre action = new Genre();
            action.Libelle = "Action";
            context.Genres.Add(action);
            Genre sf = new Genre();
            sf.Libelle = "SF";
            context.Genres.Add(sf);
            Genre spaceOpera = new Genre();
            spaceOpera.Libelle = "Space Opera";
            context.Genres.Add(spaceOpera);
            Genre robots = new Genre();
            robots.Libelle = "Robots";
            context.Genres.Add(robots);
            Genre aliens = new Genre();
            aliens.Libelle = "Aliens";
            context.Genres.Add(aliens);
            Genre cartoon = new Genre();
            cartoon.Libelle = "Cartoon";
            context.Genres.Add(cartoon);
            Genre adventure = new Genre();
            adventure.Libelle = "Adventure";
            context.Genres.Add(adventure);

            // Save VideothequeDbContext
            context.SaveChanges();

        }

        public async Task createMedia()
        {
            var context = await VideothequeDbContext.getInstance();

            //Creating a movie
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
            context.Medias.Add(matrix);

            //Creating another movie
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
            context.Medias.Add(fightClub);

            //Creating a series
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
            context.Medias.Add(babylon5);

            // Save VideothequeDbContext
            context.SaveChanges();
        }

        public async Task createPerson()
        {
            var context = await VideothequeDbContext.getInstance();

            //Create a Person Matrix director
            Person lanaWachowski = new Person();
            lanaWachowski.LastName = "Wachowski";
            lanaWachowski.FirstName = "Lana";
            lanaWachowski.Nationality = "Americaine";
            lanaWachowski.BirthDate = new DateTime(1965, 6, 21);
            context.Persons.Add(lanaWachowski);
            //Create a Person Matrix director
            Person lillyWachowski = new Person();
            lillyWachowski.LastName = "Wachowski";
            lillyWachowski.FirstName = "Lilly";
            lillyWachowski.Nationality = "Americaine";
            lillyWachowski.BirthDate = new DateTime(1967, 12, 29);
            context.Persons.Add(lanaWachowski);
            //Create a Person Neo
            Person keanuReeves = new Person();
            keanuReeves.LastName = "Reeves";
            keanuReeves.FirstName = "Keanu";
            keanuReeves.Nationality = "Canadienne";
            keanuReeves.BirthDate = new DateTime(1964, 9, 2);
            context.Persons.Add(keanuReeves);
            //Create a Person Trinity
            Person carrieAnneMoss = new Person();
            carrieAnneMoss.LastName = "Moss";
            carrieAnneMoss.FirstName = "Carrie-Anne";
            carrieAnneMoss.Nationality = "Canadienne";
            carrieAnneMoss.BirthDate = new DateTime(1967, 8, 21);
            context.Persons.Add(carrieAnneMoss);
            //Create a Person Morpheus
            Person laurenceFishburne = new Person();
            laurenceFishburne.LastName = "Fishburne";
            laurenceFishburne.FirstName = "Laurence";
            laurenceFishburne.Nationality = "Americaine";
            laurenceFishburne.BirthDate = new DateTime(1960, 7, 30);
            context.Persons.Add(laurenceFishburne);
            //Create a Person Agent Smith
            Person hugoWeaving = new Person();
            hugoWeaving.LastName = "Weaving";
            hugoWeaving.FirstName = "Hugo";
            hugoWeaving.Nationality = "Australienne";
            hugoWeaving.BirthDate = new DateTime(1960, 4, 4);
            context.Persons.Add(hugoWeaving);

            //Create a Person Fight Club Director
            Person davidFincher = new Person();
            davidFincher.LastName = "Fincher";
            davidFincher.FirstName = "David";
            davidFincher.Nationality = "Américaine";
            davidFincher.BirthDate = new DateTime(1962, 8, 28);
            context.Persons.Add(davidFincher);
            //Create a Person Main Character
            Person edwardNorton = new Person();
            edwardNorton.LastName = "Norton";
            edwardNorton.FirstName = "Edward";
            edwardNorton.Nationality = "Américaine";
            edwardNorton.BirthDate = new DateTime(1969, 8, 18);
            context.Persons.Add(edwardNorton);
            //Create a Person Tyler Durden
            Person bradPitt = new Person();
            bradPitt.LastName = "Pitt";
            bradPitt.FirstName = "Brad";
            bradPitt.Nationality = "Américaine";
            bradPitt.BirthDate = new DateTime(1963, 12, 18);
            context.Persons.Add(bradPitt);
            //Create a Person Marla Singer
            Person helenaCarter = new Person();
            helenaCarter.LastName = "Carter";
            helenaCarter.FirstName = "Helena";
            helenaCarter.Nationality = "Britannique";
            helenaCarter.BirthDate = new DateTime(1966, 5, 26);
            context.Persons.Add(helenaCarter);
            //Create a Person Bob Paulson
            Person meatLoaf = new Person();
            meatLoaf.LastName = "Loaf";
            meatLoaf.FirstName = "Meat";
            meatLoaf.Nationality = "Américaine";
            meatLoaf.BirthDate = new DateTime(1947, 9, 27);
            context.Persons.Add(meatLoaf);

            //Create a Person John Sherridan
            Person bruceBoxleitner = new Person();
            laurenceFishburne.LastName = "Boxleitner";
            laurenceFishburne.FirstName = "Bruce";
            laurenceFishburne.Nationality = "Améicaine";
            laurenceFishburne.BirthDate = new DateTime(1950, 5, 12);
            context.Persons.Add(laurenceFishburne);
            //Create a Person Susan Ivanova
            Person claudiaChristian = new Person();
            claudiaChristian.LastName = "Christian";
            claudiaChristian.FirstName = "Claudia";
            claudiaChristian.Nationality = "Améicaine";
            claudiaChristian.BirthDate = new DateTime(1965, 8, 10);
            context.Persons.Add(claudiaChristian);
            //Create a Person Garibaldi
            Person jerryDoyle = new Person();
            jerryDoyle.LastName = "Doyle";
            jerryDoyle.FirstName = "Jerry";
            jerryDoyle.Nationality = "Améicaine";
            jerryDoyle.BirthDate = new DateTime(1956, 7, 16);
            context.Persons.Add(jerryDoyle);
            //Create a Person Delenn
            Person miraFurlan = new Person();
            miraFurlan.LastName = "Furlan";
            miraFurlan.FirstName = "Furlan";
            miraFurlan.Nationality = "Croate";
            miraFurlan.BirthDate = new DateTime(1955, 9, 7);
            context.Persons.Add(miraFurlan);
            //Create a Person G'kar
            Person andreasKatsulas = new Person();
            andreasKatsulas.LastName = "Katsulas";
            andreasKatsulas.FirstName = "Andreas";
            andreasKatsulas.Nationality = "Ameéicaine";
            andreasKatsulas.BirthDate = new DateTime(1946, 5, 18);
            context.Persons.Add(andreasKatsulas);
            //Create a Person Londo Mollari
            Person peterJurasik = new Person();
            peterJurasik.LastName = "Jurasik";
            peterJurasik.FirstName = "Peter";
            peterJurasik.Nationality = "Ameéicaine";
            peterJurasik.BirthDate = new DateTime(1950, 4, 25);
            context.Persons.Add(peterJurasik);

            // Save VideothequeDbContext
            context.SaveChanges();
        }

        public async Task createGenreMedia()
        {
           var context = await VideothequeDbContext.getInstance();

            // Genre for serie Babylon5
            GenreMedia babylon5SF = new GenreMedia();
            Media b5 = context.Medias.Where((m) => m.Title.Equals("Babylon 5")).FirstOrDefault();
            babylon5SF.MediaId = b5.MediaId;
            Genre sf = context.Genres.Where((g) => g.Libelle.Equals("SF")).FirstOrDefault();
            babylon5SF.GenreId = sf.GenreId;

            context.GenreMedias.Add(babylon5SF);

            // Genre for serie FightClub
            GenreMedia fightClubAction  = new GenreMedia();
            Media fightClub = context.Medias.Where((m) => m.Title.Equals("Fight Club")).FirstOrDefault();
            fightClubAction.MediaId = fightClub.MediaId;
            Genre action = context.Genres.Where((g) => g.Libelle.Equals("Action")).FirstOrDefault();
            fightClubAction.GenreId = action.GenreId;

            context.GenreMedias.Add(fightClubAction);

            // Genre for serie Matrix
            GenreMedia matrixSF = new GenreMedia();
            Media matrix = context.Medias.Where((m) => m.Title.Equals("Matrix")).FirstOrDefault();
            matrixSF.MediaId = matrix.MediaId;
            fightClubAction.GenreId = sf.GenreId;

            context.GenreMedias.Add(matrixSF);

            // Save dbContext
            context.SaveChanges();

        }
    }
}
