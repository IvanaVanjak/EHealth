//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EHealth.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Person
    {
        public Person()
        {
            this.DoctorsCompetence = new HashSet<DoctorsCompetence>();
            this.Email = new HashSet<Email>();
            this.HealthInsurance = new HashSet<HealthInsurance>();
            this.MedicalRecord = new HashSet<MedicalRecord>();
            this.MedicalRecord1 = new HashSet<MedicalRecord>();
            this.PatientChronicalDisease = new HashSet<PatientChronicalDisease>();
            this.Person1 = new HashSet<Person>();
            this.PhoneNumber = new HashSet<PhoneNumber>();
        }
    
        public int personId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public System.DateTime dateOfBirth { get; set; }
        public string gender { get; set; }
        public string OIB { get; set; }
        public string streetName { get; set; }
        public string streetNumber { get; set; }
        public Nullable<int> placeOfLivingId { get; set; }
        public int placeOfBirthId { get; set; }
        public Nullable<int> imageId { get; set; }
        public byte isDoctor { get; set; }
        public Nullable<int> primaryDoctorId { get; set; }
        public string bloodType { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string salt { get; set; }
    
        public virtual City City { get; set; }
        public virtual City City1 { get; set; }
        public virtual ICollection<DoctorsCompetence> DoctorsCompetence { get; set; }
        public virtual ICollection<Email> Email { get; set; }
        public virtual ICollection<HealthInsurance> HealthInsurance { get; set; }
        public virtual Image Image { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecord { get; set; }
        public virtual ICollection<MedicalRecord> MedicalRecord1 { get; set; }
        public virtual ICollection<PatientChronicalDisease> PatientChronicalDisease { get; set; }
        public virtual ICollection<Person> Person1 { get; set; }
        public virtual Person Person2 { get; set; }
        public virtual ICollection<PhoneNumber> PhoneNumber { get; set; }
    }
}