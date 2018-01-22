using EHealth.Models;
using EHealth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EHealth.Controllers
{
    public class DiagnosisController : ApplicationController
    {
        EHealthDB2Entities ent = new EHealthDB2Entities();
        private List<DiagnosisViewModel> diagnosisList
        {
            get { return Session["appointments"] as List<DiagnosisViewModel>; }
            set { Session["appointments"] = value; }
        }

        public ActionResult Index()
        {
            diagnosisList = new List<DiagnosisViewModel>();
            DiagnosisViewModel diagnosisListVM = new DiagnosisViewModel();
            var userName = User.Identity.Name;
            Person user = ent.Person.First(u => u.username == userName);

            foreach (var mr in ent.MedicalRecord.Where(m => m.personId == user.personId))
            {
                foreach (var app in mr.DoctorsAppointment)
                {
                    foreach (var d in app.Diagnosis)
                    {
                        if (!diagnosisList.Exists(x => x.disesase.ICDId == d.Disease.ICDId))
                        {
                            diagnosisListVM = new DiagnosisViewModel();
                            diagnosisListVM.disesase = d.Disease;
                            diagnosisListVM.diagnosisList.Add(d);
                            diagnosisList.Add(diagnosisListVM);
                        }
                        else
                        {
                            diagnosisList.Where(x => x.disesase.ICDId == d.Disease.ICDId).First().diagnosisList.Add(d);
                        }
                    }
                }
            }


            diagnosisList = diagnosisList.OrderBy(d => d.disesase.ICDTytle).ToList();
            foreach (DiagnosisViewModel dl in diagnosisList)
            {
                dl.diagnosisList = dl.diagnosisList.OrderByDescending(a => a.DoctorsAppointment.appointmentDate).ToList();
            }
            DiagnosisListViewModel dlvm = new DiagnosisListViewModel();
            dlvm.diagnosisVMList = diagnosisList;

            return View(dlvm);
        }

        [HttpPost]
        public ActionResult Index(DiagnosisListViewModel model)
        {
            string search = model.search;
            List<DiagnosisViewModel> dl = new List<DiagnosisViewModel>();
            var userName = User.Identity.Name;
            Person user = ent.Person.First(u => u.username == userName);
            DiagnosisListViewModel dlvm = new DiagnosisListViewModel();
            dlvm.diagnosisVMList = diagnosisList;

            foreach (var d in model.diseaseGroups)
            {
                if (d.IsCheked)
                {
                    DiseaseGroupViewModel dg = new DiseaseGroupViewModel();
                    dg = dlvm.diseaseGroups.Where(x => x.Id == d.Id).First();

                    string start = dg.Start;
                    string end = dg.End;

                    string startChar = start.Substring(0, 1);
                    int startNum = Int32.Parse(start.Substring(1, 2));

                    string endChar = end.Substring(0, 1);
                    int endNum = Int32.Parse(end.Substring(1, 2));

                    if (startChar == endChar)
                    {
                        for (int i = startNum; i <= endNum; i++)
                        {
                            string b = i.ToString("00");
                            if (diagnosisList.Exists(x => x.disesase.ICDCode.Contains(startChar + b)))
                            {
                                dl.Add( diagnosisList.Where(x => x.disesase.ICDCode.Contains(startChar + b)).First());
                            }
                        }
                    }

                    else
                    {
                        for (int i = startNum; i <= 99; i++)
                        {
                            string b = i.ToString("00");
                            if (diagnosisList.Exists(x => x.disesase.ICDCode.Contains(startChar + b)))
                            {
                                dl.Add(diagnosisList.Where(x => x.disesase.ICDCode.Contains(startChar + b)).First());
                            }
                        }

                        for (int i = 0; i <= endNum; i++)
                        {
                            string b = i.ToString("00");
                            if (diagnosisList.Exists(x => x.disesase.ICDCode.Contains(endChar + b)))
                            {
                                dl.Add(diagnosisList.Where(x => x.disesase.ICDCode.Contains(endChar + b)).First());
                            }
                        }
                    }

                    dlvm.diagnosisVMList = new List<DiagnosisViewModel>();
                    dlvm.diagnosisVMList = dl;
                }
            }
            if (dl.Count == 0) {
                dl = diagnosisList;
            }
            if (search != null)
            {
                dl = dl.Where(x => x.disesase.ICDTytle.ToUpper().Contains(search.ToUpper())).ToList();
                dlvm.diagnosisVMList = dl;
            }


            return View(dlvm);
        }

    }
}
