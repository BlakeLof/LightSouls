using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace LS
{
    public class QuitButton : MonoBehaviour
    {
        Button button;

        // Start is called before the first frame update
        void Start()
        {

        }
        private void Awake()
        {
            button = GetComponent<Button>();
            button.onClick.AddListener(Quit);
        }

        private void Quit()
        {
            print("Quitting");
            Application.Quit();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}