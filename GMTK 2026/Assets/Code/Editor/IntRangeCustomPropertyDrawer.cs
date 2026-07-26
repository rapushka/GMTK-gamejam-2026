using UnityEditor;
using UnityEngine;

namespace Core.Editor
{
    [CustomPropertyDrawer(typeof(IntRange))]
    public class IntRangeCustomPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);

            position = EditorGUI.PrefixLabel(position, label);

            var min = property.FindPropertyRelative("<Min>k__BackingField");
            var max = property.FindPropertyRelative("<Max>k__BackingField");

            var half = position.width * 0.5f;
            var gap = 4f;

            var minRect = new Rect(position.x, position.y, half - gap * 0.5f, position.height);
            var maxRect = new Rect(position.x + half + gap * 0.5f, position.y, half - gap * 0.5f, position.height);
            var old = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 28f;

            EditorGUI.PropertyField(minRect, min, new GUIContent("Min"));
            EditorGUI.PropertyField(maxRect, max, new GUIContent("Max"));

            EditorGUIUtility.labelWidth = old;
            EditorGUI.EndProperty();
        }
    }
}