using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


public class ExtOscBindToVisualScripting : MonoBehaviour {
  public string address;
  extOSC.OSCReceiver receiver; 
  
     // Start is called before the first frame update
    void Start() {
        receiver = gameObject.GetComponent<extOSC.OSCReceiver>();
        receiver.Bind(address,MessageReceived);
    }

    // MessageReceived is called 
    protected void MessageReceived(extOSC.OSCMessage message) {
        CustomEvent.Trigger (gameObject,address, message);
    }
    
    // Update is called once per frame
    void Update()  {
    }
}
