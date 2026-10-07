using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using wirachain_backend.Security.Domain.Models;

namespace wirachain_backend.Shared.Persistence.Seeding;

public class UserRoleSeeding : IEntityTypeConfiguration<UserRole>
{
    public void Configure(EntityTypeBuilder<UserRole> builder)
    {
        builder.HasData(
            new UserRole { UserId = Guid.Parse("2920ff55-ca14-4df0-bdd3-622d84f44e29"), RoleId = 1 },
            new UserRole { UserId = Guid.Parse("2920ff55-ca14-4df0-bdd3-622d84f44e29"), RoleId = 2 },
            new UserRole { UserId = Guid.Parse("2920ff55-ca14-4df0-bdd3-622d84f44e29"), RoleId = 7 },
            new UserRole { UserId = Guid.Parse("2920ff55-ca14-4df0-bdd3-622d84f44e29"), RoleId = 8 },
            new UserRole { UserId = Guid.Parse("2920ff55-ca14-4df0-bdd3-622d84f44e29"), RoleId = 9 },

            new UserRole { UserId = Guid.Parse("51ddfd30-d8e3-4df7-905e-07065f2bd440"), RoleId = 3 },
            new UserRole { UserId = Guid.Parse("51ddfd30-d8e3-4df7-905e-07065f2bd440"), RoleId = 4 },
            new UserRole { UserId = Guid.Parse("51ddfd30-d8e3-4df7-905e-07065f2bd440"), RoleId = 5 },

            new UserRole { UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"), RoleId = 1 },
            new UserRole { UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"), RoleId = 2 },
            new UserRole { UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"), RoleId = 7 },
            new UserRole { UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"), RoleId = 8 },
            new UserRole { UserId = Guid.Parse("550e8400-e29b-41d4-a716-446655440000"), RoleId = 9 },

            new UserRole { UserId = Guid.Parse("dcf5afba-0960-449f-b967-9972af646ce2"), RoleId = 11 },
            new UserRole { UserId = Guid.Parse("dcf5afba-0960-449f-b967-9972af646ce2"), RoleId = 12 },
            new UserRole { UserId = Guid.Parse("dcf5afba-0960-449f-b967-9972af646ce2"), RoleId = 15 },
            
            new UserRole { UserId = Guid.Parse("569dd9fa-798d-4876-8d61-4573fea4b01d"), RoleId = 100 }
        );

    }
}