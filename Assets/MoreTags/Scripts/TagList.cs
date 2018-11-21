namespace MoreTags
{
    public static class Tag
    {
        public static AllTags all = new AllTags();
        public static UIGroup UI = new UIGroup("UI");
        public static EnemyGroup Enemy = new EnemyGroup("Enemy");
        public static TagName Player = new TagName("Player");
        public static TagName Bullet = new TagName("Bullet");
    }

    public class UIGroup : TagGroup
    {
        public UIGroup(string name) : base(name) { }
    }

    public class EnemyGroup : TagGroup
    {
        public EnemyGroup(string name) : base(name) { }
        public TagName Boss1 = new TagName("Enemy.Boss1");
    }

    public class AllTags : TagNames
    {
        public AllTags() : base(TagSystem.AllTags()) { }
        public TagChildren Mainmenu = new TagChildren("Mainmenu");
        public TagChildren NewgameBtn = new TagChildren("NewgameBtn");
        public TagChildren LevelselectBtn = new TagChildren("LevelselectBtn");
        public TagChildren HighscoreBtn = new TagChildren("HighscoreBtn");
        public TagChildren Boss1 = new TagChildren("Boss1");
    }
}
