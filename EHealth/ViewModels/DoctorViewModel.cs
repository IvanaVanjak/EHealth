using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using EHealth.Models;
namespace EHealth.ViewModels
{
    public class DoctorViewModel
    {
        public DoctorViewModel()
        {
            this.DoctorsSpecialisation = new HashSet<DoctorSpecialisation>();
            this.Email = new HashSet<Email>();
            this.PhoneNumber = new HashSet<PhoneNumber>();
        }
        public int personId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public Nullable<int> imageId { get; set; }
        public bool idDoctorChecked { get; set; }

        public virtual ICollection<DoctorSpecialisation> DoctorsSpecialisation { get; set; }
        public virtual ICollection<Email> Email { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumber { get; set; }
    }
}