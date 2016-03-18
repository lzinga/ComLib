using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Collections.Generic;

namespace ComLib.Unity.Editor
{
    public class Heirarchy : MonoBehaviour
    {

        [MenuItem("GameObject/Hierarchy/Collapse All  [Alt+Q] &q", false, 0)]
        private static void CollapseAll()
        {
            foreach (GameObject obj in SceneRoots())
            {
                SetExpandedRecursive(obj, false);
            }
        }

        [MenuItem("GameObject/Hierarchy/Un-Parent And Collapse All  [Ctrl+Q] %q", false, 0)]
        private static void UnparentAndCollapse()
        {
            foreach (GameObject obj in Selection.gameObjects)
            {
                obj.transform.parent = null;
            }
            CollapseAll();
        }

        [MenuItem("GameObject/Hierarchy/Place Selection In New Container  [Shift+Ctrl+Q] #%q", false, 0)]
        private static void PlaceInNewContainer()
        {
            if (Selection.gameObjects.Length <= 0)
            {
                return;
            }

            GameObject container = new GameObject("GameObject");

            foreach (GameObject obj in Selection.gameObjects)
            {
                Transform nextParent = obj.transform.parent;
                bool dontMove = false;
                while (nextParent != null)
                {
                    if (Selection.gameObjects.Any(o => o.gameObject == nextParent.gameObject))
                    {
                        dontMove = true;
                        break;
                    }
                    nextParent = nextParent.transform.parent;
                }

                if (!dontMove)
                {
                    obj.transform.parent = container.transform;
                }
            }

            Selection.objects = new Object[] { };
            CollapseAll();
        }

        [MenuItem("GameObject/Hierarchy/Sort Children By Name  [Alt+Shift+Ctrl+Q] &#%q", false, -1)]
        public static void SortGameObjectsByName(MenuCommand menuCommand)
        {
            if (menuCommand.context == null || menuCommand.context.GetType() != typeof(GameObject))
            {
                EditorUtility.DisplayDialog("Error", "You must select an item to sort in the frame", "Okay");
                return;
            }

            GameObject parentObject = (GameObject)menuCommand.context;

            // Build a list of all the Transforms in this player's hierarchy
            Transform[] objectTransforms = new Transform[parentObject.transform.childCount];
            for (int i = 0; i < objectTransforms.Length; i++)
                objectTransforms[i] = parentObject.transform.GetChild(i);

            int sortTime = System.Environment.TickCount;

            bool sorted = false;
            // Perform a bubble sort on the objects
            while (sorted == false)
            {
                sorted = true;
                for (int i = 0; i < objectTransforms.Length - 1; i++)
                {
                    // Compare the two strings to see which is sooner
                    int comparison = objectTransforms[i].name.CompareTo(objectTransforms[i + 1].name);

                    if (comparison > 0) // 1 means that the current value is larger than the last value
                    {
                        objectTransforms[i].transform.SetSiblingIndex(objectTransforms[i + 1].GetSiblingIndex());
                        sorted = false;
                    }
                }

                // resort the list to get the new layout
                for (int i = 0; i < objectTransforms.Length; i++)
                    objectTransforms[i] = parentObject.transform.GetChild(i);
            }

            Debug.Log("Sort took " + (System.Environment.TickCount - sortTime) + " milliseconds");
        }

        public static IEnumerable<GameObject> SceneRoots()
        {
            var prop = new HierarchyProperty(HierarchyType.GameObjects);
            var expanded = new int[0];
            while (prop.Next(expanded))
            {
                yield return prop.pptrValue as GameObject;
            }
        }

        public static void Collapse(GameObject gameObject, bool collapse = true)
        {
            if (gameObject.transform.childCount == 0) return;
            var hierarchy = GetFocusedWindow("Hierarchy");
            SelectObject(gameObject);
            var key = new Event { keyCode = collapse ? KeyCode.RightArrow : KeyCode.LeftArrow, type = EventType.keyDown };
            hierarchy.SendEvent(key);
        }

        public static void SetExpandedRecursive(GameObject go, bool expand)
        {
            var type = typeof(EditorWindow).Assembly.GetType("UnityEditor.SceneHierarchyWindow");
            var methodInfo = type.GetMethod("SetExpandedRecursive");

            EditorApplication.ExecuteMenuItem("Window/Hierarchy");
            var window = EditorWindow.focusedWindow;

            methodInfo.Invoke(window, new object[] { go.GetInstanceID(), expand });
        }

        public static void SelectObject(Object obj)
        {
            Selection.activeObject = obj;
        }

        public static EditorWindow GetFocusedWindow(string window)
        {
            FocusOnWindow(window);
            return EditorWindow.focusedWindow;
        }

        public static void FocusOnWindow(string window)
        {
            EditorApplication.ExecuteMenuItem("Window/" + window);
        }
    }
}
