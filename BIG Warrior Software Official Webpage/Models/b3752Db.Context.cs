﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIG_Warrior_Software_Official_Webpage.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class b3752Entities : DbContext
    {
        public b3752Entities()
            : base("name=b3752Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admins> Admins { get; set; }
        public virtual DbSet<BlogsTags> BlogsTags { get; set; }
        public virtual DbSet<Clients> Clients { get; set; }
        public virtual DbSet<CurriculumVitae> CurriculumVitae { get; set; }
        public virtual DbSet<CurriculumVitaeContacts> CurriculumVitaeContacts { get; set; }
        public virtual DbSet<CurriculumVitaeHobbies> CurriculumVitaeHobbies { get; set; }
        public virtual DbSet<CurriculumVitaeLinguisticLanguages> CurriculumVitaeLinguisticLanguages { get; set; }
        public virtual DbSet<CurriculumVitaeOperatingSystems> CurriculumVitaeOperatingSystems { get; set; }
        public virtual DbSet<CurriculumVitaeProfessionalSkillsCircleDiagram> CurriculumVitaeProfessionalSkillsCircleDiagram { get; set; }
        public virtual DbSet<CurriculumVitaeProgrammingLanguages> CurriculumVitaeProgrammingLanguages { get; set; }
        public virtual DbSet<CurriculumVitaeQualities> CurriculumVitaeQualities { get; set; }
        public virtual DbSet<CurriculumVitaeScholarships> CurriculumVitaeScholarships { get; set; }
        public virtual DbSet<CurriculumVitaeSoftwares> CurriculumVitaeSoftwares { get; set; }
        public virtual DbSet<CurriculumVitaeWorkExperiences> CurriculumVitaeWorkExperiences { get; set; }
        public virtual DbSet<Home> Home { get; set; }
        public virtual DbSet<Licences> Licences { get; set; }
        public virtual DbSet<References> References { get; set; }
        public virtual DbSet<Blogs> Blogs { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
    }
}
