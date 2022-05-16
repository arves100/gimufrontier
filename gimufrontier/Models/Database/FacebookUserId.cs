#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gimufrontier.Models.Database
{
    [Table("facebook_users")]
    public class FacebookUserDb
    {
        [Key]
        [Column("api_userid")]
        public string UserId { get; set; }

        [Column("android_id")]
        public string AndroidId { get; set; }

        [Column("facebook_token")]
        public string Token { get; set; }
    }
}
