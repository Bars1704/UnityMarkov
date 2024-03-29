using System;
using Markov.MarkovTest.Sequences;
using Markov.MarkovTest.ThreeDimension;
using MarkovEditor;
using UnityEditor;
using UnityEngine;

namespace Editor._3D.EditorElementDrawers
{
    public class SequenceDrawer :
        IEditorElementDrawer<SelectRandomSequence<byte, MarkovSimulation<byte>>, IMarkovSimulationDrawer>,
        IEditorElementDrawer<MarkovSequence<byte, MarkovSimulation<byte>>, IMarkovSimulationDrawer>,
        IEditorElementDrawer<CycleSequence<byte, MarkovSimulation<byte>>, IMarkovSimulationDrawer>
    {
        private readonly PlayableListDrawer<MarkovSimulation<byte>> _selectRandomDrawer =
            new PlayableListDrawer<MarkovSimulation<byte>>();
        private readonly PlayableListDrawer<MarkovSimulation<byte>> _markovDrawer =
            new PlayableListDrawer<MarkovSimulation<byte>>();
        private readonly PlayableListDrawer<MarkovSimulation<byte>> _cycleDrawer =
            new PlayableListDrawer<MarkovSimulation<byte>>();
        public SelectRandomSequence<byte, MarkovSimulation<byte>> Draw(
            SelectRandomSequence<byte, MarkovSimulation<byte>> elem,
            IMarkovSimulationDrawer sim)
        {
            _selectRandomDrawer.Draw(elem.Playables, sim,"Random sequence");
            return elem;
        }

        public MarkovSequence<byte, MarkovSimulation<byte>> Draw(MarkovSequence<byte, MarkovSimulation<byte>> elem,
            IMarkovSimulationDrawer sim)
        {
            _markovDrawer.Draw(elem.Playables, sim,"Markov sequence");
            return elem;
        }

        public CycleSequence<byte, MarkovSimulation<byte>> Draw(CycleSequence<byte, MarkovSimulation<byte>> elem, IMarkovSimulationDrawer sim)
        {
            var style = new GUIStyle(GUI.skin.textField)
            {
                alignment = TextAnchor.MiddleLeft
            };

            elem.Cycles = Math.Max(EditorGUILayout.IntField("Cycles count:", elem.Cycles, style), 1);
            _cycleDrawer.Draw(elem.Playables, sim, "Cycle sequence");
            return elem;
        }
    }
}