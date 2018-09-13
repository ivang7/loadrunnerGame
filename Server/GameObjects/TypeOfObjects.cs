namespace Server.GameObjects
{
    public enum CellChar
    {
        //Пустое место – по которому может двигаться герой:
        None = (int)' ',

        //Cтена в которой можно просверлить дырочку слева или справа от героя= (int)в зависимости от того, куда он сейчас смотрит, :
        Brick = (int)'#',

        //Стена со временем зарастает.Когда процесс начинается - мы видим таймер:
        PitFill1 = (int)'1',
        PitFill2 = (int)'2',
        PitFill3 = (int)'3',
        PitFill4 = (int)'4',

        //Неразрушаемая стена - в ней ничего просверлить не получится:
        UndestroyableWall = (int)'☼',

        //В момент сверления мы видим процесс так:
        DrillPit = (int)'*',

        //Золото - его надо собирать:
        Gold = (int)'$',

        //Лестница и труба - по ним можно перемещаться по уровню:
        Ladder = (int)'H',
        Pipe = (int)'~',

        HeroDie = (int)'Ѡ',
        HeroDrillLeft = (int)'Я',
        HeroDrillRight = (int)'R',
        HeroLadder = (int)'Y',
        HeroLeft = (int)'◄',
        HeroRight = (int)'►',
        HeroFallLeft = (int)']',
        HeroFallRight = (int)'[',
        HeroPipeLeft = (int)'{',
        HeroPipeRight = (int)'}',

        //Герои других игроков, соответственно
        OtherHeroDie = (int)'Z',
        OtherHeroLeft = (int)',',
        OtherHeroRight = (int)'=',
        OtherHeroLadder = (int)'U',
        OtherHeroPipeLeft = (int)'Э',
        OtherHeroPipeRight = (int)'Є',

        //Так же и враг-охотник
        EnemyLadder = (int)'Q',
        EnemyLeft = (int)'«',
        EnemyRight = (int)'»',
        EnemyPipeLeft = (int)'<',
        EnemyPipeRight = (int)'>',
        EnemyPit = (int)'X'
    };

    static class TypeOfObjects
    {
        




        ////Пустое место – по которому может двигаться герой:
        //public const char NONE = ' ';

        ////Cтена в которой можно просверлить дырочку слева или справа от героя=в зависимости от того, куда он сейчас смотрит; :
        //public const char BRICK = '#';

        ////Стена со временем зарастает.Когда процесс начинается - мы видим таймер:
        //public const char PIT_FILL_1 = '1';
        //public const char PIT_FILL_2 = '2';
        //public const char PIT_FILL_3 = '3';
        //public const char PIT_FILL_4 = '4';

        ////Неразрушаемая стена - в ней ничего просверлить не получится:
        //public const char UNDESTROYABLE_WALL = '☼';

        ////В момент сверления мы видим процесс так:
        //public const char DRILL_PIT = '*';

        ////Золото - его надо собирать:
        //public const char GOLD = '$';

        ////Лестница и труба - по ним можно перемещаться по уровню:
        //public const char LADDER = 'H';
        //public const char PIPE = '~';

        //public const char HERO_DIE = 'Ѡ';
        //public const char HERO_DRILL_LEFT = 'Я';
        //public const char HERO_DRILL_RIGHT = 'R';
        //public const char HERO_LADDER = 'Y';
        //public const char HERO_LEFT = '◄';
        //public const char HERO_RIGHT = '►';
        //public const char HERO_FALL_LEFT = ']';
        //public const char HERO_FALL_RIGHT = '[';
        //public const char HERO_PIPE_LEFT = '{';
        //public const char HERO_PIPE_RIGHT = '}';

        ////Герои других игроков, соответственно
        //public const char OTHER_HERO_DIE = 'Z';
        //public const char OTHER_HERO_LEFT = ';';
        //public const char OTHER_HERO_RIGHT = '=';
        //public const char OTHER_HERO_LADDER = 'U';
        //public const char OTHER_HERO_PIPE_LEFT = 'Э';
        //public const char OTHER_HERO_PIPE_RIGHT = 'Є';

        ////Так же и враг-охотник
        //public const char ENEMY_LADDER = 'Q';
        //public const char ENEMY_LEFT = '«';
        //public const char ENEMY_RIGHT = '»';
        //public const char ENEMY_PIPE_LEFT = '<';
        //public const char ENEMY_PIPE_RIGHT = '>';
        //public const char ENEMY_PIT = 'X';
        ////Пустое место – по которому может двигаться герой:
        //public const char NONE = ' ';

        ////Cтена в которой можно просверлить дырочку слева или справа от героя=в зависимости от того, куда он сейчас смотрит; :
        //public const char BRICK = '#';

        ////Стена со временем зарастает.Когда процесс начинается - мы видим таймер:
        //public const char PIT_FILL_1 = '1';
        //public const char PIT_FILL_2 = '2';
        //public const char PIT_FILL_3 = '3';
        //public const char PIT_FILL_4 = '4';

        ////Неразрушаемая стена - в ней ничего просверлить не получится:
        //public const char UNDESTROYABLE_WALL = '☼';

        ////В момент сверления мы видим процесс так:
        //public const char DRILL_PIT = '*';

        ////Золото - его надо собирать:
        //public const char GOLD = '$';

        ////Лестница и труба - по ним можно перемещаться по уровню:
        //public const char LADDER = 'H';
        //public const char PIPE = '~';

        //public const char HERO_DIE = 'Ѡ';
        //public const char HERO_DRILL_LEFT = 'Я';
        //public const char HERO_DRILL_RIGHT = 'R';
        //public const char HERO_LADDER = 'Y';
        //public const char HERO_LEFT = '◄';
        //public const char HERO_RIGHT = '►';
        //public const char HERO_FALL_LEFT = ']';
        //public const char HERO_FALL_RIGHT = '[';
        //public const char HERO_PIPE_LEFT = '{';
        //public const char HERO_PIPE_RIGHT = '}';

        ////Герои других игроков, соответственно
        //public const char OTHER_HERO_DIE = 'Z';
        //public const char OTHER_HERO_LEFT = ';';
        //public const char OTHER_HERO_RIGHT = '=';
        //public const char OTHER_HERO_LADDER = 'U';
        //public const char OTHER_HERO_PIPE_LEFT = 'Э';
        //public const char OTHER_HERO_PIPE_RIGHT = 'Є';

        ////Так же и враг-охотник
        //public const char ENEMY_LADDER = 'Q';
        //public const char ENEMY_LEFT = '«';
        //public const char ENEMY_RIGHT = '»';
        //public const char ENEMY_PIPE_LEFT = '<';
        //public const char ENEMY_PIPE_RIGHT = '>';
        //public const char ENEMY_PIT = 'X';
    }
}