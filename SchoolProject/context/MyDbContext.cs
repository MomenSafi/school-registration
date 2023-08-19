using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SchoolProject.Models;

namespace SchoolProject.context
{
	public class MyDbContext :DbContext
	{
		public MyDbContext()
		{
		}
		public MyDbContext(DbContextOptions<MyDbContext> options)
			: base(options)
		{
		}
	
		public DbSet<Student> Students { get; set; }
		public DbSet<Teacher> Teachers { get; set; }
		public DbSet<Romm> Rooms { get; set; }
		public DbSet<Course> Courses { get; set; }
		public DbSet<StudentCourse> StudentCourses { get; set; }
		protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
		{
			base.OnConfiguring(dbContextOptionsBuilder);
			var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
			IConfigurationRoot config = builder.Build();
			var conString = config.GetConnectionString("MyKsaTDB");
			dbContextOptionsBuilder.UseSqlServer(conString);
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
		}
	}
}
