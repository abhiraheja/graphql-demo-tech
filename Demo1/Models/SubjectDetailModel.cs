﻿namespace Demo1.Models
{
    public class SubjectDetailModel
    {
        [GraphQLNonNullType]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public InstructorModel1 Instructor { get; set; }
    }
}