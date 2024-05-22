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

        // Right Bound
        [SerializeField] private GameObject bound1;
        // Left Bound
        [SerializeField] private GameObject bound2;
        // Upper Bound
        [SerializeField] private GameObject bound3;
        // Bottom Bound
        [SerializeField] private GameObject bound4;

        private Transform previousTransformBound1;
        private Transform previousTransformBound2;
        private Transform previousTransformBound3;
        private Transform previousTransformBound4;

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

            previousTransformBound1 = bound1.transform;
            previousTransformBound2 = bound2.transform;
            previousTransformBound3 = bound3.transform;
            previousTransformBound4 = bound4.transform;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            //Debug.Log("My actual velocity is:" + coasterTrainScript.velocity);
            if (coasterTrainScript.velocity > 15)
            {
                Debug.Log("Voy rapidisimo");
                
                bound1.transform.position = previousTransformBound1.position;
                bound2.transform.position = previousTransformBound2.position;
                bound3.transform.position = previousTransformBound3.position;
                bound4.transform.position = previousTransformBound4.position;
            }
            else
            {
                Debug.Log("Voy lentisimo");
                   
                bound1.transform.position = new Vector3(1.457f, bound1.transform.position.y, bound1.transform.position.z);
                bound2.transform.position = new Vector3(-1.49f, bound2.transform.position.y, bound2.transform.position.z);
                bound3.transform.position = new Vector3(bound3.transform.position.x, 1.357f, bound3.transform.position.z);
                bound4.transform.position = new Vector3(bound4.transform.position.x, -1.513f, bound4.transform.position.z);
            }
        }
    }
}