﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Videotheque.Model;

namespace Videotheque.Migrations
{
    [DbContext(typeof(VideothequeDbContext))]
    [Migration("20190618070054_final")]
    partial class final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("Videotheque.Model.Episode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BroadcastDate");

                    b.Property<string>("Description");

                    b.Property<int>("Duration");

                    b.Property<int>("MediaId");

                    b.Property<int>("NumEpisode");

                    b.Property<int>("NumSeason");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.HasKey("EpisodeId");

                    b.HasIndex("MediaId");

                    b.ToTable("Episode");
                });

            modelBuilder.Entity("Videotheque.Model.Genre", b =>
                {
                    b.Property<int>("GenreId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Libelle");

                    b.HasKey("GenreId");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("Videotheque.Model.GenreMedia", b =>
                {
                    b.Property<int>("MediaId");

                    b.Property<int>("GenreId");

                    b.HasKey("MediaId", "GenreId");

                    b.HasIndex("GenreId");

                    b.ToTable("GenreMedias");
                });

            modelBuilder.Entity("Videotheque.Model.Media", b =>
                {
                    b.Property<int>("MediaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Comment");

                    b.Property<string>("DateRelease");

                    b.Property<int?>("Duration");

                    b.Property<string>("ImagePath");

                    b.Property<int>("LanguageMedia");

                    b.Property<int>("LanguageSubtitles");

                    b.Property<int>("LanguageVO");

                    b.Property<int?>("MinAge");

                    b.Property<bool?>("NumericalSupport");

                    b.Property<bool?>("PhysicalSupport");

                    b.Property<int>("Rated");

                    b.Property<bool?>("Seen");

                    b.Property<string>("Synopsis");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Type");

                    b.HasKey("MediaId");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("Videotheque.Model.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Nationality");

                    b.Property<string>("Picture");

                    b.Property<int>("Title");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("Videotheque.Model.PersonMedia", b =>
                {
                    b.Property<int>("PersonMediaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Function");

                    b.Property<int>("MediaId");

                    b.Property<int>("PersonId");

                    b.Property<string>("Role");

                    b.HasKey("PersonMediaId");

                    b.HasIndex("MediaId");

                    b.HasIndex("PersonId");

                    b.ToTable("PersonMedias");
                });

            modelBuilder.Entity("Videotheque.Model.Episode", b =>
                {
                    b.HasOne("Videotheque.Model.Media", "Media")
                        .WithMany("Episodes")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Videotheque.Model.GenreMedia", b =>
                {
                    b.HasOne("Videotheque.Model.Genre", "Genre")
                        .WithMany("GenreMedias")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Videotheque.Model.Media", "Media")
                        .WithMany("GenreMedias")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Videotheque.Model.PersonMedia", b =>
                {
                    b.HasOne("Videotheque.Model.Media", "Media")
                        .WithMany("PersonMedias")
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Videotheque.Model.Person", "Person")
                        .WithMany("PersonMedias")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}