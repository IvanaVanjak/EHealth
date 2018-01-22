using EHealth.Models;
using EHealth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace EHealth.Controllers
{
    [Authorize]
    public class DoctorsController : ApplicationController
    {
        //
        // GET: /Doctors/
        EHealthDB2Entities ent = new EHealthDB2Entities();
        private List<AppointmentViewModel> appointmentList
        {
            get { return Session["appointments"] as List<AppointmentViewModel>; }
            set { Session["appointments"] = value; }
        }

        //static List<AppointmentViewModel> appointmentList = new List<AppointmentViewModel>();


        public ActionResult Index()
        {
            appointmentList = new List<AppointmentViewModel>();
            ViewBag.Day = DateTime.Now.Date;
            DoctorsPageViewModel viewModel = new DoctorsPageViewModel();
            var userName = User.Identity.Name;
            Person user = ent.Person.First(u => u.username == userName);
            // all doctors for current user
            getUserDoctors(user, viewModel);


            // list of appointments for primary doctor
            return View(viewModel);
        }

        private DoctorsPageViewModel getUserDoctors(Person user, DoctorsPageViewModel viewModel)
        {
            List<int> userDoctorsIds = new List<int>();
            HashSet<DoctorSpecialisation> doctorSpecialisations = new HashSet<DoctorSpecialisation>();
            foreach (var mr in ent.MedicalRecord.Where(m => m.personId == user.personId))
            {
                userDoctorsIds.Add(mr.doctorId);

            }
            foreach (var drId in userDoctorsIds)
            {
                Person doctor = ent.Person.First(u => u.personId == drId);

                DoctorViewModel doctorViewModel = new DoctorViewModel();

                doctorViewModel.personId = doctor.personId;
                doctorViewModel.firstName = doctor.firstName;
                doctorViewModel.lastName = doctor.lastName;

                //Competence

                foreach (var comp in ent.MedicalRecord.Where(m => m.doctorId == drId))
                {
                    if (comp != null)
                        doctorViewModel.DoctorsSpecialisation.Add(comp.DoctorSpecialisation);
                }

                //Email
                foreach (var email in ent.Email.Where(m => m.personId == doctor.personId))
                {
                    if (email != null)
                        doctorViewModel.Email.Add(email);
                }
                //PhoneNumber
                foreach (var num in ent.PhoneNumber.Where(m => m.personId == doctor.personId))
                {
                    if (num != null)
                        doctorViewModel.PhoneNumber.Add(num);
                }
                viewModel.UsersDoctors.Add(doctorViewModel);
            }
            viewModel.UsersDoctors.OrderBy(d => d.lastName).ThenBy(d => d.firstName).ToList();
            foreach (var mr in ent.MedicalRecord.Where(m => m.personId == user.personId))
            {
                doctorSpecialisations.Add(ent.DoctorSpecialisation.First(d => d.doctorSpecialisationId == mr.doctorSpecialisationId));
            }
            foreach (var s in doctorSpecialisations)
            {
                viewModel.DoctorSpecializationDropDown.Add(new SelectListItem() { Text = s.doctorSpecialisation1, Value = s.doctorSpecialisationId.ToString() });

            }
            return viewModel;
        }

        [HttpPost]
        public ActionResult Index(DoctorsPageViewModel model)
        {
            ViewBag.Day = DateTime.Now.Date;
            var userName = User.Identity.Name;
            Person user = ent.Person.First(u => u.username == userName);
            DoctorsPageViewModel viewModel = new DoctorsPageViewModel();
            viewModel = getUserDoctors(user, viewModel);
            for (int i = 0; i < model.UsersDoctors.Count; i++)
            {
                if (model.UsersDoctors[i].idDoctorChecked)
                {
                    viewModel.UsersDoctors[i].idDoctorChecked = true;
                }

            }
            for (int i = 0; i < model.DoctorSpecializationDropDown.Count; i++)
            {
                if (model.DoctorSpecializationDropDown[i].Selected)
                {
                    viewModel.DoctorSpecializationDropDown[i].Selected = true;
                }

            }
            //get data

            int count = 0;
            foreach (var doctor in model.UsersDoctors)
            {
                if (doctor.idDoctorChecked)
                {
                    count++;
                    List<MedicalRecord> medRec = ent.MedicalRecord.Where(a => (a.doctorId == doctor.personId && a.personId == user.personId)).ToList();
                    foreach (var mr in medRec)
                    {
                        List<DoctorsAppointment> docApp = ent.DoctorsAppointment.Where(a => a.MedicalRecord.medicalRecordId == mr.medicalRecordId).ToList();
                        foreach (var app in docApp)
                        {
                            AppointmentViewModel appViewModel = new AppointmentViewModel();
                            appViewModel.MedicalRecord = mr;
                            appViewModel.Appointment = app;
                            viewModel.Appointments.Add(appViewModel);
                        }
                    }
                }
                appointmentList = viewModel.Appointments;

            }
            if (count == 0)
            {
                appointmentList = new List<AppointmentViewModel>();
            }
            else {
                viewModel.Appointments = appointmentList.Where(a => a.Appointment.appointmentDate.Month == ViewBag.Day.Month
                        && a.Appointment.appointmentDate.Year == ViewBag.Day.Year).OrderByDescending(a => a.Appointment.appointmentDate).ToList();
            }

            return View("~/Views/Doctors/Index.cshtml", viewModel);
            //return Redirect(Url.RouteUrl(new { controller = "Doctors", action = "Index", viewModel = viewModel })  + "#show-appointments");
        }

        public ActionResult GetByDate(String date)
        {
            ViewBag.Day = Convert.ToDateTime(date);
            ICollection<AppointmentViewModel> appointments = GetAppointmentsByDate(Convert.ToDateTime(date));
            return PartialView("Partials/_ShowAppointments", appointments);
        }

        public ICollection<AppointmentViewModel> GetAppointmentsByDate(DateTime day)
        {
            IList<AppointmentViewModel> appointments = appointmentList.Where(a => a.Appointment.appointmentDate.Month == day.Month
                            && a.Appointment.appointmentDate.Year == day.Year).OrderByDescending(a => a.Appointment.appointmentDate).ToList();
            return appointments;
        }

        public ActionResult PreviousMonth(DateTime day)
        {
            ViewBag.Day = day.AddMonths(-1);
            ICollection<AppointmentViewModel> appointments = GetAppointmentsByDate(day.AddMonths(-1));
            return PartialView("Partials/_ShowAppointments", appointments);
        }
        public ActionResult NextMonth(DateTime day)
        {

            ViewBag.Day = day.AddMonths(1);
            ICollection<AppointmentViewModel> appointments = GetAppointmentsByDate(day.AddMonths(1));
            return PartialView("Partials/_ShowAppointments", appointments);
        }

        //public ActionResult GetByDate(String date)
        //{
        //    ViewBag.Day = Convert.ToDateTime(date);
        //    IList<AppointmentViewModel> appointments = appointmentList.Where(
        //        a => a.Appointment.appointmentDate == Convert.ToDateTime(date)).ToList();
        //    return PartialView("Partials/_ShowAppointments", appointments);
        //}

        //public ICollection<AppointmentViewModel> GetAppointmentsByDate(DateTime day)
        //{
        //    IList<AppointmentViewModel> appointments = appointmentList.Where(
        //        a => a.Appointment.appointmentDate.ToShortDateString() == Convert.ToDateTime(day).ToShortDateString()).ToList();
        //    return appointments;
        //}


        public ActionResult PreviousDay(DateTime day)
        {
            ViewBag.Day = day.AddDays(-1);
            ICollection<AppointmentViewModel> appointments = GetAppointmentsByDate(day.AddDays(-1));
            return PartialView("Partials/_ShowAppointments", appointments);
        }
        public ActionResult NextDay(DateTime day)
        {

            ViewBag.Day = day.AddDays(1);
            ICollection<AppointmentViewModel> appointments = GetAppointmentsByDate(day.AddDays(1));
            return PartialView("Partials/_ShowAppointments", appointments);
        }
    }
}