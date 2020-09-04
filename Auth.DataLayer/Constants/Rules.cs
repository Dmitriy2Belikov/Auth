using Auth.DataLayer.Models;
using System;

namespace Auth.DataLayer.Constants
{
    public static class Rules
    {
        public static Rule Nothing = new Rule() { Id = Guid.Parse("83e190ba-dd7c-496a-a637-713ac3d7961d"), Name = "Никакие"};
        public static Rule AllOrganizations = new Rule() { Id = Guid.Parse("fdaefba0-b506-4b0c-8069-61a2b42b82be"), Name = "Любые" };
    }
}
