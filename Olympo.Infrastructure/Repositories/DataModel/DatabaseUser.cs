using MongoDB.Bson.Serialization.Attributes;

namespace Olympo.Infrastructure.Repositories.DataModel
{
    internal class DatabaseUser
    {
        [BsonId]
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Password { get; set; }
    }
}