using Microsoft.AspNetCore.Authorization;

namespace FamilyManager2UI.Data {
    public static class Policies {
        public const string IsAdmin = "IsAdmin";

        public static AuthorizationPolicy FollowsAdminPolicy() {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .RequireRole("Admin")
                .Build();
        }
    }
}