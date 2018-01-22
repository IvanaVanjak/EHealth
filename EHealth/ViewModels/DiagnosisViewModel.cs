using EHealth.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace EHealth.ViewModels
{
    public class DiagnosisViewModel
    {
        public DiagnosisViewModel() {
            diagnosisList = new List<Diagnosis>();
        }
        public Disease disesase { get; set; }
        public List<Diagnosis> diagnosisList { get; set; }
    }
}