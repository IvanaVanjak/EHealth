using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EHealth.ViewModels
{
    public class DiagnosisListViewModel
    {
        public virtual string search { get; set; }
        public List<DiagnosisViewModel> diagnosisVMList { get; set; }

        public List<DiseaseGroupViewModel> diseaseGroups { get; set; }

        public DiagnosisListViewModel()
        {
            diagnosisVMList = new List<DiagnosisViewModel>();

            diseaseGroups = new List<DiseaseGroupViewModel>();
            DiseaseGroupViewModel dg = new DiseaseGroupViewModel();

            dg.Id = 1;
            dg.Name = "Određene infekcijske i parazitske bolesti";
            dg.Start = "A00";
            dg.End = "B99";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 2;
            dg.Name = "Neoplazme";
            dg.Start = "C00";
            dg.End = "D48";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 3;
            dg.Name = "Bolesti krvi i krvotvornih organa i određeni poremećaji imunološkog sustava";
            dg.Start = "D50";
            dg.End = "D89";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 4;
            dg.Name = "Endokrine, nutricijske i metaboličke bolesti";
            dg.Start = "E00";
            dg.End = "E90";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 5;
            dg.Name = "Mentalni poremećaji i poremećaji ponašanja";
            dg.Start = "F00";
            dg.End = "F99";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 6;
            dg.Name = "Bolesti živčanog sustava";
            dg.Start = "G00";
            dg.End = "G99";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 6;
            dg.Name = "Bolesti oka i adneksa";
            dg.Start = "H00";
            dg.End = "H59";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 7;
            dg.Name = "Bolesti uha i mastoidnih procesa";
            dg.Start = "H60";
            dg.End = "H95";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 8;
            dg.Name = "Bolesti cirkulacijskog (krvožilnog) sustava";
            dg.Start = "I00";
            dg.End = "I99";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 9;
            dg.Name = "Bolesti dišnog (respiracijskog) sustava";
            dg.Start = "J00";
            dg.End = "J99";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 10;
            dg.Name = "Bolesti probavnog sustava";
            dg.Start = "K00";
            dg.End = "K93";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 11;
            dg.Name = "Bolesti kože i potkožnog tkiva";
            dg.Start = "L00";
            dg.End = "L99";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 12;
            dg.Name = "Bolesti mišićno-koštanog sustava i vezivnog tkiva";
            dg.Start = "M00";
            dg.End = "M99";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 13;
            dg.Name = "Bolesti genitalno-urinarnog sustava";
            dg.Start = "N00";
            dg.End = "N99";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 14;
            dg.Name = "Trudnoća i porođaj";
            dg.Start = "P00";
            dg.End = "P96";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 15;
            dg.Name = "Određena stanja porođajnog perioda (5 mj. prije i 1 mj. poslije)";
            dg.Start = "P00";
            dg.End = "P96";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 16;
            dg.Name = "Prirođene malformacije, deformacije i kromosomske abnormalnosti";
            dg.Start = "Q00";
            dg.End = "Q99";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 17;
            dg.Name = "Simptomi, znakovi i abnormalni klinički i laboratorijski nalazi, neklasificirani drugdje";
            dg.Start = "R00";
            dg.End = "R99";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 18;
            dg.Name = "Ozljede, trovanja i određene druge posljedice s vanjskim uzrokom";
            dg.Start = "S00";
            dg.End = "T98";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 19;
            dg.Name = "Vanjski uzroci pobola i smrtnosti";
            dg.Start = "V01";
            dg.End = "Y98";
            diseaseGroups.Add(dg);
            dg = new DiseaseGroupViewModel();
            dg.Id = 20;
            dg.Name = "Čimbenici s utjecajem na zdravstveni status i kontakt s zdravstvenim ustanovama";
            dg.Start = "Z00";
            dg.End = "Z99";
            diseaseGroups.Add(dg);
        }
    }
}