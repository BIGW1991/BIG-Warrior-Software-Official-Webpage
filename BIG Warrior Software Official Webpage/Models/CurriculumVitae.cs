//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class CurriculumVitae
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CurriculumVitae()
        {
            this.CurriculumVitaeContacts = new HashSet<CurriculumVitaeContacts>();
            this.CurriculumVitaeHobbies = new HashSet<CurriculumVitaeHobbies>();
            this.CurriculumVitaeLinguisticLanguages = new HashSet<CurriculumVitaeLinguisticLanguages>();
            this.CurriculumVitaeOperatingSystems = new HashSet<CurriculumVitaeOperatingSystems>();
            this.CurriculumVitaeProfessionalSkillsCircleDiagram = new HashSet<CurriculumVitaeProfessionalSkillsCircleDiagram>();
            this.CurriculumVitaeProgrammingLanguages = new HashSet<CurriculumVitaeProgrammingLanguages>();
            this.CurriculumVitaeQualities = new HashSet<CurriculumVitaeQualities>();
            this.CurriculumVitaeScholarships = new HashSet<CurriculumVitaeScholarships>();
            this.CurriculumVitaeSoftwares = new HashSet<CurriculumVitaeSoftwares>();
            this.CurriculumVitaeWorkExperiences = new HashSet<CurriculumVitaeWorkExperiences>();
        }
    
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Lang { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurriculumVitaeContacts> CurriculumVitaeContacts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurriculumVitaeHobbies> CurriculumVitaeHobbies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurriculumVitaeLinguisticLanguages> CurriculumVitaeLinguisticLanguages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurriculumVitaeOperatingSystems> CurriculumVitaeOperatingSystems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurriculumVitaeProfessionalSkillsCircleDiagram> CurriculumVitaeProfessionalSkillsCircleDiagram { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurriculumVitaeProgrammingLanguages> CurriculumVitaeProgrammingLanguages { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurriculumVitaeQualities> CurriculumVitaeQualities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurriculumVitaeScholarships> CurriculumVitaeScholarships { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurriculumVitaeSoftwares> CurriculumVitaeSoftwares { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CurriculumVitaeWorkExperiences> CurriculumVitaeWorkExperiences { get; set; }
    }
}
