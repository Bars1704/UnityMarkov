using UnityEditor;
using UnityEngine;

namespace Editor.EditorElementDrawers
{
    public class PaletteDrawer : IEditorElementDrawer<ColorPalette>
    {
        public ColorPalette Draw(ColorPalette elem, MarkovSimulation sim)
        {
            var buttonStyle = new GUIStyle
            {
                normal =
                {
                    background = Texture2D.whiteTexture
                },
                margin = new RectOffset(5, 5, 0, 0)
            };

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Palette");
            var defaultColor = GUI.backgroundColor;
            GUI.backgroundColor = sim.ColorPaletteLink.CurrentColor;
            GUILayout.Button("", buttonStyle);
            GUI.backgroundColor = defaultColor;
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            defaultColor = GUI.backgroundColor;
            for (byte i = 0; i < sim.ColorPaletteLink.Length; i++)
            {
                GUI.backgroundColor = sim.ColorPaletteLink.GetColor(i);
                if (GUILayout.Button("", buttonStyle))
                {
                    ColorPalette.CurrentColorIndex = i;
                }
            }

            GUI.backgroundColor = defaultColor;

            EditorGUILayout.EndHorizontal();
            return elem;
        }
    }
}