namespace Metoda.Reporting.Lib.Base.Contracts
{
    public interface ITabledReport<T> : IReportBase where T : IReportTableItem
    {
        ReportTable<T> Table { get; }
    }
}