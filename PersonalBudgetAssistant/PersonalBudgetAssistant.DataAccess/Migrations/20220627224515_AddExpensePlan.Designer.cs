﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalBudgetAssistant.DataAccess;

namespace PersonalBudgetAssistant.DataAccess.Migrations
{
    [DbContext(typeof(BudgetContext))]
    [Migration("20220627224515_AddExpensePlan")]
    partial class AddExpensePlan
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("PersonalBudgetAssistant.DataAccess.Models.Expense", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("Date");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("PersonalBudgetAssistant.DataAccess.Models.ExpenseCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("ExpenseCategories");
                });

            modelBuilder.Entity("PersonalBudgetAssistant.DataAccess.Models.ExpensePlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<int>("CategoryId");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Period");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("ExpensePlans");
                });

            modelBuilder.Entity("PersonalBudgetAssistant.DataAccess.Models.Expense", b =>
                {
                    b.HasOne("PersonalBudgetAssistant.DataAccess.Models.ExpenseCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PersonalBudgetAssistant.DataAccess.Models.ExpensePlan", b =>
                {
                    b.HasOne("PersonalBudgetAssistant.DataAccess.Models.ExpenseCategory", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}