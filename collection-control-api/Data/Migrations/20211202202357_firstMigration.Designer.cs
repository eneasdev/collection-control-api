// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using collection_control_api;

namespace collection_control_api.Migrations
{
    [DbContext(typeof(CollectionContext))]
    [Migration("20211202202357_firstMigration")]
    partial class firstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("collection_control_api.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("collection_control_api.Entities.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ReleasedYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("items");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Item");
                });

            modelBuilder.Entity("collection_control_api.Entities.Loan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FinishedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.HasIndex("ItemId");

                    b.ToTable("loans");
                });

            modelBuilder.Entity("collection_control_api.Entities.Book", b =>
                {
                    b.HasBaseType("collection_control_api.Entities.Item");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PagesNumber")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("collection_control_api.Entities.Cd", b =>
                {
                    b.HasBaseType("collection_control_api.Entities.Item");

                    b.Property<string>("Singer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SongsNumber")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Cd");
                });

            modelBuilder.Entity("collection_control_api.Entities.Dvd", b =>
                {
                    b.HasBaseType("collection_control_api.Entities.Item");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Staring")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Dvd");
                });

            modelBuilder.Entity("collection_control_api.Entities.Loan", b =>
                {
                    b.HasOne("collection_control_api.Entities.Client", "Client")
                        .WithOne("Loan")
                        .HasForeignKey("collection_control_api.Entities.Loan", "ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("collection_control_api.Entities.Item", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("collection_control_api.Entities.Client", b =>
                {
                    b.Navigation("Loan");
                });
#pragma warning restore 612, 618
        }
    }
}
