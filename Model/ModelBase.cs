using System;

namespace tunder.Model
{
    public abstract class ModelBase
    {
        public long Id { get; protected set; }
        public Guid Guid { get; protected set; }
    }
}