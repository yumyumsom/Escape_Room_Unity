/******
 * MARCIN'S ASSETS 2019:
 * www.assetstore.unity.com/publishers/6702
******/

using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class character_Ctrl : MonoBehaviourPunCallbacks
{
    private Animator animator;
    private Transform tr;
    private PhotonView PV;
    public GameObject user_name;
    // Start is called before the first frame update

    private void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        tr = GetComponent<Transform>();
        Set_Camera();
        if (PV.IsMine)
        {
            PV.RPC("SetNickname", RpcTarget.All,  PlayerPrefs.GetString("nickName"));
        }
  
    }
    [PunRPC]
    public void SetNickname(string nm) //플레이어가 레디 할때 RPC로 전달되는 함수
    {
        this.user_name.GetComponent<TextMesh>().text = nm;
    }
    void FixedUpdate()
    {
        if (!PV.IsMine)
            return;
        if (animator)
        {
            if (Input.GetKey(KeyCode.UpArrow) && !Input.GetKey(KeyCode.LeftShift))
            {
                if (animator.GetInteger("move") != 1)
                {
                    animator.SetFloat("speed", 1);
                    animator.SetInteger("move", 1);
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow) && !Input.GetKey(KeyCode.LeftShift))
            {
                if (animator.GetInteger("move") != 1)
                {
                    animator.SetFloat("speed", -1);
                    animator.SetInteger("move", 1);
                }
            }
            //----RUN-----
            else if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.LeftShift))
            {
                if (animator.GetInteger("move") != 2)
                    animator.SetInteger("move", 2);
            }
            //----IDLE----
            else
            {
                if (animator.GetInteger("move") != 0)
                {
                    animator.SetInteger("move", 0);
                    animator.SetFloat("speed", 1);
                }
            }

            //---TURN LEFT-----
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.up, -120f * Time.deltaTime);
                if (animator.GetInteger("head_turn") != 1)
                    animator.SetInteger("head_turn", 1);
                //---TURN RIGHT-----
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up, 120f * Time.deltaTime);
                if (animator.GetInteger("head_turn") != 2)
                    animator.SetInteger("head_turn", 2);
            }
            else
            {
                if (animator.GetInteger("head_turn") != 0)
                    animator.SetInteger("head_turn", 0);
            }
            //---TURN LEFT-----
           /* if (Input.GetKey(KeyCode.A))
            {
                print("손들어");
                //animator.SetInteger("shake_hand", 1);
                animator.SetTrigger("hand_up");
            }*/
            /*
            //---FORWARD FALL
            if (Input.GetKeyDown(KeyCode.Alpha1) && !animator.GetCurrentAnimatorStateInfo(0).IsName("forward_fall"))
            {
                animator.SetTrigger("forward_fall");
            }

            //---BACKWARD FALL
            if (Input.GetKeyDown(KeyCode.Alpha2) &&
                !animator.GetCurrentAnimatorStateInfo(0).IsName("backward_fall"))
            {
                animator.SetTrigger("backward_fall");
            }

            //---SITTING
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                animator.SetTrigger("sitting");
            }

            //---SITTING+hand_up
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                animator.SetTrigger("sitting_hand_up");
            }

            //---HAPPY DANCE
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                animator.SetTrigger("happy_dance");
            }

            //---HAPPY DANCE_2
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                animator.SetTrigger("happy_dance_2");
            }

            //---JUMP
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                animator.SetTrigger("jump");
            }

            //---HANDS ON HEAD
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                animator.SetTrigger("hands_on_head");
            }

            //---HANDS ON HEAD
            if (Input.GetKeyDown(KeyCode.Alpha9))
            {
                animator.SetTrigger("lying");
            }

            //---HANDS ON HEAD
            if (Input.GetKeyDown(KeyCode.Alpha0))
            {
                animator.SetTrigger("on_all_fours");
            }
            */
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
            {
                transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
            }

            //RESET Y position
            if (transform.localPosition.y > 0)
                transform.localPosition = Vector3.Slerp(transform.localPosition,
                    new Vector3(transform.localPosition.x, 0, transform.localPosition.z), 0.5f * Time.deltaTime);
        }

    }

    private void Update()

    {
        if (PV.IsMine)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            if (Camera.main.GetComponent<SmoothFollow>() == null)
            {
                Camera.main.GetComponent<SmoothFollow>().target = tr.Find("CamPivot").transform;
            }
        }
            
    }

    public void Set_Camera()
    {
        if (PV.IsMine)
        {
            Camera.main.GetComponent<SmoothFollow>().target = tr.Find("CamPivot").transform;
        }
    }


    
}