using UnityEngine;
using System.Collections;

namespace ComLib.Unity.Extensions
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Sets the layer of this gameobject, and all of its children
        /// </summary>
        /// <param name="go">root gameObject</param>
        /// <param name="newLayer">new Layer</param>
        public static void SetLayerRecursively(this GameObject go, LayerMask newLayer)
        {
            go.layer = newLayer;

            for (int i = 0; i < go.transform.childCount; i++)
            {
                go.transform.GetChild(i).gameObject.SetLayerRecursively(newLayer);
            }
        }

        /// <summary>
        /// Sets the tag of this gameobject, and all of its children
        /// </summary>
        /// <param name="go">root gameObject</param>
        /// <param name="newTag">new Tag</param>
        public static void SetTagRecursively(this GameObject go, string newTag)
        {
            go.tag = newTag;

            foreach (GameObject child in go.transform)
            {
                child.SetTagRecursively(newTag);
            }
        }
    }
}
