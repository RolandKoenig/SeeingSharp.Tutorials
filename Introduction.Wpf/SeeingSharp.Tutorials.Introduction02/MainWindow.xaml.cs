﻿using SeeingSharp.Multimedia.Drawing3D;
using SeeingSharp.Multimedia.Objects;
using SeeingSharp.Multimedia.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SeeingSharp.Tutorials.Introduction02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += OnMainWindow_Loaded;
        }

        private async void OnMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CtrlRenderPanel.RenderLoop.ClearColor = Color4.CornflowerBlue;

            // Build scene graph
            await CtrlRenderPanel.Scene.ManipulateSceneAsync((manipulator) =>
            {
                // Create pallet geometry resource
                PalletType pType = new PalletType();
                pType.ContentColor = Color4.GreenColor;
                var resPalletGeometry = manipulator.AddResource<GeometryResource>(
                    () => new GeometryResource(pType));

                // Create pallet object
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
            Camera3DBase camera = CtrlRenderPanel.Camera;
            camera.Position = new Vector3(2f, 2f, 2f);
            camera.Target = new Vector3(0f, 0.5f, 0f);
            camera.UpdateCamera();
        }
    }
}
