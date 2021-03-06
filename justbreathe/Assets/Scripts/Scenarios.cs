﻿using UnityEngine;

public class Scenarios 
{
    public static GameScriptController[] GetLevel1Script(GameManager manager, KeyDisplay HeartKey)
    {
        return new GameScriptController[]
        {
            new GameScriptController
            {
                ScenarioTime = 0.0f,
                Subtitle = "",
                VOClip = null,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = HeartKey,
                        TimeDown = 19.0f,
                        TimeUp = 19.0f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 4.0f,
                Subtitle = "Monday mornings are the worst.",
                VOClip = manager.VO1Monday,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 10.0f,
                Subtitle = "Staring up at the ceiling, nothing but me and my heartbeat.",
                VOClip = manager.VO1Ceiling,
                Volume = .5f
            },

            new GameScriptController { ScenarioTime = 11.0f, Subtitle = "", VOClip = null },
            new GameScriptController { ScenarioTime = 12.0f, Subtitle = "*Heartbeat sounds*", VOClip = manager.VO1Heartbeat, Volume = .1f },
            new GameScriptController { ScenarioTime = 13.0f, Subtitle = "*Heartbeat sounds*", VOClip = manager.VO1Heartbeat, Volume = .125f },
            new GameScriptController { ScenarioTime = 14.0f, Subtitle = "*Heartbeat sounds*", VOClip = manager.VO1Heartbeat, Volume = .15f },
            new GameScriptController { ScenarioTime = 15.0f, Subtitle = "*Heartbeat sounds*", VOClip = manager.VO1Heartbeat, Volume = .175f },
            new GameScriptController { ScenarioTime = 16.0f, Subtitle = "*Heartbeat sounds*", VOClip = manager.VO1Heartbeat, Volume = .2f },
            
            new GameScriptController
            {
                ScenarioTime = 25.0f,
                Subtitle = "If I focus hard enough, it's like I can control it. Like tapping a key on my keyboard.",
                VOClip = manager.VO1Keyboard,
                Volume = .5f,
                HeartEnabled = true,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = HeartKey,
                        TimeDown = 1.0f,
                        TimeUp = 1.0f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 30.0f,
                Subtitle = "I can make it beat faster.",
                VOClip = manager.VO1Faster,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = HeartKey,
                        TimeDown = 0.7f,
                        TimeUp = 0.7f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 35.0f,
                Subtitle = "Or slower.",
                VOClip = manager.VO1Slower,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = HeartKey,
                        TimeDown = 1.3f,
                        TimeUp = 1.3f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 45.0f,
                Subtitle = "Probably best not to focus on it too much.",
                VOClip = manager.VO1Focus,
                Volume = .5f,
            },

            new GameScriptController
            {
                ScenarioTime = 50.0f,
                Subtitle = "",
                VOClip = null,
                Volume = .5f,
            },
        };
    }

    public static GameScriptController[] GetLevel2Script(GameManager manager, KeyDisplay HeartKey, KeyDisplay BreathKey)
    {
        return new GameScriptController[]
        {
            new GameScriptController
            { 
                ScenarioTime = 2.0f,    
                Subtitle = "", 
                VOClip = null, 
                Adjustment = null ,
                HeartEnabled = true,
                LungsEnabled = true,
            },

            new GameScriptController
            { 
                ScenarioTime = 7.0f,    
                Subtitle = "Looks like cereal again.", 
                VOClip = manager.VO2Cereal,
                Adjustment = null,
                Volume = .5f
            },

            new GameScriptController
            { 
                ScenarioTime = 14.0f,  
                Subtitle = "*eating dry cereal*",
                VOClip = manager.VO2Crunching1,
                Adjustment = null,
                Volume = .5f
            },

            new GameScriptController
            { 
                ScenarioTime = 19.0f,   
                Subtitle = "I wonder if all this sugar is good for me?", 
                VOClip = manager.VO2Sugar,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                { 
                    new RhythmAdjustment
                    { 
                        Key = HeartKey, 
                        TimeDown = 0.9f, 
                        TimeUp = 1.0f 
                    } 
                } 
            },
            
            new GameScriptController
            { 
                ScenarioTime = 25.0f,   
                Subtitle = "*eating pure sugar cereal*",
                VOClip = manager.VO2Crunching2,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    { 
                        Key = HeartKey, 
                        TimeDown = 0.8f, 
                        TimeUp = 1.0f 
                    } 
                } 
            },

            new GameScriptController
            { 
                ScenarioTime = 35.0f,   
                Subtitle = "*drinking tap water*", 
                VOClip = manager.VO2Drink,
                Volume = .8f,
                Adjustment = new RhythmAdjustment[]
                { 
                    new RhythmAdjustment
                    { 
                        Key = HeartKey, 
                        TimeDown = 1.0f, 
                        TimeUp = 1.0f 
                    } 
                } 
            },

            new GameScriptController
            { 
                ScenarioTime = 45.0f,   
                Subtitle = "Wait, did I forget to pay the power bill yesterday?", 
                VOClip = manager.VO2Power,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                { 
                    new RhythmAdjustment
                    { 
                        Key = BreathKey, 
                        TimeDown = 1.5f, 
                        TimeUp = 1.5f 
                    } 
                } 
            },

            new GameScriptController
            { 
                ScenarioTime = 50.0f,   
                Subtitle = "*looking through various bills*", 
                VOClip = manager.VO2Papers,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                { 
                    new RhythmAdjustment
                    { 
                        Key = BreathKey, 
                        TimeDown = 1.0f,
                        TimeUp = 1.0f 
                    } 
                } 
            },

            new GameScriptController
            { 
                ScenarioTime = 60.0f,   
                Subtitle = "*Whew* I must have forgotten that I paid it earlier this month.", 
                VOClip = manager.VO2Forgotten,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                { 
                    new RhythmAdjustment
                    { 
                        Key = BreathKey, 
                        TimeDown = 1.8f, 
                        TimeUp = 1.8f 
                    } 
                } 
            },

            new GameScriptController
            { 
                ScenarioTime = 70.0f,   
                Subtitle = "I wish it was Saturday.", 
                VOClip = manager.VO2Saturday,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                { 
                    new RhythmAdjustment
                    { 
                        Key = BreathKey, 
                        TimeDown = 2.0f, 
                        TimeUp = 2.0f 
                    } 
                } 
            },
            
            new GameScriptController
            {
                ScenarioTime = 80.0f,   
                Subtitle = "*sadly eating cereal*",
                VOClip = manager.VO2Crunching3,
                Volume = .5f,
                Adjustment = null 
            }
        };
    }

    public static GameScriptController[] GetLevel3Script(GameManager manager, KeyDisplay HeartKey, KeyDisplay BreathKey, KeyDisplay EyeKey)
    {
        return new GameScriptController[]
        {
            new GameScriptController
            {
                ScenarioTime = 0.0f,
                Subtitle = "",
                VOClip = null,
                HeartEnabled = true,
                LungsEnabled = true,
                EyesEnabled = true,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = BreathKey,
                        TimeDown = 1.5f,
                        TimeUp = 1.5f
                    },
                    new RhythmAdjustment
                    {
                        Key = HeartKey,
                        TimeDown = .75f,
                        TimeUp = .75f
                    },
                    new RhythmAdjustment
                    {
                        Key = EyeKey,
                        TimeDown = 4.5f,
                        TimeUp = 4.5f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 5.0f,
                Subtitle = "*heavy breathing*",
                VOClip = manager.VO3HeavyBreathing,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 10.0f,
                Subtitle = "I don't even like running, what am I doing out here?",
                VOClip = manager.VO3Running,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 17.0f,
                Subtitle = "Just because SHE likes it doesn't mean I need to, right?",
                VOClip = manager.VO3She,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 21.0f,
                Subtitle = "",
                VOClip = null,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = BreathKey,
                        TimeDown = 1.1f,
                        TimeUp = 1.1f
                    },
                    new RhythmAdjustment
                    {
                        Key = HeartKey,
                        TimeDown = .6f,
                        TimeUp = .6f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 25.0f,
                Subtitle = "*choking on spit*",
                VOClip = manager.VO3Choking,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 30.0f,
                Subtitle = "I think I swallowed a bug!",
                VOClip = manager.VO3Bug,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 33.0f,
                Subtitle = "*struggling for air*",
                VOClip = manager.VO3Breathing2,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = BreathKey,
                        TimeDown = 1.5f,
                        TimeUp = 1.5f
                    },
                    new RhythmAdjustment
                    {
                        Key = HeartKey,
                        TimeDown = .75f,
                        TimeUp = .75f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 37.0f,
                Subtitle = "*struggling for air*",
                VOClip = null,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = EyeKey,
                        TimeDown = 1.0f,
                        TimeUp = 1.0f
                    },
                    new RhythmAdjustment
                    {
                        Key = BreathKey,
                        TimeDown = 1.2f,
                        TimeUp = 1.2f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 39.0f,
                Subtitle = "Stupid sun right on the stupid horizon, right in my stupid eyes.",
                VOClip = manager.VO3Eyes,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 47.0f,
                Subtitle = "Stupid sun right on the stupid horizon, right in my stupid eyes.",
                VOClip = null,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = EyeKey,
                        TimeDown = 3.5f,
                        TimeUp = 3.5f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 49.0f,
                Subtitle = "*gasping for air on the side of the road*",
                VOClip = manager.VO3Gasping,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = BreathKey,
                        TimeDown = 0.8f,
                        TimeUp = 0.8f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 54.0f,
                Subtitle = "How much longer do I need to keep this up?",
                VOClip = manager.VO3Up,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 63.0f,
                Subtitle = "*out-of-shape gasping*",
                VOClip = manager.VO3Gasping2,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 70.0f,
                Subtitle = "I just wish she would call me back.",
                VOClip = manager.VO3CallMe,
                Volume = .5f
            },
        };
    }

    public static GameScriptController[] GetLevel4Script(GameManager manager, KeyDisplay HeartKey, KeyDisplay BreathKey, KeyDisplay EyeKey, KeyDisplay IntestinesKey)
    {
        return new GameScriptController[]
        {
            new GameScriptController
            {
                ScenarioTime = 0.0f,
                Subtitle = "",
                VOClip = null,
                HeartEnabled = true,
                LungsEnabled = true,
                EyesEnabled = true,
                IntestinesEnabled = true,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = BreathKey,
                        TimeDown = 3f,
                        TimeUp = 3f
                    },
                    new RhythmAdjustment
                    {
                        Key = HeartKey,
                        TimeDown = 1f,
                        TimeUp = 1f
                    },
                    new RhythmAdjustment
                    {
                        Key = EyeKey,
                        TimeDown = 6f,
                        TimeUp = 6f
                    },
                    new RhythmAdjustment
                    {
                        Key = IntestinesKey,
                        TimeDown = 3f,
                        TimeUp = 3f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 8.0f,
                Subtitle = "Oh dear GOD, I should NOT have had that burrito for lunch.",
                VOClip = manager.VO4Burrito,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = IntestinesKey,
                        TimeDown = 3f,
                        TimeUp = 3f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 16.0f,
                Subtitle = "*Typing Noises*",
                VOClip = manager.VO4Typing1,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = IntestinesKey,
                        TimeDown = 4f,
                        TimeUp = 4f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 24.0f,
                Subtitle = "My poor stomach. My poor. . . uh oh!",
                VOClip = manager.VO4Stomach,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = IntestinesKey,
                        TimeDown = 3f,
                        TimeUp = 3f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 30.0f,
                Subtitle = "*Typing Intensifies*",
                VOClip = manager.VO4Typing2,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = BreathKey,
                        TimeDown = 2f,
                        TimeUp = 2f
                    },
                    new RhythmAdjustment
                    {
                        Key = IntestinesKey,
                        TimeDown = 4f,
                        TimeUp = 4f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 36.0f,
                Subtitle = "Just need to get this report in so I can go to the bath-{Hey! How's it going?}",
                VOClip = manager.VO4Report,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 42.0f,
                Subtitle = "Oh, uh, just fine. H-how are you?",
                VOClip = manager.VO4JustFine,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 53.0f,
                Subtitle = "{Not bad. Hey, I just wanted to tell you that I might need to postpone our date on Saturday.}",
                VOClip = manager.VO4Postpone,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = BreathKey,
                        TimeDown = 3f,
                        TimeUp = 3f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 58.0f,
                Subtitle = "Oh god, not now. PLEASE not now.",
                VOClip = manager.VO4OhGod,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = IntestinesKey,
                        TimeDown = 2f,
                        TimeUp = 2f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime =66.0f,
                Subtitle = "Oh, y-yeah, no problem. Everything okay?",
                VOClip = manager.VO4NoProblem,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = IntestinesKey,
                        TimeDown = 6f,
                        TimeUp = 6f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 74.0f,
                Subtitle = "{Yeah, it's just that I had a friend suddenly decide to come to town and he really wanted to hang out.}",
                VOClip = manager.VO4Friend,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 80.0f,
                Subtitle = "He!? HE wanted to hang out?",
                VOClip = manager.VO4He,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = BreathKey,
                        TimeDown = 2f,
                        TimeUp = 2f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 86.0f,
                Subtitle = "Oh, that's cool. . . yeah.",
                VOClip = manager.VO4Cool,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 91.0f,
                Subtitle = "Burrito PLEASE!",
                VOClip = manager.VO4Please,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = IntestinesKey,
                        TimeDown = 1f,
                        TimeUp = 1f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 97.0f,
                Subtitle = "Maybe we can do something the next weekend?",
                VOClip = manager.VO4NextWeekend,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = IntestinesKey,
                        TimeDown = 3f,
                        TimeUp = 3f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 110.0f,
                Subtitle = "Yeah, maybe. . .",
                VOClip = manager.VO4Maybe,
                Volume = .5f
            },
        };
    }
}

public struct RhythmAdjustment
{
    public KeyDisplay Key;
    public float TimeUp;
    public float TimeDown;
}

public struct GameScriptController
{
    public float ScenarioTime;
    public string Subtitle;
    public AudioClip VOClip;
    public float Volume;
    public RhythmAdjustment[] Adjustment;
    public bool HeartEnabled;
    public bool LungsEnabled;
    public bool EyesEnabled;
    public bool IntestinesEnabled;
}