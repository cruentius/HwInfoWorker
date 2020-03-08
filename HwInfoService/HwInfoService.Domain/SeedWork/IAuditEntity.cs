using System;

namespace HwInfoService.Domain.SeedWork
{
    public interface IAuditEntity
    {
        DateTime DateCreated { get; }
        DateTime DateModified { get; }
    }
}
