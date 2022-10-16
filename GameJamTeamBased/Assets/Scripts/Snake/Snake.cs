using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

using Everyday;


namespace Snake
{

    public class Snake : MonoBehaviour
    {
        //Current Movement Direction
        // (by default it moves to the right)
        Vector2 dir = Vector2.right;

        //Keep Track of Tail
        List<Transform> tail = new List<Transform>();

        //Did the snake eat sth?
        bool ate = false;

        //Tail Prefab
        public GameObject tailPrefab;

        private float _speed = 0.1f;
        [SerializeField] private SpawnFood _food;

        AudioSource audioData;

        //Needs to be added to a start button for the game
        public void StartSnake()
        {
            InvokeRepeating(nameof(Move), _speed, _speed);
            /*if (!audioData.isPlaying)
            {
                audioData = GetComponent<AudioSource>();
            }*/
        }

        // Update is called once per frame
        void Update()
        {
            // Move in a new Direction?
            if (Input.GetKey(KeyCode.RightArrow))
                dir = Vector2.right;
            else if (Input.GetKey(KeyCode.DownArrow))
                dir = -Vector2.up;    // '-up' means 'down'
            else if (Input.GetKey(KeyCode.LeftArrow))
                dir = -Vector2.right; // '-right' means 'left'
            else if (Input.GetKey(KeyCode.UpArrow))
                dir = Vector2.up;
        }

        void Move()
        {
            //Save current position (gap will be here)
            Vector2 v = transform.position;
            Vector2 far = new Vector2((float)(dir.x * 0.05), (float)(dir.y * 0.05));
            transform.Translate(far);

            //Ate sth? Then insert new Element into gap
            if (ate)
            {
                //Load Prefab into the world
                GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

                //Keep track of it in our tail list
                tail.Insert(0, g.transform);

                //Reset the flag
                ate = false;
            }

            //Do we have a tail?
            if (tail.Count > 0)
            {
                // Move last Tail Element to where the Head was
                tail.Last().position = v;

                // Add to front of list, remove from the back
                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }
        }

        void OnTriggerEnter2D(Collider2D coll)
        {
            //Food?
            if (coll.name.StartsWith("VeryBigFoodPreFab"))
            {
                // Get Longer in next Move call
                ate = true;
                _speed /= 1.1f;
                CancelInvoke();
                StartSnake();

                // Remove the Food
                Destroy(coll.gameObject);
            }
            //Collided with Tail or Border
            else if (coll.name.StartsWith("Border") || coll.name.StartsWith("TailPrefab"))
            {
                // ToDo You lose message and scene return
                //Cancel all Invoke calls
                CancelInvoke();
                _food.GameRuns = false;
                //audioData.Play(0);
            }
        }
    }
}
