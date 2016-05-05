using System;

namespace Homework8
{
    public interface IReportStatus
    {
        long RecordsProcessed { get; }
        long BytesProcessed { get; }

        TimeSpan TotalProcessingTime { get; }
        TimeSpan AverageProcessingTime { get; }
    }
}
