// using System.Collections;
// using System.Collections.Generic;
// using Photon.Pun;
// using UnityEngine;
// using UnityEngine.UI;
// using Cinemachine;

// public class Temp : MonoBehaviourPunCallbacks
// {
//     public Rigidbody2D RB;
//     public Animator AN;
//     public SpriteRenderer SR;
//     public PhotonView PV;
//     public Text NickNameText;
//     public Image HealthImage;

//     bool isGround;
//     Vector3 curPos;

//     void Awake()
//     {
//         //닉네임
//         NickNameText.text = PV.IsMine ? PhotonNetwork.NickName : PV.Owner.NickName;
//         NickNameText.color = PV.IsMine ? Color.green : Color.red;

//         if(PV.IsMine){
//             var CM = GameObject.Find("CMCamera").GetComponent<CinemachineVirtualCamera>();
//             CM.Follow = transform;
//             CM.LookAt = transform;
//         }
//     }



// }
