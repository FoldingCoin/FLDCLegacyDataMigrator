namespace FLDCLegacyDataMigrator.Services.Abstract
{
    using System;

    public interface ILegacyDbDumpReaderService
    {
        event EventHandler<RecordsForDayReadEventArgs> RecordsForDayRead;

        int ReadData(string filename);
    }
}