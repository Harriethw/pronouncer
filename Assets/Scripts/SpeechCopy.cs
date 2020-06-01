using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SpeechCopy {

    public static string[] chatter = new string[] {
        "hey how did that big meeting go?",
        "Oh yeah it was pretty good, we talked over the KPI's for this sprint.",
        "Awesome.",
        "(name) gave (wrongPronoun2) presentation about donuts and it was great",
        "oh cool! I've heard about (name)'s and (wrongPronoun2) donut theory!",
        "Yeah actually (wrongPronoun1) had a good idea about deep fat frying that I think could help our cycle time",
        "Let's table that idea for now, I don't wanna overload (wrongPronoun2) plate!"
    };

    public static string interruption = "Hey actually my pronouns are (rightPronoun1)/(rightPronoun2)";

    public static string[] apologies = new string[] {
        "Oh I'm sorry! I'll do better next time",
        "Yeah sorry about that"
    };

}