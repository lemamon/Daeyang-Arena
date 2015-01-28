using UnityEngine;
using System.Collections;

public class RandomMatchmak : Photon.MonoBehaviour {
    private PhotonView myPhotonView;
	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
	}
    
    void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("JoinRandom");
    }
   
    void OnPhotonRandomJoinFailed()
    {
        PhotonNetwork.CreateRoom(null);
        Debug.Log("can'tJoinRandom");
    }
    
   void OnJoinedRoom()
   {
       //GameObject round = PhotonNetwork.Instantiate("RoundBehaviour", Vector3.zero, Quaternion.identity, 0);

       RoundBehaviourScript round = FindObjectOfType(typeof(RoundBehaviourScript)) as RoundBehaviourScript;
       round.enabled = true;

       CameraFollow camera = Camera.main.GetComponent<CameraFollow>();
       camera.enabled = true;

       VirtualJoystick joy = Camera.main.GetComponentInChildren<VirtualJoystick>();
       joy.enabled = true;

       ArrowFollow [] arrow = Camera.main.GetComponentsInChildren<ArrowFollow>();       
       for (int i = 0; i < arrow.Length; i++) {
           arrow[i].enabled = true;
       }

       NetworkCharact[] s = FindObjectsOfType(typeof(NetworkCharact)) as NetworkCharact[];
       for (int i = 0; i < s.Length; i++)
       {
           s[i].enabled = true;
       }

       GameObject car;

       switch (PlayerPrefs.GetInt("TypeVehicle"))
       {
           case 0:
               car = PhotonNetwork.Instantiate("Vehicle1", Vector3.zero, Quaternion.identity, 0);
               break;
           case 1:
                car = PhotonNetwork.Instantiate("Vehicle2", Vector3.zero, Quaternion.identity, 0);
               break;
           case 2:
                car = PhotonNetwork.Instantiate("Vehicle3", Vector3.zero, Quaternion.identity, 0);
               break;
           case 3:
               car = PhotonNetwork.Instantiate("Vehicle4", Vector3.zero, Quaternion.identity, 0);
               break;
           default:
               car = PhotonNetwork.Instantiate("Vehicle1", Vector3.zero, Quaternion.identity, 0);
               break;
       }
       

       //Vehicle controller = car.GetComponent<Vehicle>();
       //  controller.enabled = true;
       //camera.objectToFollow = car;
       
       //AudioSource sfx = Camera.main.GetComponent<AudioSource>();
       //sfx.enabled = true;
   }
   
   void OnGUI()
   {
       GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
       /*
       if (PhotonNetwork.connectionStateDetailed == PeerState.Joined)
       {
           bool shoutMarco = GameLogic.playerWhoIsIt == PhotonNetwork.player.ID;

           if (shoutMarco && GUILayout.Button("Marco!"))
           {
               myPhotonView.RPC("Marco", PhotonTargets.All);
           }    
           if (!shoutMarco && GUILayout.Button("Polo!"))
           {
               myPhotonView.RPC("Polo", PhotonTargets.All);
           }
       }
      */
   }
    
}
