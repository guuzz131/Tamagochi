using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tamagucci
{
    

    public class CreatureStats
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public float Hunger { get; set; }
        public float Thirst { get; set; }
        public float Boredom { get; set; }
        public float Loneliness { get; set; }
        public float Stimulated { get; set; }
        public float Tired { get; set; }

        /*
        "id": 0,
        "name": "string",
        "userName": "string",
        "hunger": 0,
        "thirst": 0,
        "boredom": 0,
        "loneliness": 0,
        "stimulated": 0,
        "tired": 0
        */

        public string HungerText => Hunger switch
        {
            >= 1.0f => "God is SOOO full",
            > 0.5f => "God is enjoying the sacrifices",
            > 0.0f => "God needs sacrifices",
            .0f => "God is dying",
            _ => throw new Exception("Impossible")
        };
        public string ThirstText => Thirst switch
        {
            >= 1.0f => "God is VERY hydrated",
            > 0.5f => "God is hydrated",
            > 0.0f => "God needs blood",
            .0f => "God really needs BLOODDDD",
            _ => throw new Exception("Impossible")
        };
        public string BoredomText => Boredom switch
        {
            >= 1.0f => "God REALLY enjoys the show",
            > 0.5f => "God likes the show",
            > 0.0f => "God needs a show",
            .0f => "God is EXTREMELY bored",
            _ => throw new Exception("Impossible")
        };
        public string LonelinessText => Loneliness switch
        {
            >= 1.0f => "God FEELS like a real god",
            > 0.5f => "God feels praised",
            > 0.0f => "God needs praise",
            .0f => "God feels left alone",
            _ => throw new Exception("Impossible")
        };
        public string StimulatedText => Stimulated switch
        {
            >= 1.0f => "God likes the other mortal's pressence",
            > 0.5f => "God isn't bothered by the other mortal",
            > 0.0f => "God is bothered by the other mortal",
            .0f => "God will KILL the everyone if the other mortal doesn't leave",
            _ => throw new Exception("Impossible")
        };
        public string TiredText => Tired switch
        {
            >= 1.0f => "God likes the mortal's pressence",
            > 0.5f => "God isn't bothered by the mortal",
            > 0.0f => "God is bothered by the mortal",
            .0f => "God will KILL the mortal if he doesn't leave",
            _ => throw new Exception("Impossible")
        };

        public event PropertyChangedEventHandler PropertyChanged;
    }
    
}
