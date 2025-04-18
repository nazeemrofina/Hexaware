﻿using CARS_Case_Study.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CARS_Case_Study.Repository
{
    internal interface IReportRepository
    {
        int AddReport(Report report);
        int UpdateReport(int reportId, string status);
        Report GetReportForCase(int reportId);
        List<Report> GetAllReports();
        int GetReportById(int reportId);
    }
}
