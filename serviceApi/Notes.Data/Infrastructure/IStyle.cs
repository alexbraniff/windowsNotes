using Notes.Data.Model.Style;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Data.Infrastructure
{
    public interface IStyle
    {
        [Index("IX_StyleUnique", 1, IsUnique = true)]
        [Column("PrimaryBackgroundColorId")]
        [ForeignKey("PrimaryBackgroundColor")]
        int? PrimaryBackgroundColorId { get; set; }
        Color PrimaryBackgroundColor { get; set; }

        [Index("IX_StyleUnique", 2, IsUnique = true)]
        [Column("SecondaryBackgroundColorId")]
        [ForeignKey("SecondaryBackgroundColor")]
        int? SecondaryBackgroundColorId { get; set; }
        Color SecondaryBackgroundColor { get; set; }

        [Index("IX_StyleUnique", 3, IsUnique = true)]
        [Column("AccentBackgroundColorId")]
        [ForeignKey("AccentBackgroundColor")]
        int? AccentBackgroundColorId { get; set; }
        Color AccentBackgroundColor { get; set; }

        [Index("IX_StyleUnique", 4, IsUnique = true)]
        [Column("PrimaryFontColorId")]
        [ForeignKey("PrimaryFontColor")]
        int? PrimaryFontColorId { get; set; }
        Color PrimaryFontColor { get; set; }

        [Index("IX_StyleUnique", 5, IsUnique = true)]
        [Column("SecondaryFontColorId")]
        [ForeignKey("SecondaryFontColor")]
        int? SecondaryFontColorId { get; set; }
        Color SecondaryFontColor { get; set; }

        [Index("IX_StyleUnique", 6, IsUnique = true)]
        [Column("AccentFontColorId")]
        [ForeignKey("AccentFontColor")]
        int? AccentFontColorId { get; set; }
        Color AccentFontColor { get; set; }

        [Index("IX_StyleUnique", 7, IsUnique = true)]
        [Column("PrimaryBorderId")]
        [ForeignKey("PrimaryBorder")]
        int? PrimaryBorderId { get; set; }
        Border PrimaryBorder { get; set; }

        [Index("IX_StyleUnique", 8, IsUnique = true)]
        [Column("SecondaryBorderId")]
        [ForeignKey("SecondaryBorder")]
        int? SecondaryBorderId { get; set; }
        Border SecondaryBorder { get; set; }

        [Index("IX_StyleUnique", 9, IsUnique = true)]
        [Column("AccentBorderId")]
        [ForeignKey("AccentBorder")]
        int? AccentBorderId { get; set; }
        Border AccentBorder { get; set; }
    }
}
