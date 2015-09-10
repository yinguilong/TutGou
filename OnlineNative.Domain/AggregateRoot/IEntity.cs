using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineNative.Domain
{
    public interface IEntity
    {
        // 当前领域实体的全局唯一标识
        Guid Id { get; }
    }
}
