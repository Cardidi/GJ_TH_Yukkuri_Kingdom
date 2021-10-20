using System;
using Environment.Pool;
using UnityEngine;

namespace Visual
{
    public class ClickFeedbackController : MonoBehaviour
    {
        public GameObject VFXRoot;
        public GameObject ValidPrefab, InvalidPrefab;

        private PoolRoot mPoolValid, mPoolInvalid;

        private void Awake()
        {
            mPoolValid = new PoolRoot(
                3,
                Pool =>
                {
                    var obj = Instantiate(ValidPrefab, VFXRoot.transform);
                    return obj.GetComponent<ClickFeedbackBehaviour>();
                },
                false);
            
            mPoolInvalid = new PoolRoot(
                4,
                Pool =>
                {
                    var obj = Instantiate(InvalidPrefab, VFXRoot.transform);
                    return obj.GetComponent<ClickFeedbackBehaviour>();
                },
                false);
        }

        public void DoClick(Vector3 position, bool valid = true)
        {
            if (valid)
            {
                if (mPoolValid.TryGetObject(out var instance))
                {
                    var confirm = instance as ClickFeedbackBehaviour;
                    position.z = confirm.transform.position.z;
                    confirm.transform.position = position;
                }   
            }
            else
            {
                if (mPoolInvalid.TryGetObject(out var instance))
                {
                    var confirm = instance as ClickFeedbackBehaviour;
                    position.z = confirm.transform.position.z;
                    confirm.transform.position = position;
                }
            }
        }
    }
}