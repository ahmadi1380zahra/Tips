﻿namespace Students.Core.Domain
{
    public class CourseTecher
    {
        public int Id { get; set; }
        public int SortOrder { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }

        public Teacher Teacher { get; set; }
        public Course Course { get; set; }

    }

}