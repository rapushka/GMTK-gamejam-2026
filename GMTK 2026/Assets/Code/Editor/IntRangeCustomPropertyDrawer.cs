namespace Core.Editor
{
    using UnityEditor;
    using UnityEngine;

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

            EditorGUI.PropertyField(minRect, min, GUIContent.none);
            EditorGUI.PropertyField(maxRect, max, GUIContent.none);

            EditorGUI.EndProperty();
        }
    }
}