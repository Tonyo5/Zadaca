using Zadaca.Models;

namespace Zadaca.DbContext;

using Microsoft.EntityFrameworkCore;
using System;

public class SubjectContext : DbContext
{
    public DbSet<Subject> Subjects { get; set; }
    public DbSet<Literature> Posts { get; set; }
    public DbSet<Author> Authors { get; set; }
    public string DbPath { get; }

    public SubjectContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "subjectinfosystem.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}