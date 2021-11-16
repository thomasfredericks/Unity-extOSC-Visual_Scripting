using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;


public class ParseOSC : MonoBehaviour
{

  public extOSC.OSCReceiver receiver; 

    // Start is called before the first frame update
    void Start()
    {
        //receiver = gameObject.AddComponent<extOSC.OSCReceiver>(); 
        receiver.Bind("/test", MessageReceived); 
    }

   protected void MessageReceived(extOSC.OSCMessage message)
{
	// Any code...
	Debug.Log(message);
    //CustomEvent.Trigger (gameObject,"/test", message.Values[0].FloatValue);
    CustomEvent.Trigger (gameObject,"/test", message);
}

    // Update is called once per frame
    void Update()
    {
        
    }

   
}
