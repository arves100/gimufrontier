#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gimufrontier.Models.Database
{
    [Table("users")]
    public class UserDb
    {
        [Key]
        [Column("userid")]
        public uint Id { get; set; }

        [Column("username")]
        public string Username { get; set; }

        [Column("api_userid")]
        public string ApiId { get; set; }

        [Column("friendid")]
        public string FriendId { get; set; }

        [Column("tutorial")]
        public uint Tutorial { get; set; }

        [Column("finished_tutorial")]
        public bool FinishedTutorial { get; set; }

        [Column("level")]
        public uint Level { get; set; }

        [Column("exp")]
        public ulong Exp { get; set; }

        [Column("unit_inc")]
        public uint UnitInc { get; set; }

        [Column("friend_inc")]
        public uint FriendInc { get; set; }

        [Column("honor_pt")]
        public uint HonorPt { get; set; }

        [Column("zel")]
        public ulong Zel { get; set; }

        [Column("karma")]
        public ulong Karma { get; set; }

        [Column("friend_msg")]
        public string FriendMsg { get; set; }

        [Column("colosseum_tickets")]
        public uint ColosseumTickets { get; set; }

        [Column("summon_tickets")]
        public uint SummonTickets { get; set; }

        [Column("brave_points")]
        public uint BravePoints { get; set; }

        [Column("total_brave_points")]
        public uint TotalBravePoints { get; set; }

        [Column("mystery_box")]
        public uint MysteryBox { get; set; }

        [Column("paid_gems")]
        public uint PaidGems { get; set; }

        [Column("free_gems")]
        public uint FreeGems { get; set; }

        [Column("admin")]
        public bool IsAdmin { get; set; }

        [Column("banned")]
        public bool IsBanned { get; set; }
    }
}
