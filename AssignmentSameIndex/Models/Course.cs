using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace AssignmentSameIndex.Models
{
    public enum Grade { Refer, Pass, Merit, Distinction }
    public class Course
    {
        public int? Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Course Code")]
        public string Code { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Course Full Name")]
        public string FullName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Course Short Name")]
        public string ShortName { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Course Description")]
        public string Description { get; set; }

        [Display(Name = "Course Duration (Week)")]
        public int? Duration { get; set; }

        [Display(Name = "Course Credit")]
        public int? Credit { get; set; }

        [Display(Name = "Course Category")]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public virtual ICollection<Class> Classes { get; set; }
    }
    public class Category
    {
        public int? Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Category Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Category Description")]
        public string Description { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
    public class Topic
    {
        public int? Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Topic Name")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Topic Description")]
        public string Description { get; set; }

        [Display(Name = "Trainer")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser Trainer { get; set; }

        [Display(Name = "Class")]
        public string ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
    public class Class
    {
        public int? Id { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Class Code")]
        public string Code { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Class Start Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Class End Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]

        public DateTime? EndDate { get; set; }

        [Display(Name ="Course")]
        public int? CourseId { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
        public virtual ICollection<TraineeClass> TraineeClasses { get; set; }
    }
    public class TraineeClass
    {
        public int? Id { get; set; }

        [Display(Name = "Trainee Grade")]
        public string Grade { get; set; }

        [DataType(DataType.Text)]
        [Display(Name = "Trainee Note")]
        public string Note { get; set; }

        [Display(Name = "Trainee ")]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser Trainee { get; set; }

        [Display(Name = "Class")]
        public int? ClassId { get; set; }
        public virtual Class Class { get; set; }
    }
}