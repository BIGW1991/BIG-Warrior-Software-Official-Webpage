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
    
    public partial class CurriculumVitaeProfessionalSkillsCircleDiagram
    {
        public System.Guid ID { get; set; }
        public string Name { get; set; }
        public decimal Pecent { get; set; }
        public System.Guid CurriculumVitaeID { get; set; }
    
        public virtual CurriculumVitae CurriculumVitae { get; set; }
    }
}
