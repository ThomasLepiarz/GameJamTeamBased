using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Enums
{
    #region Enumerators

    public enum GameState
    {
        Starting,
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
    }

    public enum Tasks
    {
        Coffee = 1,
        Work = 2,
        Shower = 3,
        Sleep = 4,
    }

    public enum Scenes
    {
        MainMenu,
        Credits,
        Bedroom,
        Hall,
        Livingroom,
        Kitchen,
        Bathroom,
        Garage,
        BadEnding,
        GoodEnding,
        Snake,
    }

    #endregion
}
