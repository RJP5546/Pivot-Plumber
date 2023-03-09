using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameMode
{
    idle,
    playing,
    levelEnd
}

public class GameManager : MonoBehaviour
{
    static private GameManager s;

    [Header("Inscribed")]
    public Text uitLevel; //The UITest_Level text
    public Text uitScore; //The UIText_Score text
    public Vector3 boardPos; //The place to put boards
    public GameObject[] boards; //An array of boards
    public int scoreToWin; //score needed to win

    [Header("Dynamic")]
    public int level; //The current level
    public int score; //current score
    public int levelMax; //The number of levels
    public GameObject board; //the current board
    public GameMode mode = GameMode.idle;

    // Start is called before the first frame update
    void Start()
    {
        s = this; //Define the singleton

        level = 0;
        score = 0;
        levelMax = boards.Length;
        StartLevel();
    }

    void StartLevel()
    {
        //Get rid of any old board
        if (board != null)
        {
            Destroy(board);
        }

        //Destroy old water if they exist
        Water.DESTROY_WATERS();

        //Instantiate new castle
        board = Instantiate<GameObject>(boards[level]);
        board.transform.position = boardPos;

        //Reset the goal
        Goal.goalMet = false;

        UpdateGUI();

        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        //show the data in the GUITexts
        uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitScore.text = "Score: " + score;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateGUI();

        //Check for level end
        if ((mode == GameMode.playing) && score >= scoreToWin)
        {
            //Channge mode to stop checking for level end
            mode = GameMode.levelEnd;
            //Start the next level in 2 seconds
            Invoke("NextLevel", 2f);
        }
    }


    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
            score = 0;
        }
        StartLevel();
    }

    //Static method that allows code anywhere to increment score
    static public void SCORE_ADD()
    {
        s.score++;
    }

    //Static method that allows code anywhere to refrence S.board
    static public GameObject GET_BOARD()
    {
        return s.board;
    }
}
