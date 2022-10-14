﻿// <auto-generated />
using System;
using DemoEF6Peliculas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetTopologySuite.Geometries;

#nullable disable

namespace DemoEF6Peliculas.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20221013052248_VistaPeliculaConteo")]
    partial class VistaPeliculaConteo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Biografia")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Nacimiento")
                        .HasColumnType("datetime");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Actores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Biografia = "Thomas Stanley Holland (Kingston upon Thames, Londres; 1 de junio de 1996), conocido simplemente como Tom Holland, es un actor, actor de voz y bailarín británico.",
                            Nacimiento = new DateTime(1996, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Tom Holland"
                        },
                        new
                        {
                            Id = 2,
                            Biografia = "Samuel Leroy Jackson (Washington D. C., 21 de diciembre de 1948), conocido como Samuel L. Jackson, es un actor y productor de cine, televisión y teatro estadounidense. Ha sido candidato al premio Óscar, a los Globos de Oro y al Premio del Sindicato de Actores, así como ganador de un BAFTA al mejor actor de reparto.",
                            Nacimiento = new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Samuel L. Jackson"
                        },
                        new
                        {
                            Id = 3,
                            Biografia = "Robert John Downey Jr. (Nueva York, 4 de abril de 1965) es un actor, actor de voz, productor y cantante estadounidense. Inició su carrera como actor a temprana edad apareciendo en varios filmes dirigidos por su padre, Robert Downey Sr., y en su infancia estudió actuación en varias academias de Nueva York.",
                            Nacimiento = new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Robert Downey Jr."
                        },
                        new
                        {
                            Id = 4,
                            Nacimiento = new DateTime(1981, 6, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Chris Evans"
                        },
                        new
                        {
                            Id = 5,
                            Nacimiento = new DateTime(1972, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Dwayne Johnson"
                        },
                        new
                        {
                            Id = 6,
                            Nacimiento = new DateTime(2000, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Auli'i Cravalho"
                        },
                        new
                        {
                            Id = 7,
                            Nacimiento = new DateTime(1984, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Scarlett Johansson"
                        },
                        new
                        {
                            Id = 8,
                            Nacimiento = new DateTime(1964, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Nombre = "Keanu Reeves"
                        });
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.Cine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<Point>("Ubicacion")
                        .HasColumnType("geography");

                    b.HasKey("Id");

                    b.ToTable("Cines");

                    b.HasData(
                        new
                        {
                            Id = 4,
                            Nombre = "Acropolis",
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.939248 18.469649)")
                        },
                        new
                        {
                            Id = 2,
                            Nombre = "Sambil",
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.911582 18.482455)")
                        },
                        new
                        {
                            Id = 3,
                            Nombre = "Megacentro",
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.856309 18.506662)")
                        },
                        new
                        {
                            Id = 1,
                            Nombre = "Agora Mall",
                            Ubicacion = (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (-69.9388777 18.4839233)")
                        });
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.CineOferta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CineId")
                        .HasColumnType("int");

                    b.Property<decimal>("Descuento")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<DateTime>("Final")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Inicio")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.HasIndex("CineId")
                        .IsUnique();

                    b.ToTable("CinesOfertas");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            CineId = 4,
                            Descuento = 15m,
                            Final = new DateTime(2022, 10, 18, 0, 0, 0, 0, DateTimeKind.Local),
                            Inicio = new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Local)
                        },
                        new
                        {
                            Id = 1,
                            CineId = 1,
                            Descuento = 10m,
                            Final = new DateTime(2022, 10, 20, 0, 0, 0, 0, DateTimeKind.Local),
                            Inicio = new DateTime(2022, 10, 13, 0, 0, 0, 0, DateTimeKind.Local)
                        });
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("EstaBorrado")
                        .HasColumnType("bit");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("Nombre")
                        .IsUnique()
                        .HasFilter("EstaBorrado = 'false'");

                    b.ToTable("Generos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EstaBorrado = false,
                            Nombre = "Acción"
                        },
                        new
                        {
                            Id = 2,
                            EstaBorrado = false,
                            Nombre = "Animación"
                        },
                        new
                        {
                            Id = 3,
                            EstaBorrado = false,
                            Nombre = "Comedia"
                        },
                        new
                        {
                            Id = 4,
                            EstaBorrado = false,
                            Nombre = "Ciencia ficción"
                        },
                        new
                        {
                            Id = 5,
                            EstaBorrado = false,
                            Nombre = "Drama"
                        });
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.Log", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime");

                    b.Property<string>("Mensaje")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("EnCartelera")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Estreno")
                        .HasColumnType("datetime");

                    b.Property<string>("PosterURL")
                        .HasMaxLength(500)
                        .IsUnicode(false)
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("Peliculas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EnCartelera = false,
                            Estreno = new DateTime(2012, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/8/8a/The_Avengers_%282012_film%29_poster.jpg",
                            Titulo = "Avengers"
                        },
                        new
                        {
                            Id = 2,
                            EnCartelera = false,
                            Estreno = new DateTime(2017, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/9/98/Coco_%282017_film%29_poster.jpg",
                            Titulo = "Coco"
                        },
                        new
                        {
                            Id = 3,
                            EnCartelera = false,
                            Estreno = new DateTime(2021, 12, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg",
                            Titulo = "Spider-Man: No way home"
                        },
                        new
                        {
                            Id = 4,
                            EnCartelera = false,
                            Estreno = new DateTime(2019, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/0/00/Spider-Man_No_Way_Home_poster.jpg",
                            Titulo = "Spider-Man: Far From Home"
                        },
                        new
                        {
                            Id = 5,
                            EnCartelera = true,
                            Estreno = new DateTime(2100, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PosterURL = "https://upload.wikimedia.org/wikipedia/en/5/50/The_Matrix_Resurrections.jpg",
                            Titulo = "The Matrix Resurrections"
                        });
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.PeliculaActor", b =>
                {
                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<string>("Personaje")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("PeliculaId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("PeliculasActores");

                    b.HasData(
                        new
                        {
                            PeliculaId = 4,
                            ActorId = 2,
                            Orden = 2,
                            Personaje = "Samuel L. Jackson"
                        },
                        new
                        {
                            PeliculaId = 4,
                            ActorId = 1,
                            Orden = 1,
                            Personaje = "Peter Parker"
                        },
                        new
                        {
                            PeliculaId = 3,
                            ActorId = 1,
                            Orden = 1,
                            Personaje = "Peter Parker"
                        },
                        new
                        {
                            PeliculaId = 1,
                            ActorId = 3,
                            Orden = 2,
                            Personaje = "Iron Man"
                        },
                        new
                        {
                            PeliculaId = 1,
                            ActorId = 7,
                            Orden = 3,
                            Personaje = "Black Widow"
                        },
                        new
                        {
                            PeliculaId = 1,
                            ActorId = 4,
                            Orden = 1,
                            Personaje = "Capitán América"
                        },
                        new
                        {
                            PeliculaId = 5,
                            ActorId = 8,
                            Orden = 1,
                            Personaje = "Neo"
                        });
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.SalaCine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CineId")
                        .HasColumnType("int");

                    b.Property<string>("Moneda")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasPrecision(9, 2)
                        .HasColumnType("decimal(9,2)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("NoDefinida");

                    b.HasKey("Id");

                    b.HasIndex("CineId");

                    b.ToTable("SalasCine");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            CineId = 3,
                            Moneda = "",
                            Precio = 250m,
                            Tipo = "DosDimensiones"
                        },
                        new
                        {
                            Id = 6,
                            CineId = 3,
                            Moneda = "",
                            Precio = 330m,
                            Tipo = "TresDimensiones"
                        },
                        new
                        {
                            Id = 7,
                            CineId = 3,
                            Moneda = "",
                            Precio = 450m,
                            Tipo = "VIP"
                        },
                        new
                        {
                            Id = 8,
                            CineId = 4,
                            Moneda = "",
                            Precio = 250m,
                            Tipo = "DosDimensiones"
                        },
                        new
                        {
                            Id = 1,
                            CineId = 1,
                            Moneda = "",
                            Precio = 220m,
                            Tipo = "DosDimensiones"
                        },
                        new
                        {
                            Id = 2,
                            CineId = 1,
                            Moneda = "",
                            Precio = 320m,
                            Tipo = "TresDimensiones"
                        },
                        new
                        {
                            Id = 3,
                            CineId = 2,
                            Moneda = "",
                            Precio = 200m,
                            Tipo = "DosDimensiones"
                        },
                        new
                        {
                            Id = 4,
                            CineId = 2,
                            Moneda = "",
                            Precio = 290m,
                            Tipo = "TresDimensiones"
                        });
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.SinLlaves.CineSinUbicacion", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.ToView(null);

                    b.ToSqlQuery("SELECT id, nombre FROM Cines");
                });

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.Property<int>("GenerosId")
                        .HasColumnType("int");

                    b.Property<int>("PeliculasId")
                        .HasColumnType("int");

                    b.HasKey("GenerosId", "PeliculasId");

                    b.HasIndex("PeliculasId");

                    b.ToTable("GeneroPelicula");

                    b.HasData(
                        new
                        {
                            GenerosId = 1,
                            PeliculasId = 1
                        },
                        new
                        {
                            GenerosId = 4,
                            PeliculasId = 1
                        },
                        new
                        {
                            GenerosId = 2,
                            PeliculasId = 2
                        },
                        new
                        {
                            GenerosId = 4,
                            PeliculasId = 3
                        },
                        new
                        {
                            GenerosId = 1,
                            PeliculasId = 3
                        },
                        new
                        {
                            GenerosId = 3,
                            PeliculasId = 3
                        },
                        new
                        {
                            GenerosId = 4,
                            PeliculasId = 4
                        },
                        new
                        {
                            GenerosId = 1,
                            PeliculasId = 4
                        },
                        new
                        {
                            GenerosId = 3,
                            PeliculasId = 4
                        },
                        new
                        {
                            GenerosId = 4,
                            PeliculasId = 5
                        },
                        new
                        {
                            GenerosId = 1,
                            PeliculasId = 5
                        },
                        new
                        {
                            GenerosId = 5,
                            PeliculasId = 5
                        });
                });

            modelBuilder.Entity("PeliculaSalaCine", b =>
                {
                    b.Property<int>("PeliculasId")
                        .HasColumnType("int");

                    b.Property<int>("SalasCineId")
                        .HasColumnType("int");

                    b.HasKey("PeliculasId", "SalasCineId");

                    b.HasIndex("SalasCineId");

                    b.ToTable("PeliculaSalaCine");

                    b.HasData(
                        new
                        {
                            PeliculasId = 5,
                            SalasCineId = 3
                        },
                        new
                        {
                            PeliculasId = 5,
                            SalasCineId = 4
                        },
                        new
                        {
                            PeliculasId = 5,
                            SalasCineId = 1
                        },
                        new
                        {
                            PeliculasId = 5,
                            SalasCineId = 2
                        },
                        new
                        {
                            PeliculasId = 5,
                            SalasCineId = 5
                        },
                        new
                        {
                            PeliculasId = 5,
                            SalasCineId = 6
                        },
                        new
                        {
                            PeliculasId = 5,
                            SalasCineId = 7
                        });
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.CineOferta", b =>
                {
                    b.HasOne("DemoEF6Peliculas.Entidades.Cine", null)
                        .WithOne("Oferta")
                        .HasForeignKey("DemoEF6Peliculas.Entidades.CineOferta", "CineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.PeliculaActor", b =>
                {
                    b.HasOne("DemoEF6Peliculas.Entidades.Actor", "Actor")
                        .WithMany("PeliculasActores")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoEF6Peliculas.Entidades.Pelicula", "Pelicula")
                        .WithMany("PeliculasActores")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.SalaCine", b =>
                {
                    b.HasOne("DemoEF6Peliculas.Entidades.Cine", "Cine")
                        .WithMany("SalasCine")
                        .HasForeignKey("CineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cine");
                });

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.HasOne("DemoEF6Peliculas.Entidades.Genero", null)
                        .WithMany()
                        .HasForeignKey("GenerosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoEF6Peliculas.Entidades.Pelicula", null)
                        .WithMany()
                        .HasForeignKey("PeliculasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PeliculaSalaCine", b =>
                {
                    b.HasOne("DemoEF6Peliculas.Entidades.Pelicula", null)
                        .WithMany()
                        .HasForeignKey("PeliculasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemoEF6Peliculas.Entidades.SalaCine", null)
                        .WithMany()
                        .HasForeignKey("SalasCineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.Actor", b =>
                {
                    b.Navigation("PeliculasActores");
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.Cine", b =>
                {
                    b.Navigation("Oferta");

                    b.Navigation("SalasCine");
                });

            modelBuilder.Entity("DemoEF6Peliculas.Entidades.Pelicula", b =>
                {
                    b.Navigation("PeliculasActores");
                });
#pragma warning restore 612, 618
        }
    }
}
