using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;
using EHealth.ViewModels;
using EHealth.Models;

namespace EHealth.ViewModels
{
    public class DoctorsPageViewModel
    {
        public DoctorsPageViewModel()
        {
            this.UsersDoctors = new List<DoctorViewModel>();
            this.Appointments = new List<AppointmentViewModel>();
            this.DoctorSpecializationDropDown = new List<SelectListItem>();
            
        }
        public virtual IList<DoctorViewModel> UsersDoctors { get; set; }
        public virtual List<SelectListItem> DoctorSpecializationDropDown { get; set; }

        public List<AppointmentViewModel> Appointments;
    }
}
