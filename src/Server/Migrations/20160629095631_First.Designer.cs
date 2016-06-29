using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Epam.Password.Server.Model;

namespace Server.Migrations
{
    [DbContext(typeof(Db))]
    [Migration("20160629095631_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Epam.Password.Server.Model.Account", b =>
                {
                    b.Property<string>("Email");

                    b.Property<int>("VerificationType");

                    b.HasKey("Email");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Epam.Password.Server.Model.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountEmail")
                        .IsRequired();

                    b.Property<DateTime>("EventDate");

                    b.Property<int>("EventType");

                    b.Property<bool>("IsSuccess");

                    b.HasKey("Id");

                    b.HasIndex("AccountEmail");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Epam.Password.Server.Model.Event", b =>
                {
                    b.HasOne("Epam.Password.Server.Model.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountEmail")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
