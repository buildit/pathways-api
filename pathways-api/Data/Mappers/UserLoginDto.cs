namespace pathways_api.Data.Mappers
{
    public class UserLoginDto
    {
        public int Id  { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Deactivated { get; set; }
    }
}