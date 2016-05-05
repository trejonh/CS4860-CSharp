using System;

namespace Homework9
{
    public interface IReportStatus
    {
        long RecordsProcessed { get; }
        long BytesProcessed { get; }

        TimeSpan TotalProcessingTime { get; }
        TimeSpan AverageProcessingTime { get; }
    }
}
