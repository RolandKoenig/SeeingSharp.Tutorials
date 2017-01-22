#region License information (SeeingSharp and all based games/applications)
/*
    All tutorials of Seeing# are provided under the following license.

    The MIT License (MIT)
    Copyright (c) 2016 Roland Koenig

    Permission is hereby granted, free of charge, to any person obtaining a copy 
    of this software and associated documentation files (the "Software"), to deal 
    in the Software without restriction, including without limitation the rights 
    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies 
    of the Software, and to permit persons to whom the Software is furnished to do 
    so, subject to the following conditions:

    The above copyright notice and this permission notice shall be included in all 
    copies or substantial portions of the Software.

    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
    INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
    PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
    HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
    CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
    OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
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

namespace SeeingSharp.Tutorials.Introduction03
{
    public partial class MainWindow : Form
    {
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
                        "SeeingSharp.Tutorials.Introduction03",
                        true,
                        "Assets/Textures/Background.png"));
                manipulator.Add(new FullscreenTextureObject(resBackgroundTexture), bgLayer.Name);

                // Create pallet geometry resource
                PalletType pType = new PalletType();
                pType.ContentColor = Color4.GreenColor;
                var resPalletGeometry = manipulator.AddResource<GeometryResource>(
                    () => new GeometryResource(pType));

                // Create pallet object and add it to the scene
                //  => The DEFAULT layer is used by default
                GenericObject palletObject = manipulator.AddGeneric(resPalletGeometry);
                palletObject.Color = Color4.GreenColor;
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
            });

            // Configure camera
            Camera3DBase camera = m_ctrlRenderControl.Camera;
            camera.Position = new Vector3(2f, 2f, 2f);
            camera.Target = new Vector3(0f, 0.5f, 0f);
            camera.UpdateCamera();
        }
    }
}
