using System;

namespace Metoda.Reporting.Lib.Base.Contracts
{
    public interface IReportBase
    {
        string CompanyName { get; set; }
        DateTime ReferenceDate { get; set; }
        string Title { get; set; }
        
        void ToPdf(string dest);
        //void ToExcel(string dest);
    }
}