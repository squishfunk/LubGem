using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public bool IsPaused = false;

    [SerializeField]
    private GameObject PausePanel;

    // Start is called before the first frame update
    void Start()
    {
        PausePanel.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            Pause();         
        }
    }

    private void Pause()
    {
        if (!IsPaused)
        {
            PausePanel.SetActive(true);
            IsPaused = true;
            Time.timeScale = 0;
        }
        else
        {
            IsPaused = false;
            Time.timeScale = 1;
            PausePanel.SetActive(false);
        }
    }


}
