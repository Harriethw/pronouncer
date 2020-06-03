using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpeechCopy {

    public static string[] chatter = new string[] {
        "hey how did that big meeting go?",
        "Pretty good, we talked over the KPI's for this sprint.",
        "Awesome.",
        "Nico gave a presentation about donuts, (wrongPronoun1) killed it!",
        "oh cool! I've seen (wrongPronoun2) give that talk before!",
        "yeah actually (wrongPronoun1) had a good idea about deep fat frying that I think could help our cycle time",
        "I'll have to ask (wrongPronoun2) about it",
        "(wrongPronoun1) also talked about more efficient sprinkle application",
        "I heard the Seattle office is making some dough out of that",
        "we could bake it into our next release planning"
    };

    public static string interruption = "Hey actually Nico's pronouns are (rightPronoun1)/(rightPronoun2)";

    public static string[] apologies = new string[] {
        "Oh I'm sorry! I'll do better next time",
        "Sorry about that"
    };

}