using MarkovTest.TwoDimension.Rules;
using UnityEditor;
using UnityEngine;

namespace Editor.EditorElementDrawers
{
    public class RotationSettingsDrawer : IEditorElementDrawer<RotationSettingsFlags>
    {
        public RotationSettingsFlags Draw(RotationSettingsFlags elem, MarkovSimulation sim)
        {
            RotationSettingsFlags resultFlag = RotationSettingsFlags.None;
            EditorGUILayout.BeginVertical();
            if (GUILayout.Toggle(elem.HasFlag(RotationSettingsFlags.Rotate), "Rotate"))
                resultFlag = resultFlag | RotationSettingsFlags.Rotate;
            if (GUILayout.Toggle(elem.HasFlag(RotationSettingsFlags.FlipX), "FlipX"))
                resultFlag = resultFlag | RotationSettingsFlags.FlipX;
            if (GUILayout.Toggle(elem.HasFlag(RotationSettingsFlags.FlipY), "FlipY"))
                resultFlag = resultFlag | RotationSettingsFlags.FlipY;
            EditorGUILayout.EndVertical();
            return resultFlag;
        }
    }
}