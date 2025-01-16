﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace OnePiece.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OnePiece.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("Denomination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("category");
                });

            modelBuilder.Entity("OnePiece.Models.Pirate", b =>
                {
                    b.Property<int>("PirateID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PirateID"));

                    b.Property<string>("Budget")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Denomination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TeamID")
                        .HasColumnType("int");

                    b.HasKey("PirateID");

                    b.HasIndex("TeamID");

                    b.ToTable("pirate");
                });

            modelBuilder.Entity("OnePiece.Models.Proposal", b =>
                {
                    b.Property<int>("ProposalID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProposalID"));

                    b.Property<int?>("Category")
                        .HasColumnType("int");

                    b.Property<decimal?>("CounterOfferAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateProposal")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateReplyProposal")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("ProposedOfferAmount")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProposedTreasureID")
                        .HasColumnType("int");

                    b.Property<int>("ProposingPirateID")
                        .HasColumnType("int");

                    b.Property<int>("RequestingPirateID")
                        .HasColumnType("int");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("ProposalID");

                    b.HasIndex("ProposedTreasureID");

                    b.HasIndex("ProposingPirateID");

                    b.HasIndex("RequestingPirateID");

                    b.ToTable("proposal");
                });

            modelBuilder.Entity("OnePiece.Models.Team", b =>
                {
                    b.Property<int>("TeamID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TeamID"));

                    b.Property<string>("Denomination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeamID");

                    b.ToTable("team");
                });

            modelBuilder.Entity("OnePiece.Models.Treasure", b =>
                {
                    b.Property<int>("TreasureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TreasureID"));

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Denomination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PirateID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("TreasureID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("PirateID");

                    b.ToTable("treasure");
                });

            modelBuilder.Entity("OnePiece.Models.Pirate", b =>
                {
                    b.HasOne("OnePiece.Models.Team", "Team")
                        .WithMany()
                        .HasForeignKey("TeamID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Team");
                });

            modelBuilder.Entity("OnePiece.Models.Proposal", b =>
                {
                    b.HasOne("OnePiece.Models.Treasure", "ProposedTreasure")
                        .WithMany()
                        .HasForeignKey("ProposedTreasureID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnePiece.Models.Pirate", "ProposingPirate")
                        .WithMany()
                        .HasForeignKey("ProposingPirateID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("OnePiece.Models.Pirate", "RequestingPirate")
                        .WithMany()
                        .HasForeignKey("RequestingPirateID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ProposedTreasure");

                    b.Navigation("ProposingPirate");

                    b.Navigation("RequestingPirate");
                });

            modelBuilder.Entity("OnePiece.Models.Treasure", b =>
                {
                    b.HasOne("OnePiece.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OnePiece.Models.Pirate", "Pirate")
                        .WithMany()
                        .HasForeignKey("PirateID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Pirate");
                });
#pragma warning restore 612, 618
        }
    }
}
