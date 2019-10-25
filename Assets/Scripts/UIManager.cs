using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text Collect;
    [SerializeField] private GameObject RestartScreen;
    [SerializeField] private Text EndScore;
    [SerializeField] private Text EndStair;
    private static UIManager instance;
    public static UIManager Instance
    {
        // by calling Instance, you can get the value of instance, but you can't reset it
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UIEndscreen(bool toggle)
    {
        Collect.gameObject.SetActive(!toggle);
        EndScore.gameObject.SetActive(toggle);
        EndStair.gameObject.SetActive(toggle);
        RestartScreen.gameObject.SetActive(toggle);
        Time.timeScale = toggle?0:1;
    }
    public void Scored(int score)
    {
        Collect.text = "Score: " + score*10;
    }
    public void StairClimb(int stairclimber)
    {
        EndStair.text = "" + stairclimber;
    }
    public void FinishScore(int EndFloor)
    {
        EndScore.text = "" + EndFloor;
    }

}
