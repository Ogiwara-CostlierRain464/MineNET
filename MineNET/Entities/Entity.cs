using System;

namespace MineNET.Entities
{
    public abstract class Entity : IDisposable
    {
        public virtual void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
