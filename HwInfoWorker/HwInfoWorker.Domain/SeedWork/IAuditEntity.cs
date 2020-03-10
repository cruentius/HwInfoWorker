using System;

namespace HwInfoWorker.Domain.SeedWork
{
    public interface IAuditEntity
    {
        DateTime DateCreated { get; }
        DateTime DateModified { get; }
    }
}
