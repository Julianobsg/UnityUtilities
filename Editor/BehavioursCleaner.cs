namespace UnityUtilities.Editor
{
    using UnityEngine;
    using UnityEditor;
    using System;
    using System.Collections.Generic;

    public class BehavioursCleaner :  Editor
	{	
		[MenuItem("Edit/Clean Missing Behaviours")]
        public static void CleanGameObjectsMissingBehaviours ()
        {
			foreach(GameObject go in FindObjectsOfType(typeof(GameObject)) as GameObject[])
			{
				CleanGameObject(go);	
			}
        }

        private static void CleanGameObject(GameObject go)
        {
			Component[] components = go.GetComponents<Component>();
			SerializedObject serializedObject = new SerializedObject(go);
			removeComponentFromPoperty(components, serializedObject.FindProperty("m_Component"));
			serializedObject.ApplyModifiedProperties();
        }

        private static void removeComponentFromPoperty(Component[] components, SerializedProperty property)
        {
            int removeComponents = 0;
			for(int i = 0; i < components.Length; i++)
			{
				if(components[i] == null)
				{
					property.DeleteArrayElementAtIndex(i-removeComponents);
					removeComponents++;
				}
			}
        }
    }
}
