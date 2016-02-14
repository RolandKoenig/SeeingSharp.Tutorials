#region License information (SeeingSharp and all based games/applications)
/*
    Seeing# and all games/applications distributed together with it. 
    More info at 
     - https://github.com/RolandKoenig/SeeingSharp (sourcecode)
     - http://www.rolandk.de/wp (the autors homepage, german)
    Copyright (C) 2016 Roland König (RolandK)
    
    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published
    by the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.
    
    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with this program.  If not, see http://www.gnu.org/licenses/.
*/
#endregion
using SeeingSharp.Multimedia.Core;
using SeeingSharp.Multimedia.Drawing3D;
using SeeingSharp.Multimedia.Objects;
using SeeingSharp.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeeingSharp.Tutorials.Introduction04
{
    public partial class MainWindow : Form
    {
        #region Current mouse state
        private bool m_isPicking;
        private bool m_isMouseInside;
        private Point m_mousePosition;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        protected override async void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Attach the painter to the target render panel
            m_ctrlRenderControl.RenderLoop.ClearColor = Color4.CornflowerBlue;

            // Build scene graph
            await m_ctrlRenderControl.Scene.ManipulateSceneAsync((manipulator) =>
            {
                // Define a BACKGROUND layer and configure layer IDs 
                //  => Ensures correct render order
                SceneLayer bgLayer = manipulator.AddLayer("BACKGROUND");
                manipulator.SetLayerOrderID(bgLayer, 0);
                manipulator.SetLayerOrderID(Scene.DEFAULT_LAYER_NAME, 1);

                // Add the background texture painter to the BACKGROUND layer
                var resBackgroundTexture = manipulator.AddTexture(
                    new AssemblyResourceUriBuilder(
                        "SeeingSharp.Tutorials.Introduction04",
                        true,
                        "Assets/Textures/Background.png"));
                manipulator.Add(new TexturePainter(resBackgroundTexture), bgLayer.Name);

                // Create pallet geometry resource
                PalletType pType = new PalletType();
                pType.ContentColor = Color4.GreenColor;
                var resPalletGeometry = manipulator.AddResource<GeometryResource>(
                    () => new GeometryResource(pType));

                // Create pallet object and add it to the scene
                //  => The DEFAULT layer is used by default
                for (int loopX = 0; loopX < 11; loopX++)
                {
                    for (int loopY = 0; loopY < 11; loopY++)
                    {
                        GenericObject palletObject = manipulator.AddGeneric(resPalletGeometry);
                        palletObject.Color = Color4.GreenColor;
                        palletObject.Position = new Vector3(
                            -10f + loopX * 2f,
                            -10f + loopY * 2f,
                            0f);
                        palletObject.Tag1 = $"Pallet (X={loopX}, Y={loopY})";
                        palletObject.EnableShaderGeneratedBorder();
                        palletObject.BuildAnimationSequence()
                            .RotateEulerAnglesTo(new Vector3(0f, EngineMath.RAD_180DEG, EngineMath.RAD_45DEG), TimeSpan.FromSeconds(2.0))
                            .WaitFinished()
                            .RotateEulerAnglesTo(new Vector3(0f, EngineMath.RAD_360DEG, EngineMath.RAD_45DEG), TimeSpan.FromSeconds(2.0))
                            .WaitFinished()
                            .RotateEulerAnglesTo(new Vector3(0f, 0f, 0f), TimeSpan.FromSeconds(2.0))
                            .WaitFinished()
                            .CallAction(() => palletObject.RotationEuler = Vector3.Zero)
                            .ApplyAndRewind();
                    }
                }
            });

            // Configure camera
            Camera3DBase camera = m_ctrlRenderControl.Camera;
            camera.Position = new Vector3(0f, 0f, -25f);
            camera.Target = new Vector3(0f, 0f, 0f);
            camera.UpdateCamera();
        }

        private async void OnPickingTimer_Tick(object sender, EventArgs e)
        {
            if (m_isPicking) { return; }
            if (!m_isMouseInside) { return; }

            m_isPicking = true;
            try
            {
                if (m_mousePosition == Point.Empty) { return; }

                // The main picking call
                // (needs the mouse position and the detail level
                List<SceneObject> pickedObjects = await m_ctrlRenderControl.RenderLoop.PickObjectAsync(
                    m_mousePosition,
                    new PickingOptions() { OnlyCheckBoundingBoxes = false });

                if (pickedObjects.Count > 0)
                {
                    m_lblPickedObject.Text = pickedObjects
                        .Select((actObject) => actObject.Tag1)
                        .ToCommaSeparatedString();
                }
                else
                {
                    m_lblPickedObject.Text = "none";
                }
            }
            finally
            {
                m_isPicking = false;
            }
        }

        private void OnCtrlRenderControl_MouseEnter(object sender, EventArgs e)
        {
            m_isMouseInside = true;
        }

        private void OnCtrlRenderControl_MouseLeave(object sender, EventArgs e)
        {
            m_isMouseInside = false;
        }

        private void OnCtrlRenderControl_MouseMove(object sender, MouseEventArgs e)
        {
            m_mousePosition = new Point(e.X, e.Y);
        }
    }
}
