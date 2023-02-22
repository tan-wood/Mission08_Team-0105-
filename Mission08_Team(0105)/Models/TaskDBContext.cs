using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mission08_Team_0105_.Models;

namespace Mission08_Team_0105_.Models
{
	public class TaskDBContext : DbContext
	{

		//Constructor
		public TaskDBContext(DbContextOptions<TaskDBContext> options) : base(options)
		{
			//Leave blank for now
		}
		//Setting the title of the table
		public DbSet<TaskModel> Tasks { get; set; }
		public DbSet<CategoryModel> Categories { get; set; }



		protected override void OnModelCreating(ModelBuilder mb)
		{
			//seeding the categories database with these base categories
			mb.Entity<CategoryModel>().HasData(

				new CategoryModel
				{
					CategoryId = 1,
					CategoryName = "Home"
				},
				new CategoryModel
				{
					CategoryId = 2,
					CategoryName = "School"
				},
				new CategoryModel
				{
					CategoryId = 3,
					CategoryName = "Work"
				},
				new CategoryModel
				{
					CategoryId = 4,
					CategoryName = "Church"
				}


				);
			mb.Entity<TaskModel>().HasData(
				new TaskModel
				{
					TaskId = 1,
					TaskText = "Mission8",
					CategoryId = 1,
					DueDate = new DateTime(),
					Completed = false,
					Quadrant = 1,
				}
				);


		}
	}
}
