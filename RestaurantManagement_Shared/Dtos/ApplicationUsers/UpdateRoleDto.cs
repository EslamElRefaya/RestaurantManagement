namespace RestaurantManagement_Applicatin.Dtos.ApplicationUsers
{
    public class UpdateRoleDto
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
    }
}
