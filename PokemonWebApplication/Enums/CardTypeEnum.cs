using System.ComponentModel;

namespace PokemonWebApplication.Enums
{
    public enum CardTypeEnum
    {
        [Description("寶可夢卡-草屬性")]
        Grass = 1,

        [Description("寶可夢卡-火屬性")]
        Fire = 2,

        [Description("寶可夢卡-水屬性")]
        Water = 3,

        [Description("寶可夢卡-電屬性")]
        Lightning = 4,

        [Description("寶可夢卡-超能力屬性")]
        Psychic = 5,

        [Description("寶可夢卡-格鬥屬性")]
        Fighting = 6,

        [Description("寶可夢卡-惡屬性")]
        Darkness = 7,

        [Description("寶可夢卡-鋼屬性")]
        Metal= 8,

        [Description("寶可夢卡-龍屬性")]
        Dragon = 9,

        [Description("寶可夢卡-無色屬性")]
        Colorless=10,

        [Description("寶可夢卡-妖精屬性")]
        Fairy = 11,

        [Description("能量卡")]
        Energy = 12,

        [Description("訓練家卡-支援者卡")]
        Supporter = 13,

        [Description("訓練家卡-物品卡")]
        Item = 14,

        [Description("訓練家卡-競技場卡")]
        Stadium = 15
    }
}
