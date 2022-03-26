using MongoDB.Bson.Serialization.Attributes;

namespace BeFit_Server_API.Models {
    public class Post {
        [BsonId]
        public string Id { get; init; }
        public string MainHeading { get; init; }
        public string ContentImageName { get; init; }
        public string ContentBodyParagraph { get; init; }
        public string UserDetailsName { get; init; }
        public string UserDetailsDescription { get; init; }
        public string UserDetailsImageName { get; init; }
    }
}
