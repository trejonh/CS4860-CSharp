using System;

namespace Homework7
{
    public interface IReportStatus
    {
        long RecordsProcessed { get; }
        long BytesProcessed { get; }

        TimeSpan TotalProcessingTime { get; }
        TimeSpan AverageProcessingTime { get; }
    }
}
