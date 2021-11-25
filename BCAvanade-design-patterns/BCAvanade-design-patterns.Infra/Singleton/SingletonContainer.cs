using System;

namespace BCAvanade_design_patterns.Infra.Singleton
{
    public class SingletonContainer
    {
        public Guid Id { get; } = Guid.NewGuid();
    }
}
