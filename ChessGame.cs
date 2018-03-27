using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessGame : MonoBehaviour
{
    private int[,] state = new int[3, 3];
    private int turn = 1;

    
    // Use this for initialization
    void Start()
    {
        Reset();
    }

    void Reset()
    {
        turn = 1;
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                state[i, j] = 0;
            }
        }
    }

    void OnGUI()
    {
        Texture2D baby = (Texture2D)Resources.Load("baby");
        Texture2D pig = (Texture2D)Resources.Load("pig");
        GUI.Label(new Rect(366, 50, 100, 50), "Tic Tac Toe");
        //判断是否点击reset
        if (GUI.Button(new Rect(350, 370, 100, 50), "RESET"))
        {
            Reset();
        }
        //判断是否胜利
        int win = IsWin();
        if (win == 1) {
            GUI.Label(new Rect(280, 70, 80 , 40), "Baby Win!");
         }
        else if(win == 2)
            GUI.Label(new Rect(280, 70, 80, 40), "Pig Win!");
        else if(win == 3)
            GUI.Label(new Rect(280, 70, 80, 40), "Tied!");
        //游戏继续
        for (int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if (state[i, j] == 1)
                    GUI.Button(new Rect(280 + i * 80, 100 + j * 80, 80 ,80), baby);
                else if(state[i, j] == 2)
                    GUI.Button(new Rect(280 + i * 80, 100 + j * 80, 80, 80), pig);
                else if(GUI.Button(new Rect(280 + i * 80, 100 + j * 80, 80, 80), ""))
                {
                    if(win == 0)
                    {
                        if (turn == 1)
                            state[i, j] = 1;
                        else
                            state[i, j] = 2;
                        turn = -turn;
                    }
                }
            }
        }

    }


    int IsWin(){
        // 横向连线    
        for (int i = 0; i < 3; i++)
        {
            if (state[i, 0] != 0 && state[i, 0] == state[i, 1] && state[i, 0] == state[i, 2])
            {
                return state[i, 0];
            }
        }
        //纵向连线
        for (int j = 0; j < 3; j++)
        {
            if (state[0, j] != 0 && state[0, j] == state[1, j] && state[0, j] == state[2, j])
            {
                return state[0, j];
            }
        }
        //斜向连线
        if (state[1, 1] != 0 &&
            state[0, 0] == state[1, 1] && state[1, 1] == state[2, 2] ||
            state[0, 2] == state[1, 1] && state[1, 1] == state[2, 0])
        {
            return state[1, 1];
        }
        //平局
        int flag = 1;
        for(int i = 0; i < 3; i++)
        {
            for(int j = 0; j < 3; j++)
            {
                if (state[i, j] == 0)
                {
                    flag = 0;
                    break;
                }    
            }
        }
        if(flag == 1)
        {
            return 3;
        }
        //未结束
        return 0;
    }
}
