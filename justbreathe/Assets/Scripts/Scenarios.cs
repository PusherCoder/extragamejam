using UnityEngine;

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
                ScenarioTime = 35.0f,
                Subtitle = "Probably best not to focus on it too much.",
                VOClip = manager.VO1Focus,
                Volume = .5f,
            },

            new GameScriptController
            {
                ScenarioTime = 40.0f,
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
                ScenarioTime = 0.0f,    
                Subtitle = "", 
                VOClip = null, 
                Adjustment = null ,
                HeartEnabled = true,
                LungsEnabled = true,
            },

            new GameScriptController
            { 
                ScenarioTime = 2.0f,    
                Subtitle = "Looks like cereal again.", 
                VOClip = manager.VO2Cereal,
                Adjustment = null,
                Volume = .5f
            },

            new GameScriptController
            { 
                ScenarioTime = 10.0f,  
                Subtitle = "*crunching sounds*",
                VOClip = null,        
                Adjustment = null,
                Volume = .5f
            },

            new GameScriptController
            { 
                ScenarioTime = 18.0f,   
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
                Subtitle = "*crunching sounds*", 
                VOClip = null,
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
                Subtitle = "*drinking sounds*", 
                VOClip = manager.VO2Drink,
                Volume = .5f,
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
                Subtitle = "Wait, did I forget to pay the power bill again?", 
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
                Subtitle = "*papers shuffling*", 
                VOClip = manager.VO2Papers,
                Volume = .25f,
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
                Subtitle = "*Whew* I must have forgotten that I paid it early.", 
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
                Subtitle = "I wish today was Saturday.", 
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
                Subtitle = "*crunching sounds*", 
                VOClip = null,
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
                Subtitle = "*Heavy breathing noises*",
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
                Subtitle = "Just because she likes it doesn't mean I need to, right?",
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
                ScenarioTime = 23.0f,
                Subtitle = "*Choking*",
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
                Subtitle = "*Heavy breathing noises*",
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
                Subtitle = "*Heavy breathing noises*",
                VOClip = null,
                Volume = .5f,
                Adjustment = new RhythmAdjustment[]
                {
                    new RhythmAdjustment
                    {
                        Key = EyeKey,
                        TimeDown = 1.0f,
                        TimeUp = 1.0f
                    }
                }
            },

            new GameScriptController
            {
                ScenarioTime = 39.0f,
                Subtitle = "Stupid sun right on the stupid horizon, right in my stupid eyes",
                VOClip = manager.VO3Eyes,
                Volume = .5f
            },

            new GameScriptController
            {
                ScenarioTime = 47.0f,
                Subtitle = "Stupid sun right on the stupid horizon, right in my stupid eyes",
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
                Subtitle = "*Gasping for air on the side of the road*",
                VOClip = manager.VO3Gasping,
                Volume = .5f
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
                Subtitle = "*Gasping*",
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
                        TimeDown = 2f,
                        TimeUp = 2f
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
                        TimeDown = 5f,
                        TimeUp = 5f
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
                ScenarioTime = 100.0f,
                Subtitle = "",
                VOClip = null
            },

            new GameScriptController
            {
                ScenarioTime = 101.0f,
                Subtitle = "",
                VOClip = null
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