using UnityEngine;
using System.Collections;

namespace ComLib.Unity.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Resets a transformation to default values
        /// </summary>
        /// <param name="trans"></param>
        public static void ResetTransformation(this Transform trans)
        {
            trans.position = Vector3.zero;
            trans.localRotation = Quaternion.identity;
            trans.localScale = new Vector3(1, 1, 1);
        }

        /// <summary>
        /// Destroys all child gameObjects to this transform
        /// </summary>
        /// <param name="go"></param>
        public static void DestroyChildren(this Transform trans)
        {
            for (int i = 0; i < trans.childCount; i++)
            {
                GameObject.Destroy(trans.GetChild(i).gameObject);
            }
        }

        public static void Shake(this Transform trans, float shakeAmt, float speed)
        {
            Quaternion randomRot = Quaternion.identity;

            randomRot = Random.rotation;
            randomRot = Quaternion.RotateTowards(trans.rotation, randomRot, shakeAmt);
            randomRot = Quaternion.Slerp(trans.rotation, randomRot, speed * Time.deltaTime);

            trans.rotation = randomRot;
        }
    }
}
