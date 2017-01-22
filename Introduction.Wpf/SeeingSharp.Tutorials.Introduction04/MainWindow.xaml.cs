using SeeingSharp.Multimedia.Drawing3D;
using SeeingSharp.Multimedia.Objects;
using SeeingSharp.Multimedia.Core;
using SeeingSharp.Util;
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
using System.Windows.Threading;

namespace SeeingSharp.Tutorials.Introduction04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Members for picking
        private DispatcherTimer m_pickingTimer;
        private bool m_isPicking;
        private bool m_isMouseInside;
        private Point m_mousePosition;
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            m_pickingTimer = new DispatcherTimer();
            m_pickingTimer.Tick += OnPickingTimer_Tick;
            m_pickingTimer.Interval = TimeSpan.FromMilliseconds(100.0);
            m_pickingTimer.Start();

            this.Loaded += OnMainWindow_Loaded;
            this.MouseEnter += OnMainWindow_MouseEnter;
            this.MouseLeave += OnMainWindow_MouseLeave;
            this.MouseMove += OnMainWindow_MouseMove;
        }

        private async void OnMainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            CtrlRenderPanel.RenderLoop.ClearColor = Color4.CornflowerBlue;

            // Build scene graph
            await CtrlRenderPanel.Scene.ManipulateSceneAsync((manipulator) =>
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
                manipulator.Add(new FullscreenTextureObject(resBackgroundTexture), bgLayer.Name);

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
            Camera3DBase camera = CtrlRenderPanel.Camera;
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
                List<SceneObject> pickedObjects = await CtrlRenderPanel.RenderLoop.PickObjectAsync(
                    m_mousePosition,
                    new PickingOptions() { OnlyCheckBoundingBoxes = false });

                if (pickedObjects.Count > 0)
                {
                    this.TxtPickedObject.Text = pickedObjects
                        .Select((actObject) => actObject.Tag1)
                        .ToCommaSeparatedString();
                }
                else
                {
                    this.TxtPickedObject.Text = "none";
                }
            }
            finally
            {
                m_isPicking = false;
            }
        }

        private void OnMainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            var dpiScaling = CtrlRenderPanel.GetDpiScaling();
            var position = e.GetPosition(this);
            m_mousePosition = new Point(
                (int)(position.X * dpiScaling.ScaleFactorX),
                (int)(position.Y * dpiScaling.ScaleFactorY));
        }

        private void OnMainWindow_MouseLeave(object sender, MouseEventArgs e)
        {
            m_isMouseInside = false;
        }

        private void OnMainWindow_MouseEnter(object sender, MouseEventArgs e)
        {
            m_isMouseInside = true;
        }
    }
}
