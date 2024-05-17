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

        private float fovMin = 80;
        private float fovMax = 110;

        // Start is called before the first frame update
        void Start()
        {
            cameraVRplayer.stereoTargetEye = StereoTargetEyeMask.None;    

            Debug.Log(transform.parent.transform.parent.transform.parent.name);
            if (transform.parent.transform.parent.transform.parent.name == "ExampleTrain")
            {
                trainGameObject = transform.parent.transform.parent.transform.parent.gameObject;
                trainRigidBody = trainGameObject.GetComponent<Rigidbody>();
                coasterTrainScript = trainGameObject.GetComponent<CoasterTrain>();
            }
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Debug.Log("My actual velocity is:" + coasterTrainScript.velocity);
            if (coasterTrainScript.velocity > 20f)
            {
                cameraVRplayer.fieldOfView = fovMin;
            }
            else
            {
                cameraVRplayer.fieldOfView = fovMax;
            }
        }
    }
}