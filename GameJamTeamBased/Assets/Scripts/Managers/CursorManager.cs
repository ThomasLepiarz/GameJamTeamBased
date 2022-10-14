using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager: MonoBehaviour
{
    #region Fields

    [SerializeField] private Texture2D cursorTextureLeft;
    [SerializeField] private Texture2D cursorTextureRight;
    [SerializeField] private Texture2D cursorTextureTop;
    [SerializeField] private Texture2D cursorTextureBottom;

    private readonly CursorMode cursorMode = CursorMode.Auto;

    public Vector2 _hotSpotAuto = Vector2.zero;

    #endregion

    #region Public Fields

    public void SwitchCursorUp()
    {
        _hotSpotAuto = new Vector2(cursorTextureTop.width * 0.5f, cursorTextureTop.height * 0.5f);
        Cursor.SetCursor(cursorTextureTop, _hotSpotAuto, CursorMode.ForceSoftware);
    }

    public void SwitchCursorDown()
    {
        _hotSpotAuto = new Vector2(cursorTextureBottom.width * 0.5f, cursorTextureBottom.height * 0.5f);
        Cursor.SetCursor(cursorTextureBottom, _hotSpotAuto, CursorMode.ForceSoftware);
    }

    public void SwitchCursorLeft()
    {
        _hotSpotAuto = new Vector2(cursorTextureLeft.width * 0.5f, cursorTextureLeft.height * 0.5f);
        Cursor.SetCursor(cursorTextureLeft, _hotSpotAuto, CursorMode.ForceSoftware);
    }

    public void SwitchCursorRight()
    {
        _hotSpotAuto = new Vector2(cursorTextureRight.width * 0.5f, cursorTextureRight.height * 0.5f);
        Cursor.SetCursor(cursorTextureRight, _hotSpotAuto, CursorMode.ForceSoftware);
    }

    public void NormalizeCursor()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    #endregion


}
