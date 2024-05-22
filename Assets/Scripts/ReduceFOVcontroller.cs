using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Rollercoaster
{
    public class ReduceFOVcontroller : MonoBehaviour
    {
        private GameObject trainGameObject;
        private Rigidbody trainRigidBody;
        private CoasterTrain coasterTrainScript; 
        [SerializeField] Camera cameraVRplayer;
        [SerializeField] GameObject canvasPlayer;

        private GameObject bound1;
        private GameObject bound2;
        private GameObject bound3;
        private GameObject bound4;
        private float velocityToReduceFov = 1.0f;
        private float scaleToReduce = 2.5F;

        // Start is called before the first frame update
        void Start()
        {
            Debug.Log(cameraVRplayer.transform.parent.transform.parent.transform.parent.name);
            if (cameraVRplayer.transform.parent.transform.parent.transform.parent.name == "ExampleTrain")
            {
                trainGameObject = cameraVRplayer.transform.parent.transform.parent.transform.parent.gameObject;
                trainRigidBody = trainGameObject.GetComponent<Rigidbody>();
                coasterTrainScript = trainGameObject.GetComponent<CoasterTrain>();
            }

            bound1 = canvasPlayer.transform.GetChild(0).gameObject;
            bound2 = canvasPlayer.transform.GetChild(1).gameObject;
            bound3 = canvasPlayer.transform.GetChild(2).gameObject;
            bound4 = canvasPlayer.transform.GetChild(3).gameObject;

            Debug.Log(bound3.gameObject.name);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //Debug.Log("My actual velocity is:" + coasterTrainScript.velocity);
            if (coasterTrainScript.velocity > 15)
            {
                scaleToReduce = 2;
                Debug.Log("Voy rapidisimo");
                velocityToReduceFov = 1.0f;
 
                bound1.transform.localScale = new Vector3(scaleToReduce, scaleToReduce, scaleToReduce);
                bound2.transform.localScale = new Vector3(scaleToReduce, scaleToReduce, scaleToReduce);
                bound3.transform.localScale = new Vector3(scaleToReduce, scaleToReduce, scaleToReduce);
                bound4.transform.localScale = new Vector3(scaleToReduce, scaleToReduce, scaleToReduce);

            }
            else
            {
                scaleToReduce = 1;
                Debug.Log("Voy lentisimo");
                velocityToReduceFov = -1.0f;

                bound1.transform.localScale = new Vector3(scaleToReduce, scaleToReduce, scaleToReduce);
                bound2.transform.localScale = new Vector3(scaleToReduce, scaleToReduce, scaleToReduce);
                bound3.transform.localScale = new Vector3(scaleToReduce, scaleToReduce, scaleToReduce);
                bound4.transform.localScale = new Vector3(scaleToReduce, scaleToReduce, scaleToReduce);
                   
            }
        }
    }
}