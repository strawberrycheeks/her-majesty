// <auto-generated />
using HerMajesty.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HerMajesty.src.Migrations
{
    [DbContext(typeof(PostgresDbContext))]
    [Migration("20221226172851_CreateAttempts")]
    partial class CreateAttempts
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseSerialColumns(modelBuilder);

            modelBuilder.Entity("HerMajesty.Entity.AttemptEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<int>("AttemptNumber")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Attempts");
                });

            modelBuilder.Entity("HerMajesty.Entity.ContenderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseSerialColumn(b.Property<int>("Id"));

                    b.Property<int>("AttemptEntityId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Order")
                        .HasColumnType("integer");

                    b.Property<int>("Score")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("AttemptEntityId");

                    b.ToTable("Contenders");
                });

            modelBuilder.Entity("HerMajesty.Entity.ContenderEntity", b =>
                {
                    b.HasOne("HerMajesty.Entity.AttemptEntity", "AttemptEntity")
                        .WithMany("Contenders")
                        .HasForeignKey("AttemptEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AttemptEntity");
                });

            modelBuilder.Entity("HerMajesty.Entity.AttemptEntity", b =>
                {
                    b.Navigation("Contenders");
                });
#pragma warning restore 612, 618
        }
    }
}
