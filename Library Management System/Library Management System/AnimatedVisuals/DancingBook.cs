using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.UI.Composition;
using System;
using System.Collections.Generic;
using System.Numerics;
using Windows.UI;
#pragma warning disable CS0168, CS0219, CS0414, CS8600,CS8597,CS8618,CS8625,CA1822,IDE0029,IDE0060,IDE0059,IDE0052,IDE0018
namespace Library_Management_System.AnimatedVisuals
{
    // Name:        03
    // Frame rate:  30 fps
    // Frame count: 120
    // Duration:    4000.0 mS
    public sealed class DancingBook
        : Microsoft.UI.Xaml.Controls.IAnimatedVisualSource
    {
        // Animation duration: 4.000 seconds.
        internal const long c_durationTicks = 40000000;

        public Microsoft.UI.Xaml.Controls.IAnimatedVisual TryCreateAnimatedVisual(Compositor compositor)
        {
            object ignored = null;
            return TryCreateAnimatedVisual(compositor, out ignored);
        }

        public Microsoft.UI.Xaml.Controls.IAnimatedVisual TryCreateAnimatedVisual(Compositor compositor, out object diagnostics)
        {
            diagnostics = null;

            var res =
                new DancingBook_AnimatedVisual(
                    compositor
                    );
            res.CreateAnimations();
            return res;
        }

        /// <summary>
        /// Gets the number of frames in the animation.
        /// </summary>
        public double FrameCount => 120d;

        /// <summary>
        /// Gets the frame rate of the animation.
        /// </summary>
        public double Framerate => 30d;

        /// <summary>
        /// Gets the duration of the animation.
        /// </summary>
        public TimeSpan Duration => TimeSpan.FromTicks(c_durationTicks);

        /// <summary>
        /// Converts a zero-based frame number to the corresponding progress value denoting the
        /// start of the frame.
        /// </summary>
        public double FrameToProgress(double frameNumber)
        {
            return frameNumber / 120d;
        }

        /// <summary>
        /// Returns a map from marker names to corresponding progress values.
        /// </summary>
        public IReadOnlyDictionary<string, double> Markers =>
            new Dictionary<string, double>
            {
            };

        /// <summary>
        /// Sets the color property with the given name, or does nothing if no such property
        /// exists.
        /// </summary>
        public void SetColorProperty(string propertyName, Color value)
        {
        }

        /// <summary>
        /// Sets the scalar property with the given name, or does nothing if no such property
        /// exists.
        /// </summary>
        public void SetScalarProperty(string propertyName, double value)
        {
        }

        sealed class DancingBook_AnimatedVisual : Microsoft.UI.Xaml.Controls.IAnimatedVisual2
        {
            const long c_durationTicks = 40000000;
            readonly Compositor _c;
            readonly ExpressionAnimation _reusableExpressionAnimation;
            CompositionColorBrush _colorBrush_AlmostBlack_FF211F1F;
            CompositionColorBrush _colorBrush_AlmostDarkCyan_FF139F82;
            CompositionColorBrush _colorBrush_AlmostGainsboro_FFE4E5E6;
            CompositionColorBrush _colorBrush_AlmostTurquoise_FF35EBC6;
            CompositionColorBrush _colorBrush_White;
            CompositionContainerShape _containerShape_0;
            CompositionContainerShape _containerShape_1;
            CompositionContainerShape _containerShape_2;
            CompositionContainerShape _containerShape_3;
            CompositionContainerShape _containerShape_4;
            CompositionContainerShape _containerShape_5;
            CompositionContainerShape _containerShape_6;
            CompositionContainerShape _containerShape_7;
            CompositionPath _path_00;
            CompositionPath _path_01;
            CompositionPath _path_02;
            CompositionPath _path_03;
            CompositionPath _path_04;
            CompositionPath _path_05;
            CompositionPath _path_06;
            CompositionPath _path_07;
            CompositionPath _path_08;
            CompositionPath _path_09;
            CompositionPath _path_10;
            CompositionPath _path_11;
            CompositionPath _path_12;
            CompositionPath _path_13;
            CompositionPath _path_14;
            CompositionPath _path_15;
            CompositionPath _path_16;
            CompositionPath _path_17;
            CompositionPath _path_18;
            CompositionPath _path_19;
            CompositionPath _path_20;
            CompositionPath _path_21;
            CompositionPath _path_22;
            CompositionPath _path_23;
            CompositionPath _path_24;
            CompositionPath _path_25;
            CompositionPath _path_26;
            CompositionPath _path_27;
            CompositionPath _path_28;
            CompositionPath _path_29;
            CompositionPath _path_30;
            CompositionPath _path_31;
            CompositionPathGeometry _pathGeometry_00;
            CompositionPathGeometry _pathGeometry_01;
            CompositionPathGeometry _pathGeometry_02;
            CompositionPathGeometry _pathGeometry_03;
            CompositionPathGeometry _pathGeometry_04;
            CompositionPathGeometry _pathGeometry_05;
            CompositionPathGeometry _pathGeometry_06;
            CompositionPathGeometry _pathGeometry_07;
            CompositionPathGeometry _pathGeometry_08;
            CompositionPathGeometry _pathGeometry_09;
            CompositionPathGeometry _pathGeometry_10;
            CompositionPathGeometry _pathGeometry_11;
            CompositionPathGeometry _pathGeometry_13;
            CompositionPathGeometry _pathGeometry_14;
            CompositionPathGeometry _pathGeometry_15;
            CompositionPathGeometry _pathGeometry_16;
            CompositionPathGeometry _pathGeometry_17;
            CompositionPathGeometry _pathGeometry_18;
            CompositionPathGeometry _pathGeometry_19;
            CompositionPathGeometry _pathGeometry_20;
            ContainerVisual _root;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0;
            CubicBezierEasingFunction _cubicBezierEasingFunction_1;
            CubicBezierEasingFunction _cubicBezierEasingFunction_2;
            ExpressionAnimation _rootProgress;
            ScalarKeyFrameAnimation _rotationAngleInDegreesScalarAnimation_0_to_0;
            StepEasingFunction _holdThenStepEasingFunction;
            Vector2KeyFrameAnimation _offsetVector2Animation_0;
            Vector2KeyFrameAnimation _offsetVector2Animation_1;

            static void StartProgressBoundAnimation(
                CompositionObject target,
                string animatedPropertyName,
                CompositionAnimation animation,
                ExpressionAnimation controllerProgressExpression)
            {
                target.StartAnimation(animatedPropertyName, animation);
                var controller = target.TryGetAnimationController(animatedPropertyName);
                controller.Pause();
                controller.StartAnimation("Progress", controllerProgressExpression);
            }

            PathKeyFrameAnimation CreatePathKeyFrameAnimation(float initialProgress, CompositionPath initialValue, CompositionEasingFunction initialEasingFunction)
            {
                var result = _c.CreatePathKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(c_durationTicks);
                result.InsertKeyFrame(initialProgress, initialValue, initialEasingFunction);
                return result;
            }

            ScalarKeyFrameAnimation CreateScalarKeyFrameAnimation(float initialProgress, float initialValue, CompositionEasingFunction initialEasingFunction)
            {
                var result = _c.CreateScalarKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(c_durationTicks);
                result.InsertKeyFrame(initialProgress, initialValue, initialEasingFunction);
                return result;
            }

            Vector2KeyFrameAnimation CreateVector2KeyFrameAnimation(float initialProgress, Vector2 initialValue, CompositionEasingFunction initialEasingFunction)
            {
                var result = _c.CreateVector2KeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(c_durationTicks);
                result.InsertKeyFrame(initialProgress, initialValue, initialEasingFunction);
                return result;
            }

            CompositionSpriteShape CreateSpriteShape(CompositionGeometry geometry, Matrix3x2 transformMatrix)
            {
                var result = _c.CreateSpriteShape(geometry);
                result.TransformMatrix = transformMatrix;
                return result;
            }

            CompositionSpriteShape CreateSpriteShape(CompositionGeometry geometry, Matrix3x2 transformMatrix, CompositionBrush fillBrush)
            {
                var result = _c.CreateSpriteShape(geometry);
                result.TransformMatrix = transformMatrix;
                result.FillBrush = fillBrush;
                return result;
            }

            CanvasGeometry Geometry_00()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(75.2750015F, -181.115005F));
                    builder.AddCubicBezier(new Vector2(84.8509979F, -142.253998F), new Vector2(44.5079994F, -88.5319977F), new Vector2(-10.2200003F, -128.975998F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - Layer aggregator
            // - - - Transforms: A 4 RotationDegrees:9, Offset:<-84.216, 186.894>
            // - Path
            CanvasGeometry Geometry_01()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(76.862999F, -182.171997F));
                    builder.AddCubicBezier(new Vector2(95.4499969F, -106.370003F), new Vector2(33.5050011F, -72.7220001F), new Vector2(11.0050001F, -160.722F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - Layer aggregator
            // - - - Transforms: A 4 RotationDegrees:9, Offset:<-84.216, 186.894>
            // - Path
            CanvasGeometry Geometry_02()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(77.1210022F, -180.647995F));
                    builder.AddCubicBezier(new Vector2(92.314003F, -135.082993F), new Vector2(69.4140015F, -78.3030014F), new Vector2(-5.78200006F, -88.1679993F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - Layer aggregator
            // - - - Transforms: A 4 RotationDegrees:9, Offset:<-84.216, 186.894>
            // - Path
            CanvasGeometry Geometry_03()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(75.211998F, -181.404007F));
                    builder.AddCubicBezier(new Vector2(98.1490021F, -114.897003F), new Vector2(35.2260017F, -61.8580017F), new Vector2(12.7259998F, -149.858002F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_04()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-139.343994F, -39.1969986F));
                    builder.AddCubicBezier(new Vector2(-141.423004F, -36.8660011F), new Vector2(-142.285995F, -28.2040005F), new Vector2(-142.436996F, -19.7929993F));
                    builder.AddCubicBezier(new Vector2(-142.470993F, -17.8759995F), new Vector2(-141.485001F, -16.1130009F), new Vector2(-139.569F, -16.0440006F));
                    builder.AddCubicBezier(new Vector2(-139.569F, -16.0440006F), new Vector2(86.737999F, -7.90899992F), new Vector2(86.737999F, -7.90899992F));
                    builder.AddCubicBezier(new Vector2(89.9329987F, -7.79400015F), new Vector2(92.4660034F, -10.5769997F), new Vector2(92.0510025F, -13.7480001F));
                    builder.AddCubicBezier(new Vector2(92.0510025F, -13.7480001F), new Vector2(89.4800034F, -46.0009995F), new Vector2(89.4800034F, -46.0009995F));
                    builder.AddCubicBezier(new Vector2(89.348999F, -47.6380005F), new Vector2(87.9420013F, -48.8759995F), new Vector2(86.3010025F, -48.7960014F));
                    builder.AddCubicBezier(new Vector2(86.3010025F, -48.7960014F), new Vector2(-137.231003F, -40.1980019F), new Vector2(-137.231003F, -40.1980019F));
                    builder.AddCubicBezier(new Vector2(-138.048004F, -40.1580009F), new Vector2(-138.798996F, -39.8069992F), new Vector2(-139.343994F, -39.1969986F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_05()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-81.0940018F, -35.6969986F));
                    builder.AddCubicBezier(new Vector2(-83.1729965F, -33.3660011F), new Vector2(-88.3679962F, -26.8880005F), new Vector2(-90.4369965F, -18.2929993F));
                    builder.AddCubicBezier(new Vector2(-90.8850021F, -16.4290009F), new Vector2(-89.4850006F, -14.6129999F), new Vector2(-87.5690002F, -14.5439997F));
                    builder.AddCubicBezier(new Vector2(-87.5690002F, -14.5439997F), new Vector2(138.738007F, -6.40899992F), new Vector2(138.738007F, -6.40899992F));
                    builder.AddCubicBezier(new Vector2(141.932999F, -6.29400015F), new Vector2(144.466003F, -9.07699966F), new Vector2(144.050995F, -12.2480001F));
                    builder.AddCubicBezier(new Vector2(144.050995F, -12.2480001F), new Vector2(141.479996F, -44.5009995F), new Vector2(141.479996F, -44.5009995F));
                    builder.AddCubicBezier(new Vector2(141.348999F, -46.1380005F), new Vector2(139.942001F, -47.3759995F), new Vector2(138.300995F, -47.2960014F));
                    builder.AddCubicBezier(new Vector2(138.300995F, -47.2960014F), new Vector2(-78.9810028F, -36.6980019F), new Vector2(-78.9810028F, -36.6980019F));
                    builder.AddCubicBezier(new Vector2(-79.7979965F, -36.6580009F), new Vector2(-80.5490036F, -36.3069992F), new Vector2(-81.0940018F, -35.6969986F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_06()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-100.371002F, -43.7529984F));
                    builder.AddCubicBezier(new Vector2(-100.371002F, -43.7529984F), new Vector2(-129.843002F, -34.7579994F), new Vector2(-138.929993F, -10.3559999F));
                    builder.AddCubicBezier(new Vector2(-138.929993F, -10.3559999F), new Vector2(77.810997F, -10.3389997F), new Vector2(77.810997F, -10.3389997F));
                    builder.AddCubicBezier(new Vector2(80.2249985F, -10.3380003F), new Vector2(82.2809982F, -12.0959997F), new Vector2(82.6569977F, -14.4799995F));
                    builder.AddCubicBezier(new Vector2(82.6569977F, -14.4799995F), new Vector2(86.6419983F, -39.8040009F), new Vector2(86.6419983F, -39.8040009F));
                    builder.AddCubicBezier(new Vector2(86.6419983F, -39.8040009F), new Vector2(-100.371002F, -43.7529984F), new Vector2(-100.371002F, -43.7529984F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_07()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-46.7910004F, -46.4669991F));
                    builder.AddCubicBezier(new Vector2(-46.7910004F, -46.4669991F), new Vector2(-76.5400009F, -38.4350014F), new Vector2(-86.4150009F, -14.3409996F));
                    builder.AddCubicBezier(new Vector2(-86.4150009F, -14.3409996F), new Vector2(130.210999F, -7.28100014F), new Vector2(130.210999F, -7.28100014F));
                    builder.AddCubicBezier(new Vector2(132.623993F, -7.20200014F), new Vector2(134.735992F, -8.8920002F), new Vector2(135.188995F, -11.2629995F));
                    builder.AddCubicBezier(new Vector2(135.188995F, -11.2629995F), new Vector2(139.994995F, -36.4440002F), new Vector2(139.994995F, -36.4440002F));
                    builder.AddCubicBezier(new Vector2(139.994995F, -36.4440002F), new Vector2(-46.7910004F, -46.4669991F), new Vector2(-46.7910004F, -46.4669991F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_08()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-130.927994F, -9.95800018F));
                    builder.AddCubicBezier(new Vector2(-116.005997F, -9.38099957F), new Vector2(-101.082001F, -9.02900028F), new Vector2(-86.1589966F, -8.70100021F));
                    builder.AddCubicBezier(new Vector2(-71.2350006F, -8.37300014F), new Vector2(-56.3110008F, -8.22299957F), new Vector2(-41.3860016F, -7.97599983F));
                    builder.AddCubicBezier(new Vector2(-26.4619999F, -7.89099979F), new Vector2(-11.5369997F, -7.71999979F), new Vector2(3.38800001F, -7.71600008F));
                    builder.AddCubicBezier(new Vector2(3.38800001F, -7.71600008F), new Vector2(25.7759991F, -7.75F), new Vector2(25.7759991F, -7.75F));
                    builder.AddCubicBezier(new Vector2(33.2389984F, -7.83400011F), new Vector2(40.7019997F, -7.85099983F), new Vector2(48.1650009F, -7.99599981F));
                    builder.AddCubicBezier(new Vector2(40.7050018F, -8.30500031F), new Vector2(33.243F, -8.4829998F), new Vector2(25.7800007F, -8.73099995F));
                    builder.AddCubicBezier(new Vector2(25.7800007F, -8.73099995F), new Vector2(3.39599991F, -9.25599957F), new Vector2(3.39599991F, -9.25599957F));
                    builder.AddCubicBezier(new Vector2(-11.5279999F, -9.57900047F), new Vector2(-26.4529991F, -9.73499966F), new Vector2(-41.3769989F, -9.97700024F));
                    builder.AddCubicBezier(new Vector2(-56.3009987F, -10.0570002F), new Vector2(-71.2249985F, -10.2309999F), new Vector2(-86.151001F, -10.2340002F));
                    builder.AddCubicBezier(new Vector2(-101.077003F, -10.2370005F), new Vector2(-116.001999F, -10.2069998F), new Vector2(-130.927994F, -9.95800018F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_09()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-62.644001F, -31.7029991F));
                    builder.AddCubicBezier(new Vector2(-47.7039986F, -31.5270004F), new Vector2(-32.7820015F, -31.0130005F), new Vector2(-17.8630009F, -30.448F));
                    builder.AddCubicBezier(new Vector2(-2.94300008F, -29.8899994F), new Vector2(11.9610004F, -29.0559998F), new Vector2(26.875F, -28.3729992F));
                    builder.AddCubicBezier(new Vector2(41.7729988F, -27.441F), new Vector2(56.6800003F, -26.6420002F), new Vector2(71.5719986F, -25.5849991F));
                    builder.AddCubicBezier(new Vector2(71.5719986F, -25.5849991F), new Vector2(93.9079971F, -23.9379997F), new Vector2(93.9079971F, -23.9379997F));
                    builder.AddCubicBezier(new Vector2(101.347F, -23.2770004F), new Vector2(108.791F, -22.7210007F), new Vector2(116.224998F, -21.9659996F));
                    builder.AddCubicBezier(new Vector2(108.753998F, -22.0230007F), new Vector2(101.292999F, -22.2789993F), new Vector2(93.8249969F, -22.4290009F));
                    builder.AddCubicBezier(new Vector2(93.8249969F, -22.4290009F), new Vector2(71.4440002F, -23.2159996F), new Vector2(71.4440002F, -23.2159996F));
                    builder.AddCubicBezier(new Vector2(56.5250015F, -23.7819996F), new Vector2(41.6189995F, -24.6060009F), new Vector2(26.7070007F, -25.2970009F));
                    builder.AddCubicBezier(new Vector2(11.809F, -26.2369995F), new Vector2(-3.09800005F, -27.0249996F), new Vector2(-17.9899998F, -28.0900002F));
                    builder.AddCubicBezier(new Vector2(-32.8829994F, -29.1480007F), new Vector2(-47.7729988F, -30.257F), new Vector2(-62.644001F, -31.7029991F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_10()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-107.915001F, -25.0440006F));
                    builder.AddCubicBezier(new Vector2(-93.012001F, -24.25F), new Vector2(-78.0999985F, -23.6800003F), new Vector2(-63.1870003F, -23.1340008F));
                    builder.AddCubicBezier(new Vector2(-48.2729988F, -22.5879993F), new Vector2(-33.3530006F, -22.2220001F), new Vector2(-18.4360008F, -21.757F));
                    builder.AddCubicBezier(new Vector2(-3.51399994F, -21.4540005F), new Vector2(11.4049997F, -21.0650005F), new Vector2(26.3309994F, -20.8430004F));
                    builder.AddCubicBezier(new Vector2(26.3309994F, -20.8430004F), new Vector2(48.7210007F, -20.5499992F), new Vector2(48.7210007F, -20.5499992F));
                    builder.AddCubicBezier(new Vector2(56.1879997F, -20.5249996F), new Vector2(63.6520004F, -20.4330006F), new Vector2(71.1210022F, -20.4689999F));
                    builder.AddCubicBezier(new Vector2(63.6699982F, -20.8869991F), new Vector2(56.2140007F, -21.1739998F), new Vector2(48.7599983F, -21.5310001F));
                    builder.AddCubicBezier(new Vector2(48.7599983F, -21.5310001F), new Vector2(26.3920002F, -22.382F), new Vector2(26.3920002F, -22.382F));
                    builder.AddCubicBezier(new Vector2(11.4779997F, -22.9230003F), new Vector2(-3.44199991F, -23.2970009F), new Vector2(-18.3589993F, -23.7560005F));
                    builder.AddCubicBezier(new Vector2(-33.2809982F, -24.0540009F), new Vector2(-48.2000008F, -24.4459991F), new Vector2(-63.1269989F, -24.6669998F));
                    builder.AddCubicBezier(new Vector2(-78.0530014F, -24.8880005F), new Vector2(-92.9789963F, -25.0750008F), new Vector2(-107.915001F, -25.0440006F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_11()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-62.730999F, -29.6690006F));
                    builder.AddCubicBezier(new Vector2(-47.7910004F, -29.8279991F), new Vector2(-32.8610001F, -29.6499996F), new Vector2(-17.9330006F, -29.4200001F));
                    builder.AddCubicBezier(new Vector2(-3.00399995F, -29.198F), new Vector2(11.915F, -28.698F), new Vector2(26.8400002F, -28.3500004F));
                    builder.AddCubicBezier(new Vector2(41.7560005F, -27.7530003F), new Vector2(56.6769981F, -27.2889996F), new Vector2(71.5889969F, -26.5680008F));
                    builder.AddCubicBezier(new Vector2(71.5889969F, -26.5680008F), new Vector2(93.9550018F, -25.4230003F), new Vector2(93.9550018F, -25.4230003F));
                    builder.AddCubicBezier(new Vector2(101.407997F, -24.9290009F), new Vector2(108.862999F, -24.5410004F), new Vector2(116.311996F, -23.9529991F));
                    builder.AddCubicBezier(new Vector2(108.841003F, -23.8409996F), new Vector2(101.375999F, -23.9300003F), new Vector2(93.9069977F, -23.9120007F));
                    builder.AddCubicBezier(new Vector2(93.9069977F, -23.9120007F), new Vector2(71.5139999F, -24.1970005F), new Vector2(71.5139999F, -24.1970005F));
                    builder.AddCubicBezier(new Vector2(56.5849991F, -24.427F), new Vector2(41.6650009F, -24.9160004F), new Vector2(26.7409992F, -25.2719994F));
                    builder.AddCubicBezier(new Vector2(11.8260002F, -25.8770008F), new Vector2(-3.09500003F, -26.3299999F), new Vector2(-18.0079994F, -27.0599995F));
                    builder.AddCubicBezier(new Vector2(-32.9199982F, -27.7830009F), new Vector2(-47.8310013F, -28.5569992F), new Vector2(-62.730999F, -29.6690006F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_12()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-89.5189972F, -36.3260002F));
                    builder.AddCubicBezier(new Vector2(-74.6060028F, -35.6290016F), new Vector2(-59.6860008F, -35.1559982F), new Vector2(-44.7680016F, -34.7060013F));
                    builder.AddCubicBezier(new Vector2(-29.8500004F, -34.2560005F), new Vector2(-14.927F, -33.987999F), new Vector2(-0.00600000005F, -33.6189995F));
                    builder.AddCubicBezier(new Vector2(14.9180002F, -33.4129982F), new Vector2(29.8409996F, -33.1199989F), new Vector2(44.7669983F, -32.9949989F));
                    builder.AddCubicBezier(new Vector2(44.7669983F, -32.9949989F), new Vector2(67.1579971F, -32.8470001F), new Vector2(67.1579971F, -32.8470001F));
                    builder.AddCubicBezier(new Vector2(74.6240005F, -32.8709984F), new Vector2(82.086998F, -32.8269997F), new Vector2(89.5540009F, -32.9119987F));
                    builder.AddCubicBezier(new Vector2(82.0979996F, -33.2809982F), new Vector2(74.6389999F, -33.5209999F), new Vector2(67.1819992F, -33.8289986F));
                    builder.AddCubicBezier(new Vector2(67.1819992F, -33.8289986F), new Vector2(44.8040009F, -34.5349998F), new Vector2(44.8040009F, -34.5349998F));
                    builder.AddCubicBezier(new Vector2(29.8850002F, -34.9790001F), new Vector2(14.9630003F, -35.2560005F), new Vector2(0.0419999994F, -35.6189995F));
                    builder.AddCubicBezier(new Vector2(-14.882F, -35.8199997F), new Vector2(-29.8050003F, -36.1150017F), new Vector2(-44.7319984F, -36.2389984F));
                    builder.AddCubicBezier(new Vector2(-59.6590004F, -36.362999F), new Vector2(-74.586998F, -36.4550018F), new Vector2(-89.5189972F, -36.3260002F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_13()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-62.6980019F, -30.5990009F));
                    builder.AddCubicBezier(new Vector2(-47.757F, -30.6089993F), new Vector2(-32.8289986F, -30.2819996F), new Vector2(-17.9039993F, -29.9029999F));
                    builder.AddCubicBezier(new Vector2(-2.97900009F, -29.5319996F), new Vector2(11.9350004F, -28.8829994F), new Vector2(26.8549995F, -28.3869991F));
                    builder.AddCubicBezier(new Vector2(41.7639999F, -27.6410007F), new Vector2(56.6800003F, -27.0279999F), new Vector2(71.5839996F, -26.1569996F));
                    builder.AddCubicBezier(new Vector2(71.5839996F, -26.1569996F), new Vector2(93.9380035F, -24.7900009F), new Vector2(93.9380035F, -24.7900009F));
                    builder.AddCubicBezier(new Vector2(101.385002F, -24.2210007F), new Vector2(108.835999F, -23.7579994F), new Vector2(116.278999F, -23.0960007F));
                    builder.AddCubicBezier(new Vector2(108.806999F, -23.0599995F), new Vector2(101.343002F, -23.2220001F), new Vector2(93.875F, -23.2789993F));
                    builder.AddCubicBezier(new Vector2(93.875F, -23.2789993F), new Vector2(71.4850006F, -23.7870007F), new Vector2(71.4850006F, -23.7870007F));
                    builder.AddCubicBezier(new Vector2(56.5600014F, -24.1669998F), new Vector2(41.6459999F, -24.8040009F), new Vector2(26.7259998F, -25.309F));
                    builder.AddCubicBezier(new Vector2(11.8170004F, -26.0629997F), new Vector2(-3.09899998F, -26.6650009F), new Vector2(-18.0030003F, -27.5440006F));
                    builder.AddCubicBezier(new Vector2(-32.9080009F, -28.4160004F), new Vector2(-47.8100014F, -29.3379993F), new Vector2(-62.6980019F, -30.5990009F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_14()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-117.226997F, 8.54199982F));
                    builder.AddCubicBezier(new Vector2(-117.675003F, 10.4060001F), new Vector2(-116.275002F, 12.2220001F), new Vector2(-114.359001F, 12.2910004F));
                    builder.AddCubicBezier(new Vector2(-114.359001F, 12.2910004F), new Vector2(111.947998F, 20.4260006F), new Vector2(111.947998F, 20.4260006F));
                    builder.AddCubicBezier(new Vector2(115.142998F, 20.5410004F), new Vector2(117.676003F, 17.7579994F), new Vector2(117.261002F, 14.5869999F));
                    builder.AddCubicBezier(new Vector2(117.261002F, 14.5869999F), new Vector2(114.690002F, -17.6660004F), new Vector2(114.690002F, -17.6660004F));
                    builder.AddCubicBezier(new Vector2(114.558998F, -19.3029995F), new Vector2(113.152F, -20.5410004F), new Vector2(111.511002F, -20.4610004F));
                    builder.AddCubicBezier(new Vector2(111.511002F, -20.4610004F), new Vector2(-36.5359993F, -28.5139999F), new Vector2(-75.7089996F, -29.1760006F));
                    builder.AddCubicBezier(new Vector2(-114.882004F, -29.8379993F), new Vector2(-115.157997F, -0.0529999994F), new Vector2(-117.226997F, 8.54199982F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_15()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-114.514F, 16.9790001F));
                    builder.AddCubicBezier(new Vector2(-114.514F, 16.9790001F), new Vector2(-114.771004F, 15.9619999F), new Vector2(-114.771004F, 15.9619999F));
                    builder.AddCubicBezier(new Vector2(-114.771004F, 15.9619999F), new Vector2(112.536003F, 24.1130009F), new Vector2(112.536003F, 24.1130009F));
                    builder.AddCubicBezier(new Vector2(112.536003F, 24.1130009F), new Vector2(123.098999F, 25.5240002F), new Vector2(123.098999F, 25.5240002F));
                    builder.AddCubicBezier(new Vector2(123.098999F, 25.5240002F), new Vector2(130.328995F, 27.8400002F), new Vector2(130.778F, 30.5209999F));
                    builder.AddCubicBezier(new Vector2(131.259995F, 33.4000015F), new Vector2(127.512001F, 36.5379982F), new Vector2(124.598999F, 36.7260017F));
                    builder.AddCubicBezier(new Vector2(66.2129974F, 40.4860001F), new Vector2(-71.0579987F, 47.137001F), new Vector2(-71.0579987F, 47.137001F));
                    builder.AddCubicBezier(new Vector2(-71.0579987F, 47.137001F), new Vector2(-114.514F, 16.9790001F), new Vector2(-114.514F, 16.9790001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_16()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-73.5810013F, -19.6329994F));
                    builder.AddCubicBezier(new Vector2(-73.5810013F, -19.6329994F), new Vector2(-103.330002F, -11.6009998F), new Vector2(-113.205002F, 12.493F));
                    builder.AddCubicBezier(new Vector2(-113.205002F, 12.493F), new Vector2(103.420998F, 19.5529995F), new Vector2(103.420998F, 19.5529995F));
                    builder.AddCubicBezier(new Vector2(105.834F, 19.632F), new Vector2(107.945999F, 17.9430008F), new Vector2(108.399002F, 15.5719995F));
                    builder.AddCubicBezier(new Vector2(108.399002F, 15.5719995F), new Vector2(113.205002F, -9.60900021F), new Vector2(113.205002F, -9.60900021F));
                    builder.AddCubicBezier(new Vector2(113.205002F, -9.60900021F), new Vector2(-73.5810013F, -19.6329994F), new Vector2(-73.5810013F, -19.6329994F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_17()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-71.2139969F, 51.4920006F));
                    builder.AddCubicBezier(new Vector2(-71.2139969F, 51.4920006F), new Vector2(-96.8850021F, 47.5610008F), new Vector2(-110.486F, 30.868F));
                    builder.AddCubicBezier(new Vector2(-110.486F, 30.868F), new Vector2(108.288002F, 33.1780014F), new Vector2(108.288002F, 33.1780014F));
                    builder.AddCubicBezier(new Vector2(110.700996F, 33.257F), new Vector2(114.114998F, 33.0620003F), new Vector2(114.765999F, 33.1969986F));
                    builder.AddCubicBezier(new Vector2(114.765999F, 33.1969986F), new Vector2(121.334F, 43.7659988F), new Vector2(121.334F, 43.7659988F));
                    builder.AddCubicBezier(new Vector2(121.334F, 43.7659988F), new Vector2(-71.2139969F, 51.4920006F), new Vector2(-71.2139969F, 51.4920006F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_18()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-89.4339981F, -4.86899996F));
                    builder.AddCubicBezier(new Vector2(-74.4940033F, -4.69299984F), new Vector2(-59.5730019F, -4.1789999F), new Vector2(-44.6539993F, -3.61400008F));
                    builder.AddCubicBezier(new Vector2(-29.7339993F, -3.05599999F), new Vector2(-14.8290005F, -2.22199988F), new Vector2(0.0850000009F, -1.53900003F));
                    builder.AddCubicBezier(new Vector2(14.9829998F, -0.606999993F), new Vector2(29.8899994F, 0.192000002F), new Vector2(44.7820015F, 1.24899995F));
                    builder.AddCubicBezier(new Vector2(44.7820015F, 1.24899995F), new Vector2(67.1179962F, 2.89599991F), new Vector2(67.1179962F, 2.89599991F));
                    builder.AddCubicBezier(new Vector2(74.5569992F, 3.55699992F), new Vector2(82F, 4.11299992F), new Vector2(89.4339981F, 4.86800003F));
                    builder.AddCubicBezier(new Vector2(81.9629974F, 4.81099987F), new Vector2(74.5029984F, 4.55499983F), new Vector2(67.0350037F, 4.40500021F));
                    builder.AddCubicBezier(new Vector2(67.0350037F, 4.40500021F), new Vector2(44.6529999F, 3.61800003F), new Vector2(44.6529999F, 3.61800003F));
                    builder.AddCubicBezier(new Vector2(29.7339993F, 3.05200005F), new Vector2(14.8280001F, 2.22799993F), new Vector2(-0.0839999989F, 1.53699994F));
                    builder.AddCubicBezier(new Vector2(-14.9820004F, 0.597000003F), new Vector2(-29.8880005F, -0.191F), new Vector2(-44.7799988F, -1.25600004F));
                    builder.AddCubicBezier(new Vector2(-59.6730003F, -2.31399989F), new Vector2(-74.5630035F, -3.4230001F), new Vector2(-89.4339981F, -4.86899996F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_19()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-79.1800003F, 55.2249985F));
                    builder.AddCubicBezier(new Vector2(-64.2399979F, 55.1100006F), new Vector2(-49.3180008F, 54.7680016F), new Vector2(-34.3989983F, 54.4020004F));
                    builder.AddCubicBezier(new Vector2(-19.4790001F, 54.0359993F), new Vector2(-4.57499981F, 53.4900017F), new Vector2(10.3389997F, 53.0419998F));
                    builder.AddCubicBezier(new Vector2(25.2369995F, 52.4309998F), new Vector2(40.144001F, 51.9070015F), new Vector2(55.0359993F, 51.2140007F));
                    builder.AddCubicBezier(new Vector2(55.0359993F, 51.2140007F), new Vector2(77.3720016F, 50.1339989F), new Vector2(77.3720016F, 50.1339989F));
                    builder.AddCubicBezier(new Vector2(84.810997F, 49.7010002F), new Vector2(92.2549973F, 49.3359985F), new Vector2(99.689003F, 48.8409996F));
                    builder.AddCubicBezier(new Vector2(92.2180023F, 48.8779984F), new Vector2(84.7570038F, 49.0470009F), new Vector2(77.2890015F, 49.1450005F));
                    builder.AddCubicBezier(new Vector2(77.2890015F, 49.1450005F), new Vector2(54.9080009F, 49.6609993F), new Vector2(54.9080009F, 49.6609993F));
                    builder.AddCubicBezier(new Vector2(39.9889984F, 50.0320015F), new Vector2(25.0830002F, 50.5719986F), new Vector2(10.1709995F, 51.0250015F));
                    builder.AddCubicBezier(new Vector2(-4.72700024F, 51.6409988F), new Vector2(-19.6329994F, 52.1619987F), new Vector2(-34.526001F, 52.855999F));
                    builder.AddCubicBezier(new Vector2(-49.4189987F, 53.5499992F), new Vector2(-64.3089981F, 54.2770004F), new Vector2(-79.1800003F, 55.2249985F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_20()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-89.5210037F, -2.83500004F));
                    builder.AddCubicBezier(new Vector2(-74.5810013F, -2.99399996F), new Vector2(-59.6520004F, -2.81500006F), new Vector2(-44.723999F, -2.58500004F));
                    builder.AddCubicBezier(new Vector2(-29.7950001F, -2.36299992F), new Vector2(-14.8760004F, -1.86399996F), new Vector2(0.0489999987F, -1.51600003F));
                    builder.AddCubicBezier(new Vector2(14.9650002F, -0.91900003F), new Vector2(29.8869991F, -0.453999996F), new Vector2(44.7989998F, 0.26699999F));
                    builder.AddCubicBezier(new Vector2(44.7989998F, 0.26699999F), new Vector2(67.1640015F, 1.41100001F), new Vector2(67.1640015F, 1.41100001F));
                    builder.AddCubicBezier(new Vector2(74.6169968F, 1.90499997F), new Vector2(82.0719986F, 2.29399991F), new Vector2(89.5210037F, 2.88199997F));
                    builder.AddCubicBezier(new Vector2(82.0500031F, 2.99399996F), new Vector2(74.5859985F, 2.90499997F), new Vector2(67.1169968F, 2.9230001F));
                    builder.AddCubicBezier(new Vector2(67.1169968F, 2.9230001F), new Vector2(44.723999F, 2.63800001F), new Vector2(44.723999F, 2.63800001F));
                    builder.AddCubicBezier(new Vector2(29.7950001F, 2.40799999F), new Vector2(14.875F, 1.91900003F), new Vector2(-0.0489999987F, 1.56299996F));
                    builder.AddCubicBezier(new Vector2(-14.9639997F, 0.958000004F), new Vector2(-29.8859997F, 0.504999995F), new Vector2(-44.7989998F, -0.224999994F));
                    builder.AddCubicBezier(new Vector2(-59.7109985F, -0.948000014F), new Vector2(-74.6210022F, -1.72300005F), new Vector2(-89.5210037F, -2.83500004F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_21()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-79.2669983F, 40.5979996F));
                    builder.AddCubicBezier(new Vector2(-64.3270035F, 40.7019997F), new Vector2(-49.3969994F, 40.5810013F), new Vector2(-34.4690018F, 40.4350014F));
                    builder.AddCubicBezier(new Vector2(-19.5400009F, 40.2890015F), new Vector2(-4.62099981F, 39.9609985F), new Vector2(10.3039999F, 39.7330017F));
                    builder.AddCubicBezier(new Vector2(25.2199993F, 39.3419991F), new Vector2(40.1409988F, 39.0379982F), new Vector2(55.0530014F, 38.5649986F));
                    builder.AddCubicBezier(new Vector2(55.0530014F, 38.5649986F), new Vector2(77.4189987F, 37.8139992F), new Vector2(77.4189987F, 37.8139992F));
                    builder.AddCubicBezier(new Vector2(84.8720016F, 37.4900017F), new Vector2(92.3270035F, 37.2360001F), new Vector2(99.776001F, 36.8510017F));
                    builder.AddCubicBezier(new Vector2(92.3050003F, 36.7779999F), new Vector2(84.8399963F, 36.8359985F), new Vector2(77.3710022F, 36.8240013F));
                    builder.AddCubicBezier(new Vector2(77.3710022F, 36.8240013F), new Vector2(54.9780006F, 37.0099983F), new Vector2(54.9780006F, 37.0099983F));
                    builder.AddCubicBezier(new Vector2(40.0489998F, 37.1609993F), new Vector2(25.1289997F, 37.4819984F), new Vector2(10.2049999F, 37.7150002F));
                    builder.AddCubicBezier(new Vector2(-4.71000004F, 38.1119995F), new Vector2(-19.6310005F, 38.4140015F), new Vector2(-34.5439987F, 38.8880005F));
                    builder.AddCubicBezier(new Vector2(-49.4560013F, 39.3619995F), new Vector2(-64.3669968F, 39.8689995F), new Vector2(-79.2669983F, 40.5979996F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_22()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-89.487999F, -3.76399994F));
                    builder.AddCubicBezier(new Vector2(-74.5469971F, -3.77399993F), new Vector2(-59.6199989F, -3.44700003F), new Vector2(-44.6949997F, -3.06800008F));
                    builder.AddCubicBezier(new Vector2(-29.7700005F, -2.69700003F), new Vector2(-14.8559999F, -2.0480001F), new Vector2(0.064000003F, -1.55200005F));
                    builder.AddCubicBezier(new Vector2(14.9729996F, -0.805999994F), new Vector2(29.8889999F, -0.193000004F), new Vector2(44.7929993F, 0.677999973F));
                    builder.AddCubicBezier(new Vector2(44.7929993F, 0.677999973F), new Vector2(67.1470032F, 2.04500008F), new Vector2(67.1470032F, 2.04500008F));
                    builder.AddCubicBezier(new Vector2(74.5940018F, 2.61400008F), new Vector2(82.0449982F, 3.0769999F), new Vector2(89.487999F, 3.73900008F));
                    builder.AddCubicBezier(new Vector2(82.0159988F, 3.7750001F), new Vector2(74.5530014F, 3.61299992F), new Vector2(67.0849991F, 3.55599999F));
                    builder.AddCubicBezier(new Vector2(67.0849991F, 3.55599999F), new Vector2(44.6940002F, 3.0480001F), new Vector2(44.6940002F, 3.0480001F));
                    builder.AddCubicBezier(new Vector2(29.7689991F, 2.66799998F), new Vector2(14.8549995F, 2.0309999F), new Vector2(-0.0649999976F, 1.52600002F));
                    builder.AddCubicBezier(new Vector2(-14.974F, 0.772000015F), new Vector2(-29.8899994F, 0.170000002F), new Vector2(-44.7939987F, -0.708999991F));
                    builder.AddCubicBezier(new Vector2(-59.6990013F, -1.58099997F), new Vector2(-74.5999985F, -2.50300002F), new Vector2(-89.487999F, -3.76399994F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_23()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-79.2340012F, 29.6690006F));
                    builder.AddCubicBezier(new Vector2(-64.2929993F, 29.6760006F), new Vector2(-49.3650017F, 29.4549999F), new Vector2(-34.4399986F, 29.2119999F));
                    builder.AddCubicBezier(new Vector2(-19.5149994F, 28.9689999F), new Vector2(-4.60099983F, 28.5440006F), new Vector2(10.3190002F, 28.2189999F));
                    builder.AddCubicBezier(new Vector2(25.2280006F, 27.7299995F), new Vector2(40.144001F, 27.3279991F), new Vector2(55.0480003F, 26.757F));
                    builder.AddCubicBezier(new Vector2(55.0480003F, 26.757F), new Vector2(77.4020004F, 25.8600006F), new Vector2(77.4020004F, 25.8600006F));
                    builder.AddCubicBezier(new Vector2(84.848999F, 25.4869995F), new Vector2(92.3000031F, 25.184F), new Vector2(99.7429962F, 24.75F));
                    builder.AddCubicBezier(new Vector2(92.2710037F, 24.7259998F), new Vector2(84.8069992F, 24.8330002F), new Vector2(77.3389969F, 24.8700008F));
                    builder.AddCubicBezier(new Vector2(77.3389969F, 24.8700008F), new Vector2(54.9490013F, 25.2029991F), new Vector2(54.9490013F, 25.2029991F));
                    builder.AddCubicBezier(new Vector2(40.0239983F, 25.4519997F), new Vector2(25.1100006F, 25.8700008F), new Vector2(10.1899996F, 26.2010002F));
                    builder.AddCubicBezier(new Vector2(-4.71899986F, 26.6949997F), new Vector2(-19.6340008F, 27.0939999F), new Vector2(-34.5390015F, 27.6660004F));
                    builder.AddCubicBezier(new Vector2(-49.4440002F, 28.2380009F), new Vector2(-64.3460007F, 28.8419991F), new Vector2(-79.2340012F, 29.6690006F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_24()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-34.1819992F, -105.872002F));
                    builder.AddCubicBezier(new Vector2(-34.1819992F, -105.872002F), new Vector2(-24.9309998F, -142.880997F), new Vector2(9.50899982F, -143.910004F));
                    builder.AddCubicBezier(new Vector2(9.50899982F, -143.910004F), new Vector2(34.1819992F, 105.389999F), new Vector2(34.1819992F, 105.389999F));
                    builder.AddCubicBezier(new Vector2(34.1819992F, 105.389999F), new Vector2(-0.418000013F, 116.153F), new Vector2(-7.36100006F, 143.910004F));
                    builder.AddCubicBezier(new Vector2(-7.36100006F, 143.910004F), new Vector2(-34.1819992F, -105.872002F), new Vector2(-34.1819992F, -105.872002F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_25()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(19.5680008F, -108.622002F));
                    builder.AddCubicBezier(new Vector2(19.5680008F, -108.622002F), new Vector2(18.6280003F, -81.4150009F), new Vector2(60.4469986F, -68.5350037F));
                    builder.AddCubicBezier(new Vector2(60.4469986F, -68.5350037F), new Vector2(36.3699989F, 181.514999F), new Vector2(36.3699989F, 181.514999F));
                    builder.AddCubicBezier(new Vector2(36.3699989F, 181.514999F), new Vector2(3.12800002F, 182.085007F), new Vector2(-7.36100006F, 143.910004F));
                    builder.AddCubicBezier(new Vector2(-7.36100006F, 143.910004F), new Vector2(19.5680008F, -108.622002F), new Vector2(19.5680008F, -108.622002F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - Layer aggregator
            // - - ShapeGroup: Group 1 Offset:<19.865, 19.865>
            CanvasGeometry Geometry_26()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-15.9350004F, 6.66200018F));
                    builder.AddCubicBezier(new Vector2(-12.2550001F, 15.4630003F), new Vector2(-2.13800001F, 19.6149998F), new Vector2(6.66300011F, 15.9350004F));
                    builder.AddCubicBezier(new Vector2(15.4630003F, 12.2559996F), new Vector2(19.6149998F, 2.13800001F), new Vector2(15.9350004F, -6.66200018F));
                    builder.AddCubicBezier(new Vector2(12.2550001F, -15.4630003F), new Vector2(2.13800001F, -19.6140003F), new Vector2(-6.66300011F, -15.9350004F));
                    builder.AddCubicBezier(new Vector2(-15.4630003F, -12.2550001F), new Vector2(-19.6149998F, -2.13899994F), new Vector2(-15.9350004F, 6.66200018F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_27()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(19.198F, 0F));
                    builder.AddCubicBezier(new Vector2(19.198F, 4.03399992F), new Vector2(10.6029997F, 7.3039999F), new Vector2(0F, 7.3039999F));
                    builder.AddCubicBezier(new Vector2(-10.6020002F, 7.3039999F), new Vector2(-19.198F, 4.03399992F), new Vector2(-19.198F, 0F));
                    builder.AddCubicBezier(new Vector2(-19.198F, -4.03399992F), new Vector2(-10.6020002F, -7.3039999F), new Vector2(0F, -7.3039999F));
                    builder.AddCubicBezier(new Vector2(10.6029997F, -7.3039999F), new Vector2(19.198F, -4.03399992F), new Vector2(19.198F, 0F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_28()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(-42F, 57.5F));
                    builder.AddCubicBezier(new Vector2(-42F, 57.5F), new Vector2(24F, 119.5F), new Vector2(-37F, 201.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - Layer aggregator
            // - - -  Offset:<317, 309.5>
            // - Path
            CanvasGeometry Geometry_29()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(-10.5F, 81.5F));
                    builder.AddCubicBezier(new Vector2(-10.5F, 81.5F), new Vector2(54F, 156.5F), new Vector2(-37F, 201.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - Layer aggregator
            // - - -  Offset:<317, 309.5>
            // - Path
            CanvasGeometry Geometry_30()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(-31F, 36F));
                    builder.AddCubicBezier(new Vector2(-31F, 36F), new Vector2(8F, 121.5F), new Vector2(-37F, 201.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - Layer aggregator
            // - - -  Offset:<317, 309.5>
            // - Path
            CanvasGeometry Geometry_31()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(-14.6780005F, 75.6429977F));
                    builder.AddCubicBezier(new Vector2(-14.6780005F, 75.6429977F), new Vector2(56F, 158F), new Vector2(-37F, 201.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_32()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(-18F, 64F));
                    builder.AddCubicBezier(new Vector2(-18F, 64F), new Vector2(39F, 138F), new Vector2(-37F, 201.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - Layer aggregator
            // - - -  Offset:<415, 309.5>
            // - Path
            CanvasGeometry Geometry_33()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(7.5F, 71.5F));
                    builder.AddCubicBezier(new Vector2(7.5F, 71.5F), new Vector2(47F, 152.5F), new Vector2(-37F, 201.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - Layer aggregator
            // - - -  Offset:<415, 309.5>
            // - Path
            CanvasGeometry Geometry_34()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(-9F, 61F));
                    builder.AddCubicBezier(new Vector2(-9F, 61F), new Vector2(42F, 136.5F), new Vector2(-37F, 201.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - Layer aggregator
            // - - -  Offset:<415, 309.5>
            // - Path
            CanvasGeometry Geometry_35()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(4.32200003F, 65.1429977F));
                    builder.AddCubicBezier(new Vector2(4.32200003F, 65.1429977F), new Vector2(48.5F, 147F), new Vector2(-37F, 201.5F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_36()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-111.588997F, -129.677994F));
                    builder.AddCubicBezier(new Vector2(-111.588997F, -129.677994F), new Vector2(-86.9160004F, 119.623001F), new Vector2(-86.9160004F, 119.623001F));
                    builder.AddCubicBezier(new Vector2(-86.9160004F, 119.623001F), new Vector2(98.4400024F, 129.298004F), new Vector2(98.4400024F, 129.298004F));
                    builder.AddCubicBezier(new Vector2(105.728996F, 129.677994F), new Vector2(111.588997F, 123.374001F), new Vector2(110.678001F, 116.132004F));
                    builder.AddCubicBezier(new Vector2(110.678001F, 116.132004F), new Vector2(82.3850021F, -108.703003F), new Vector2(82.3850021F, -108.703003F));
                    builder.AddCubicBezier(new Vector2(81.6800003F, -114.305F), new Vector2(77.0800018F, -118.608002F), new Vector2(71.4440002F, -118.939003F));
                    builder.AddCubicBezier(new Vector2(71.4440002F, -118.939003F), new Vector2(-111.588997F, -129.677994F), new Vector2(-111.588997F, -129.677994F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_37()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-60.7140007F, -54.0530014F));
                    builder.AddCubicBezier(new Vector2(-60.7140007F, -54.0530014F), new Vector2(-85.0410004F, 195.998001F), new Vector2(-85.0410004F, 195.998001F));
                    builder.AddCubicBezier(new Vector2(-85.0410004F, 195.998001F), new Vector2(109.315002F, 185.423004F), new Vector2(109.315002F, 185.423004F));
                    builder.AddCubicBezier(new Vector2(116.603996F, 185.802994F), new Vector2(122.463997F, 179.498993F), new Vector2(121.553001F, 172.257004F));
                    builder.AddCubicBezier(new Vector2(121.553001F, 172.257004F), new Vector2(142.259995F, -53.3279991F), new Vector2(142.259995F, -53.3279991F));
                    builder.AddCubicBezier(new Vector2(141.554993F, -58.9300003F), new Vector2(136.955002F, -63.2330017F), new Vector2(131.319F, -63.5639992F));
                    builder.AddCubicBezier(new Vector2(131.319F, -63.5639992F), new Vector2(-60.7140007F, -54.0530014F), new Vector2(-60.7140007F, -54.0530014F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_38()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(7.91300011F, 0F));
                    builder.AddCubicBezier(new Vector2(7.91300011F, 4.36999989F), new Vector2(4.36999989F, 7.91300011F), new Vector2(0F, 7.91300011F));
                    builder.AddCubicBezier(new Vector2(-4.36999989F, 7.91300011F), new Vector2(-7.91300011F, 4.36999989F), new Vector2(-7.91300011F, 0F));
                    builder.AddCubicBezier(new Vector2(-7.91300011F, -4.36999989F), new Vector2(-4.36999989F, -7.91300011F), new Vector2(0F, -7.91300011F));
                    builder.AddCubicBezier(new Vector2(4.36999989F, -7.91300011F), new Vector2(7.91300011F, -4.36999989F), new Vector2(7.91300011F, 0F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_39()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(7.1170001F, 8.4630003F));
                    builder.AddCubicBezier(new Vector2(8.14799976F, 10.6079998F), new Vector2(2.37899995F, 7.91300011F), new Vector2(0F, 7.91300011F));
                    builder.AddCubicBezier(new Vector2(-2.90899992F, 7.91300011F), new Vector2(-7.44899988F, 11.085F), new Vector2(-8.70899963F, 8.4630003F));
                    builder.AddCubicBezier(new Vector2(-9.87800026F, 6.03100014F), new Vector2(-3.96600008F, 5.27699995F), new Vector2(-1.26699996F, 5.27699995F));
                    builder.AddCubicBezier(new Vector2(1.72300005F, 5.27699995F), new Vector2(5.82200003F, 5.76800013F), new Vector2(7.1170001F, 8.4630003F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_40()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(26.9510002F, -19.5799999F));
                    builder.AddCubicBezier(new Vector2(28.9510002F, -8.25300026F), new Vector2(22.0259991F, 11.7849998F), new Vector2(2.76399994F, 11.8780003F));
                    builder.AddCubicBezier(new Vector2(-16.7280006F, 11.9720001F), new Vector2(-28.2350006F, -9.41699982F), new Vector2(-26.5529995F, -17.9139996F));
                    builder.AddCubicBezier(new Vector2(-24.9759998F, -25.8810005F), new Vector2(-17.0170002F, -23.3719997F), new Vector2(2.44499993F, -23.8729992F));
                    builder.AddCubicBezier(new Vector2(12.6730003F, -24.1359997F), new Vector2(25.8999996F, -25.5300007F), new Vector2(26.9510002F, -19.5799999F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_41()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(27.5330009F, -18.9899998F));
                    builder.AddCubicBezier(new Vector2(27.5330009F, -18.9899998F), new Vector2(23.7019997F, -2.47300005F), new Vector2(2.59899998F, -0.234999999F));
                    builder.AddCubicBezier(new Vector2(-22.2919998F, 2.40400004F), new Vector2(-29.5720005F, -15.5430002F), new Vector2(-29.5720005F, -15.5430002F));
                    builder.AddCubicBezier(new Vector2(-29.5720005F, -15.5430002F), new Vector2(-23.3600006F, 1.75199997F), new Vector2(1.07299995F, -0.372999996F));
                    builder.AddCubicBezier(new Vector2(24.7399998F, -2.43099999F), new Vector2(27.5330009F, -18.9899998F), new Vector2(27.5330009F, -18.9899998F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_42()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(13.6350002F, 0F));
                    builder.AddCubicBezier(new Vector2(13.6350002F, 0.98299998F), new Vector2(7.53000021F, 1.77999997F), new Vector2(0F, 1.77999997F));
                    builder.AddCubicBezier(new Vector2(-7.53000021F, 1.77999997F), new Vector2(-13.6350002F, 0.98299998F), new Vector2(-13.6350002F, 0F));
                    builder.AddCubicBezier(new Vector2(-13.6350002F, -0.98299998F), new Vector2(-7.53000021F, -1.77999997F), new Vector2(0F, -1.77999997F));
                    builder.AddCubicBezier(new Vector2(7.53000021F, -1.77999997F), new Vector2(13.6350002F, -0.98299998F), new Vector2(13.6350002F, 0F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_43()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(-201.5F, -83F));
                    builder.AddCubicBezier(new Vector2(-204.5F, -42F), new Vector2(-272.5F, 5F), new Vector2(-295F, -83F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - Layer aggregator
            // - - - Transforms: A 3 Offset:<187.369, 210.494>
            // - Path
            CanvasGeometry Geometry_44()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(-172.884003F, -14.2440004F));
                    builder.AddCubicBezier(new Vector2(-198.878006F, 52.2989998F), new Vector2(-293.970001F, 43.4770012F), new Vector2(-217.595001F, -44.105999F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - Layer aggregator
            // - - - Transforms: A 3 Offset:<187.369, 210.494>
            // - Path
            CanvasGeometry Geometry_45()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(-198.209F, -84.6490021F));
                    builder.AddCubicBezier(new Vector2(-224.494995F, -73.7689972F), new Vector2(-303.098999F, -71.4440002F), new Vector2(-292.59201F, -162.835007F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - Layer aggregator
            // - - - Transforms: A 3 Offset:<187.369, 210.494>
            // - Path
            CanvasGeometry Geometry_46()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(-171.867004F, -13.618F));
                    builder.AddCubicBezier(new Vector2(-214.630005F, 65.9779968F), new Vector2(-295.303009F, 24.2880001F), new Vector2(-210.432007F, -48.8699989F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - Layer aggregator
            // - - ShapeGroup: Group 1 Offset:<17.522, 17.522>
            CanvasGeometry Geometry_47()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(17.2719994F, 0F));
                    builder.AddCubicBezier(new Vector2(17.2719994F, 9.53899956F), new Vector2(9.53899956F, 17.2719994F), new Vector2(0F, 17.2719994F));
                    builder.AddCubicBezier(new Vector2(-9.53899956F, 17.2719994F), new Vector2(-17.2719994F, 9.53899956F), new Vector2(-17.2719994F, 0F));
                    builder.AddCubicBezier(new Vector2(-17.2719994F, -9.53899956F), new Vector2(-9.53899956F, -17.2719994F), new Vector2(0F, -17.2719994F));
                    builder.AddCubicBezier(new Vector2(9.53899956F, -17.2719994F), new Vector2(17.2719994F, -9.53899956F), new Vector2(17.2719994F, 0F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CompositionColorBrush ColorBrush_AlmostBlack_FF211F1F()
            {
                return (_colorBrush_AlmostBlack_FF211F1F == null)
                    ? _colorBrush_AlmostBlack_FF211F1F = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x21, 0x1F, 0x1F))
                    : _colorBrush_AlmostBlack_FF211F1F;
            }

            // - - - Layer aggregator
            // - Transforms: mlt
            // ShapeGroup: Group 1 Offset:<34.609, 26.649>
            CompositionColorBrush ColorBrush_AlmostDarkCyan_FF129F81()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0x12, 0x9F, 0x81));
            }

            CompositionColorBrush ColorBrush_AlmostDarkCyan_FF139F82()
            {
                return (_colorBrush_AlmostDarkCyan_FF139F82 == null)
                    ? _colorBrush_AlmostDarkCyan_FF139F82 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x13, 0x9F, 0x82))
                    : _colorBrush_AlmostDarkCyan_FF139F82;
            }

            // - - Layer aggregator
            // ShapeGroup: Group 1 Offset:<111.839, 129.928>
            CompositionColorBrush ColorBrush_AlmostDarkTurquoise_FF1CDDB5()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0x1C, 0xDD, 0xB5));
            }

            // - Layer aggregator
            // Scale:1,0.3, Offset:<317, 309.5>
            CompositionColorBrush ColorBrush_AlmostGainsboro_FFE4E4E6()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xE4, 0xE4, 0xE6));
            }

            CompositionColorBrush ColorBrush_AlmostGainsboro_FFE4E5E6()
            {
                return (_colorBrush_AlmostGainsboro_FFE4E5E6 == null)
                    ? _colorBrush_AlmostGainsboro_FFE4E5E6 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xE4, 0xE5, 0xE6))
                    : _colorBrush_AlmostGainsboro_FFE4E5E6;
            }

            CompositionColorBrush ColorBrush_AlmostTurquoise_FF35EBC6()
            {
                return (_colorBrush_AlmostTurquoise_FF35EBC6 == null)
                    ? _colorBrush_AlmostTurquoise_FF35EBC6 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x35, 0xEB, 0xC6))
                    : _colorBrush_AlmostTurquoise_FF35EBC6;
            }

            CompositionColorBrush ColorBrush_White()
            {
                return (_colorBrush_White == null)
                    ? _colorBrush_White = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF))
                    : _colorBrush_White;
            }

            // Layer aggregator
            CompositionContainerShape ContainerShape_0()
            {
                if (_containerShape_0 != null) { return _containerShape_0; }
                var result = _containerShape_0 = _c.CreateContainerShape();
                // Transforms: A 4 RotationDegrees:9, Offset:<-84.216, 186.894>
                result.Shapes.Add(SpriteShape_00());
                return result;
            }

            // Layer aggregator
            CompositionContainerShape ContainerShape_1()
            {
                if (_containerShape_1 != null) { return _containerShape_1; }
                var result = _containerShape_1 = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(111.43F, 259.240997F);
                var shapes = result.Shapes;
                // Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
                shapes.Add(SpriteShape_02());
                // Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
                shapes.Add(SpriteShape_03());
                // Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
                shapes.Add(SpriteShape_04());
                // Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
                shapes.Add(SpriteShape_05());
                // Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
                shapes.Add(SpriteShape_06());
                // Transforms: buku Outlines Offset:<-43.691, 0>
                shapes.Add(SpriteShape_07());
                // Transforms: buku Outlines Offset:<-43.691, 0>
                shapes.Add(SpriteShape_08());
                // Transforms: buku Outlines Offset:<-43.691, 0>
                shapes.Add(SpriteShape_09());
                // Transforms: buku Outlines Offset:<-43.691, 0>
                shapes.Add(SpriteShape_10());
                // Transforms: buku Outlines Offset:<-43.691, 0>
                shapes.Add(SpriteShape_11());
                // Transforms: buku Outlines Offset:<-43.691, 0>
                shapes.Add(SpriteShape_12());
                return result;
            }

            // Layer aggregator
            CompositionContainerShape ContainerShape_2()
            {
                if (_containerShape_2 != null) { return _containerShape_2; }
                var result = _containerShape_2 = _c.CreateContainerShape();
                // ShapeGroup: Group 1 Offset:<19.865, 19.865>
                result.Shapes.Add(SpriteShape_13());
                return result;
            }

            // Layer aggregator
            CompositionContainerShape ContainerShape_3()
            {
                if (_containerShape_3 != null) { return _containerShape_3; }
                var result = _containerShape_3 = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(111.43F, 259.240997F);
                var shapes = result.Shapes;
                // ShapeGroup: Group 1 Offset:<111.839, 129.928>
                shapes.Add(SpriteShape_18());
                // Transforms: mata
                shapes.Add(ContainerShape_4());
                // Transforms: mlt
                shapes.Add(ContainerShape_5());
                // Transforms: pipi
                shapes.Add(ContainerShape_6());
                // Transforms: A 3 Offset:<187.369, 210.494>
                shapes.Add(SpriteShape_24());
                return result;
            }

            // - Layer aggregator
            // Transforms for mata
            CompositionContainerShape ContainerShape_4()
            {
                if (_containerShape_4 != null) { return _containerShape_4; }
                var result = _containerShape_4 = _c.CreateContainerShape();
                var shapes = result.Shapes;
                // ShapeGroup: Group 2 Offset:<8.163, 8.163>
                shapes.Add(SpriteShape_19());
                // ShapeGroup: Group 1 Offset:<107.012, 8.163>
                shapes.Add(SpriteShape_20());
                return result;
            }

            // - Layer aggregator
            // Transforms for mlt
            CompositionContainerShape ContainerShape_5()
            {
                if (_containerShape_5 != null) { return _containerShape_5; }
                var result = _containerShape_5 = _c.CreateContainerShape();
                // ShapeGroup: Group 1 Offset:<34.609, 26.649>
                result.Shapes.Add(SpriteShape_21());
                return result;
            }

            // - Layer aggregator
            // Transforms for pipi
            CompositionContainerShape ContainerShape_6()
            {
                if (_containerShape_6 != null) { return _containerShape_6; }
                var result = _containerShape_6 = _c.CreateContainerShape();
                var shapes = result.Shapes;
                // ShapeGroup: Group 2 Offset:<13.884, 5.591>
                shapes.Add(SpriteShape_22());
                // ShapeGroup: Group 1 Offset:<142.802, 2.03>
                shapes.Add(SpriteShape_23());
                return result;
            }

            // Layer aggregator
            CompositionContainerShape ContainerShape_7()
            {
                if (_containerShape_7 != null) { return _containerShape_7; }
                var result = _containerShape_7 = _c.CreateContainerShape();
                // ShapeGroup: Group 1 Offset:<17.522, 17.522>
                result.Shapes.Add(SpriteShape_25());
                return result;
            }

            // - Layer aggregator
            // Scale:1,0.3, Offset:<317, 309.5>
            // Ellipse Path 1.EllipseGeometry
            CompositionEllipseGeometry Ellipse_122()
            {
                var result = _c.CreateEllipseGeometry();
                result.Radius = new Vector2(122F, 122F);
                return result;
            }

            CompositionPath Path_00()
            {
                if (_path_00 != null) { return _path_00; }
                var result = _path_00 = new CompositionPath(Geometry_00());
                return result;
            }

            CompositionPath Path_01()
            {
                if (_path_01 != null) { return _path_01; }
                var result = _path_01 = new CompositionPath(Geometry_04());
                return result;
            }

            CompositionPath Path_02()
            {
                if (_path_02 != null) { return _path_02; }
                var result = _path_02 = new CompositionPath(Geometry_05());
                return result;
            }

            CompositionPath Path_03()
            {
                if (_path_03 != null) { return _path_03; }
                var result = _path_03 = new CompositionPath(Geometry_06());
                return result;
            }

            CompositionPath Path_04()
            {
                if (_path_04 != null) { return _path_04; }
                var result = _path_04 = new CompositionPath(Geometry_07());
                return result;
            }

            CompositionPath Path_05()
            {
                if (_path_05 != null) { return _path_05; }
                var result = _path_05 = new CompositionPath(Geometry_08());
                return result;
            }

            CompositionPath Path_06()
            {
                if (_path_06 != null) { return _path_06; }
                var result = _path_06 = new CompositionPath(Geometry_09());
                return result;
            }

            CompositionPath Path_07()
            {
                if (_path_07 != null) { return _path_07; }
                var result = _path_07 = new CompositionPath(Geometry_10());
                return result;
            }

            CompositionPath Path_08()
            {
                if (_path_08 != null) { return _path_08; }
                var result = _path_08 = new CompositionPath(Geometry_11());
                return result;
            }

            CompositionPath Path_09()
            {
                if (_path_09 != null) { return _path_09; }
                var result = _path_09 = new CompositionPath(Geometry_12());
                return result;
            }

            CompositionPath Path_10()
            {
                if (_path_10 != null) { return _path_10; }
                var result = _path_10 = new CompositionPath(Geometry_13());
                return result;
            }

            CompositionPath Path_11()
            {
                if (_path_11 != null) { return _path_11; }
                var result = _path_11 = new CompositionPath(Geometry_14());
                return result;
            }

            CompositionPath Path_12()
            {
                if (_path_12 != null) { return _path_12; }
                var result = _path_12 = new CompositionPath(Geometry_15());
                return result;
            }

            CompositionPath Path_13()
            {
                if (_path_13 != null) { return _path_13; }
                var result = _path_13 = new CompositionPath(Geometry_16());
                return result;
            }

            CompositionPath Path_14()
            {
                if (_path_14 != null) { return _path_14; }
                var result = _path_14 = new CompositionPath(Geometry_17());
                return result;
            }

            CompositionPath Path_15()
            {
                if (_path_15 != null) { return _path_15; }
                var result = _path_15 = new CompositionPath(Geometry_18());
                return result;
            }

            CompositionPath Path_16()
            {
                if (_path_16 != null) { return _path_16; }
                var result = _path_16 = new CompositionPath(Geometry_19());
                return result;
            }

            CompositionPath Path_17()
            {
                if (_path_17 != null) { return _path_17; }
                var result = _path_17 = new CompositionPath(Geometry_20());
                return result;
            }

            CompositionPath Path_18()
            {
                if (_path_18 != null) { return _path_18; }
                var result = _path_18 = new CompositionPath(Geometry_21());
                return result;
            }

            CompositionPath Path_19()
            {
                if (_path_19 != null) { return _path_19; }
                var result = _path_19 = new CompositionPath(Geometry_22());
                return result;
            }

            CompositionPath Path_20()
            {
                if (_path_20 != null) { return _path_20; }
                var result = _path_20 = new CompositionPath(Geometry_23());
                return result;
            }

            CompositionPath Path_21()
            {
                if (_path_21 != null) { return _path_21; }
                var result = _path_21 = new CompositionPath(Geometry_24());
                return result;
            }

            CompositionPath Path_22()
            {
                if (_path_22 != null) { return _path_22; }
                var result = _path_22 = new CompositionPath(Geometry_25());
                return result;
            }

            CompositionPath Path_23()
            {
                if (_path_23 != null) { return _path_23; }
                var result = _path_23 = new CompositionPath(Geometry_28());
                return result;
            }

            CompositionPath Path_24()
            {
                if (_path_24 != null) { return _path_24; }
                var result = _path_24 = new CompositionPath(Geometry_32());
                return result;
            }

            CompositionPath Path_25()
            {
                if (_path_25 != null) { return _path_25; }
                var result = _path_25 = new CompositionPath(Geometry_36());
                return result;
            }

            CompositionPath Path_26()
            {
                if (_path_26 != null) { return _path_26; }
                var result = _path_26 = new CompositionPath(Geometry_37());
                return result;
            }

            CompositionPath Path_27()
            {
                if (_path_27 != null) { return _path_27; }
                var result = _path_27 = new CompositionPath(Geometry_38());
                return result;
            }

            CompositionPath Path_28()
            {
                if (_path_28 != null) { return _path_28; }
                var result = _path_28 = new CompositionPath(Geometry_39());
                return result;
            }

            CompositionPath Path_29()
            {
                if (_path_29 != null) { return _path_29; }
                var result = _path_29 = new CompositionPath(Geometry_40());
                return result;
            }

            CompositionPath Path_30()
            {
                if (_path_30 != null) { return _path_30; }
                var result = _path_30 = new CompositionPath(Geometry_41());
                return result;
            }

            CompositionPath Path_31()
            {
                if (_path_31 != null) { return _path_31; }
                var result = _path_31 = new CompositionPath(Geometry_43());
                return result;
            }

            // - - Layer aggregator
            // Transforms: A 4 RotationDegrees:9, Offset:<-84.216, 186.894>
            CompositionPathGeometry PathGeometry_00()
            {
                if (_pathGeometry_00 != null) { return _pathGeometry_00; }
                var result = _pathGeometry_00 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
            CompositionPathGeometry PathGeometry_01()
            {
                if (_pathGeometry_01 != null) { return _pathGeometry_01; }
                var result = _pathGeometry_01 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
            CompositionPathGeometry PathGeometry_02()
            {
                if (_pathGeometry_02 != null) { return _pathGeometry_02; }
                var result = _pathGeometry_02 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
            CompositionPathGeometry PathGeometry_03()
            {
                if (_pathGeometry_03 != null) { return _pathGeometry_03; }
                var result = _pathGeometry_03 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
            CompositionPathGeometry PathGeometry_04()
            {
                if (_pathGeometry_04 != null) { return _pathGeometry_04; }
                var result = _pathGeometry_04 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
            CompositionPathGeometry PathGeometry_05()
            {
                if (_pathGeometry_05 != null) { return _pathGeometry_05; }
                var result = _pathGeometry_05 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // Transforms: buku Outlines Offset:<-43.691, 0>
            CompositionPathGeometry PathGeometry_06()
            {
                if (_pathGeometry_06 != null) { return _pathGeometry_06; }
                var result = _pathGeometry_06 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // Transforms: buku Outlines Offset:<-43.691, 0>
            CompositionPathGeometry PathGeometry_07()
            {
                if (_pathGeometry_07 != null) { return _pathGeometry_07; }
                var result = _pathGeometry_07 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // Transforms: buku Outlines Offset:<-43.691, 0>
            CompositionPathGeometry PathGeometry_08()
            {
                if (_pathGeometry_08 != null) { return _pathGeometry_08; }
                var result = _pathGeometry_08 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // Transforms: buku Outlines Offset:<-43.691, 0>
            CompositionPathGeometry PathGeometry_09()
            {
                if (_pathGeometry_09 != null) { return _pathGeometry_09; }
                var result = _pathGeometry_09 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // Transforms: buku Outlines Offset:<-43.691, 0>
            CompositionPathGeometry PathGeometry_10()
            {
                if (_pathGeometry_10 != null) { return _pathGeometry_10; }
                var result = _pathGeometry_10 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // Transforms: buku Outlines Offset:<-43.691, 0>
            CompositionPathGeometry PathGeometry_11()
            {
                if (_pathGeometry_11 != null) { return _pathGeometry_11; }
                var result = _pathGeometry_11 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // ShapeGroup: Group 1 Offset:<19.865, 19.865>
            CompositionPathGeometry PathGeometry_12()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_26()));
            }

            CompositionPathGeometry PathGeometry_13()
            {
                return (_pathGeometry_13 == null)
                    ? _pathGeometry_13 = _c.CreatePathGeometry(new CompositionPath(Geometry_27()))
                    : _pathGeometry_13;
            }

            // - Layer aggregator
            // Offset:<317, 309.5>
            CompositionPathGeometry PathGeometry_14()
            {
                if (_pathGeometry_14 != null) { return _pathGeometry_14; }
                var result = _pathGeometry_14 = _c.CreatePathGeometry();
                return result;
            }

            // - Layer aggregator
            // Offset:<415, 309.5>
            CompositionPathGeometry PathGeometry_15()
            {
                if (_pathGeometry_15 != null) { return _pathGeometry_15; }
                var result = _pathGeometry_15 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // ShapeGroup: Group 1 Offset:<111.839, 129.928>
            CompositionPathGeometry PathGeometry_16()
            {
                if (_pathGeometry_16 != null) { return _pathGeometry_16; }
                var result = _pathGeometry_16 = _c.CreatePathGeometry();
                return result;
            }

            CompositionPathGeometry PathGeometry_17()
            {
                if (_pathGeometry_17 != null) { return _pathGeometry_17; }
                var result = _pathGeometry_17 = _c.CreatePathGeometry();
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: mlt
            // ShapeGroup: Group 1 Offset:<34.609, 26.649>
            CompositionPathGeometry PathGeometry_18()
            {
                if (_pathGeometry_18 != null) { return _pathGeometry_18; }
                var result = _pathGeometry_18 = _c.CreatePathGeometry();
                return result;
            }

            CompositionPathGeometry PathGeometry_19()
            {
                return (_pathGeometry_19 == null)
                    ? _pathGeometry_19 = _c.CreatePathGeometry(new CompositionPath(Geometry_42()))
                    : _pathGeometry_19;
            }

            // - - Layer aggregator
            // Transforms: A 3 Offset:<187.369, 210.494>
            CompositionPathGeometry PathGeometry_20()
            {
                if (_pathGeometry_20 != null) { return _pathGeometry_20; }
                var result = _pathGeometry_20 = _c.CreatePathGeometry();
                return result;
            }

            // - - Layer aggregator
            // ShapeGroup: Group 1 Offset:<17.522, 17.522>
            CompositionPathGeometry PathGeometry_21()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_47()));
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_00()
            {
                // Offset:<-84.216, 186.894>, Rotation:8.999991941061564 degrees
                var result = CreateSpriteShape(PathGeometry_00(), new Matrix3x2(0.987688363F, 0.156434476F, -0.156434476F, 0.987688363F, -84.2160034F, 186.893997F)); ;
                result.StrokeBrush = ColorBrush_AlmostBlack_FF211F1F();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeMiterLimit = 2F;
                result.StrokeThickness = 5F;
                return result;
            }

            // Layer aggregator
            // Ellipse Path 1
            CompositionSpriteShape SpriteShape_01()
            {
                // Offset:<342, 509.99997>, Scale:<1, 0.3>
                var geometry = Ellipse_122();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 0.300000012F, 342F, 509.999969F), ColorBrush_AlmostGainsboro_FFE4E4E6()); ;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_02()
            {
                // Offset:<100.656, 20.790009>, Scale:<1, -1>
                var geometry = PathGeometry_01();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, -1F, 100.655998F, 20.7900085F), ColorBrush_AlmostDarkCyan_FF139F82()); ;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_03()
            {
                // Offset:<98.505, 30.11499>, Scale:<1, -1>
                var geometry = PathGeometry_02();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, -1F, 98.5049973F, 30.1149902F), ColorBrush_White()); ;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_04()
            {
                // Offset:<114.357994, 37.028015>, Scale:<1, -1>
                var geometry = PathGeometry_03();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, -1F, 114.357994F, 37.0280151F), ColorBrush_AlmostGainsboro_FFE4E5E6()); ;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_05()
            {
                // Offset:<102.07099, 28.998993>, Scale:<1, -1>
                var geometry = PathGeometry_04();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, -1F, 102.070992F, 28.9989929F), ColorBrush_AlmostGainsboro_FFE4E5E6()); ;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_06()
            {
                // Offset:<92.523994, 22.029999>, Scale:<1, -1>
                var geometry = PathGeometry_05();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, -1F, 92.5239944F, 22.0299988F), ColorBrush_AlmostGainsboro_FFE4E5E6()); ;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_07()
            {
                // Offset:<100.656, 278.508>
                var geometry = PathGeometry_06();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 100.655998F, 278.507996F), ColorBrush_AlmostDarkCyan_FF139F82()); ;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_08()
            {
                // Offset:<98.505, 269.183>
                var geometry = PathGeometry_07();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 98.5049973F, 269.183014F), ColorBrush_White()); ;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_09()
            {
                // Offset:<114.357994, 262.27>
                var geometry = PathGeometry_08();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 114.357994F, 262.269989F), ColorBrush_AlmostGainsboro_FFE4E5E6()); ;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_10()
            {
                // Offset:<102.07099, 270.299>
                var geometry = PathGeometry_09();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 102.070992F, 270.299011F), ColorBrush_AlmostGainsboro_FFE4E5E6()); ;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_11()
            {
                // Offset:<92.523994, 277.268>
                var geometry = PathGeometry_10();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 92.5239944F, 277.268005F), ColorBrush_AlmostGainsboro_FFE4E5E6()); ;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_12()
            {
                // Offset:<-9.259003, 144.16>
                var geometry = PathGeometry_11();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, -9.25900269F, 144.160004F), ColorBrush_AlmostDarkCyan_FF139F82()); ;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_13()
            {
                // Offset:<19.865, 19.865>
                var geometry = PathGeometry_12();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 19.8649998F, 19.8649998F), ColorBrush_AlmostBlack_FF211F1F()); ;
                return result;
            }

            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_14()
            {
                // Offset:<295.898, 512.087>
                var geometry = PathGeometry_13();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 295.89801F, 512.086975F), ColorBrush_AlmostBlack_FF211F1F()); ;
                return result;
            }

            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_15()
            {
                // Offset:<394.466, 512.462>
                var geometry = PathGeometry_13();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 394.466003F, 512.461975F), ColorBrush_AlmostBlack_FF211F1F()); ;
                return result;
            }

            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_16()
            {
                // Offset:<317, 309.5>
                var result = CreateSpriteShape(PathGeometry_14(), new Matrix3x2(1F, 0F, 0F, 1F, 317F, 309.5F)); ;
                result.StrokeBrush = ColorBrush_AlmostBlack_FF211F1F();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeMiterLimit = 2F;
                result.StrokeThickness = 8F;
                return result;
            }

            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_17()
            {
                // Offset:<415, 309.5>
                var result = CreateSpriteShape(PathGeometry_15(), new Matrix3x2(1F, 0F, 0F, 1F, 415F, 309.5F)); ;
                result.StrokeBrush = ColorBrush_AlmostBlack_FF211F1F();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeMiterLimit = 2F;
                result.StrokeThickness = 8F;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_18()
            {
                // Offset:<111.839, 129.928>
                var geometry = PathGeometry_16();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 111.838997F, 129.927994F), ColorBrush_AlmostDarkTurquoise_FF1CDDB5()); ;
                return result;
            }

            // - - Layer aggregator
            // Transforms: mata
            // Path 1
            CompositionSpriteShape SpriteShape_19()
            {
                // Offset:<8.163, 8.163>
                var geometry = PathGeometry_17();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 8.16300011F, 8.16300011F), ColorBrush_AlmostDarkCyan_FF139F82()); ;
                return result;
            }

            // - - Layer aggregator
            // Transforms: mata
            // Path 1
            CompositionSpriteShape SpriteShape_20()
            {
                // Offset:<107.012, 8.163>
                var geometry = PathGeometry_17();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 107.012001F, 8.16300011F), ColorBrush_AlmostDarkCyan_FF139F82()); ;
                return result;
            }

            // - - Layer aggregator
            // Transforms: mlt
            // Path 1
            CompositionSpriteShape SpriteShape_21()
            {
                // Offset:<34.609, 26.649>
                var geometry = PathGeometry_18();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 34.6090012F, 26.6490002F), ColorBrush_AlmostDarkCyan_FF139F82()); ;
                result.StrokeBrush = ColorBrush_AlmostDarkCyan_FF129F81();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeMiterLimit = 2F;
                result.StrokeThickness = 3F;
                return result;
            }

            // - - Layer aggregator
            // Transforms: pipi
            // Path 1
            CompositionSpriteShape SpriteShape_22()
            {
                // Offset:<13.884, 5.591>
                var geometry = PathGeometry_19();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 13.8839998F, 5.59100008F), ColorBrush_AlmostTurquoise_FF35EBC6()); ;
                return result;
            }

            // - - Layer aggregator
            // Transforms: pipi
            // Path 1
            CompositionSpriteShape SpriteShape_23()
            {
                // Offset:<142.802, 2.03>
                var geometry = PathGeometry_19();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 142.802002F, 2.02999997F), ColorBrush_AlmostTurquoise_FF35EBC6()); ;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_24()
            {
                // Offset:<187.369, 210.494>
                var result = CreateSpriteShape(PathGeometry_20(), new Matrix3x2(1F, 0F, 0F, 1F, 187.369003F, 210.494003F)); ;
                result.StrokeBrush = ColorBrush_AlmostBlack_FF211F1F();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeLineJoin = CompositionStrokeLineJoin.Round;
                result.StrokeMiterLimit = 2F;
                result.StrokeThickness = 5F;
                return result;
            }

            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_25()
            {
                // Offset:<17.522, 17.522>
                var geometry = PathGeometry_21();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 17.5219994F, 17.5219994F), ColorBrush_AlmostBlack_FF211F1F()); ;
                return result;
            }

            // The root of the composition.
            ContainerVisual Root()
            {
                if (_root != null) { return _root; }
                var result = _root = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Progress", 0F);
                // Layer aggregator
                result.Children.InsertAtTop(ShapeVisual_0());
                return result;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0()
            {
                return (_cubicBezierEasingFunction_0 == null)
                    ? _cubicBezierEasingFunction_0 = _c.CreateCubicBezierEasingFunction(new Vector2(0.50999999F, 0F), new Vector2(0.49000001F, 1F))
                    : _cubicBezierEasingFunction_0;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_1()
            {
                return (_cubicBezierEasingFunction_1 == null)
                    ? _cubicBezierEasingFunction_1 = _c.CreateCubicBezierEasingFunction(new Vector2(0.550000012F, 0F), new Vector2(0.449999988F, 1F))
                    : _cubicBezierEasingFunction_1;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_2()
            {
                return (_cubicBezierEasingFunction_2 == null)
                    ? _cubicBezierEasingFunction_2 = _c.CreateCubicBezierEasingFunction(new Vector2(0.333000004F, 0F), new Vector2(0.666999996F, 1F))
                    : _cubicBezierEasingFunction_2;
            }

            ExpressionAnimation RootProgress()
            {
                if (_rootProgress != null) { return _rootProgress; }
                var result = _rootProgress = _c.CreateExpressionAnimation("_.Progress");
                result.SetReferenceParameter("_", _root);
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: A 4 RotationDegrees:9, Offset:<-84.216, 186.894>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_00()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_00(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, new CompositionPath(Geometry_01()), CubicBezierEasingFunction_0());
                // Frame 60.
                result.InsertKeyFrame(0.5F, new CompositionPath(Geometry_02()), CubicBezierEasingFunction_0());
                // Frame 90.
                result.InsertKeyFrame(0.75F, new CompositionPath(Geometry_03()), CubicBezierEasingFunction_0());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_00(), CubicBezierEasingFunction_0());
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_01()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_01(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_02(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_01(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_02(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_01(), CubicBezierEasingFunction_1());
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_02()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_03(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_04(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_03(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_04(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_03(), CubicBezierEasingFunction_1());
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_03()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_05(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_06(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_05(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_06(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_05(), CubicBezierEasingFunction_1());
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_04()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_07(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_08(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_07(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_08(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_07(), CubicBezierEasingFunction_1());
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: buku Outlines 2 Scale:1,-1, Offset:<-43.691, 0>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_05()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_09(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_10(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_09(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_10(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_09(), CubicBezierEasingFunction_1());
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: buku Outlines Offset:<-43.691, 0>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_06()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_11(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_12(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_11(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_12(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_11(), CubicBezierEasingFunction_1());
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: buku Outlines Offset:<-43.691, 0>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_07()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_13(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_14(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_13(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_14(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_13(), CubicBezierEasingFunction_1());
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: buku Outlines Offset:<-43.691, 0>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_08()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_15(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_16(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_15(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_16(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_15(), CubicBezierEasingFunction_1());
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: buku Outlines Offset:<-43.691, 0>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_09()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_17(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_18(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_17(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_18(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_17(), CubicBezierEasingFunction_1());
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: buku Outlines Offset:<-43.691, 0>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_10()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_19(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_20(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_19(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_20(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_19(), CubicBezierEasingFunction_1());
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: buku Outlines Offset:<-43.691, 0>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_11()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_21(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_22(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_21(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_22(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_21(), CubicBezierEasingFunction_1());
                return result;
            }

            // - - Layer aggregator
            // -  Offset:<317, 309.5>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_12()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_23(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, new CompositionPath(Geometry_29()), CubicBezierEasingFunction_0());
                // Frame 60.
                result.InsertKeyFrame(0.5F, new CompositionPath(Geometry_30()), CubicBezierEasingFunction_0());
                // Frame 90.
                result.InsertKeyFrame(0.75F, new CompositionPath(Geometry_31()), CubicBezierEasingFunction_0());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_23(), CubicBezierEasingFunction_0());
                return result;
            }

            // - - Layer aggregator
            // -  Offset:<415, 309.5>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_13()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_24(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, new CompositionPath(Geometry_33()), CubicBezierEasingFunction_0());
                // Frame 60.
                result.InsertKeyFrame(0.5F, new CompositionPath(Geometry_34()), CubicBezierEasingFunction_0());
                // Frame 90.
                result.InsertKeyFrame(0.75F, new CompositionPath(Geometry_35()), CubicBezierEasingFunction_0());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_24(), CubicBezierEasingFunction_0());
                return result;
            }

            // - - - Layer aggregator
            // - ShapeGroup: Group 1 Offset:<111.839, 129.928>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_14()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_25(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_26(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_25(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_26(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_25(), CubicBezierEasingFunction_1());
                return result;
            }

            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_15()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_27(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_28(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_27(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_28(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_27(), CubicBezierEasingFunction_1());
                return result;
            }

            // - - - - Layer aggregator
            // - - Transforms: mlt
            // - ShapeGroup: Group 1 Offset:<34.609, 26.649>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_16()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_29(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, Path_30(), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, Path_29(), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, Path_30(), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_29(), CubicBezierEasingFunction_1());
                return result;
            }

            // - - - Layer aggregator
            // - Transforms: A 3 Offset:<187.369, 210.494>
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_17()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_31(), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, new CompositionPath(Geometry_44()), CubicBezierEasingFunction_0());
                // Frame 60.
                result.InsertKeyFrame(0.5F, new CompositionPath(Geometry_45()), CubicBezierEasingFunction_0());
                // Frame 90.
                result.InsertKeyFrame(0.75F, new CompositionPath(Geometry_46()), CubicBezierEasingFunction_0());
                // Frame 120.
                result.InsertKeyFrame(1F, Path_31(), CubicBezierEasingFunction_0());
                return result;
            }

            // Rotation
            ScalarKeyFrameAnimation RotationAngleInDegreesScalarAnimation_0_to_0()
            {
                // Frame 0.
                if (_rotationAngleInDegreesScalarAnimation_0_to_0 != null) { return _rotationAngleInDegreesScalarAnimation_0_to_0; }
                var result = _rotationAngleInDegreesScalarAnimation_0_to_0 = CreateScalarKeyFrameAnimation(0F, 0F, HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, -5F, CubicBezierEasingFunction_2());
                // Frame 60.
                result.InsertKeyFrame(0.5F, 9F, CubicBezierEasingFunction_2());
                // Frame 90.
                result.InsertKeyFrame(0.75F, -5F, CubicBezierEasingFunction_2());
                // Frame 120.
                result.InsertKeyFrame(1F, 0F, CubicBezierEasingFunction_2());
                return result;
            }

            // Layer aggregator
            ShapeVisual ShapeVisual_0()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(634F, 619F);
                var shapes = result.Shapes;
                shapes.Add(ContainerShape_0());
                // Scale:1,0.3, Offset:<317, 309.5>
                shapes.Add(SpriteShape_01());
                shapes.Add(ContainerShape_1());
                shapes.Add(ContainerShape_2());
                // Offset:<276.45, 504.533>
                shapes.Add(SpriteShape_14());
                // Offset:<375.018, 504.908>
                shapes.Add(SpriteShape_15());
                // Offset:<317, 309.5>
                shapes.Add(SpriteShape_16());
                // Offset:<415, 309.5>
                shapes.Add(SpriteShape_17());
                shapes.Add(ContainerShape_3());
                shapes.Add(ContainerShape_7());
                return result;
            }

            StepEasingFunction HoldThenStepEasingFunction()
            {
                if (_holdThenStepEasingFunction != null) { return _holdThenStepEasingFunction; }
                var result = _holdThenStepEasingFunction = _c.CreateStepEasingFunction();
                result.IsFinalStepSingleFrame = true;
                return result;
            }

            // Offset
            Vector2KeyFrameAnimation OffsetVector2Animation_0()
            {
                // Frame 0.
                if (_offsetVector2Animation_0 != null) { return _offsetVector2Animation_0; }
                var result = _offsetVector2Animation_0 = CreateVector2KeyFrameAnimation(0F, new Vector2(495.88501F, 179.384995F), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, new Vector2(481.279999F, 261.533997F), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, new Vector2(517.88501F, 125.385002F), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, new Vector2(481.279999F, 261.533997F), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, new Vector2(495.88501F, 179.384995F), CubicBezierEasingFunction_1());
                return result;
            }

            // Offset
            Vector2KeyFrameAnimation OffsetVector2Animation_1()
            {
                // Frame 0.
                if (_offsetVector2Animation_1 != null) { return _offsetVector2Animation_1; }
                var result = _offsetVector2Animation_1 = CreateVector2KeyFrameAnimation(0F, new Vector2(227.630997F, 99.0059967F), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, new Vector2(235.731003F, 92.5059967F), CubicBezierEasingFunction_2());
                // Frame 60.
                result.InsertKeyFrame(0.5F, new Vector2(239.630997F, 89.0059967F), CubicBezierEasingFunction_2());
                // Frame 90.
                result.InsertKeyFrame(0.75F, new Vector2(235.731003F, 92.5059967F), CubicBezierEasingFunction_2());
                // Frame 120.
                result.InsertKeyFrame(1F, new Vector2(227.630997F, 99.0059967F), CubicBezierEasingFunction_2());
                return result;
            }

            // - - Layer aggregator
            // Transforms: mata
            // Offset
            Vector2KeyFrameAnimation OffsetVector2Animation_2()
            {
                // Frame 0.
                var result = CreateVector2KeyFrameAnimation(0F, new Vector2(51.9039993F, 90.5889969F), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, new Vector2(92.4039993F, 163.089005F), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, new Vector2(51.9039993F, 90.5889969F), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, new Vector2(92.4039993F, 163.089005F), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, new Vector2(51.9039993F, 90.5889969F), CubicBezierEasingFunction_1());
                return result;
            }

            // - - Layer aggregator
            // Transforms: mlt
            // Offset
            Vector2KeyFrameAnimation OffsetVector2Animation_3()
            {
                // Frame 0.
                var result = CreateVector2KeyFrameAnimation(0F, new Vector2(83.0510025F, 119.551003F), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, new Vector2(118.551003F, 196.050995F), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, new Vector2(83.0510025F, 119.551003F), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, new Vector2(118.551003F, 196.050995F), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, new Vector2(83.0510025F, 119.551003F), CubicBezierEasingFunction_1());
                return result;
            }

            // - - Layer aggregator
            // Transforms: pipi
            // Offset
            Vector2KeyFrameAnimation OffsetVector2Animation_4()
            {
                // Frame 0.
                var result = CreateVector2KeyFrameAnimation(0F, new Vector2(34.0099983F, 119.68F), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, new Vector2(67.5100021F, 192.179993F), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, new Vector2(34.0099983F, 119.68F), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, new Vector2(67.5100021F, 192.179993F), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, new Vector2(34.0099983F, 119.68F), CubicBezierEasingFunction_1());
                return result;
            }

            // - Layer aggregator
            // Offset
            Vector2KeyFrameAnimation OffsetVector2Animation_5()
            {
                // Frame 0.
                var result = CreateVector2KeyFrameAnimation(0F, new Vector2(100.477997F, 205.227997F), HoldThenStepEasingFunction());
                // Frame 30.
                result.InsertKeyFrame(0.25F, new Vector2(187.367996F, 249.962997F), CubicBezierEasingFunction_1());
                // Frame 60.
                result.InsertKeyFrame(0.5F, new Vector2(151.477997F, 88.2279968F), CubicBezierEasingFunction_1());
                // Frame 90.
                result.InsertKeyFrame(0.75F, new Vector2(187.367996F, 249.962997F), CubicBezierEasingFunction_1());
                // Frame 120.
                result.InsertKeyFrame(1F, new Vector2(100.477997F, 205.227997F), CubicBezierEasingFunction_1());
                return result;
            }

            internal DancingBook_AnimatedVisual(
                Compositor compositor
                )
            {
                _c = compositor;
                _reusableExpressionAnimation = compositor.CreateExpressionAnimation();
                Root();
            }

            public Visual RootVisual => _root;
            public TimeSpan Duration => TimeSpan.FromTicks(c_durationTicks);
            public Vector2 Size => new(634F, 619F);
            void IDisposable.Dispose() => _root?.Dispose();

            public void CreateAnimations()
            {
                StartProgressBoundAnimation(_containerShape_0, "Offset", OffsetVector2Animation_0(), RootProgress());
                StartProgressBoundAnimation(_containerShape_1, "RotationAngleInDegrees", RotationAngleInDegreesScalarAnimation_0_to_0(), RootProgress());
                StartProgressBoundAnimation(_containerShape_1, "Offset", OffsetVector2Animation_1(), RootProgress());
                StartProgressBoundAnimation(_containerShape_2, "Offset", OffsetVector2Animation_0(), RootProgress());
                StartProgressBoundAnimation(_containerShape_3, "RotationAngleInDegrees", RotationAngleInDegreesScalarAnimation_0_to_0(), RootProgress());
                StartProgressBoundAnimation(_containerShape_3, "Offset", OffsetVector2Animation_1(), RootProgress());
                StartProgressBoundAnimation(_containerShape_4, "Offset", OffsetVector2Animation_2(), RootProgress());
                StartProgressBoundAnimation(_containerShape_5, "Offset", OffsetVector2Animation_3(), RootProgress());
                StartProgressBoundAnimation(_containerShape_6, "Offset", OffsetVector2Animation_4(), RootProgress());
                StartProgressBoundAnimation(_containerShape_7, "Offset", OffsetVector2Animation_5(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_00, "Path", PathKeyFrameAnimation_00(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_01, "Path", PathKeyFrameAnimation_01(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_02, "Path", PathKeyFrameAnimation_02(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_03, "Path", PathKeyFrameAnimation_03(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_04, "Path", PathKeyFrameAnimation_04(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_05, "Path", PathKeyFrameAnimation_05(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_06, "Path", PathKeyFrameAnimation_06(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_07, "Path", PathKeyFrameAnimation_07(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_08, "Path", PathKeyFrameAnimation_08(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_09, "Path", PathKeyFrameAnimation_09(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_10, "Path", PathKeyFrameAnimation_10(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_11, "Path", PathKeyFrameAnimation_11(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_14, "Path", PathKeyFrameAnimation_12(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_15, "Path", PathKeyFrameAnimation_13(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_16, "Path", PathKeyFrameAnimation_14(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_17, "Path", PathKeyFrameAnimation_15(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_18, "Path", PathKeyFrameAnimation_16(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_20, "Path", PathKeyFrameAnimation_17(), RootProgress());
            }

            public void DestroyAnimations()
            {
                _containerShape_0.StopAnimation("Offset");
                _containerShape_1.StopAnimation("RotationAngleInDegrees");
                _containerShape_1.StopAnimation("Offset");
                _containerShape_2.StopAnimation("Offset");
                _containerShape_3.StopAnimation("RotationAngleInDegrees");
                _containerShape_3.StopAnimation("Offset");
                _containerShape_4.StopAnimation("Offset");
                _containerShape_5.StopAnimation("Offset");
                _containerShape_6.StopAnimation("Offset");
                _containerShape_7.StopAnimation("Offset");
                _pathGeometry_00.StopAnimation("Path");
                _pathGeometry_01.StopAnimation("Path");
                _pathGeometry_02.StopAnimation("Path");
                _pathGeometry_03.StopAnimation("Path");
                _pathGeometry_04.StopAnimation("Path");
                _pathGeometry_05.StopAnimation("Path");
                _pathGeometry_06.StopAnimation("Path");
                _pathGeometry_07.StopAnimation("Path");
                _pathGeometry_08.StopAnimation("Path");
                _pathGeometry_09.StopAnimation("Path");
                _pathGeometry_10.StopAnimation("Path");
                _pathGeometry_11.StopAnimation("Path");
                _pathGeometry_14.StopAnimation("Path");
                _pathGeometry_15.StopAnimation("Path");
                _pathGeometry_16.StopAnimation("Path");
                _pathGeometry_17.StopAnimation("Path");
                _pathGeometry_18.StopAnimation("Path");
                _pathGeometry_20.StopAnimation("Path");
            }

        }
    }
}
