using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASTMA.Domain.Common;

public abstract class BaseAuditableEntity : BaseEntity
{
    /// <summary>
    /// The base class date the entity was created
    /// </summary>
    public DateTime Created { get; set; }

    /// <summary>
    /// The base class date the entity was last updated
    /// </summary>
    public DateTime? LastModified { get; set; }
}
