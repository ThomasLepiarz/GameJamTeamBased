using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.EventSystems;
using Cursor = UnityEngine.Cursor;
using Enums;


namespace Transitions
{
    public class TransitionRight : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        //public enum ButtonPosition { Left, Right, Top, Bottom }

        #region Fields

        //lets you set which screenborder the TransitionButton is on
        //public ButtonPosition buttonPosition;

        [SerializeField] private Texture2D cursorTextureRight;

        private bool mouse_over = false;
        private Vector2 _hotSpotAuto = Vector2.zero;
        private readonly CursorMode cursorMode = CursorMode.Auto;

        //properties to be called by the GameManager
        //(Script TransitionButtonHandler)
        public bool TransitionMouseOver { get => mouse_over; private set => mouse_over = value; }

        #endregion

        #region Public Functions

        //sets identifiers for the game manager to know:
        //where the button is on the screen
        //if the mouse is over the button
        //changes the button instance so that I can make general references
        //in the game manager


        //did the mouse leave the button?
        public void ClickedTransitionButton()
        {
            mouse_over = false;
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            Debug.Log("Went to next screen");
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            Debug.Log("Mouse entered");
            mouse_over = true;
            /*_eventDataString = eventData.pointerEnter.ToString();

            if (_eventDataString.StartsWith("Down"))
            {
                ButtonPosition = "Down";
            }
            else if (_eventDataString.StartsWith("Up"))
            {
                ButtonPosition = "Up";
            }
            else if (_eventDataString.StartsWith("Left"))
            {
                _eventDataString = "Left";
            }
            else if (_eventDataString.StartsWith("Right"))
            {
                _eventDataString = "Right";
            }*/
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            mouse_over = false;
            Debug.Log("Mouse exit");
        }

        #endregion

        #region Private Functions

        private void FixedUpdate()
        {
            switch (mouse_over)
            {
                case true:

                    _hotSpotAuto = new Vector2(cursorTextureRight.width * 0.5f, cursorTextureRight.height * 0.5f);
                    Cursor.SetCursor(cursorTextureRight, _hotSpotAuto, CursorMode.ForceSoftware);
                    /*
                    switch (transitionPosition)
                    {
                        case TransitionPosition.Left:
                            _hotSpotAuto = new Vector2(cursorTextureLeft.width * 0.5f, cursorTextureLeft.height * 0.5f);
                            Cursor.SetCursor(cursorTextureLeft, _hotSpotAuto, CursorMode.ForceSoftware);
                            break;

                        case TransitionPosition.Right:
                            _hotSpotAuto = new Vector2(cursorTextureRight.width * 0.5f, cursorTextureRight.height * 0.5f);
                            Cursor.SetCursor(cursorTextureRight, _hotSpotAuto, CursorMode.ForceSoftware);
                            break;

                        case TransitionPosition.Top:
                            _hotSpotAuto = new Vector2(cursorTextureTop.width * 0.5f, cursorTextureTop.height * 0.5f);
                            Cursor.SetCursor(cursorTextureTop, _hotSpotAuto, CursorMode.ForceSoftware);
                            break;

                        case TransitionPosition.Bottom:
                            _hotSpotAuto = new Vector2(cursorTextureBottom.width * 0.5f, cursorTextureBottom.height * 0.5f);
                            Cursor.SetCursor(cursorTextureBottom, _hotSpotAuto, CursorMode.ForceSoftware);
                            break;

                        default:
                            break;
                    }*/
                    break;

                case false:
                    {
                        Cursor.SetCursor(null, Vector2.zero, cursorMode);
                    }
                    break;
            }
        }

        #endregion        
    }
}