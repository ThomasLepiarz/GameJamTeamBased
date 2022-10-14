using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enums
{
    public enum GameState
    {
        Starting,
        MainMenu,
        Credits,
        NewGame,
        Hallway,
        BadEnding,
        NextDay,
        GoodEnding,
        LivingRoom,
        Kitchen,
        Garage,
        Bathroom,
        Bedroom,
        Snake,
    }

    public enum Tasks
    {
        Coffee = 1,
        Work = 2,
        Shower = 3,
        Sleep = 4,
    }

    public enum TransitionPosition
    {
        Left,
        Right,
        Bottom,
        Top,
    }
}
