using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            pausePanel.SetActive(true);

        }
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            pausePanel.SetActive(false);
        }
    }


}
