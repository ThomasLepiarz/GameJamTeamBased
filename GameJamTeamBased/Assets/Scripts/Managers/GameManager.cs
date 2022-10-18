using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using TMPro;


using Enums;
using Snake;
using Unity.VisualScripting;

namespace Everyday
{
    public class GameManager : MonoBehaviour
    {

        #region Fields

        public static GameManager Instance;
        private static AudioManager _audioManager;

        public GameObject MenuCanvas;
        public GameObject CreditsCanvas;
        public GameObject BedroomCanvas;
        public GameObject HallCanvas;
        public GameObject LivingRoomCanvas;
        public GameObject KitchenCanvas;
        public GameObject BathroomCanvas;
        public GameObject GarageCanvas;
        public GameObject BadEndingCanvas;
        public GameObject GoodEndingCanvas;

        //to animate room transitions
        [SerializeField] private LevelChanger _levelChanger;

        //bools to handle whether sounds have played already
        private bool _nothingCoffee = false;
        private bool _finallySomeQuiet = false;

        #endregion

        #region Properties

        private int _currentDay;

        public int CurrentDay
        {
            get { return _currentDay; }
            private set { _currentDay = value; }
        }

        private int _currentTask;

        public int CurrentTask
        {
            get { return _currentTask; }
            set { _currentTask = value; }
        }

        //becomes true if voice line was already played
        //becomes false again for a new day
        public bool CoffeeNarrator { get; set; }


        #endregion

        #region Public Methods

        //responsible for all changes in scenery
        //decides what the player will see
        //takes care of game load up (called in Awake())
        public void SwitchState(GameState newState)
        {
            switch (newState)
            {
                //loads the main menu, regardless where editor was
                //starts the menumusic
                case GameState.Starting:
                    Debug.Log("Game Starting");
                    Instance.MenuCanvas.SetActive(true);
                    Instance.CreditsCanvas.SetActive(false);
                    Instance.BedroomCanvas.SetActive(false);
                    Instance.HallCanvas.SetActive(false);
                    Instance.LivingRoomCanvas.SetActive(false);
                    Instance.KitchenCanvas.SetActive(false);
                    Instance.GarageCanvas.SetActive(false);
                    Instance.GoodEndingCanvas.SetActive(false);
                    Instance.BadEndingCanvas.SetActive(false);
                    Instance.BathroomCanvas.SetActive(false);
                    _audioManager.PlayMenuMusic();
                    break;

                //goes to MainMenu to credits
                case GameState.MainMenu:
                    Instance.CreditsCanvas.SetActive(false);
                    Instance.MenuCanvas.SetActive(true);
                    break;
                
                //goes to Credits from MainMenu
                case GameState.Credits:
                    Instance.MenuCanvas.SetActive(false);
                    Instance.CreditsCanvas.SetActive(true);
                    break;
                
                //starts the player off in the bedroom
                case GameState.NewGame:
                    StartCoroutine(nameof(NewGame));
                    break;

                //sends the player to the bedroom, when coming from the hallway
                case GameState.Bedroom:
                    StartCoroutine(nameof(Bedroom));                    
                    break;

                //sends the player to the bathroom
                case GameState.Bathroom:
                    StartCoroutine(nameof(Bathroom));
                    break;
                
                //goes to kitchen from either 
                case GameState.Kitchen:
                    StartCoroutine(nameof(Kitchen));
                    break;

                //goes to living room from both directions
                case GameState.LivingRoom:
                    StartCoroutine(nameof(LivingRoom));
                    break;
                
                //goes to garage from hallway
                case GameState.Garage:
                    StartCoroutine(nameof(Garage));
                    break;
                
                //goes to hallway from all possible directions
                case GameState.Hallway:
                    StartCoroutine(nameof(Hallway));                   
                    break;

                //goes to bedending from "bed"
                case GameState.BadEnding:
                    StartCoroutine(nameof(BadEnding));
                    break;

                //handles the day changes
                case GameState.NextDay:
                    StartCoroutine(nameof(NextDay));
                    break;

                //goes to good ending from "cycle"
                case GameState.GoodEnding:
                    StartCoroutine(nameof(GoodEnding));
                    break;
                
                //goes to snake from "Snake Button"
                case GameState.Snake:
                    StartCoroutine(nameof(Snake));
                    break;

                default:
                    break;
            }
        }

        #region public StateChangers (for Buttons)

        //Go to main menu from credits
        public void GoToMainMenu()
        {
            SwitchState(GameState.MainMenu);
            Debug.Log("Switch to Main Menu");
        }

        //Transfer to bedroom
        public void PlayGame()
        {
            SwitchState(GameState.NewGame);
            Debug.Log("Started new game");
        }

        //Quit Game... duh
        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }

        //GoToCredits from main menu
        public void GoToCredits()
        {
           Debug.Log("Clicked Credits Button");
           SwitchState(GameState.Credits);
        }

        public void GoToHallway()
        {
            Debug.Log("Went to Hallway");
            SwitchState(GameState.Hallway);
        }

        public void GoToLivingroom()
        {
            Debug.Log("Went to Livingroom");
            SwitchState(GameState.LivingRoom);
        }

        public void GoToKitchen()
        {
            Debug.Log("Went to Kitchen");
            SwitchState(GameState.Kitchen);
        }

        public void GoToBathroom()
        {
            Debug.Log("Went to Bathroom");
            SwitchState(GameState.Bathroom);
        }

        public void GoToGarage()
        {
            Debug.Log("Went to Garage");
            SwitchState(GameState.Garage);
        }

        public void GoToSnake()
        {
            Debug.Log("Play Snake");
            SwitchState(GameState.Snake);
        }

        public void GoToBedroom()
        {
            Debug.Log("Go to bedroom");
            SwitchState(GameState.Bedroom);
        }

        public void GoToGoodEnding()
        {
            Instance.GarageCanvas.SetActive(false);
            Instance.GoodEndingCanvas.SetActive(true);
        }

        #endregion
        #endregion

        #region Private Methods

        //instantiates GameManager and thus all Manager children
        private void Awake()
        {
            if (GameManager.Instance != null)
            {
                Debug.Log("DestroyObject");
                Destroy(gameObject);
                return;
            }

            Instance = this;
            Debug.Log(Instance.GetComponent<AudioManager>());
            _audioManager = Instance.GetComponent<AudioManager>();
            Debug.Log(Instance);
            DontDestroyOnLoad(gameObject);
            Instance.SwitchState(GameState.Starting);
        }

        private IEnumerator WaitForFade()
        {
            Debug.Log("Started Coroutine at timestamp: " + Time.time);
            yield return new WaitForSeconds(200);
            Debug.Log("Finished Coroutine at timestamp: " + Time.time);
        }

        private void Update()
        {
        
            if (Instance.BadEndingCanvas.activeInHierarchy || Instance.GoodEndingCanvas.activeInHierarchy)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    Debug.Log("Escape Pressed");
                    Instance.SwitchState(GameState.Starting);
                }
            }
        }

        #region IEnumerators for Transitions

        private IEnumerator NewGame()
        {
            _levelChanger.FadeOut();
            yield return new WaitForSeconds(1);
            Instance.MenuCanvas.SetActive(false);
            Instance.BedroomCanvas.SetActive(true);

            //stops menu music (if on) and plays Day1 BG music
            _audioManager.PlayBackgroundMusicDayOne();
            _audioManager.PlayCoffeeTaskLine();

            //sets the first Task to Coffee
            _currentTask = (int)Task.Kaffee;
        }

        private IEnumerator Hallway()
        {
            _levelChanger.FadeOut();
            yield return new WaitForSeconds(1);
            if (Instance.GarageCanvas.activeInHierarchy)
            {
                _audioManager.StopGarageMusic();
                _audioManager.UnPauseBackgroundMusic();
            }

            Instance.GarageCanvas.SetActive(false);
            Instance.LivingRoomCanvas.SetActive(false);
            Instance.BedroomCanvas.SetActive(false);
            Instance.HallCanvas.SetActive(true);
        }

        private IEnumerator BadEnding()
        {
            _levelChanger.FadeOut();
            yield return new WaitForSeconds(1);
            Instance.BedroomCanvas.SetActive(false);
            Instance.BadEndingCanvas.SetActive(true);
        }

        private IEnumerator NextDay()
        {
            _levelChanger.FadeOut();
            yield return new WaitForSeconds(1);
            _currentDay += 1;
            _currentTask = (int)Task.Kaffee;
            _audioManager.PlayCoffeeTaskLine();
            _nothingCoffee = false;
            _finallySomeQuiet = false;

        }

        private IEnumerator GoodEnding()
        {
            _levelChanger.FadeOut();
            yield return new WaitForSeconds(1);
            Instance.GarageCanvas.SetActive(false);
            Instance.GoodEndingCanvas.SetActive(true);
        }

        private IEnumerator LivingRoom()
        {
            _levelChanger.FadeOut();
            yield return new WaitForSeconds(1);
            Instance.LivingRoomCanvas.SetActive(true);
            Instance.HallCanvas.SetActive(false);
            Instance.KitchenCanvas.SetActive(false);
        }

        private IEnumerator Kitchen()
        {
            _levelChanger.FadeOut();
            yield return new WaitForSeconds(1);
            if (!_audioManager.BackGroundMusicIsOn)
            {
                _audioManager.StopBathroomMusic();
                _audioManager.UnPauseBackgroundMusic();
            }
            Instance.LivingRoomCanvas.SetActive(false);
            Instance.KitchenCanvas.SetActive(true);
            Instance.BathroomCanvas.SetActive(false);

            if (!_nothingCoffee)
            {
                _audioManager.PlayNothingWithoutCoffee();
                _nothingCoffee = true;
            }
        }

        private IEnumerator Garage()
        {
            _levelChanger.FadeOut();
            yield return new WaitForSeconds(1);
            Instance.HallCanvas.SetActive(false);
            Instance.GarageCanvas.SetActive(true);
            _audioManager.PauseBackgroundMusic();
            _audioManager.PlayGarageMusic();
        }

        private IEnumerator Bathroom()
        {
            _levelChanger.FadeOut();
            yield return new WaitForSeconds(1);
            Instance.BathroomCanvas.SetActive(true);
            Instance.LivingRoomCanvas.SetActive(false);
            _audioManager.PauseBackgroundMusic();
            _audioManager.PlayBathroomMusic();
            if (!_finallySomeQuiet)
            {
                _audioManager.PlayFinallySomeQuiet();
                _finallySomeQuiet = true;
            }
        }

        private IEnumerator Bedroom()
        {
            _levelChanger.FadeOut();
            yield return new WaitForSeconds(1);
            Instance.HallCanvas.SetActive(false);
            Instance.BedroomCanvas.SetActive(true);
        }

        private IEnumerator Snake()
        {
            _levelChanger.FadeOut();
            yield return new WaitForSeconds(1);
            Instance.MenuCanvas.SetActive(false);
            Instance.CreditsCanvas.SetActive(false);
            Instance.BedroomCanvas.SetActive(false);
            Instance.HallCanvas.SetActive(false);
            Instance.LivingRoomCanvas.SetActive(false);
            Instance.KitchenCanvas.SetActive(false);
            Instance.GarageCanvas.SetActive(false);
            Instance.GoodEndingCanvas.SetActive(false);
            Instance.BadEndingCanvas.SetActive(false);
            Instance.BathroomCanvas.SetActive(false);
        }


        #endregion

        #endregion
    }
}