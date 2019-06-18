﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Videotheque.Model;

namespace Videotheque
{
    class InitData
    {
        public InitData() { }

        public async void createData()
        {
            var context = await VideothequeDbContext.getInstance();
            await createPerson();
        }
        public static Genre GenreAction()
        {
            Genre action = new Genre();
            action.Libelle = "Action";
            return action;
        }
        public static Genre GenreSf()
        {
            Genre sf = new Genre();
            sf.Libelle = "Sf";
            return sf;
        }
        public static Genre GenreSpaceOpera()
        {
            Genre spaceOpera = new Genre();
            spaceOpera.Libelle = "Space opera";
            return spaceOpera;
        }
        public static Genre GenreRobots()
        {
            Genre robots = new Genre();
            robots.Libelle = "Robots";
            return robots;
        }
        public static Genre GenreAliens()
        {
            Genre aliens = new Genre();
            aliens.Libelle = "Aliens";
            return aliens;
        }
        public static Genre GenreCartoon()
        {
            Genre cartoon = new Genre();
            cartoon.Libelle = "Cartoon";
            return cartoon;
        }
        public static Genre GenreAdventure()
        {
            Genre adventure = new Genre();
            adventure.Libelle = "Adventure";
            return adventure;
        }
        public static Media MovieMatrix(List<Genre> genres)
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

        public static Media MovieFightClub(List<Genre> genres)
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
                
        public static Media SeriesBabylon5(List<Genre> genres)
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

            context.SaveChanges();
        }
    }
}
