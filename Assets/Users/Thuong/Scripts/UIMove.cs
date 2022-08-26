using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMove : MonoBehaviour
{
    [SerializeField] private Animator[] _wallMove = null;
    [SerializeField] private Animator[] _lockPlayer = null;

    [SerializeField] private string wallIn = "wallIn";
    [SerializeField] private string wallBack = "wallBack";
    
    [SerializeField] private Transform[] playerPick;
    [SerializeField] private Transform[] posSetLab;

    [SerializeField] private List<GameObject> characterSpritesLeft;
    [SerializeField] private List<GameObject> characterSpritesRight;

    [SerializeField] private AudioSource audioSources;
    [SerializeField] private AudioClip[] AudioClips;
    private bool CheckLockP1;
    private bool CheckLockP2;
    private int numP1 = -1;
    private int numP2 = 0;
    private void Start()
    {
        audioSources = GetComponent<AudioSource>();
        _wallMove[0].Play(wallIn, 0, 0.0f);
        _wallMove[1].Play(wallIn, 0, 0.0f);
        CheckLockP1 = false;
        CheckLockP2 = false;
        //-----------

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            audioSources.PlayOneShot(AudioClips[0], 0.8f);
            F1MoveP1();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            audioSources.PlayOneShot(AudioClips[0], 0.8f);
            F2MoveP1();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            audioSources.PlayOneShot(AudioClips[0], 0.8f);
            F1MoveP2();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            audioSources.PlayOneShot(AudioClips[0], 0.8f);
            F2MoveP2();
        }
        //--------
        if (Input.GetKeyDown(KeyCode.F))
        {
            _lockPlayer[0].Play("LockP1", 0, 0.0f);
            CheckLockP1 = true;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            _lockPlayer[1].Play("LockP2", 0, 0.0f);
            CheckLockP2 = true;
        }
        updateSpriteLeft();
        updateSpriteRight();
    }





        void F1MoveP1() //phai
        {
            if(CheckLockP1 == false)
            { 
                if (numP1 == -1)
                {
                    playerPick[0].position = posSetLab[1].position;
                    numP1++;
                }
                else if (numP1 == 0)
                {
                    playerPick[0].position = posSetLab[2].position;
                    numP1++;
                }
                else if (numP1 == 1)
                {
                    playerPick[0].position = posSetLab[3].position;
                    numP1++;
                }
                else if (numP1 == 2)
                {
                    playerPick[0].position = posSetLab[0].position;
                    numP1 = numP1 - 3;
                }
            } 
        }
    void F2MoveP1() // trai
    {
        if (CheckLockP1 == false)
        {
           
            if (numP1 == 2)
            {
                numP1--;
                playerPick[0].position = posSetLab[2].position;
            }
            else if (numP1 == 1)
            {
                numP1--;
                playerPick[0].position = posSetLab[1].position;
            }
            else if (numP1 == 0)
            {
                numP1--;
                playerPick[0].position = posSetLab[0].position;
            }
            else if (numP1 == -1)
            {
                numP1 = numP1 + 3;
                playerPick[0].position = posSetLab[3].position;
            }


        }
    }
    void F1MoveP2()
    {
        if (CheckLockP2 == false)
        {
            
            if (numP2 == -1)
            {
                playerPick[1].position = posSetLab[1].position;
                numP2++;
            }
            else if (numP2 == 0)
            {
                playerPick[1].position = posSetLab[2].position;
                numP2++;
            }
            else if (numP2 == 1)
            {
                playerPick[1].position = posSetLab[3].position;
                numP2++;
            }
            else if (numP2 == 2)
            {
                playerPick[1].position = posSetLab[0].position;
                numP2 = numP2 - 3;
            }
        }
    }
    void F2MoveP2()
    {
        if (CheckLockP2 == false)
        {
            if (numP2 == 2)
            {
                numP2--;
                playerPick[1].position = posSetLab[2].position;
            }
            else if (numP2 == 1)
            {
                numP2--;
                playerPick[1].position = posSetLab[1].position;
            }
            else if (numP2 == 0)
            {
                numP2--;
                playerPick[1].position = posSetLab[0].position;
            }
            else if (numP2 == -1)
            {
                numP2 = numP2 + 3;
                playerPick[1].position = posSetLab[3].position;
            }
        }
    }
        void updateSpriteLeft()
        {
            switch (numP1)
            {
                case -1:
                characterSpritesLeft[0].SetActive(true);
                characterSpritesLeft[1].SetActive(false);
                characterSpritesLeft[2].SetActive(false);
                characterSpritesLeft[3].SetActive(false);
                break;
                case 0:
                characterSpritesLeft[0].SetActive(false);
                characterSpritesLeft[1].SetActive(true);
                characterSpritesLeft[2].SetActive(false);
                characterSpritesLeft[3].SetActive(false);
                break;
                case 1:
                characterSpritesLeft[0].SetActive(false);
                characterSpritesLeft[1].SetActive(false);
                characterSpritesLeft[2].SetActive(true);
                characterSpritesLeft[3].SetActive(false);
                break;
                case 2:
                characterSpritesLeft[0].SetActive(false);
                characterSpritesLeft[1].SetActive(false);
                characterSpritesLeft[2].SetActive(false);
                characterSpritesLeft[3].SetActive(true);
                break;
            }
        }
        void updateSpriteRight()
        {
            switch (numP2)
            {
                case -1:
                characterSpritesRight[0].SetActive(true);
                characterSpritesRight[1].SetActive(false);
                characterSpritesRight[2].SetActive(false);
                characterSpritesRight[3].SetActive(false);
                break;
                case 0:
                characterSpritesRight[0].SetActive(false);
                characterSpritesRight[1].SetActive(true);
                characterSpritesRight[2].SetActive(false);
                characterSpritesRight[3].SetActive(false);
                break;
                case 1:
                characterSpritesRight[0].SetActive(false);
                characterSpritesRight[1].SetActive(false);
                characterSpritesRight[2].SetActive(true);
                characterSpritesRight[3].SetActive(false);
                break;
                case 2:
                characterSpritesRight[0].SetActive(false);
                characterSpritesRight[1].SetActive(false);
                characterSpritesRight[2].SetActive(false);
                characterSpritesRight[3].SetActive(true);
                break;
            }
        }
    
}
