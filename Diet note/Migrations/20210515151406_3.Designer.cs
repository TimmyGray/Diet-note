// <auto-generated />
using System;
using Diet_note;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diet_note.Migrations
{
    [DbContext(typeof(Aplicatincontext))]
    [Migration("20210515151406_3")]
    partial class _3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.5");

            modelBuilder.Entity("Diet_note.Edgeelements", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Calloriesedge")
                        .HasColumnType("TEXT");

                    b.Property<string>("Carbohydrates")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fats")
                        .HasColumnType("TEXT");

                    b.Property<int>("Numbereats")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Proteins")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Edges");
                });

            modelBuilder.Entity("Diet_note.Energoelements", b =>
                {
                    b.Property<int>("EnergoelementsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Callories")
                        .HasColumnType("TEXT");

                    b.Property<string>("Carbohydrates")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fats")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Protein")
                        .HasColumnType("TEXT");

                    b.HasKey("EnergoelementsId");

                    b.ToTable("Elements");
                });

            modelBuilder.Entity("Diet_note.History", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Callories")
                        .HasColumnType("TEXT");

                    b.Property<string>("CarboHydrates")
                        .HasColumnType("TEXT");

                    b.Property<int>("Countofeat")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<string>("Fats")
                        .HasColumnType("TEXT");

                    b.Property<string>("Foodname")
                        .HasColumnType("TEXT");

                    b.Property<string>("Proteins")
                        .HasColumnType("TEXT");

                    b.Property<int>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("firsttime")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Histories");
                });

            modelBuilder.Entity("Diet_note.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Diet_note.Edgeelements", b =>
                {
                    b.HasOne("Diet_note.User", "user")
                        .WithOne("Edges")
                        .HasForeignKey("Diet_note.Edgeelements", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Diet_note.History", b =>
                {
                    b.HasOne("Diet_note.User", "user")
                        .WithMany("Histories")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("Diet_note.User", b =>
                {
                    b.Navigation("Edges");

                    b.Navigation("Histories");
                });
#pragma warning restore 612, 618
        }
    }
}
