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
}