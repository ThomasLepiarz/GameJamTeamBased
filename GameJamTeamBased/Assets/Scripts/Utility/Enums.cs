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

    public enum Task
    {
        Kaffee = 1,
        Arbeiten = 2,
        Waschen = 3,
        Schlafen = 4,
    }

    public enum TransitionPosition
    {
        Left,
        Right,
        Bottom,
        Top,
    }
}
