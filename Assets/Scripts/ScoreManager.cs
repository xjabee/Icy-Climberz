using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public GameObject player;
    public int Score;
    public Vector2 initPos;
    public float scoreCalc;
    public float scoreMul = 3.76156f;
    // Start is called before the first frame update
    void Start()
    {
        initPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        scoreCalc = player.transform.position.y - initPos.y;
        Debug.Log(scoreCalc);
        if(scoreCalc >= scoreMul)
        {
            Score++;
            scoreMul = scoreMul + 3.76156f;
        }
        UIManager.Instance.Scored(Score);
        UIManager.Instance.StairClimb(Score);
        UIManager.Instance.FinishScore(Score*10);
    }
}
