using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace LS
{
    public class Pause : MonoBehaviour
    {
        public GameObject pauseMenu;
        GameObject[] pauseObjects;
        public Button resumeButton;
        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1;
            pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
            hidePaused();
        }

        void Awake()
        {
            pauseMenu.SetActive(false);
            resumeButton.onClick.AddListener(OnResumePressed);
        }

        private void OnResumePressed()
        {
            //pauseMenu.SetActive(false);
            Time.timeScale = 1;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if(Time.timeScale == 1)
                {
                    Cursor.visible = true;
                    Cursor.lockState = CursorLockMode.None;
                    Time.timeScale = 0;
                    showPaused();
                }else if(Time.timeScale == 0)
                {
                    Time.timeScale = 0;
                    hidePaused();
                }
                //Cursor.visible = true;
                //Cursor.lockState = CursorLockMode.None;
                //pauseMenu.SetActive(true);
                //Time.timeScale = 0;
            }

        }

        //Reloads the Level
        public void Reload()
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        //controls the pausing of the scene
        public void pauseControl()
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                showPaused();
            }
            else if (Time.timeScale == 0)
            {
                Time.timeScale = 1;
                hidePaused();
            }
        }

        //hides objects with ShowOnPause tag
        private void hidePaused()
        {
            foreach(GameObject g in pauseObjects)
            {
                g.SetActive(false);
            }
        }

        //shows objects with ShowOnPause tag
        private void showPaused()
        {
            foreach (GameObject g in pauseObjects)
            {
                g.SetActive(true);
            }
        }

        //loads inputted level
        public void LoadLevel(string level)
        {
            //Application.LoadLevel(level);
            SceneManager.LoadScene(level);
        }

    }
}
