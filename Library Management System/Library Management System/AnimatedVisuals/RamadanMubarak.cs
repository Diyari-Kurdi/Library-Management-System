using Microsoft.Graphics.Canvas;
using Microsoft.Graphics.Canvas.Effects;
using Microsoft.Graphics.Canvas.Geometry;
using Microsoft.UI.Composition;
using System;
using System.Collections.Generic;
using System.Numerics;
using Windows.UI;
#pragma warning disable CS0168, CS0219, CS0414, CS8600,CS8597,CS8618,CS8625,CA1822,IDE0029,IDE0060,IDE0059,IDE0052,IDE0018,IDE1006
namespace Library_Management_System.AnimatedVisuals
{
    // Name:        Comp 1
    // Frame rate:  60 fps
    // Frame count: 180
    // Duration:    3000.0 mS
    public sealed class RamadanMubarak
        : Microsoft.UI.Xaml.Controls.IAnimatedVisualSource
    {
        // Animation duration: 3.000 seconds.
        internal const long c_durationTicks = 30000000;

        public Microsoft.UI.Xaml.Controls.IAnimatedVisual TryCreateAnimatedVisual(Compositor compositor)
        {
            object ignored = null;
            return TryCreateAnimatedVisual(compositor, out ignored);
        }

        public Microsoft.UI.Xaml.Controls.IAnimatedVisual TryCreateAnimatedVisual(Compositor compositor, out object diagnostics)
        {
            diagnostics = null;

            var res =
                new RamadanMubarak_AnimatedVisual(
                    compositor
                    );
            res.CreateAnimations();
            return res;
        }

        /// <summary>
        /// Gets the number of frames in the animation.
        /// </summary>
        public double FrameCount => 180d;

        /// <summary>
        /// Gets the frame rate of the animation.
        /// </summary>
        public double Framerate => 60d;

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
            return frameNumber / 180d;
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

        sealed class RamadanMubarak_AnimatedVisual : Microsoft.UI.Xaml.Controls.IAnimatedVisual2
        {
            const long c_durationTicks = 30000000;
            readonly Compositor _c;
            readonly ExpressionAnimation _reusableExpressionAnimation;
            CompositionColorBrush _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_0;
            CompositionColorBrush _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_1;
            CompositionColorBrush _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_2;
            CompositionColorBrush _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_3;
            CompositionColorBrush _colorBrush_AlmostGold_FFF8C900;
            CompositionColorBrush _colorBrush_AlmostMidnightBlue_FF002C5D;
            CompositionColorBrush _colorBrush_AlmostTeal_FF004DA5;
            CompositionColorBrush _colorBrush_AlmostTeal_FF004DA6;
            CompositionContainerShape _containerShape_0;
            CompositionContainerShape _containerShape_1;
            CompositionContainerShape _containerShape_2;
            CompositionContainerShape _containerShape_3;
            CompositionPath _path_0;
            CompositionPath _path_1;
            CompositionPathGeometry _pathGeometry_03;
            CompositionPathGeometry _pathGeometry_12;
            CompositionPathGeometry _pathGeometry_20;
            CompositionPathGeometry _pathGeometry_21;
            CompositionPathGeometry _pathGeometry_24;
            CompositionPathGeometry _pathGeometry_25;
            CompositionPathGeometry _pathGeometry_26;
            CompositionPathGeometry _pathGeometry_30;
            CompositionPathGeometry _pathGeometry_37;
            CompositionPathGeometry _pathGeometry_38;
            CompositionPathGeometry _pathGeometry_39;
            CompositionPathGeometry _pathGeometry_40;
            CompositionSpriteShape _spriteShape_55;
            CompositionSpriteShape _spriteShape_56;
            CompositionSpriteShape _spriteShape_57;
            CompositionSpriteShape _spriteShape_58;
            ContainerVisual _root;
            CubicBezierEasingFunction _cubicBezierEasingFunction_0;
            CubicBezierEasingFunction _cubicBezierEasingFunction_1;
            CubicBezierEasingFunction _cubicBezierEasingFunction_2;
            CubicBezierEasingFunction _cubicBezierEasingFunction_3;
            CubicBezierEasingFunction _cubicBezierEasingFunction_4;
            ExpressionAnimation _rootProgress;
            ScalarKeyFrameAnimation _scalarAnimation_0_to_1_0;
            ScalarKeyFrameAnimation _scalarAnimation_0_to_1_1;
            ScalarKeyFrameAnimation _scalarAnimation_0_to_1_2;
            StepEasingFunction _holdThenStepEasingFunction;
            StepEasingFunction _stepThenHoldEasingFunction;

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

            ColorKeyFrameAnimation CreateColorKeyFrameAnimation(float initialProgress, Color initialValue, CompositionEasingFunction initialEasingFunction)
            {
                var result = _c.CreateColorKeyFrameAnimation();
                result.Duration = TimeSpan.FromTicks(c_durationTicks);
                result.InterpolationColorSpace = CompositionColorSpace.Rgb;
                result.InsertKeyFrame(initialProgress, initialValue, initialEasingFunction);
                return result;
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

            CompositionSpriteShape CreateSpriteShape(CompositionGeometry geometry, Matrix3x2 transformMatrix, CompositionBrush fillBrush)
            {
                var result = _c.CreateSpriteShape(geometry);
                result.TransformMatrix = transformMatrix;
                result.FillBrush = fillBrush;
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 15 Offset:<28.453, 28.095>
            CanvasGeometry Geometry_00()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-24.7770004F, 16.6879997F));
                    builder.AddCubicBezier(new Vector2(-26.1369991F, 14.1049995F), new Vector2(-26.8899994F, 11.2650003F), new Vector2(-26.8899994F, 8.2840004F));
                    builder.AddCubicBezier(new Vector2(-26.8899994F, -3.64100003F), new Vector2(-14.8509998F, -16.6879997F), new Vector2(-0.00100000005F, -16.6879997F));
                    builder.AddCubicBezier(new Vector2(14.8500004F, -16.6879997F), new Vector2(26.8899994F, -3.64100003F), new Vector2(26.8899994F, 8.2840004F));
                    builder.AddCubicBezier(new Vector2(26.8899994F, 11.2650003F), new Vector2(26.1380005F, 14.1049995F), new Vector2(24.7770004F, 16.6879997F));
                    builder.AddLine(new Vector2(-24.7770004F, 16.6879997F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 14 Offset:<28.453, 11.095>
            CanvasGeometry Geometry_01()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(1.60699999F, 1.34399998F));
                    builder.AddLine(new Vector2(-1.60800004F, 1.34399998F));
                    builder.AddCubicBezier(new Vector2(-2.0079999F, 1.34399998F), new Vector2(-2.33200002F, 1.01900005F), new Vector2(-2.33200002F, 0.617999971F));
                    builder.AddLine(new Vector2(-2.33200002F, -0.619000018F));
                    builder.AddCubicBezier(new Vector2(-2.33200002F, -1.01900005F), new Vector2(-2.0079999F, -1.34399998F), new Vector2(-1.60800004F, -1.34399998F));
                    builder.AddLine(new Vector2(1.60599995F, -1.34399998F));
                    builder.AddCubicBezier(new Vector2(2.00699997F, -1.34399998F), new Vector2(2.33200002F, -1.01900005F), new Vector2(2.33200002F, -0.619000018F));
                    builder.AddLine(new Vector2(2.33200002F, 0.617999971F));
                    builder.AddCubicBezier(new Vector2(2.33200002F, 1.01900005F), new Vector2(2.00699997F, 1.34399998F), new Vector2(1.60699999F, 1.34399998F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 13 Offset:<28.453, 8.445>
            CanvasGeometry Geometry_02()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(1.60699999F, 1.34399998F));
                    builder.AddLine(new Vector2(-1.60800004F, 1.34399998F));
                    builder.AddCubicBezier(new Vector2(-2.0079999F, 1.34399998F), new Vector2(-2.33200002F, 1.01999998F), new Vector2(-2.33200002F, 0.619000018F));
                    builder.AddLine(new Vector2(-2.33200002F, -0.619000018F));
                    builder.AddCubicBezier(new Vector2(-2.33200002F, -1.01900005F), new Vector2(-2.0079999F, -1.34399998F), new Vector2(-1.60800004F, -1.34399998F));
                    builder.AddLine(new Vector2(1.60599995F, -1.34399998F));
                    builder.AddCubicBezier(new Vector2(2.00699997F, -1.34399998F), new Vector2(2.33200002F, -1.01900005F), new Vector2(2.33200002F, -0.619000018F));
                    builder.AddLine(new Vector2(2.33200002F, 0.619000018F));
                    builder.AddCubicBezier(new Vector2(2.33200002F, 1.01999998F), new Vector2(2.00699997F, 1.34399998F), new Vector2(1.60699999F, 1.34399998F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_03()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(2.81999993F, 24.7029991F));
                    builder.AddLine(new Vector2(-2.81999993F, 24.7029991F));
                    builder.AddLine(new Vector2(-2.81999993F, -24.7029991F));
                    builder.AddLine(new Vector2(2.81999993F, -24.7029991F));
                    builder.AddLine(new Vector2(2.81999993F, 24.7029991F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 11 Offset:<28.391, 133.232>
            CanvasGeometry Geometry_04()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(24.8649998F, -39.0419998F));
                    builder.AddLine(new Vector2(-24.8649998F, -39.0419998F));
                    builder.AddLine(new Vector2(-24.8649998F, 39.0419998F));
                    builder.AddLine(new Vector2(24.8649998F, 39.0419998F));
                    builder.AddLine(new Vector2(24.8649998F, -39.0419998F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 6 Offset:<28.452, 6.573>
            CanvasGeometry Geometry_05()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(0.690999985F, 1.45700002F));
                    builder.AddLine(new Vector2(-0.690999985F, 1.45700002F));
                    builder.AddLine(new Vector2(-0.690999985F, -1.45700002F));
                    builder.AddLine(new Vector2(0.690999985F, -1.45700002F));
                    builder.AddLine(new Vector2(0.690999985F, 1.45700002F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 5 Offset:<28.446, 3.044>
            CanvasGeometry Geometry_06()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(1.76999998F, 0F));
                    builder.AddCubicBezier(new Vector2(2.04299998F, 1.51900005F), new Vector2(1.69000006F, 2.79399991F), new Vector2(-0.00200000009F, 2.79399991F));
                    builder.AddCubicBezier(new Vector2(-1.48399997F, 2.79399991F), new Vector2(-2.04200006F, 1.51999998F), new Vector2(-1.77499998F, 0F));
                    builder.AddCubicBezier(new Vector2(-1.44400001F, -1.88300002F), new Vector2(-0.981000006F, -2.79399991F), new Vector2(-0.00200000009F, -2.79399991F));
                    builder.AddCubicBezier(new Vector2(0.976000011F, -2.79399991F), new Vector2(1.48000002F, -1.61199999F), new Vector2(1.76999998F, 0F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 4 Offset:<28.453, 114.182>
            CanvasGeometry Geometry_07()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-6.29799986F, 8.71399975F));
                    builder.AddLine(new Vector2(-6.29799986F, -2.85899997F));
                    builder.AddCubicBezier(new Vector2(-6.29799986F, -6.09299994F), new Vector2(-3.67799997F, -8.71399975F), new Vector2(-0.444000006F, -8.71399975F));
                    builder.AddLine(new Vector2(0.444000006F, -8.71399975F));
                    builder.AddCubicBezier(new Vector2(3.67700005F, -8.71399975F), new Vector2(6.29799986F, -6.09299994F), new Vector2(6.29799986F, -2.85899997F));
                    builder.AddLine(new Vector2(6.29799986F, 8.71399975F));
                    builder.AddLine(new Vector2(-6.29799986F, 8.71399975F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 3 Offset:<28.453, 141.256>
            CanvasGeometry Geometry_08()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-6.29799986F, 8.7130003F));
                    builder.AddLine(new Vector2(-6.29799986F, -2.8599999F));
                    builder.AddCubicBezier(new Vector2(-6.29799986F, -6.09299994F), new Vector2(-3.67799997F, -8.71399975F), new Vector2(-0.444000006F, -8.71399975F));
                    builder.AddLine(new Vector2(0.444000006F, -8.71399975F));
                    builder.AddCubicBezier(new Vector2(3.67700005F, -8.71399975F), new Vector2(6.29799986F, -6.09299994F), new Vector2(6.29799986F, -2.8599999F));
                    builder.AddLine(new Vector2(6.29799986F, 8.7130003F));
                    builder.AddLine(new Vector2(-6.29799986F, 8.7130003F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 2 Offset:<28.452, 44.087>
            CanvasGeometry Geometry_09()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(26.8120003F, 2.46199989F));
                    builder.AddLine(new Vector2(-26.8129997F, 2.46199989F));
                    builder.AddCubicBezier(new Vector2(-27.5809994F, 2.46199989F), new Vector2(-28.2019997F, 1.84000003F), new Vector2(-28.2019997F, 1.07200003F));
                    builder.AddLine(new Vector2(-28.2019997F, -1.07200003F));
                    builder.AddCubicBezier(new Vector2(-28.2019997F, -1.84099996F), new Vector2(-27.5809994F, -2.46199989F), new Vector2(-26.8129997F, -2.46199989F));
                    builder.AddLine(new Vector2(26.8120003F, -2.46199989F));
                    builder.AddCubicBezier(new Vector2(27.5809994F, -2.46199989F), new Vector2(28.2019997F, -1.84099996F), new Vector2(28.2019997F, -1.07200003F));
                    builder.AddLine(new Vector2(28.2019997F, 1.07200003F));
                    builder.AddCubicBezier(new Vector2(28.2019997F, 1.84000003F), new Vector2(27.5809994F, 2.46199989F), new Vector2(26.8120003F, 2.46199989F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 1 Offset:<28.452, 95.271>
            CanvasGeometry Geometry_10()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(26.8120003F, 2.46300006F));
                    builder.AddLine(new Vector2(-26.8129997F, 2.46300006F));
                    builder.AddCubicBezier(new Vector2(-27.5809994F, 2.46300006F), new Vector2(-28.2019997F, 1.84000003F), new Vector2(-28.2019997F, 1.07200003F));
                    builder.AddLine(new Vector2(-28.2019997F, -1.07200003F));
                    builder.AddCubicBezier(new Vector2(-28.2019997F, -1.84000003F), new Vector2(-27.5809994F, -2.46300006F), new Vector2(-26.8129997F, -2.46300006F));
                    builder.AddLine(new Vector2(26.8120003F, -2.46300006F));
                    builder.AddCubicBezier(new Vector2(27.5809994F, -2.46300006F), new Vector2(28.2019997F, -1.84000003F), new Vector2(28.2019997F, -1.07200003F));
                    builder.AddLine(new Vector2(28.2019997F, 1.07200003F));
                    builder.AddCubicBezier(new Vector2(28.2019997F, 1.84000003F), new Vector2(27.5809994F, 2.46300006F), new Vector2(26.8120003F, 2.46300006F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 9 Offset:<75.021, 84.332>
            CanvasGeometry Geometry_11()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-65.689003F, 44.2449989F));
                    builder.AddCubicBezier(new Vector2(-69.2959976F, 37.3959999F), new Vector2(-71.2929993F, 29.8670006F), new Vector2(-71.2929993F, 21.9619999F));
                    builder.AddCubicBezier(new Vector2(-71.2929993F, -9.65400028F), new Vector2(-39.3730011F, -44.2449989F), new Vector2(0.00100000005F, -44.2449989F));
                    builder.AddCubicBezier(new Vector2(39.375F, -44.2449989F), new Vector2(71.2929993F, -9.65400028F), new Vector2(71.2929993F, 21.9619999F));
                    builder.AddCubicBezier(new Vector2(71.2929993F, 29.8670006F), new Vector2(69.2979965F, 37.3959999F), new Vector2(65.6900024F, 44.2449989F));
                    builder.AddLine(new Vector2(-65.689003F, 44.2449989F));
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
                    builder.BeginFigure(new Vector2(4.26100016F, 3.56299996F));
                    builder.AddLine(new Vector2(-4.26100016F, 3.56299996F));
                    builder.AddCubicBezier(new Vector2(-5.32299995F, 3.56299996F), new Vector2(-6.18300009F, 2.7019999F), new Vector2(-6.18300009F, 1.64100003F));
                    builder.AddLine(new Vector2(-6.18300009F, -1.64100003F));
                    builder.AddCubicBezier(new Vector2(-6.18300009F, -2.70300007F), new Vector2(-5.32299995F, -3.56299996F), new Vector2(-4.26100016F, -3.56299996F));
                    builder.AddLine(new Vector2(4.26100016F, -3.56299996F));
                    builder.AddCubicBezier(new Vector2(5.32299995F, -3.56299996F), new Vector2(6.18300009F, -2.70300007F), new Vector2(6.18300009F, -1.64100003F));
                    builder.AddLine(new Vector2(6.18300009F, 1.64100003F));
                    builder.AddCubicBezier(new Vector2(6.18300009F, 2.7019999F), new Vector2(5.32299995F, 3.56299996F), new Vector2(4.26100016F, 3.56299996F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 6 Offset:<73.077, 15.857>
            CanvasGeometry Geometry_13()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-3.93199992F, 3.0079999F));
                    builder.AddCubicBezier(new Vector2(-8.02200031F, -3.07599998F), new Vector2(-6.59100008F, -11.2539997F), new Vector2(-0.796999991F, -15.6070004F));
                    builder.AddCubicBezier(new Vector2(-2.58200002F, -15.2250004F), new Vector2(-4.32499981F, -14.5030003F), new Vector2(-5.93200016F, -13.4230003F));
                    builder.AddCubicBezier(new Vector2(-12.6929998F, -8.87800026F), new Vector2(-14.4899998F, 0.287999988F), new Vector2(-9.94499969F, 7.05000019F));
                    builder.AddCubicBezier(new Vector2(-5.39900017F, 13.8109999F), new Vector2(3.76699996F, 15.6070004F), new Vector2(10.5290003F, 11.0620003F));
                    builder.AddCubicBezier(new Vector2(12.1350002F, 9.98099995F), new Vector2(13.4619999F, 8.63899994F), new Vector2(14.4899998F, 7.13100004F));
                    builder.AddCubicBezier(new Vector2(8.27200031F, 10.8529997F), new Vector2(0.158999994F, 9.09200001F), new Vector2(-3.93199992F, 3.0079999F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 5 Offset:<75.021, 244.485>
            CanvasGeometry Geometry_14()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(66.2979965F, -115.910004F));
                    builder.AddLine(new Vector2(-66.2979965F, -115.910004F));
                    builder.AddLine(new Vector2(-66.2979965F, 65.4639969F));
                    builder.AddLine(new Vector2(-34.2290001F, 65.4639969F));
                    builder.AddLine(new Vector2(-37.4109993F, 68.6460037F));
                    builder.AddLine(new Vector2(-34.6959991F, 71.3610001F));
                    builder.AddLine(new Vector2(-28.7989998F, 65.4639969F));
                    builder.AddLine(new Vector2(-27.8780003F, 65.4639969F));
                    builder.AddLine(new Vector2(-27.8780003F, 64.5429993F));
                    builder.AddLine(new Vector2(-22.5760002F, 59.2410011F));
                    builder.AddLine(new Vector2(-17.9130001F, 63.9020004F));
                    builder.AddLine(new Vector2(-37.4109993F, 83.401001F));
                    builder.AddLine(new Vector2(-34.6959991F, 86.1159973F));
                    builder.AddLine(new Vector2(-15.198F, 66.6169968F));
                    builder.AddLine(new Vector2(-10.4650002F, 71.3499985F));
                    builder.AddLine(new Vector2(-37.4109993F, 98.2969971F));
                    builder.AddLine(new Vector2(-34.6959991F, 101.013F));
                    builder.AddLine(new Vector2(-7.75F, 74.0650024F));
                    builder.AddLine(new Vector2(-3.01600003F, 78.7990036F));
                    builder.AddLine(new Vector2(-37.4109993F, 113.194F));
                    builder.AddLine(new Vector2(-34.6959991F, 115.908997F));
                    builder.AddLine(new Vector2(-0.300999999F, 81.5139999F));
                    builder.AddLine(new Vector2(34.0940018F, 115.908997F));
                    builder.AddLine(new Vector2(36.8089981F, 113.194F));
                    builder.AddLine(new Vector2(2.41400003F, 78.7990036F));
                    builder.AddLine(new Vector2(7.14699984F, 74.0650024F));
                    builder.AddLine(new Vector2(34.0940018F, 101.013F));
                    builder.AddLine(new Vector2(36.8089981F, 98.2969971F));
                    builder.AddLine(new Vector2(9.86200047F, 71.3499985F));
                    builder.AddLine(new Vector2(14.5950003F, 66.6169968F));
                    builder.AddLine(new Vector2(34.0940018F, 86.1159973F));
                    builder.AddLine(new Vector2(36.8089981F, 83.401001F));
                    builder.AddLine(new Vector2(17.3099995F, 63.9020004F));
                    builder.AddLine(new Vector2(21.9729996F, 59.2410011F));
                    builder.AddLine(new Vector2(27.8780003F, 65.1460037F));
                    builder.AddLine(new Vector2(27.8780003F, 65.4639969F));
                    builder.AddLine(new Vector2(28.1970005F, 65.4639969F));
                    builder.AddLine(new Vector2(34.0940018F, 71.3610001F));
                    builder.AddLine(new Vector2(36.8089981F, 68.6460037F));
                    builder.AddLine(new Vector2(33.6259995F, 65.4639969F));
                    builder.AddLine(new Vector2(66.2979965F, 65.4639969F));
                    builder.AddLine(new Vector2(66.2979965F, -115.910004F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-0.300999999F, -7.7249999F));
                    builder.AddLine(new Vector2(4.43200016F, -2.9920001F));
                    builder.AddLine(new Vector2(-0.300999999F, 1.74300003F));
                    builder.AddLine(new Vector2(-5.03499985F, -2.9920001F));
                    builder.AddLine(new Vector2(-0.300999999F, -7.7249999F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-7.75F, -5.70499992F));
                    builder.AddLine(new Vector2(-12.4829998F, -10.4390001F));
                    builder.AddLine(new Vector2(-7.75F, -15.1730003F));
                    builder.AddLine(new Vector2(-3.01600003F, -10.4390001F));
                    builder.AddLine(new Vector2(-7.75F, -5.70499992F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(2.41400003F, -10.4390001F));
                    builder.AddLine(new Vector2(7.14699984F, -15.1730003F));
                    builder.AddLine(new Vector2(11.8809996F, -10.4390001F));
                    builder.AddLine(new Vector2(7.14699984F, -5.70499992F));
                    builder.AddLine(new Vector2(2.41400003F, -10.4390001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-0.300999999F, -13.1540003F));
                    builder.AddLine(new Vector2(-5.03499985F, -17.8889999F));
                    builder.AddLine(new Vector2(-0.300999999F, -22.6219997F));
                    builder.AddLine(new Vector2(4.43200016F, -17.8889999F));
                    builder.AddLine(new Vector2(-0.300999999F, -13.1540003F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-7.75F, -20.6040001F));
                    builder.AddLine(new Vector2(-12.4829998F, -25.3369999F));
                    builder.AddLine(new Vector2(-7.75F, -30.0699997F));
                    builder.AddLine(new Vector2(-3.01600003F, -25.3369999F));
                    builder.AddLine(new Vector2(-7.75F, -20.6040001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-10.4650002F, -17.8889999F));
                    builder.AddLine(new Vector2(-15.198F, -13.1540003F));
                    builder.AddLine(new Vector2(-19.9319992F, -17.8889999F));
                    builder.AddLine(new Vector2(-15.198F, -22.6219997F));
                    builder.AddLine(new Vector2(-10.4650002F, -17.8889999F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-17.9130001F, -10.4390001F));
                    builder.AddLine(new Vector2(-22.6459999F, -5.70499992F));
                    builder.AddLine(new Vector2(-27.3799992F, -10.4390001F));
                    builder.AddLine(new Vector2(-22.6459999F, -15.1730003F));
                    builder.AddLine(new Vector2(-17.9130001F, -10.4390001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-15.198F, -7.7249999F));
                    builder.AddLine(new Vector2(-10.4650002F, -2.9920001F));
                    builder.AddLine(new Vector2(-15.198F, 1.74300003F));
                    builder.AddLine(new Vector2(-19.9319992F, -2.9920001F));
                    builder.AddLine(new Vector2(-15.198F, -7.7249999F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-7.75F, -0.275999993F));
                    builder.AddLine(new Vector2(-3.01600003F, 4.45800018F));
                    builder.AddLine(new Vector2(-7.75F, 9.18999958F));
                    builder.AddLine(new Vector2(-12.4829998F, 4.45800018F));
                    builder.AddLine(new Vector2(-7.75F, -0.275999993F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-0.300999999F, 7.17199993F));
                    builder.AddLine(new Vector2(4.43200016F, 11.9060001F));
                    builder.AddLine(new Vector2(-0.300999999F, 16.6380005F));
                    builder.AddLine(new Vector2(-5.03499985F, 11.9060001F));
                    builder.AddLine(new Vector2(-0.300999999F, 7.17199993F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(2.41400003F, 4.45800018F));
                    builder.AddLine(new Vector2(7.14699984F, -0.275999993F));
                    builder.AddLine(new Vector2(11.8809996F, 4.45800018F));
                    builder.AddLine(new Vector2(7.14699984F, 9.18999958F));
                    builder.AddLine(new Vector2(2.41400003F, 4.45800018F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(9.86200047F, -2.9920001F));
                    builder.AddLine(new Vector2(14.5959997F, -7.7249999F));
                    builder.AddLine(new Vector2(19.3299999F, -2.9920001F));
                    builder.AddLine(new Vector2(14.5950003F, 1.74300003F));
                    builder.AddLine(new Vector2(9.86200047F, -2.9920001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(17.3110008F, -10.4390001F));
                    builder.AddLine(new Vector2(22.0440006F, -15.1730003F));
                    builder.AddLine(new Vector2(26.7779999F, -10.4390001F));
                    builder.AddLine(new Vector2(22.0440006F, -5.70499992F));
                    builder.AddLine(new Vector2(17.3110008F, -10.4390001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(14.5959997F, -13.1540003F));
                    builder.AddLine(new Vector2(9.86200047F, -17.8889999F));
                    builder.AddLine(new Vector2(14.5950003F, -22.6219997F));
                    builder.AddLine(new Vector2(19.3299999F, -17.8889999F));
                    builder.AddLine(new Vector2(14.5959997F, -13.1540003F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(7.14699984F, -20.6040001F));
                    builder.AddLine(new Vector2(2.41400003F, -25.3369999F));
                    builder.AddLine(new Vector2(7.14699984F, -30.0699997F));
                    builder.AddLine(new Vector2(11.8809996F, -25.3369999F));
                    builder.AddLine(new Vector2(7.14699984F, -20.6040001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-0.300999999F, -28.0510006F));
                    builder.AddLine(new Vector2(-5.03499985F, -32.7849998F));
                    builder.AddLine(new Vector2(-0.300999999F, -37.5180016F));
                    builder.AddLine(new Vector2(4.43200016F, -32.7849998F));
                    builder.AddLine(new Vector2(-0.300999999F, -28.0510006F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-7.75F, -35.4990005F));
                    builder.AddLine(new Vector2(-12.4829998F, -40.2340012F));
                    builder.AddLine(new Vector2(-7.75F, -44.9669991F));
                    builder.AddLine(new Vector2(-3.01600003F, -40.2340012F));
                    builder.AddLine(new Vector2(-7.75F, -35.4990005F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-10.4639997F, -32.7849998F));
                    builder.AddLine(new Vector2(-15.198F, -28.0510006F));
                    builder.AddLine(new Vector2(-19.9319992F, -32.7849998F));
                    builder.AddLine(new Vector2(-15.198F, -37.5200005F));
                    builder.AddLine(new Vector2(-10.4639997F, -32.7849998F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-17.9130001F, -25.3369999F));
                    builder.AddLine(new Vector2(-22.6459999F, -20.6019993F));
                    builder.AddLine(new Vector2(-27.3799992F, -25.3369999F));
                    builder.AddLine(new Vector2(-22.6469994F, -30.0699997F));
                    builder.AddLine(new Vector2(-17.9130001F, -25.3369999F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-25.3610001F, -17.8889999F));
                    builder.AddLine(new Vector2(-27.8780003F, -15.3699999F));
                    builder.AddLine(new Vector2(-27.8780003F, -20.4060001F));
                    builder.AddLine(new Vector2(-25.3610001F, -17.8889999F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-25.3610001F, -2.9920001F));
                    builder.AddLine(new Vector2(-27.8780003F, -0.474999994F));
                    builder.AddLine(new Vector2(-27.8780003F, -5.5079999F));
                    builder.AddLine(new Vector2(-25.3610001F, -2.9920001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-27.3799992F, 4.45800018F));
                    builder.AddLine(new Vector2(-22.6459999F, -0.275999993F));
                    builder.AddLine(new Vector2(-17.9130001F, 4.45800018F));
                    builder.AddLine(new Vector2(-22.6459999F, 9.18999958F));
                    builder.AddLine(new Vector2(-27.3799992F, 4.45800018F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-25.3610001F, 11.9060001F));
                    builder.AddLine(new Vector2(-27.8780003F, 14.4219999F));
                    builder.AddLine(new Vector2(-27.8780003F, 9.38700008F));
                    builder.AddLine(new Vector2(-25.3610001F, 11.9060001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-15.198F, 7.17199993F));
                    builder.AddLine(new Vector2(-10.4639997F, 11.9060001F));
                    builder.AddLine(new Vector2(-15.198F, 16.6380005F));
                    builder.AddLine(new Vector2(-19.9319992F, 11.9060001F));
                    builder.AddLine(new Vector2(-15.198F, 7.17199993F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-7.75F, 14.6199999F));
                    builder.AddLine(new Vector2(-3.01600003F, 19.3540001F));
                    builder.AddLine(new Vector2(-7.75F, 24.0869999F));
                    builder.AddLine(new Vector2(-12.4829998F, 19.3540001F));
                    builder.AddLine(new Vector2(-7.75F, 14.6199999F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-0.300999999F, 22.0680008F));
                    builder.AddLine(new Vector2(4.43200016F, 26.802F));
                    builder.AddLine(new Vector2(-0.300999999F, 31.5349998F));
                    builder.AddLine(new Vector2(-5.03499985F, 26.802F));
                    builder.AddLine(new Vector2(-0.300999999F, 22.0680008F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(2.41400003F, 19.3540001F));
                    builder.AddLine(new Vector2(7.14699984F, 14.6199999F));
                    builder.AddLine(new Vector2(11.8800001F, 19.3540001F));
                    builder.AddLine(new Vector2(7.14699984F, 24.0869999F));
                    builder.AddLine(new Vector2(2.41400003F, 19.3540001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(9.86200047F, 11.9060001F));
                    builder.AddLine(new Vector2(14.5950003F, 7.17199993F));
                    builder.AddLine(new Vector2(19.3290005F, 11.9060001F));
                    builder.AddLine(new Vector2(14.5950003F, 16.6380005F));
                    builder.AddLine(new Vector2(9.86200047F, 11.9060001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(17.3099995F, 4.45800018F));
                    builder.AddLine(new Vector2(22.0440006F, -0.275999993F));
                    builder.AddLine(new Vector2(26.7779999F, 4.45800018F));
                    builder.AddLine(new Vector2(22.0440006F, 9.18999958F));
                    builder.AddLine(new Vector2(17.3099995F, 4.45800018F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(27.8780003F, 8.78499985F));
                    builder.AddLine(new Vector2(27.8780003F, 15.026F));
                    builder.AddLine(new Vector2(24.7579994F, 11.9060001F));
                    builder.AddLine(new Vector2(27.8780003F, 8.78499985F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(24.7590008F, -2.9920001F));
                    builder.AddLine(new Vector2(27.8780003F, -6.11100006F));
                    builder.AddLine(new Vector2(27.8780003F, 0.129999995F));
                    builder.AddLine(new Vector2(24.7590008F, -2.9920001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(24.7590008F, -17.8889999F));
                    builder.AddLine(new Vector2(27.8780003F, -21.007F));
                    builder.AddLine(new Vector2(27.8780003F, -14.7679996F));
                    builder.AddLine(new Vector2(24.7590008F, -17.8889999F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(22.0440006F, -20.6019993F));
                    builder.AddLine(new Vector2(17.3099995F, -25.3369999F));
                    builder.AddLine(new Vector2(22.0440006F, -30.0699997F));
                    builder.AddLine(new Vector2(26.7779999F, -25.3369999F));
                    builder.AddLine(new Vector2(22.0440006F, -20.6019993F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(14.5950003F, -28.0510006F));
                    builder.AddLine(new Vector2(9.86200047F, -32.7849998F));
                    builder.AddLine(new Vector2(14.5950003F, -37.5200005F));
                    builder.AddLine(new Vector2(19.3299999F, -32.7849998F));
                    builder.AddLine(new Vector2(14.5950003F, -28.0510006F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(7.14699984F, -35.4990005F));
                    builder.AddLine(new Vector2(2.41400003F, -40.2340012F));
                    builder.AddLine(new Vector2(7.14699984F, -44.9669991F));
                    builder.AddLine(new Vector2(11.8809996F, -40.2340012F));
                    builder.AddLine(new Vector2(7.14699984F, -35.4990005F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-0.300999999F, -42.9490013F));
                    builder.AddLine(new Vector2(-5.03499985F, -47.6819992F));
                    builder.AddLine(new Vector2(-0.300999999F, -52.4150009F));
                    builder.AddLine(new Vector2(4.43200016F, -47.6819992F));
                    builder.AddLine(new Vector2(-0.300999999F, -42.9490013F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-7.75F, -50.3969994F));
                    builder.AddLine(new Vector2(-12.4829998F, -55.1300011F));
                    builder.AddLine(new Vector2(-7.75F, -59.8650017F));
                    builder.AddLine(new Vector2(-3.01600003F, -55.1300011F));
                    builder.AddLine(new Vector2(-7.75F, -50.3969994F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-10.4650002F, -47.6819992F));
                    builder.AddLine(new Vector2(-15.198F, -42.9490013F));
                    builder.AddLine(new Vector2(-19.9319992F, -47.6819992F));
                    builder.AddLine(new Vector2(-15.198F, -52.4150009F));
                    builder.AddLine(new Vector2(-10.4650002F, -47.6819992F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-17.9130001F, -40.2340012F));
                    builder.AddLine(new Vector2(-22.6469994F, -35.4990005F));
                    builder.AddLine(new Vector2(-27.3799992F, -40.2340012F));
                    builder.AddLine(new Vector2(-22.6459999F, -44.9669991F));
                    builder.AddLine(new Vector2(-17.9130001F, -40.2340012F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-25.3619995F, -32.7849998F));
                    builder.AddLine(new Vector2(-27.8780003F, -30.2700005F));
                    builder.AddLine(new Vector2(-27.8780003F, -35.3009987F));
                    builder.AddLine(new Vector2(-25.3619995F, -32.7849998F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-27.8780003F, 24.1429996F));
                    builder.AddLine(new Vector2(-25.2900009F, 26.7320004F));
                    builder.AddLine(new Vector2(-27.8780003F, 29.3199997F));
                    builder.AddLine(new Vector2(-27.8780003F, 24.1429996F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-27.309F, 19.2840004F));
                    builder.AddLine(new Vector2(-22.6459999F, 14.6199999F));
                    builder.AddLine(new Vector2(-17.9130001F, 19.3540001F));
                    builder.AddLine(new Vector2(-22.5750008F, 24.0170002F));
                    builder.AddLine(new Vector2(-27.309F, 19.2840004F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-15.198F, 22.0680008F));
                    builder.AddLine(new Vector2(-10.4639997F, 26.802F));
                    builder.AddLine(new Vector2(-15.1269999F, 31.4650002F));
                    builder.AddLine(new Vector2(-19.8600006F, 26.7320004F));
                    builder.AddLine(new Vector2(-15.198F, 22.0680008F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-7.75F, 29.5170002F));
                    builder.AddLine(new Vector2(-3.01600003F, 34.25F));
                    builder.AddLine(new Vector2(-7.6789999F, 38.9140015F));
                    builder.AddLine(new Vector2(-12.4119997F, 34.1800003F));
                    builder.AddLine(new Vector2(-7.75F, 29.5170002F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-0.300999999F, 36.9650002F));
                    builder.AddLine(new Vector2(4.36199999F, 41.6290016F));
                    builder.AddLine(new Vector2(-0.300999999F, 46.2919998F));
                    builder.AddLine(new Vector2(-4.96400023F, 41.6290016F));
                    builder.AddLine(new Vector2(-0.300999999F, 36.9650002F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(2.41400003F, 34.25F));
                    builder.AddLine(new Vector2(7.14699984F, 29.5170002F));
                    builder.AddLine(new Vector2(11.8100004F, 34.1800003F));
                    builder.AddLine(new Vector2(7.07700014F, 38.9140015F));
                    builder.AddLine(new Vector2(2.41400003F, 34.25F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(9.86200047F, 26.802F));
                    builder.AddLine(new Vector2(14.5950003F, 22.0680008F));
                    builder.AddLine(new Vector2(19.2579994F, 26.7320004F));
                    builder.AddLine(new Vector2(14.5249996F, 31.4650002F));
                    builder.AddLine(new Vector2(9.86200047F, 26.802F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(17.3099995F, 19.3540001F));
                    builder.AddLine(new Vector2(22.0440006F, 14.6199999F));
                    builder.AddLine(new Vector2(26.7070007F, 19.2840004F));
                    builder.AddLine(new Vector2(21.9729996F, 24.0170002F));
                    builder.AddLine(new Vector2(17.3099995F, 19.3540001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(27.8780003F, 23.5400009F));
                    builder.AddLine(new Vector2(27.8780003F, 29.9220009F));
                    builder.AddLine(new Vector2(24.6879997F, 26.7320004F));
                    builder.AddLine(new Vector2(27.8780003F, 23.5400009F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(27.8780003F, -29.6650009F));
                    builder.AddLine(new Vector2(24.7590008F, -32.7849998F));
                    builder.AddLine(new Vector2(27.8780003F, -35.9059982F));
                    builder.AddLine(new Vector2(27.8780003F, -29.6650009F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(22.0440006F, -35.4990005F));
                    builder.AddLine(new Vector2(17.3099995F, -40.2340012F));
                    builder.AddLine(new Vector2(22.0440006F, -44.9669991F));
                    builder.AddLine(new Vector2(26.7779999F, -40.2340012F));
                    builder.AddLine(new Vector2(22.0440006F, -35.4990005F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(14.5950003F, -42.9490013F));
                    builder.AddLine(new Vector2(9.86200047F, -47.6819992F));
                    builder.AddLine(new Vector2(14.5950003F, -52.4150009F));
                    builder.AddLine(new Vector2(19.3299999F, -47.6819992F));
                    builder.AddLine(new Vector2(14.5950003F, -42.9490013F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(7.14699984F, -50.3969994F));
                    builder.AddLine(new Vector2(2.41400003F, -55.1300011F));
                    builder.AddLine(new Vector2(7.14699984F, -59.8650017F));
                    builder.AddLine(new Vector2(11.8809996F, -55.1300011F));
                    builder.AddLine(new Vector2(7.14699984F, -50.3969994F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-0.300999999F, -57.8460007F));
                    builder.AddLine(new Vector2(-5.03499985F, -62.5779991F));
                    builder.AddLine(new Vector2(-0.300999999F, -67.3130035F));
                    builder.AddLine(new Vector2(4.43200016F, -62.5779991F));
                    builder.AddLine(new Vector2(-0.300999999F, -57.8460007F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-3.01600003F, -70.0270004F));
                    builder.AddLine(new Vector2(-7.75F, -65.2939987F));
                    builder.AddLine(new Vector2(-12.0249996F, -69.5699997F));
                    builder.AddCubicBezier(new Vector2(-9.6619997F, -70.5660019F), new Vector2(-7.11899996F, -71.2170029F), new Vector2(-4.45900011F, -71.4710007F));
                    builder.AddLine(new Vector2(-3.01600003F, -70.0270004F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-10.4639997F, -62.5779991F));
                    builder.AddLine(new Vector2(-15.198F, -57.8460007F));
                    builder.AddLine(new Vector2(-20.7980003F, -63.4469986F));
                    builder.AddCubicBezier(new Vector2(-19.2560005F, -65.0810013F), new Vector2(-17.5049992F, -66.5080032F), new Vector2(-15.5839996F, -67.6989975F));
                    builder.AddLine(new Vector2(-10.4639997F, -62.5779991F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-17.9130001F, -55.1300011F));
                    builder.AddLine(new Vector2(-22.6459999F, -50.3969994F));
                    builder.AddLine(new Vector2(-26.4249992F, -54.1759987F));
                    builder.AddCubicBezier(new Vector2(-25.6439991F, -56.4249992F), new Vector2(-24.5750008F, -58.5369987F), new Vector2(-23.2399998F, -60.4560013F));
                    builder.AddLine(new Vector2(-17.9130001F, -55.1300011F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-25.3610001F, -47.6819992F));
                    builder.AddLine(new Vector2(-27.8780003F, -45.1650009F));
                    builder.AddLine(new Vector2(-27.8780003F, -45.6839981F));
                    builder.AddCubicBezier(new Vector2(-27.8780003F, -47.1010017F), new Vector2(-27.7339993F, -48.480999F), new Vector2(-27.5149994F, -49.8349991F));
                    builder.AddLine(new Vector2(-25.3610001F, -47.6819992F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-27.8780003F, 39.0400009F));
                    builder.AddLine(new Vector2(-25.2900009F, 41.6290016F));
                    builder.AddLine(new Vector2(-27.8780003F, 44.2159996F));
                    builder.AddLine(new Vector2(-27.8780003F, 39.0400009F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-27.309F, 34.1800003F));
                    builder.AddLine(new Vector2(-22.5750008F, 29.4470005F));
                    builder.AddLine(new Vector2(-17.8419991F, 34.1800003F));
                    builder.AddLine(new Vector2(-22.5750008F, 38.9140015F));
                    builder.AddLine(new Vector2(-27.309F, 34.1800003F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-15.1269999F, 36.8950005F));
                    builder.AddLine(new Vector2(-10.3940001F, 41.6290016F));
                    builder.AddLine(new Vector2(-15.1269999F, 46.3619995F));
                    builder.AddLine(new Vector2(-19.8600006F, 41.6290016F));
                    builder.AddLine(new Vector2(-15.1269999F, 36.8950005F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-7.6789999F, 44.3419991F));
                    builder.AddLine(new Vector2(-3.01600003F, 49.0050011F));
                    builder.AddLine(new Vector2(-7.75F, 53.7400017F));
                    builder.AddLine(new Vector2(-12.4119997F, 49.0769997F));
                    builder.AddLine(new Vector2(-7.6789999F, 44.3419991F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-0.300999999F, 51.7210007F));
                    builder.AddLine(new Vector2(4.43200016F, 56.4539986F));
                    builder.AddLine(new Vector2(-0.300999999F, 61.1879997F));
                    builder.AddLine(new Vector2(-5.03499985F, 56.4539986F));
                    builder.AddLine(new Vector2(-0.300999999F, 51.7210007F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(2.41400003F, 49.0050011F));
                    builder.AddLine(new Vector2(7.07700014F, 44.3419991F));
                    builder.AddLine(new Vector2(11.8100004F, 49.0769997F));
                    builder.AddLine(new Vector2(7.14699984F, 53.7400017F));
                    builder.AddLine(new Vector2(2.41400003F, 49.0050011F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(9.79199982F, 41.6290016F));
                    builder.AddLine(new Vector2(14.5249996F, 36.8950005F));
                    builder.AddLine(new Vector2(19.2579994F, 41.6290016F));
                    builder.AddLine(new Vector2(14.5249996F, 46.3619995F));
                    builder.AddLine(new Vector2(9.79199982F, 41.6290016F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(17.2399998F, 34.1800003F));
                    builder.AddLine(new Vector2(21.9729996F, 29.4470005F));
                    builder.AddLine(new Vector2(26.7070007F, 34.1800003F));
                    builder.AddLine(new Vector2(21.9729996F, 38.9140015F));
                    builder.AddLine(new Vector2(17.2399998F, 34.1800003F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(27.8780003F, 38.4360008F));
                    builder.AddLine(new Vector2(27.8780003F, 44.8199997F));
                    builder.AddLine(new Vector2(24.6879997F, 41.6290016F));
                    builder.AddLine(new Vector2(27.8780003F, 38.4360008F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(27.8780003F, -45.6839981F));
                    builder.AddLine(new Vector2(27.8780003F, -44.5629997F));
                    builder.AddLine(new Vector2(24.7590008F, -47.6819992F));
                    builder.AddLine(new Vector2(27.4360008F, -50.3590012F));
                    builder.AddCubicBezier(new Vector2(27.7129993F, -48.8400002F), new Vector2(27.8780003F, -47.2830009F), new Vector2(27.8780003F, -45.6839981F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(26.2639999F, -54.618F));
                    builder.AddLine(new Vector2(22.0440006F, -50.3969994F));
                    builder.AddLine(new Vector2(17.3110008F, -55.1300011F));
                    builder.AddLine(new Vector2(22.9820004F, -60.8030014F));
                    builder.AddCubicBezier(new Vector2(24.3419991F, -58.9150009F), new Vector2(25.448F, -56.8380013F), new Vector2(26.2639999F, -54.618F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(20.5119991F, -63.762001F));
                    builder.AddLine(new Vector2(14.5950003F, -57.8460007F));
                    builder.AddLine(new Vector2(9.86200047F, -62.5779991F));
                    builder.AddLine(new Vector2(15.21F, -67.9260025F));
                    builder.AddCubicBezier(new Vector2(17.1550007F, -66.7659988F), new Vector2(18.941F, -65.3740005F), new Vector2(20.5119991F, -63.762001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(11.5839996F, -69.7320023F));
                    builder.AddLine(new Vector2(7.14699984F, -65.2939987F));
                    builder.AddLine(new Vector2(2.41400003F, -70.0270004F));
                    builder.AddLine(new Vector2(3.88499999F, -71.4990005F));
                    builder.AddCubicBezier(new Vector2(6.58799982F, -71.3010025F), new Vector2(9.17500019F, -70.6969986F), new Vector2(11.5839996F, -69.7320023F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-27.8780003F, 59.1119995F));
                    builder.AddLine(new Vector2(-27.8780003F, 53.9379997F));
                    builder.AddLine(new Vector2(-25.2910004F, 56.526001F));
                    builder.AddLine(new Vector2(-27.8780003F, 59.1119995F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-27.309F, 49.0779991F));
                    builder.AddLine(new Vector2(-22.5750008F, 44.3419991F));
                    builder.AddLine(new Vector2(-17.8419991F, 49.0769997F));
                    builder.AddLine(new Vector2(-22.5760002F, 53.8100014F));
                    builder.AddLine(new Vector2(-27.309F, 49.0779991F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-19.8610001F, 56.526001F));
                    builder.AddLine(new Vector2(-15.1269999F, 51.7919998F));
                    builder.AddLine(new Vector2(-10.4639997F, 56.4539986F));
                    builder.AddLine(new Vector2(-15.198F, 61.1879997F));
                    builder.AddLine(new Vector2(-19.8610001F, 56.526001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-12.4829998F, 63.9020004F));
                    builder.AddLine(new Vector2(-7.75F, 59.1689987F));
                    builder.AddLine(new Vector2(-3.01600003F, 63.9020004F));
                    builder.AddLine(new Vector2(-7.75F, 68.6350021F));
                    builder.AddLine(new Vector2(-12.4829998F, 63.9020004F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-0.300999999F, 76.0859985F));
                    builder.AddLine(new Vector2(-5.03499985F, 71.3499985F));
                    builder.AddLine(new Vector2(-0.300999999F, 66.6169968F));
                    builder.AddLine(new Vector2(4.43200016F, 71.3499985F));
                    builder.AddLine(new Vector2(-0.300999999F, 76.0859985F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(7.14699984F, 68.6350021F));
                    builder.AddLine(new Vector2(2.41400003F, 63.9020004F));
                    builder.AddLine(new Vector2(7.14699984F, 59.1689987F));
                    builder.AddLine(new Vector2(11.8809996F, 63.9020004F));
                    builder.AddLine(new Vector2(7.14699984F, 68.6350021F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(14.5950003F, 61.1879997F));
                    builder.AddLine(new Vector2(9.86200047F, 56.4539986F));
                    builder.AddLine(new Vector2(14.5249996F, 51.7919998F));
                    builder.AddLine(new Vector2(19.2579994F, 56.526001F));
                    builder.AddLine(new Vector2(14.5950003F, 61.1879997F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(17.2399998F, 49.0769997F));
                    builder.AddLine(new Vector2(21.9729996F, 44.3419991F));
                    builder.AddLine(new Vector2(26.7070007F, 49.0779991F));
                    builder.AddLine(new Vector2(21.9729996F, 53.8100014F));
                    builder.AddLine(new Vector2(17.2399998F, 49.0769997F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(24.6879997F, 56.526001F));
                    builder.AddLine(new Vector2(27.8780003F, 53.3349991F));
                    builder.AddLine(new Vector2(27.8780003F, 59.7159996F));
                    builder.AddLine(new Vector2(24.6879997F, 56.526001F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 4 Offset:<75.021, 126.732>
            CanvasGeometry Geometry_15()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(71.0859985F, 6.52899981F));
                    builder.AddLine(new Vector2(-71.0859985F, 6.52899981F));
                    builder.AddCubicBezier(new Vector2(-73.1220016F, 6.52899981F), new Vector2(-74.7710037F, 4.87900019F), new Vector2(-74.7710037F, 2.84200001F));
                    builder.AddLine(new Vector2(-74.7710037F, -2.84299994F));
                    builder.AddCubicBezier(new Vector2(-74.7710037F, -4.87900019F), new Vector2(-73.1220016F, -6.52899981F), new Vector2(-71.0859985F, -6.52899981F));
                    builder.AddLine(new Vector2(71.0859985F, -6.52899981F));
                    builder.AddCubicBezier(new Vector2(73.1210022F, -6.52899981F), new Vector2(74.7710037F, -4.87900019F), new Vector2(74.7710037F, -2.84299994F));
                    builder.AddLine(new Vector2(74.7710037F, 2.84200001F));
                    builder.AddCubicBezier(new Vector2(74.7710037F, 4.87900019F), new Vector2(73.1210022F, 6.52899981F), new Vector2(71.0859985F, 6.52899981F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 3
            CanvasGeometry Geometry_16()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(13.9969997F, 140.975006F));
                    builder.AddLine(new Vector2(136.151993F, 140.975006F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 3
            CanvasGeometry Geometry_17()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(13.9969997F, 152.041F));
                    builder.AddLine(new Vector2(136.151993F, 152.041F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 3
            CanvasGeometry Geometry_18()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.BeginFigure(new Vector2(13.9969997F, 163.106995F));
                    builder.AddLine(new Vector2(136.151993F, 163.106995F));
                    builder.EndFigure(CanvasFigureLoop.Open);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 26 Offset:<23.52, 23.225>
            CanvasGeometry Geometry_19()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-20.4430008F, 13.7690001F));
                    builder.AddCubicBezier(new Vector2(-21.566F, 11.6370001F), new Vector2(-22.1870003F, 9.29399967F), new Vector2(-22.1870003F, 6.83400011F));
                    builder.AddCubicBezier(new Vector2(-22.1870003F, -3.00500011F), new Vector2(-12.2530003F, -13.7690001F), new Vector2(0F, -13.7690001F));
                    builder.AddCubicBezier(new Vector2(12.2539997F, -13.7690001F), new Vector2(22.1870003F, -3.00500011F), new Vector2(22.1870003F, 6.83400011F));
                    builder.AddCubicBezier(new Vector2(22.1870003F, 9.29399967F), new Vector2(21.5669994F, 11.6370001F), new Vector2(20.4440002F, 13.7690001F));
                    builder.AddLine(new Vector2(-20.4430008F, 13.7690001F));
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
                    builder.BeginFigure(new Vector2(1.32599998F, 1.10899997F));
                    builder.AddLine(new Vector2(-1.32599998F, 1.10899997F));
                    builder.AddCubicBezier(new Vector2(-1.65600002F, 1.10899997F), new Vector2(-1.92400002F, 0.841000021F), new Vector2(-1.92400002F, 0.510999978F));
                    builder.AddLine(new Vector2(-1.92400002F, -0.510999978F));
                    builder.AddCubicBezier(new Vector2(-1.92400002F, -0.841000021F), new Vector2(-1.65600002F, -1.10899997F), new Vector2(-1.32599998F, -1.10899997F));
                    builder.AddLine(new Vector2(1.32599998F, -1.10899997F));
                    builder.AddCubicBezier(new Vector2(1.65699995F, -1.10899997F), new Vector2(1.92400002F, -0.841000021F), new Vector2(1.92400002F, -0.510999978F));
                    builder.AddLine(new Vector2(1.92400002F, 0.510999978F));
                    builder.AddCubicBezier(new Vector2(1.92400002F, 0.841000021F), new Vector2(1.65699995F, 1.10899997F), new Vector2(1.32599998F, 1.10899997F));
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
                    builder.BeginFigure(new Vector2(2.3269999F, 20.382F));
                    builder.AddLine(new Vector2(-2.3269999F, 20.382F));
                    builder.AddLine(new Vector2(-2.3269999F, -20.382F));
                    builder.AddLine(new Vector2(2.3269999F, -20.382F));
                    builder.AddLine(new Vector2(2.3269999F, 20.382F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 22 Offset:<23.469, 95.161>
            CanvasGeometry Geometry_22()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(20.5170002F, -17.3999996F));
                    builder.AddLine(new Vector2(-20.5170002F, -17.3999996F));
                    builder.AddLine(new Vector2(-20.5170002F, 17.3999996F));
                    builder.AddLine(new Vector2(20.5170002F, 17.3999996F));
                    builder.AddLine(new Vector2(20.5170002F, -17.3999996F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 21 Offset:<23.469, 187.045>
            CanvasGeometry Geometry_23()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(20.5170002F, -46.8740005F));
                    builder.AddLine(new Vector2(-20.5170002F, -46.8740005F));
                    builder.AddLine(new Vector2(-20.5170002F, 46.8740005F));
                    builder.AddLine(new Vector2(20.5170002F, 46.8740005F));
                    builder.AddLine(new Vector2(20.5170002F, -46.8740005F));
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
                    builder.BeginFigure(new Vector2(22.1229992F, 2.0309999F));
                    builder.AddLine(new Vector2(-22.1229992F, 2.0309999F));
                    builder.AddCubicBezier(new Vector2(-22.7560005F, 2.0309999F), new Vector2(-23.2700005F, 1.51800001F), new Vector2(-23.2700005F, 0.88499999F));
                    builder.AddLine(new Vector2(-23.2700005F, -0.884000003F));
                    builder.AddCubicBezier(new Vector2(-23.2700005F, -1.51800001F), new Vector2(-22.7560005F, -2.0309999F), new Vector2(-22.1229992F, -2.0309999F));
                    builder.AddLine(new Vector2(22.1229992F, -2.0309999F));
                    builder.AddCubicBezier(new Vector2(22.7560005F, -2.0309999F), new Vector2(23.2700005F, -1.51800001F), new Vector2(23.2700005F, -0.884000003F));
                    builder.AddLine(new Vector2(23.2700005F, 0.88499999F));
                    builder.AddCubicBezier(new Vector2(23.2700005F, 1.51800001F), new Vector2(22.7560005F, 2.0309999F), new Vector2(22.1229992F, 2.0309999F));
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
                    builder.BeginFigure(new Vector2(22.1229992F, 2.0309999F));
                    builder.AddLine(new Vector2(-22.1229992F, 2.0309999F));
                    builder.AddCubicBezier(new Vector2(-22.7560005F, 2.0309999F), new Vector2(-23.2700005F, 1.51800001F), new Vector2(-23.2700005F, 0.88499999F));
                    builder.AddLine(new Vector2(-23.2700005F, -0.88499999F));
                    builder.AddCubicBezier(new Vector2(-23.2700005F, -1.51900005F), new Vector2(-22.7560005F, -2.0309999F), new Vector2(-22.1229992F, -2.0309999F));
                    builder.AddLine(new Vector2(22.1229992F, -2.0309999F));
                    builder.AddCubicBezier(new Vector2(22.7560005F, -2.0309999F), new Vector2(23.2700005F, -1.51900005F), new Vector2(23.2700005F, -0.88499999F));
                    builder.AddLine(new Vector2(23.2700005F, 0.88499999F));
                    builder.AddCubicBezier(new Vector2(23.2700005F, 1.51800001F), new Vector2(22.7560005F, 2.0309999F), new Vector2(22.1229992F, 2.0309999F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_26()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(2.3269999F, 12.5579996F));
                    builder.AddLine(new Vector2(-2.3269999F, 12.5579996F));
                    builder.AddLine(new Vector2(-2.3269999F, -12.5579996F));
                    builder.AddLine(new Vector2(2.3269999F, -12.5579996F));
                    builder.AddLine(new Vector2(2.3269999F, 12.5579996F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 9 Offset:<23.52, 5.467>
            CanvasGeometry Geometry_27()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(0.569999993F, 1.20200002F));
                    builder.AddLine(new Vector2(-0.569999993F, 1.20200002F));
                    builder.AddLine(new Vector2(-0.569999993F, -1.20200002F));
                    builder.AddLine(new Vector2(0.569999993F, -1.20200002F));
                    builder.AddLine(new Vector2(0.569999993F, 1.20200002F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 8 Offset:<23.515, 2.555>
            CanvasGeometry Geometry_28()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(1.46000004F, 0F));
                    builder.AddCubicBezier(new Vector2(1.68599999F, 1.25300002F), new Vector2(1.39300001F, 2.30500007F), new Vector2(-0.00300000003F, 2.30500007F));
                    builder.AddCubicBezier(new Vector2(-1.22599995F, 2.30500007F), new Vector2(-1.68599999F, 1.25399995F), new Vector2(-1.46500003F, 0F));
                    builder.AddCubicBezier(new Vector2(-1.19299996F, -1.55299997F), new Vector2(-0.81099999F, -2.30500007F), new Vector2(-0.00300000003F, -2.30500007F));
                    builder.AddCubicBezier(new Vector2(0.80400002F, -2.30500007F), new Vector2(1.22099996F, -1.33000004F), new Vector2(1.46000004F, 0F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 7 Offset:<23.52, 96.144>
            CanvasGeometry Geometry_29()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-5.52600002F, 7.64499998F));
                    builder.AddLine(new Vector2(-5.52600002F, -2.5079999F));
                    builder.AddCubicBezier(new Vector2(-5.52600002F, -5.34499979F), new Vector2(-3.227F, -7.64499998F), new Vector2(-0.389999986F, -7.64499998F));
                    builder.AddLine(new Vector2(0.389999986F, -7.64499998F));
                    builder.AddCubicBezier(new Vector2(3.22600007F, -7.64499998F), new Vector2(5.52600002F, -5.34499979F), new Vector2(5.52600002F, -2.5079999F));
                    builder.AddLine(new Vector2(5.52600002F, 7.64499998F));
                    builder.AddLine(new Vector2(-5.52600002F, 7.64499998F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            CanvasGeometry Geometry_30()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-5.52600002F, 7.64499998F));
                    builder.AddLine(new Vector2(-5.52600002F, -2.50900006F));
                    builder.AddCubicBezier(new Vector2(-5.52600002F, -5.34600019F), new Vector2(-3.227F, -7.64499998F), new Vector2(-0.389999986F, -7.64499998F));
                    builder.AddLine(new Vector2(0.389999986F, -7.64499998F));
                    builder.AddCubicBezier(new Vector2(3.22600007F, -7.64499998F), new Vector2(5.52600002F, -5.34600019F), new Vector2(5.52600002F, -2.50900006F));
                    builder.AddLine(new Vector2(5.52600002F, 7.64499998F));
                    builder.AddLine(new Vector2(-5.52600002F, 7.64499998F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 2 Offset:<23.52, 78.653>
            CanvasGeometry Geometry_31()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(22.1229992F, 2.0309999F));
                    builder.AddLine(new Vector2(-22.1229992F, 2.0309999F));
                    builder.AddCubicBezier(new Vector2(-22.7560005F, 2.0309999F), new Vector2(-23.2700005F, 1.51900005F), new Vector2(-23.2700005F, 0.88499999F));
                    builder.AddLine(new Vector2(-23.2700005F, -0.88499999F));
                    builder.AddCubicBezier(new Vector2(-23.2700005F, -1.51800001F), new Vector2(-22.7560005F, -2.0309999F), new Vector2(-22.1229992F, -2.0309999F));
                    builder.AddLine(new Vector2(22.1229992F, -2.0309999F));
                    builder.AddCubicBezier(new Vector2(22.7560005F, -2.0309999F), new Vector2(23.2700005F, -1.51800001F), new Vector2(23.2700005F, -0.88499999F));
                    builder.AddLine(new Vector2(23.2700005F, 0.88499999F));
                    builder.AddCubicBezier(new Vector2(23.2700005F, 1.51900005F), new Vector2(22.7560005F, 2.0309999F), new Vector2(22.1229992F, 2.0309999F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // - - - - Layer aggregator
            // - - ShapeGroup: Group 1 Offset:<23.52, 36.42>
            CanvasGeometry Geometry_32()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(22.1229992F, 2.03200006F));
                    builder.AddLine(new Vector2(-22.1229992F, 2.03200006F));
                    builder.AddCubicBezier(new Vector2(-22.7560005F, 2.03200006F), new Vector2(-23.2700005F, 1.51800001F), new Vector2(-23.2700005F, 0.88499999F));
                    builder.AddLine(new Vector2(-23.2700005F, -0.88499999F));
                    builder.AddCubicBezier(new Vector2(-23.2700005F, -1.51800001F), new Vector2(-22.7560005F, -2.03200006F), new Vector2(-22.1229992F, -2.03200006F));
                    builder.AddLine(new Vector2(22.1229992F, -2.03200006F));
                    builder.AddCubicBezier(new Vector2(22.7560005F, -2.03200006F), new Vector2(23.2700005F, -1.51800001F), new Vector2(23.2700005F, -0.88499999F));
                    builder.AddLine(new Vector2(23.2700005F, 0.88499999F));
                    builder.AddCubicBezier(new Vector2(23.2700005F, 1.51800001F), new Vector2(22.7560005F, 2.03200006F), new Vector2(22.1229992F, 2.03200006F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - PreComp layer: ramadan
            // - - - Layer aggregator
            // - -  Offset:<-34.737, 11.75>
            CanvasGeometry Geometry_33()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-83.2939987F, 67.4369965F));
                    builder.AddCubicBezier(new Vector2(-153.466003F, -36.9430008F), new Vector2(-131.143005F, -175.733994F), new Vector2(-34.5680008F, -248.514008F));
                    builder.AddCubicBezier(new Vector2(-64.5230026F, -242.399994F), new Vector2(-93.7089996F, -230.507996F), new Vector2(-120.527F, -212.479004F));
                    builder.AddCubicBezier(new Vector2(-233.343994F, -136.634995F), new Vector2(-261.585999F, 18.8799992F), new Vector2(-183.606995F, 134.875F));
                    builder.AddCubicBezier(new Vector2(-105.626999F, 250.869003F), new Vector2(49.0449982F, 283.415985F), new Vector2(161.862F, 207.572998F));
                    builder.AddCubicBezier(new Vector2(188.681F, 189.542999F), new Vector2(210.709F, 167.005005F), new Vector2(227.677994F, 141.572998F));
                    builder.AddCubicBezier(new Vector2(123.829002F, 203.533005F), new Vector2(-13.1210003F, 171.817993F), new Vector2(-83.2939987F, 67.4369965F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - PreComp layer: ramadan
            // - - - Layer aggregator
            // - -  Offset:<-34.737, 11.75>
            CanvasGeometry Geometry_34()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-83.8949966F, 65.5319977F));
                    builder.AddCubicBezier(new Vector2(-153.227997F, -37.598999F), new Vector2(-128.955994F, -176.218002F), new Vector2(-30.7490005F, -250F));
                    builder.AddCubicBezier(new Vector2(-60.9990005F, -243.520004F), new Vector2(-90.5469971F, -231.292007F), new Vector2(-117.791F, -212.977005F));
                    builder.AddCubicBezier(new Vector2(-232.395004F, -135.931F), new Vector2(-262.842987F, 19.4319992F), new Vector2(-185.796997F, 134.037994F));
                    builder.AddCubicBezier(new Vector2(-108.750999F, 248.643005F), new Vector2(46.612999F, 279.091003F), new Vector2(161.218002F, 202.044998F));
                    builder.AddCubicBezier(new Vector2(188.462006F, 183.729996F), new Vector2(210.938004F, 160.983002F), new Vector2(228.356003F, 135.417007F));
                    builder.AddCubicBezier(new Vector2(122.962997F, 198.509003F), new Vector2(-14.5629997F, 168.662994F), new Vector2(-83.8949966F, 65.5319977F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - PreComp layer: ramadan
            // - - - Layer aggregator
            // - -  Offset:<-34.737, 11.75>
            CanvasGeometry Geometry_35()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-119.703003F, 93.9990005F));
                    builder.AddCubicBezier(new Vector2(-188.528F, -8.37800026F), new Vector2(-165.100006F, -145.712997F), new Vector2(-68.6869965F, -219.891998F));
                    builder.AddCubicBezier(new Vector2(-75.6780014F, -216.162994F), new Vector2(-82.5500031F, -212.054001F), new Vector2(-89.2679977F, -207.537003F));
                    builder.AddCubicBezier(new Vector2(-196.322006F, -135.567993F), new Vector2(-224.763F, 9.55900002F), new Vector2(-152.794006F, 116.612F));
                    builder.AddCubicBezier(new Vector2(-80.8249969F, 223.666F), new Vector2(64.302002F, 252.106995F), new Vector2(171.356003F, 180.138F));
                    builder.AddCubicBezier(new Vector2(178.690002F, 175.207001F), new Vector2(185.641006F, 169.923004F), new Vector2(192.229996F, 164.339996F));
                    builder.AddCubicBezier(new Vector2(192.335007F, 164.186996F), new Vector2(192.444F, 164.037003F), new Vector2(192.548004F, 163.884003F));
                    builder.AddCubicBezier(new Vector2(87.1549988F, 226.975998F), new Vector2(-50.3709984F, 197.130005F), new Vector2(-119.703003F, 93.9990005F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - - - - - - - PreComp layer: ramadan
            // - - - Opacity for layer: moon Outlines
            // - - ShapeGroup: Group 1 Offset:<228.357, 262>
            CanvasGeometry Geometry_36()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-83.8949966F, 65.5319977F));
                    builder.AddCubicBezier(new Vector2(-153.227997F, -37.598999F), new Vector2(-128.955994F, -176.218002F), new Vector2(-30.7490005F, -250F));
                    builder.AddCubicBezier(new Vector2(-60.9990005F, -243.520004F), new Vector2(-90.5469971F, -231.292999F), new Vector2(-117.791F, -212.977997F));
                    builder.AddCubicBezier(new Vector2(-232.395004F, -135.931F), new Vector2(-262.842987F, 19.4319992F), new Vector2(-185.796997F, 134.037994F));
                    builder.AddCubicBezier(new Vector2(-108.750999F, 248.643005F), new Vector2(46.612999F, 279.091003F), new Vector2(161.218002F, 202.044998F));
                    builder.AddCubicBezier(new Vector2(188.460999F, 183.729996F), new Vector2(210.938004F, 160.983002F), new Vector2(228.356995F, 135.417007F));
                    builder.AddCubicBezier(new Vector2(122.962997F, 198.509003F), new Vector2(-14.5629997F, 168.662994F), new Vector2(-83.8949966F, 65.5319977F));
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
                    builder.BeginFigure(new Vector2(-423.700012F, -188.804001F));
                    builder.AddCubicBezier(new Vector2(-425.795013F, -184.572006F), new Vector2(-425.056F, -183.791F), new Vector2(-429F, -182.147995F));
                    builder.AddCubicBezier(new Vector2(-424.562988F, -180.710007F), new Vector2(-424.768005F, -179.518997F), new Vector2(-423.658997F, -175.820999F));
                    builder.AddCubicBezier(new Vector2(-422.179993F, -180.216995F), new Vector2(-420.824005F, -180.544998F), new Vector2(-418.687988F, -182.229996F));
                    builder.AddCubicBezier(new Vector2(-421.809998F, -184.037994F), new Vector2(-422.631989F, -185.147003F), new Vector2(-423.700012F, -188.804001F));
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
                    builder.BeginFigure(new Vector2(-424.5F, -220.5F));
                    builder.AddCubicBezier(new Vector2(-428.5F, -192.5F), new Vector2(-428.5F, -185.5F), new Vector2(-448.5F, -180.5F));
                    builder.AddCubicBezier(new Vector2(-426.5F, -178.5F), new Vector2(-427.5F, -168.5F), new Vector2(-422.5F, -148.5F));
                    builder.AddCubicBezier(new Vector2(-420.5F, -171.5F), new Vector2(-416.5F, -175.5F), new Vector2(-400.5F, -181.5F));
                    builder.AddCubicBezier(new Vector2(-418.5F, -186.5F), new Vector2(-422.5F, -187.5F), new Vector2(-424.5F, -220.5F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - Layer aggregator
            // - -  Offset:<392.972, 145.778>
            CanvasGeometry Geometry_39()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(44.3720016F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(43.6679993F, -7.9369998F), new Vector2(43.1189995F, -7.38899994F), new Vector2(42.7280006F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(42.3370018F, -5.954F), new Vector2(42.1409988F, -5.21700001F), new Vector2(42.1409988F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(42.1409988F, -3.67799997F), new Vector2(42.3370018F, -2.93400002F), new Vector2(42.7280006F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(43.1189995F, -1.52600002F), new Vector2(43.6679993F, -0.977999985F), new Vector2(44.3720016F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(45.0760002F, -0.195999995F), new Vector2(45.8069992F, 0F), new Vector2(46.5629997F, 0F));
                    builder.AddCubicBezier(new Vector2(47.3190002F, 0F), new Vector2(48.0499992F, -0.181999996F), new Vector2(48.7540016F, -0.547999978F));
                    builder.AddCubicBezier(new Vector2(50.5279999F, -1.17400002F), new Vector2(52.0810013F, -2.16499996F), new Vector2(53.4109993F, -3.52200007F));
                    builder.AddCubicBezier(new Vector2(53.9059982F, -2.71300006F), new Vector2(54.493F, -1.95599997F), new Vector2(55.1720009F, -1.25199997F));
                    builder.AddCubicBezier(new Vector2(57.7550011F, 1.17400002F), new Vector2(60.8520012F, 2.50399995F), new Vector2(64.4649963F, 2.73900008F));
                    builder.AddCubicBezier(new Vector2(68.0780029F, 2.97399998F), new Vector2(71.3389969F, 2.06800008F), new Vector2(74.2480011F, 0.0199999996F));
                    builder.AddCubicBezier(new Vector2(77.1559982F, -2.02800012F), new Vector2(78.8450012F, -5.25600004F), new Vector2(79.3150024F, -9.66499996F));
                    builder.AddCubicBezier(new Vector2(79.4970016F, -12.1689997F), new Vector2(79.0999985F, -14.5690002F), new Vector2(78.1220016F, -16.8649998F));
                    builder.AddCubicBezier(new Vector2(77.1439972F, -19.1599998F), new Vector2(75.5910034F, -21.052F), new Vector2(73.4649963F, -22.5389996F));
                    builder.AddCubicBezier(new Vector2(71.3389969F, -24.0259991F), new Vector2(68.6460037F, -24.7950001F), new Vector2(65.3850021F, -24.8479996F));
                    builder.AddCubicBezier(new Vector2(62.9589996F, -24.8220005F), new Vector2(60.7680016F, -24.2730007F), new Vector2(58.8110008F, -23.2040005F));
                    builder.AddCubicBezier(new Vector2(56.8540001F, -22.1340008F), new Vector2(55.25F, -20.6870003F), new Vector2(53.9980011F, -18.8610001F));
                    builder.AddCubicBezier(new Vector2(53.2669983F, -17.7910004F), new Vector2(52.7060013F, -16.6429996F), new Vector2(52.3149986F, -15.4169998F));
                    builder.AddCubicBezier(new Vector2(52.0540009F, -14.8170004F), new Vector2(51.8069992F, -14.217F), new Vector2(51.5719986F, -13.6169996F));
                    builder.AddCubicBezier(new Vector2(51.1539993F, -12.3120003F), new Vector2(50.6389999F, -11.217F), new Vector2(50.026001F, -10.3299999F));
                    builder.AddCubicBezier(new Vector2(49.4129982F, -9.44299984F), new Vector2(48.4669991F, -8.96100044F), new Vector2(47.1889992F, -8.88300037F));
                    builder.AddLine(new Vector2(46.5629997F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(45.8069992F, -8.88300037F), new Vector2(45.0760002F, -8.69299984F), new Vector2(44.3720016F, -8.31499958F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(70.9609985F, -11.974F));
                    builder.AddCubicBezier(new Vector2(71.3909988F, -10.1210003F), new Vector2(71.0059967F, -8.49199963F), new Vector2(69.8059998F, -7.08300018F));
                    builder.AddCubicBezier(new Vector2(68.7099991F, -5.90899992F), new Vector2(67.4000015F, -5.31500006F), new Vector2(65.8740005F, -5.30200005F));
                    builder.AddCubicBezier(new Vector2(64.3479996F, -5.28900003F), new Vector2(62.9710007F, -5.76499987F), new Vector2(61.7449989F, -6.73000002F));
                    builder.AddCubicBezier(new Vector2(60.7529984F, -7.56500006F), new Vector2(60.0429993F, -8.57600021F), new Vector2(59.612999F, -9.76299953F));
                    builder.AddCubicBezier(new Vector2(59.1829987F, -10.9499998F), new Vector2(59.137001F, -11.9870005F), new Vector2(59.4760017F, -12.8739996F));
                    builder.AddCubicBezier(new Vector2(59.8149986F, -13.6820002F), new Vector2(60.5779991F, -14.4130001F), new Vector2(61.7649994F, -15.0649996F));
                    builder.AddCubicBezier(new Vector2(62.9519997F, -15.717F), new Vector2(64.4059982F, -15.9259996F), new Vector2(66.1279984F, -15.691F));
                    builder.AddCubicBezier(new Vector2(68.9189987F, -15.0649996F), new Vector2(70.5309982F, -13.8260002F), new Vector2(70.9609985F, -11.974F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - Layer aggregator
            // - -  Offset:<392.972, 145.778>
            CanvasGeometry Geometry_40()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(19.9740009F, 8.64799976F));
                    builder.AddCubicBezier(new Vector2(19.7000008F, 10.6560001F), new Vector2(20.3400002F, 12.4169998F), new Vector2(21.8920002F, 13.9300003F));
                    builder.AddCubicBezier(new Vector2(23.4440002F, 15.4429998F), new Vector2(25.5629997F, 15.9519997F), new Vector2(28.25F, 15.4569998F));
                    builder.AddCubicBezier(new Vector2(29.6060009F, 15.118F), new Vector2(30.8390007F, 14.3079996F), new Vector2(31.948F, 13.0299997F));
                    builder.AddCubicBezier(new Vector2(33.0559998F, 11.7519999F), new Vector2(33.4150009F, 10.1350002F), new Vector2(33.0239983F, 8.17800045F));
                    builder.AddCubicBezier(new Vector2(32.5540009F, 6.61299992F), new Vector2(31.5109997F, 5.41300011F), new Vector2(29.8939991F, 4.57800007F));
                    builder.AddCubicBezier(new Vector2(28.2759991F, 3.74300003F), new Vector2(26.5020008F, 3.58699989F), new Vector2(24.5720005F, 4.10900021F));
                    builder.AddCubicBezier(new Vector2(21.7800007F, 5.12599993F), new Vector2(20.2479992F, 6.63899994F), new Vector2(19.9740009F, 8.64799976F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(17.8610001F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(17.1439991F, -7.9369998F), new Vector2(16.5890007F, -7.38899994F), new Vector2(16.198F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(15.8070002F, -5.954F), new Vector2(15.6110001F, -5.21700001F), new Vector2(15.6110001F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(15.6110001F, -3.67799997F), new Vector2(15.8070002F, -2.93400002F), new Vector2(16.198F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(16.5890007F, -1.52600002F), new Vector2(17.1380005F, -0.977999985F), new Vector2(17.8419991F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(18.5459995F, -0.195999995F), new Vector2(19.2770004F, 0F), new Vector2(20.0330009F, 0F));
                    builder.AddCubicBezier(new Vector2(20.816F, 0F), new Vector2(21.559F, -0.195999995F), new Vector2(22.2630005F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(22.9669991F, -0.977999985F), new Vector2(23.5160007F, -1.52600002F), new Vector2(23.9069996F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(24.2980003F, -2.93400002F), new Vector2(24.4939995F, -3.67799997F), new Vector2(24.4939995F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(24.4939995F, -5.21700001F), new Vector2(24.2910004F, -5.954F), new Vector2(23.8869991F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(23.4820004F, -7.38899994F), new Vector2(22.9279995F, -7.9369998F), new Vector2(22.2240009F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(21.5200005F, -8.69299984F), new Vector2(20.7889996F, -8.88300037F), new Vector2(20.0330009F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(19.3029995F, -8.88300037F), new Vector2(18.5790005F, -8.69299984F), new Vector2(17.8610001F, -8.31499958F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(44.3720016F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(43.6679993F, -7.9369998F), new Vector2(43.1199989F, -7.38899994F), new Vector2(42.7290001F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(42.3380013F, -5.954F), new Vector2(42.1419983F, -5.21700001F), new Vector2(42.1419983F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(42.1419983F, -3.67799997F), new Vector2(42.3310013F, -2.93400002F), new Vector2(42.7089996F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(43.0870018F, -1.52600002F), new Vector2(43.6339989F, -0.977999985F), new Vector2(44.3520012F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(45.0690002F, -0.195999995F), new Vector2(45.8059998F, 0F), new Vector2(46.5629997F, 0F));
                    builder.AddCubicBezier(new Vector2(47.3460007F, 0F), new Vector2(48.0900002F, -0.195999995F), new Vector2(48.7939987F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(49.4980011F, -0.977999985F), new Vector2(50.0460014F, -1.52600002F), new Vector2(50.4370003F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(50.8279991F, -2.93400002F), new Vector2(51.0239983F, -3.67799997F), new Vector2(51.0239983F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(51.0239983F, -5.21700001F), new Vector2(50.8219986F, -5.954F), new Vector2(50.4179993F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(50.0130005F, -7.38899994F), new Vector2(49.4589996F, -7.9369998F), new Vector2(48.7550011F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(48.0509987F, -8.69299984F), new Vector2(47.3190002F, -8.88300037F), new Vector2(46.5629997F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(45.8059998F, -8.88300037F), new Vector2(45.0760002F, -8.69299984F), new Vector2(44.3720016F, -8.31499958F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(39.9700012F, -9.93900013F));
                    builder.AddCubicBezier(new Vector2(38.3129997F, -10.6429996F), new Vector2(37.0480003F, -11.5369997F), new Vector2(36.1739998F, -12.6199999F));
                    builder.AddCubicBezier(new Vector2(35.2999992F, -13.7019997F), new Vector2(34.7319984F, -14.8559999F), new Vector2(34.4720001F, -16.0830002F));
                    builder.AddCubicBezier(new Vector2(34.394001F, -16.7350006F), new Vector2(34.3019981F, -17.4130001F), new Vector2(34.1980019F, -18.1170006F));
                    builder.AddCubicBezier(new Vector2(34.0929985F, -18.6119995F), new Vector2(34.0149994F, -19.1210003F), new Vector2(33.9630013F, -19.6429996F));
                    builder.AddCubicBezier(new Vector2(33.7019997F, -22.1210003F), new Vector2(33.0629997F, -23.7520008F), new Vector2(32.0460014F, -24.5349998F));
                    builder.AddCubicBezier(new Vector2(31.0289993F, -25.3180008F), new Vector2(30.0039997F, -25.4349995F), new Vector2(28.9740009F, -24.8869991F));
                    builder.AddCubicBezier(new Vector2(27.9430008F, -24.3390007F), new Vector2(27.2970009F, -23.3220005F), new Vector2(27.0370007F, -21.8349991F));
                    builder.AddCubicBezier(new Vector2(26.8540001F, -20.2950001F), new Vector2(26.8029995F, -18.7830009F), new Vector2(26.8810005F, -17.2959995F));
                    builder.AddCubicBezier(new Vector2(26.9330006F, -16.2259998F), new Vector2(26.9260006F, -15.2220001F), new Vector2(26.8610001F, -14.283F));
                    builder.AddCubicBezier(new Vector2(26.7959995F, -13.3439999F), new Vector2(26.5799999F, -12.4949999F), new Vector2(26.2150002F, -11.7390003F));
                    builder.AddCubicBezier(new Vector2(25.8239994F, -10.9300003F), new Vector2(25.1650009F, -10.2460003F), new Vector2(24.2390003F, -9.68500042F));
                    builder.AddCubicBezier(new Vector2(23.3129997F, -9.1239996F), new Vector2(21.8719997F, -8.85700035F), new Vector2(19.9150009F, -8.88300037F));
                    builder.AddLine(new Vector2(19.9150009F, 0F));
                    builder.AddCubicBezier(new Vector2(22.0279999F, -0.0260000005F), new Vector2(23.9519997F, -0.651000023F), new Vector2(25.6870003F, -1.87800002F));
                    builder.AddCubicBezier(new Vector2(27.4220009F, -3.10400009F), new Vector2(28.6930008F, -4.73500013F), new Vector2(29.5020008F, -6.76999998F));
                    builder.AddCubicBezier(new Vector2(30.9360008F, -4.31799984F), new Vector2(32.9980011F, -2.56399989F), new Vector2(35.6850014F, -1.50699997F));
                    builder.AddCubicBezier(new Vector2(38.3720016F, -0.449999988F), new Vector2(41.0979996F, 0.0520000011F), new Vector2(43.862999F, 0F));
                    builder.AddCubicBezier(new Vector2(44.75F, 0.0260000005F), new Vector2(45.6500015F, 0.0260000005F), new Vector2(46.5629997F, 0F));
                    builder.AddLine(new Vector2(46.5629997F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(43.8240013F, -8.88300037F), new Vector2(41.6259995F, -9.23499966F), new Vector2(39.9700012F, -9.93900013F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - Layer aggregator
            // - -  Offset:<392.972, 145.778>
            CanvasGeometry Geometry_41()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(17.5690002F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(16.8649998F, -7.9369998F), new Vector2(16.3099995F, -7.38899994F), new Vector2(15.9060001F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(15.5010004F, -5.954F), new Vector2(15.2989998F, -5.21700001F), new Vector2(15.2989998F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(15.2989998F, -3.67799997F), new Vector2(15.4949999F, -2.93400002F), new Vector2(15.8859997F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(16.2770004F, -1.52600002F), new Vector2(16.8260002F, -0.977999985F), new Vector2(17.5300007F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(18.2339993F, -0.195999995F), new Vector2(18.9769993F, 0F), new Vector2(19.7600002F, 0F));
                    builder.AddCubicBezier(new Vector2(20.5160007F, 0F), new Vector2(21.2530003F, -0.195999995F), new Vector2(21.9710007F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(22.6879997F, -0.977999985F), new Vector2(23.2360001F, -1.52600002F), new Vector2(23.6140003F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(23.9920006F, -2.93400002F), new Vector2(24.1819992F, -3.67799997F), new Vector2(24.1819992F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(24.1819992F, -5.21700001F), new Vector2(23.9860001F, -5.954F), new Vector2(23.5949993F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(23.2040005F, -7.38899994F), new Vector2(22.6490002F, -7.9369998F), new Vector2(21.9319992F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(21.2140007F, -8.69299984F), new Vector2(20.4899998F, -8.88300037F), new Vector2(19.7600002F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(19.0030003F, -8.88300037F), new Vector2(18.2730007F, -8.69299984F), new Vector2(17.5690002F, -8.31499958F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(19.2910004F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(17.5429993F, -8.82999992F), new Vector2(16.0489998F, -9.26099968F), new Vector2(14.8100004F, -10.1739998F));
                    builder.AddCubicBezier(new Vector2(13.5710001F, -11.0869999F), new Vector2(12.8859997F, -12.7959995F), new Vector2(12.7559996F, -15.3000002F));
                    builder.AddLine(new Vector2(13.0690002F, -38.4650002F));
                    builder.AddCubicBezier(new Vector2(12.9910002F, -41.2560005F), new Vector2(12.2919998F, -43.0299988F), new Vector2(10.9750004F, -43.7869987F));
                    builder.AddCubicBezier(new Vector2(9.65699959F, -44.5429993F), new Vector2(8.32699966F, -44.5169983F), new Vector2(6.98400021F, -43.7089996F));
                    builder.AddCubicBezier(new Vector2(5.63999987F, -42.9000015F), new Vector2(4.90299988F, -41.5299988F), new Vector2(4.77299976F, -39.5999985F));
                    builder.AddLine(new Vector2(4.6170001F, -23.243F));
                    builder.AddLine(new Vector2(4.6170001F, -22.6170006F));
                    builder.AddCubicBezier(new Vector2(4.56400013F, -19.7210007F), new Vector2(4.61000013F, -16.9300003F), new Vector2(4.75400019F, -14.243F));
                    builder.AddCubicBezier(new Vector2(4.89699984F, -11.5559998F), new Vector2(5.37300014F, -9.14299965F), new Vector2(6.18200016F, -7.00400019F));
                    builder.AddCubicBezier(new Vector2(6.98999977F, -4.86499977F), new Vector2(8.33399963F, -3.16300011F), new Vector2(10.2119999F, -1.898F));
                    builder.AddCubicBezier(new Vector2(12.0900002F, -0.632000029F), new Vector2(14.7639999F, 0F), new Vector2(18.2339993F, 0F));
                    builder.AddLine(new Vector2(19.9169998F, 0F));
                    builder.AddLine(new Vector2(19.9169998F, -8.88300037F));
                    builder.AddLine(new Vector2(19.2910004F, -8.88300037F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - Layer aggregator
            // - -  Offset:<392.972, 145.778>
            CanvasGeometry Geometry_42()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-1.40799999F, -19.3299999F));
                    builder.AddCubicBezier(new Vector2(-1.51300001F, -20.1650009F), new Vector2(-1.66999996F, -21.0389996F), new Vector2(-1.87800002F, -21.9519997F));
                    builder.AddCubicBezier(new Vector2(-2.08699989F, -22.8649998F), new Vector2(-2.42499995F, -23.5949993F), new Vector2(-2.89499998F, -24.1429996F));
                    builder.AddCubicBezier(new Vector2(-3.33899999F, -24.6130009F), new Vector2(-3.8670001F, -24.8990002F), new Vector2(-4.48000002F, -25.0039997F));
                    builder.AddCubicBezier(new Vector2(-5.09299994F, -25.1079998F), new Vector2(-5.69999981F, -25.1350002F), new Vector2(-6.30000019F, -25.0830002F));
                    builder.AddCubicBezier(new Vector2(-6.9000001F, -25.0300007F), new Vector2(-7.48600006F, -24.8990002F), new Vector2(-8.06000042F, -24.691F));
                    builder.AddCubicBezier(new Vector2(-8.63399982F, -24.4820004F), new Vector2(-9.10400009F, -24.1299992F), new Vector2(-9.46899986F, -23.6350002F));
                    builder.AddCubicBezier(new Vector2(-9.83500004F, -23.0610008F), new Vector2(-10.0500002F, -22.3950005F), new Vector2(-10.1149998F, -21.6389999F));
                    builder.AddCubicBezier(new Vector2(-10.1800003F, -20.882F), new Vector2(-10.1730003F, -20.1779995F), new Vector2(-10.0950003F, -19.5259991F));
                    builder.AddCubicBezier(new Vector2(-10.0170002F, -18.3780003F), new Vector2(-9.89999962F, -17.243F), new Vector2(-9.74300003F, -16.1219997F));
                    builder.AddCubicBezier(new Vector2(-9.61299992F, -15.1829996F), new Vector2(-9.50800037F, -14.243F), new Vector2(-9.43000031F, -13.3039999F));
                    builder.AddCubicBezier(new Vector2(-9.11699963F, -10.9040003F), new Vector2(-9.31299973F, -8.55599976F), new Vector2(-10.0170002F, -6.26100016F));
                    builder.AddCubicBezier(new Vector2(-10.9040003F, -3.73000002F), new Vector2(-12.1630001F, -1.546F), new Vector2(-13.7930002F, 0.293000013F));
                    builder.AddCubicBezier(new Vector2(-15.4239998F, 2.13199997F), new Vector2(-17.5429993F, 3.44300008F), new Vector2(-20.1520004F, 4.22599983F));
                    builder.AddCubicBezier(new Vector2(-20.5949993F, 4.32999992F), new Vector2(-21.2140007F, 4.546F), new Vector2(-22.0100002F, 4.87200022F));
                    builder.AddCubicBezier(new Vector2(-22.8050003F, 5.19799995F), new Vector2(-23.5170002F, 5.60200024F), new Vector2(-24.1429996F, 6.08500004F));
                    builder.AddCubicBezier(new Vector2(-24.7689991F, 6.56699991F), new Vector2(-25.0559998F, 7.12200022F), new Vector2(-25.0039997F, 7.74800014F));
                    builder.AddCubicBezier(new Vector2(-24.8470001F, 8.45199966F), new Vector2(-24.3439999F, 8.98600006F), new Vector2(-23.4969997F, 9.35200024F));
                    builder.AddCubicBezier(new Vector2(-22.6490002F, 9.71700001F), new Vector2(-21.8990002F, 9.93900013F), new Vector2(-21.2469997F, 10.0170002F));
                    builder.AddCubicBezier(new Vector2(-19.6040001F, 10.2519999F), new Vector2(-17.9529991F, 10.1669998F), new Vector2(-16.2970009F, 9.76299953F));
                    builder.AddCubicBezier(new Vector2(-14.6409998F, 9.3579998F), new Vector2(-13.0950003F, 8.77799988F), new Vector2(-11.6599998F, 8.02200031F));
                    builder.AddCubicBezier(new Vector2(-8.42599964F, 6.27400017F), new Vector2(-5.96700001F, 3.95300007F), new Vector2(-4.28399992F, 1.05700004F));
                    builder.AddCubicBezier(new Vector2(-2.60100007F, -1.83899999F), new Vector2(-1.54499996F, -5.00899982F), new Vector2(-1.11500001F, -8.45199966F));
                    builder.AddCubicBezier(new Vector2(-0.685000002F, -11.8950005F), new Vector2(-0.742999971F, -15.3120003F), new Vector2(-1.29100001F, -18.7040005F));
                    builder.AddCubicBezier(new Vector2(-1.34399998F, -18.9120007F), new Vector2(-1.38199997F, -19.1210003F), new Vector2(-1.40799999F, -19.3299999F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - Layer aggregator
            // - -  Offset:<392.972, 145.778>
            CanvasGeometry Geometry_43()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-40.3810005F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(-41.0849991F, -7.9369998F), new Vector2(-41.6339989F, -7.38899994F), new Vector2(-42.0250015F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(-42.4160004F, -5.954F), new Vector2(-42.6119995F, -5.21700001F), new Vector2(-42.6119995F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(-42.6119995F, -3.67799997F), new Vector2(-42.4160004F, -2.93400002F), new Vector2(-42.0250015F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(-41.6339989F, -1.52600002F), new Vector2(-41.0849991F, -0.977999985F), new Vector2(-40.3810005F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(-39.6769981F, -0.195999995F), new Vector2(-38.9459991F, 0F), new Vector2(-38.1899986F, 0F));
                    builder.AddCubicBezier(new Vector2(-33.3639984F, 0.0780000016F), new Vector2(-29.2360001F, -1.34300005F), new Vector2(-25.8050003F, -4.26499987F));
                    builder.AddCubicBezier(new Vector2(-22.375F, -7.18599987F), new Vector2(-20.5820007F, -11.0480003F), new Vector2(-20.4249992F, -15.8479996F));
                    builder.AddCubicBezier(new Vector2(-20.5030003F, -18.0389996F), new Vector2(-20.9330006F, -20.309F), new Vector2(-21.7159996F, -22.6569996F));
                    builder.AddCubicBezier(new Vector2(-22.4990005F, -25.0049992F), new Vector2(-23.3859997F, -27.3260002F), new Vector2(-24.3770008F, -29.6219997F));
                    builder.AddCubicBezier(new Vector2(-24.9510002F, -30.9260006F), new Vector2(-25.4720001F, -32.1910019F), new Vector2(-25.9419994F, -33.4169998F));
                    builder.AddCubicBezier(new Vector2(-26.5160007F, -35.0079994F), new Vector2(-27.5330009F, -36.0649986F), new Vector2(-28.9939995F, -36.5870018F));
                    builder.AddCubicBezier(new Vector2(-30.8199997F, -37.0820007F), new Vector2(-32.2420006F, -36.8209991F), new Vector2(-33.2589989F, -35.8040009F));
                    builder.AddCubicBezier(new Vector2(-34.276001F, -34.7869987F), new Vector2(-34.6419983F, -33.3520012F), new Vector2(-34.3549995F, -31.5F));
                    builder.AddCubicBezier(new Vector2(-33.9119987F, -30.4039993F), new Vector2(-33.4290009F, -29.2299995F), new Vector2(-32.9070015F, -27.9780006F));
                    builder.AddCubicBezier(new Vector2(-31.8110008F, -25.3950005F), new Vector2(-30.8269997F, -22.7870007F), new Vector2(-29.9529991F, -20.1520004F));
                    builder.AddCubicBezier(new Vector2(-29.0790005F, -17.5170002F), new Vector2(-28.7730007F, -15.2869997F), new Vector2(-29.0330009F, -13.4610004F));
                    builder.AddCubicBezier(new Vector2(-29.2679996F, -12.1309996F), new Vector2(-30.0900002F, -11.0480003F), new Vector2(-31.4990005F, -10.2130003F));
                    builder.AddCubicBezier(new Vector2(-32.9080009F, -9.37800026F), new Vector2(-34.9169998F, -8.93500042F), new Vector2(-37.5250015F, -8.88300037F));
                    builder.AddLine(new Vector2(-38.1899986F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(-38.9459991F, -8.88300037F), new Vector2(-39.6769981F, -8.69299984F), new Vector2(-40.3810005F, -8.31499958F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-33.9249992F, -42.6910019F));
                    builder.AddCubicBezier(new Vector2(-35.3600006F, -40.4469986F), new Vector2(-34.8240013F, -39.1040001F), new Vector2(-32.3199997F, -38.6609993F));
                    builder.AddCubicBezier(new Vector2(-29.6070004F, -38.5040016F), new Vector2(-25.7989998F, -39.7700005F), new Vector2(-20.8939991F, -42.4570007F));
                    builder.AddCubicBezier(new Vector2(-15.9899998F, -45.144001F), new Vector2(-11.1440001F, -48.1949997F), new Vector2(-6.35699987F, -51.612999F));
                    builder.AddCubicBezier(new Vector2(-1.57000005F, -55.0299988F), new Vector2(2.023F, -57.7560005F), new Vector2(4.42299986F, -59.7910004F));
                    builder.AddCubicBezier(new Vector2(6.14499998F, -61.2519989F), new Vector2(7.38399982F, -62.6930008F), new Vector2(8.14099979F, -64.1149979F));
                    builder.AddCubicBezier(new Vector2(8.89700031F, -65.5370026F), new Vector2(8.9289999F, -66.4950027F), new Vector2(8.23799992F, -66.9909973F));
                    builder.AddCubicBezier(new Vector2(7.54699993F, -67.4860001F), new Vector2(5.87099981F, -67.0820007F), new Vector2(3.21000004F, -65.7779999F));
                    builder.AddCubicBezier(new Vector2(2.40100002F, -65.3339996F), new Vector2(0.50999999F, -64.2519989F), new Vector2(-2.46399999F, -62.5299988F));
                    builder.AddCubicBezier(new Vector2(-5.51599979F, -60.7560005F), new Vector2(-8.90799999F, -58.7929993F), new Vector2(-12.6379995F, -56.6409988F));
                    builder.AddCubicBezier(new Vector2(-16.3689995F, -54.4889984F), new Vector2(-19.6609993F, -52.6110001F), new Vector2(-22.5179996F, -51.007F));
                    builder.AddCubicBezier(new Vector2(-25.375F, -49.4029999F), new Vector2(-26.9860001F, -48.5470009F), new Vector2(-27.3509998F, -48.4430008F));
                    builder.AddCubicBezier(new Vector2(-30.6380005F, -46.382F), new Vector2(-32.8289986F, -44.4650002F), new Vector2(-33.9249992F, -42.6910019F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - Layer aggregator
            // - -  Offset:<392.972, 145.778>
            CanvasGeometry Geometry_44()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-59.0849991F, -8.84300041F));
                    builder.AddCubicBezier(new Vector2(-59.2680016F, -8.86900043F), new Vector2(-59.4620018F, -8.88300037F), new Vector2(-59.6710014F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(-60.4269981F, -8.88300037F), new Vector2(-61.1590004F, -8.69299984F), new Vector2(-61.862999F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(-62.5670013F, -7.9369998F), new Vector2(-63.1150017F, -7.38899994F), new Vector2(-63.5060005F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(-63.8969994F, -5.954F), new Vector2(-64.0930023F, -5.21700001F), new Vector2(-64.0930023F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(-64.0930023F, -3.67799997F), new Vector2(-63.8969994F, -2.93400002F), new Vector2(-63.5060005F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(-63.1150017F, -1.52600002F), new Vector2(-62.5670013F, -0.977999985F), new Vector2(-61.862999F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(-61.1590004F, -0.195999995F), new Vector2(-60.4269981F, 0F), new Vector2(-59.6710014F, 0F));
                    builder.AddCubicBezier(new Vector2(-59.487999F, 0F), new Vector2(-59.3069992F, -0.0130000003F), new Vector2(-59.1240005F, -0.0390000008F));
                    builder.AddLine(new Vector2(-59.1240005F, 0F));
                    builder.AddLine(new Vector2(-38.1500015F, 0F));
                    builder.AddCubicBezier(new Vector2(-37.3670006F, 0F), new Vector2(-36.6230011F, -0.195999995F), new Vector2(-35.9189987F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(-35.2150002F, -0.977999985F), new Vector2(-34.6669998F, -1.52600002F), new Vector2(-34.276001F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(-33.8849983F, -2.93400002F), new Vector2(-33.6889992F, -3.67799997F), new Vector2(-33.6889992F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(-33.6889992F, -5.21700001F), new Vector2(-33.8909988F, -5.954F), new Vector2(-34.2949982F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(-34.7000008F, -7.38899994F), new Vector2(-35.2540016F, -7.9369998F), new Vector2(-35.9580002F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(-36.6619987F, -8.69299984F), new Vector2(-37.394001F, -8.88300037F), new Vector2(-38.1500015F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(-38.3590012F, -8.88300037F), new Vector2(-38.5550003F, -8.86900043F), new Vector2(-38.7369995F, -8.84300041F));
                    builder.AddLine(new Vector2(-59.0849991F, -8.84300041F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - Layer aggregator
            // - -  Offset:<392.972, 145.778>
            CanvasGeometry Geometry_45()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-80.2919998F, -8.84300041F));
                    builder.AddCubicBezier(new Vector2(-80.4749985F, -8.86900043F), new Vector2(-80.6699982F, -8.88300037F), new Vector2(-80.8789978F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(-81.6350021F, -8.88300037F), new Vector2(-82.3669968F, -8.69299984F), new Vector2(-83.0709991F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(-83.7750015F, -7.9369998F), new Vector2(-84.322998F, -7.38899994F), new Vector2(-84.7139969F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(-85.1050034F, -5.954F), new Vector2(-85.3010025F, -5.21700001F), new Vector2(-85.3010025F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(-85.3010025F, -3.67799997F), new Vector2(-85.1050034F, -2.93400002F), new Vector2(-84.7139969F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(-84.322998F, -1.52600002F), new Vector2(-83.7750015F, -0.977999985F), new Vector2(-83.0709991F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(-82.3669968F, -0.195999995F), new Vector2(-81.6350021F, 0F), new Vector2(-80.8789978F, 0F));
                    builder.AddCubicBezier(new Vector2(-80.6959991F, 0F), new Vector2(-80.5139999F, -0.0130000003F), new Vector2(-80.3310013F, -0.0390000008F));
                    builder.AddLine(new Vector2(-80.3310013F, 0F));
                    builder.AddLine(new Vector2(-59.3569984F, 0F));
                    builder.AddCubicBezier(new Vector2(-58.5740013F, 0F), new Vector2(-57.8310013F, -0.195999995F), new Vector2(-57.1269989F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(-56.4230003F, -0.977999985F), new Vector2(-55.875F, -1.52600002F), new Vector2(-55.4840012F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(-55.0929985F, -2.93400002F), new Vector2(-54.8969994F, -3.67799997F), new Vector2(-54.8969994F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(-54.8969994F, -5.21700001F), new Vector2(-55.098999F, -5.954F), new Vector2(-55.5029984F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(-55.9080009F, -7.38899994F), new Vector2(-56.4620018F, -7.9369998F), new Vector2(-57.1660004F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(-57.8699989F, -8.69299984F), new Vector2(-58.6010017F, -8.88300037F), new Vector2(-59.3569984F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(-59.5660019F, -8.88300037F), new Vector2(-59.762001F, -8.86900043F), new Vector2(-59.9440002F, -8.84300041F));
                    builder.AddLine(new Vector2(-80.2919998F, -8.84300041F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - Layer aggregator
            // - -  Offset:<391.117, 55.994>
            CanvasGeometry Geometry_46()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(88.9229965F, -19.3299999F));
                    builder.AddCubicBezier(new Vector2(88.8180008F, -20.1650009F), new Vector2(88.6620026F, -21.0389996F), new Vector2(88.4540024F, -21.9519997F));
                    builder.AddCubicBezier(new Vector2(88.2450027F, -22.8649998F), new Vector2(87.9059982F, -23.5949993F), new Vector2(87.435997F, -24.1429996F));
                    builder.AddCubicBezier(new Vector2(86.9919968F, -24.6130009F), new Vector2(86.4649963F, -24.8990002F), new Vector2(85.8519974F, -25.0039997F));
                    builder.AddCubicBezier(new Vector2(85.2389984F, -25.1079998F), new Vector2(84.6320038F, -25.1350002F), new Vector2(84.0319977F, -25.0830002F));
                    builder.AddCubicBezier(new Vector2(83.4319992F, -25.0300007F), new Vector2(82.8450012F, -24.8990002F), new Vector2(82.2710037F, -24.691F));
                    builder.AddCubicBezier(new Vector2(81.6969986F, -24.4820004F), new Vector2(81.2279968F, -24.1299992F), new Vector2(80.862999F, -23.6350002F));
                    builder.AddCubicBezier(new Vector2(80.4970016F, -23.0610008F), new Vector2(80.2819977F, -22.3950005F), new Vector2(80.2170029F, -21.6389999F));
                    builder.AddCubicBezier(new Vector2(80.1520004F, -20.882F), new Vector2(80.1579971F, -20.1779995F), new Vector2(80.2360001F, -19.5259991F));
                    builder.AddCubicBezier(new Vector2(80.314003F, -18.3780003F), new Vector2(80.4319992F, -17.243F), new Vector2(80.5889969F, -16.1219997F));
                    builder.AddCubicBezier(new Vector2(80.7190018F, -15.1829996F), new Vector2(80.8239975F, -14.243F), new Vector2(80.9020004F, -13.3039999F));
                    builder.AddCubicBezier(new Vector2(81.2149963F, -10.9040003F), new Vector2(81.0189972F, -8.55599976F), new Vector2(80.3150024F, -6.26100016F));
                    builder.AddCubicBezier(new Vector2(79.4280014F, -3.73000002F), new Vector2(78.1689987F, -1.546F), new Vector2(76.5390015F, 0.293000013F));
                    builder.AddCubicBezier(new Vector2(74.9079971F, 2.13199997F), new Vector2(72.7890015F, 3.44300008F), new Vector2(70.1800003F, 4.22599983F));
                    builder.AddCubicBezier(new Vector2(69.7369995F, 4.32999992F), new Vector2(69.1169968F, 4.546F), new Vector2(68.3209991F, 4.87200022F));
                    builder.AddCubicBezier(new Vector2(67.526001F, 5.19799995F), new Vector2(66.8150024F, 5.60200024F), new Vector2(66.189003F, 6.08500004F));
                    builder.AddCubicBezier(new Vector2(65.5630035F, 6.56699991F), new Vector2(65.276001F, 7.12200022F), new Vector2(65.3280029F, 7.74800014F));
                    builder.AddCubicBezier(new Vector2(65.4850006F, 8.45199966F), new Vector2(65.9869995F, 8.98600006F), new Vector2(66.8339996F, 9.35200024F));
                    builder.AddCubicBezier(new Vector2(67.6819992F, 9.71700001F), new Vector2(68.4319992F, 9.93900013F), new Vector2(69.0839996F, 10.0170002F));
                    builder.AddCubicBezier(new Vector2(70.7269974F, 10.2519999F), new Vector2(72.3779984F, 10.1669998F), new Vector2(74.0339966F, 9.76299953F));
                    builder.AddCubicBezier(new Vector2(75.6900024F, 9.3579998F), new Vector2(77.2360001F, 8.77799988F), new Vector2(78.6709976F, 8.02200031F));
                    builder.AddCubicBezier(new Vector2(81.9049988F, 6.27400017F), new Vector2(84.3639984F, 3.95300007F), new Vector2(86.0469971F, 1.05700004F));
                    builder.AddCubicBezier(new Vector2(87.7300034F, -1.83899999F), new Vector2(88.7870026F, -5.00899982F), new Vector2(89.2170029F, -8.45199966F));
                    builder.AddCubicBezier(new Vector2(89.6470032F, -11.8950005F), new Vector2(89.5889969F, -15.3120003F), new Vector2(89.0410004F, -18.7040005F));
                    builder.AddCubicBezier(new Vector2(88.987999F, -18.9120007F), new Vector2(88.9489975F, -19.1210003F), new Vector2(88.9229965F, -19.3299999F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - Layer aggregator
            // - -  Offset:<391.117, 55.994>
            CanvasGeometry Geometry_47()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(36.723999F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(36.0200005F, -7.9369998F), new Vector2(35.4720001F, -7.38899994F), new Vector2(35.0810013F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(34.6899986F, -5.954F), new Vector2(34.4939995F, -5.21700001F), new Vector2(34.4939995F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(34.4939995F, -3.67799997F), new Vector2(34.6899986F, -2.93400002F), new Vector2(35.0810013F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(35.4720001F, -1.52600002F), new Vector2(36.0200005F, -0.977999985F), new Vector2(36.723999F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(37.4280014F, -0.195999995F), new Vector2(38.1599998F, 0F), new Vector2(38.9160004F, 0F));
                    builder.AddCubicBezier(new Vector2(39.6720009F, 0F), new Vector2(40.4029999F, -0.181999996F), new Vector2(41.1069984F, -0.547999978F));
                    builder.AddCubicBezier(new Vector2(42.8810005F, -1.17400002F), new Vector2(44.4329987F, -2.16499996F), new Vector2(45.7630005F, -3.52200007F));
                    builder.AddCubicBezier(new Vector2(46.2579994F, -2.71300006F), new Vector2(46.8450012F, -1.95599997F), new Vector2(47.5239983F, -1.25199997F));
                    builder.AddCubicBezier(new Vector2(50.1069984F, 1.17400002F), new Vector2(53.2050018F, 2.50399995F), new Vector2(56.8180008F, 2.73900008F));
                    builder.AddCubicBezier(new Vector2(60.4309998F, 2.97399998F), new Vector2(63.6910019F, 2.06800008F), new Vector2(66.5999985F, 0.0199999996F));
                    builder.AddCubicBezier(new Vector2(69.5080032F, -2.02800012F), new Vector2(71.197998F, -5.25600004F), new Vector2(71.6679993F, -9.66499996F));
                    builder.AddCubicBezier(new Vector2(71.8499985F, -12.1689997F), new Vector2(71.4520035F, -14.5690002F), new Vector2(70.473999F, -16.8649998F));
                    builder.AddCubicBezier(new Vector2(69.4960022F, -19.1599998F), new Vector2(67.9440002F, -21.052F), new Vector2(65.8180008F, -22.5389996F));
                    builder.AddCubicBezier(new Vector2(63.6920013F, -24.0259991F), new Vector2(60.9980011F, -24.7950001F), new Vector2(57.7369995F, -24.8479996F));
                    builder.AddCubicBezier(new Vector2(55.3110008F, -24.8220005F), new Vector2(53.1199989F, -24.2730007F), new Vector2(51.1629982F, -23.2040005F));
                    builder.AddCubicBezier(new Vector2(49.2060013F, -22.1340008F), new Vector2(47.6020012F, -20.6870003F), new Vector2(46.3499985F, -18.8610001F));
                    builder.AddCubicBezier(new Vector2(45.6189995F, -17.7910004F), new Vector2(45.0589981F, -16.6429996F), new Vector2(44.6679993F, -15.4169998F));
                    builder.AddCubicBezier(new Vector2(44.4070015F, -14.8170004F), new Vector2(44.1590004F, -14.217F), new Vector2(43.9239998F, -13.6169996F));
                    builder.AddCubicBezier(new Vector2(43.5060005F, -12.3120003F), new Vector2(42.9920006F, -11.217F), new Vector2(42.3790016F, -10.3299999F));
                    builder.AddCubicBezier(new Vector2(41.7659988F, -9.44299984F), new Vector2(40.8199997F, -8.96100044F), new Vector2(39.5419998F, -8.88300037F));
                    builder.AddLine(new Vector2(38.9160004F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(38.1599998F, -8.88300037F), new Vector2(37.4280014F, -8.69299984F), new Vector2(36.723999F, -8.31499958F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(63.3129997F, -11.974F));
                    builder.AddCubicBezier(new Vector2(63.743F, -10.1210003F), new Vector2(63.3590012F, -8.49199963F), new Vector2(62.1590004F, -7.08300018F));
                    builder.AddCubicBezier(new Vector2(61.0629997F, -5.90899992F), new Vector2(59.7529984F, -5.31500006F), new Vector2(58.2270012F, -5.30200005F));
                    builder.AddCubicBezier(new Vector2(56.7010002F, -5.28900003F), new Vector2(55.3240013F, -5.76499987F), new Vector2(54.0979996F, -6.73000002F));
                    builder.AddCubicBezier(new Vector2(53.105999F, -7.56500006F), new Vector2(52.3959999F, -8.57600021F), new Vector2(51.9659996F, -9.76299953F));
                    builder.AddCubicBezier(new Vector2(51.5359993F, -10.9499998F), new Vector2(51.4900017F, -11.9870005F), new Vector2(51.8289986F, -12.8739996F));
                    builder.AddCubicBezier(new Vector2(52.1679993F, -13.6820002F), new Vector2(52.9309998F, -14.4130001F), new Vector2(54.118F, -15.0649996F));
                    builder.AddCubicBezier(new Vector2(55.3050003F, -15.717F), new Vector2(56.7589989F, -15.9259996F), new Vector2(58.480999F, -15.691F));
                    builder.AddCubicBezier(new Vector2(61.2719994F, -15.0649996F), new Vector2(62.8829994F, -13.8260002F), new Vector2(63.3129997F, -11.974F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - Layer aggregator
            // - -  Offset:<391.117, 55.994>
            CanvasGeometry Geometry_48()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(10.0959997F, -43.5519981F));
                    builder.AddCubicBezier(new Vector2(9.82199955F, -41.5429993F), new Vector2(10.4619999F, -39.776001F), new Vector2(12.0139999F, -38.25F));
                    builder.AddCubicBezier(new Vector2(13.566F, -36.723999F), new Vector2(15.6850004F, -36.2210007F), new Vector2(18.3719997F, -36.743F));
                    builder.AddCubicBezier(new Vector2(19.7280006F, -37.0820007F), new Vector2(20.9610004F, -37.8919983F), new Vector2(22.0699997F, -39.1699982F));
                    builder.AddCubicBezier(new Vector2(23.1779995F, -40.4480019F), new Vector2(23.5370007F, -42.0519981F), new Vector2(23.1459999F, -43.9830017F));
                    builder.AddCubicBezier(new Vector2(22.6760006F, -45.5740013F), new Vector2(21.6329994F, -46.7799988F), new Vector2(20.0160007F, -47.6020012F));
                    builder.AddCubicBezier(new Vector2(18.3980007F, -48.4239998F), new Vector2(16.6240005F, -48.5740013F), new Vector2(14.6940002F, -48.0519981F));
                    builder.AddCubicBezier(new Vector2(11.9020004F, -47.0600014F), new Vector2(10.3699999F, -45.5600014F), new Vector2(10.0959997F, -43.5519981F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(11.4460001F, -13.0699997F));
                    builder.AddCubicBezier(new Vector2(12.6199999F, -14.4519997F), new Vector2(13.8389997F, -15.757F), new Vector2(15.1049995F, -16.9829998F));
                    builder.AddCubicBezier(new Vector2(16.3700008F, -18.2089996F), new Vector2(17.7590008F, -19.2259998F), new Vector2(19.2719994F, -20.0349998F));
                    builder.AddCubicBezier(new Vector2(21.1240005F, -20.8959999F), new Vector2(22.8269997F, -21.0330009F), new Vector2(24.3789997F, -20.4459991F));
                    builder.AddCubicBezier(new Vector2(25.9309998F, -19.8589993F), new Vector2(26.8500004F, -18.8470001F), new Vector2(27.1369991F, -17.4130001F));
                    builder.AddCubicBezier(new Vector2(27.4239998F, -15.9779997F), new Vector2(26.6019993F, -14.3999996F), new Vector2(24.6720009F, -12.6780005F));
                    builder.AddCubicBezier(new Vector2(22.9239998F, -11.2950001F), new Vector2(20.8899994F, -10.2189999F), new Vector2(18.5680008F, -9.44999981F));
                    builder.AddCubicBezier(new Vector2(16.2460003F, -8.68000031F), new Vector2(14.302F, -8.24300003F), new Vector2(12.7370005F, -8.13899994F));
                    builder.AddCubicBezier(new Vector2(10.7799997F, -7.95599985F), new Vector2(8.81099987F, -8.02200031F), new Vector2(6.829F, -8.33500004F));
                    builder.AddCubicBezier(new Vector2(8.42000008F, -9.74400043F), new Vector2(9.95899963F, -11.3219995F), new Vector2(11.4460001F, -13.0699997F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-5.16499996F, -2.25F));
                    builder.AddCubicBezier(new Vector2(-3.66499996F, -1.37600005F), new Vector2(-2.0539999F, -0.730000019F), new Vector2(-0.331999987F, -0.312999994F));
                    builder.AddCubicBezier(new Vector2(6.29400015F, 1.278F), new Vector2(13.0369997F, 0.925000012F), new Vector2(19.8980007F, -1.37F));
                    builder.AddCubicBezier(new Vector2(22.4020004F, -2.23099995F), new Vector2(24.7369995F, -3.36500001F), new Vector2(26.9029999F, -4.77400017F));
                    builder.AddCubicBezier(new Vector2(27.9200001F, -3.4690001F), new Vector2(29.1720009F, -2.47099996F), new Vector2(30.6590004F, -1.77999997F));
                    builder.AddCubicBezier(new Vector2(32.1459999F, -1.08800006F), new Vector2(33.6660004F, -0.620000005F), new Vector2(35.2179985F, -0.372000009F));
                    builder.AddCubicBezier(new Vector2(36.7700005F, -0.123999998F), new Vector2(38.1069984F, 0F), new Vector2(39.2290001F, 0F));
                    builder.AddLine(new Vector2(39.4239998F, 0F));
                    builder.AddCubicBezier(new Vector2(40.6500015F, 0F), new Vector2(41.7000008F, -0.430000007F), new Vector2(42.5740013F, -1.29100001F));
                    builder.AddCubicBezier(new Vector2(43.4480019F, -2.15199995F), new Vector2(43.8849983F, -3.1960001F), new Vector2(43.8849983F, -4.42199993F));
                    builder.AddCubicBezier(new Vector2(43.8849983F, -5.64799976F), new Vector2(43.4480019F, -6.69799995F), new Vector2(42.5740013F, -7.57200003F));
                    builder.AddCubicBezier(new Vector2(41.7000008F, -8.4460001F), new Vector2(40.6500015F, -8.88300037F), new Vector2(39.4239998F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(39.3979988F, -8.88300037F), new Vector2(38.7260017F, -8.90200043F), new Vector2(37.4090004F, -8.94099998F));
                    builder.AddCubicBezier(new Vector2(36.0909996F, -8.97999954F), new Vector2(34.8720016F, -9.79500008F), new Vector2(33.7509995F, -11.3870001F));
                    builder.AddCubicBezier(new Vector2(34.3769989F, -12.3000002F), new Vector2(34.9370003F, -13.2659998F), new Vector2(35.4329987F, -14.283F));
                    builder.AddCubicBezier(new Vector2(37.0239983F, -18.2220001F), new Vector2(37.0900002F, -21.4440002F), new Vector2(35.6290016F, -23.948F));
                    builder.AddCubicBezier(new Vector2(33.9329987F, -26.8169994F), new Vector2(30.7119999F, -28.4729996F), new Vector2(25.9640007F, -28.9169998F));
                    builder.AddCubicBezier(new Vector2(22.8859997F, -29.0990009F), new Vector2(20.0090008F, -28.5130005F), new Vector2(17.3349991F, -27.1569996F));
                    builder.AddCubicBezier(new Vector2(14.6610003F, -25.7999992F), new Vector2(12.2150002F, -24.0130005F), new Vector2(9.99800014F, -21.7959995F));
                    builder.AddCubicBezier(new Vector2(7.78000021F, -19.5779991F), new Vector2(5.8499999F, -17.2830009F), new Vector2(4.20699978F, -14.9090004F));
                    builder.AddCubicBezier(new Vector2(3.99799991F, -14.5959997F), new Vector2(3.76300001F, -14.243F), new Vector2(3.50300002F, -13.8520002F));
                    builder.AddCubicBezier(new Vector2(2.87700009F, -12.835F), new Vector2(2.16499996F, -11.8500004F), new Vector2(1.37F, -10.8979998F));
                    builder.AddCubicBezier(new Vector2(0.574000001F, -9.94499969F), new Vector2(-0.26699999F, -9.41699982F), new Vector2(-1.15400004F, -9.31299973F));
                    builder.AddCubicBezier(new Vector2(-1.49300003F, -9.31299973F), new Vector2(-1.79400003F, -9.41699982F), new Vector2(-2.0539999F, -9.6260004F));
                    builder.AddCubicBezier(new Vector2(-2.31500006F, -9.83399963F), new Vector2(-2.523F, -10.0559998F), new Vector2(-2.68000007F, -10.2910004F));
                    builder.AddCubicBezier(new Vector2(-3.046F, -10.8909998F), new Vector2(-3.29299998F, -11.5299997F), new Vector2(-3.4230001F, -12.2089996F));
                    builder.AddCubicBezier(new Vector2(-3.60599995F, -12.9130001F), new Vector2(-3.73699999F, -13.6300001F), new Vector2(-3.81500006F, -14.3610001F));
                    builder.AddCubicBezier(new Vector2(-3.89299989F, -14.7779999F), new Vector2(-3.97099996F, -15.1829996F), new Vector2(-4.04899979F, -15.5740004F));
                    builder.AddCubicBezier(new Vector2(-4.36199999F, -16.9559994F), new Vector2(-5.13199997F, -17.948F), new Vector2(-6.3579998F, -18.5480003F));
                    builder.AddCubicBezier(new Vector2(-7.454F, -18.9909992F), new Vector2(-8.52400017F, -18.9130001F), new Vector2(-9.56700039F, -18.3129997F));
                    builder.AddCubicBezier(new Vector2(-10.6630001F, -17.5820007F), new Vector2(-11.3149996F, -16.552F), new Vector2(-11.5229998F, -15.2220001F));
                    builder.AddCubicBezier(new Vector2(-11.5229998F, -15.1689997F), new Vector2(-11.5369997F, -15.1169996F), new Vector2(-11.5629997F, -15.0649996F));
                    builder.AddCubicBezier(new Vector2(-11.5889997F, -14.6990004F), new Vector2(-11.6149998F, -14.3479996F), new Vector2(-11.6409998F, -14.0089998F));
                    builder.AddCubicBezier(new Vector2(-11.6669998F, -13.6429996F), new Vector2(-11.7060003F, -13.2320004F), new Vector2(-11.7580004F, -12.776F));
                    builder.AddCubicBezier(new Vector2(-11.8109999F, -12.3190002F), new Vector2(-11.9020004F, -11.9219999F), new Vector2(-12.0319996F, -11.5830002F));
                    builder.AddCubicBezier(new Vector2(-12.1890001F, -11.2440004F), new Vector2(-12.4169998F, -10.9169998F), new Vector2(-12.717F, -10.6040001F));
                    builder.AddCubicBezier(new Vector2(-13.0170002F, -10.2910004F), new Vector2(-13.3100004F, -10.0299997F), new Vector2(-13.5970001F, -9.82199955F));
                    builder.AddCubicBezier(new Vector2(-14.1969995F, -9.37800026F), new Vector2(-14.9219999F, -9.11100006F), new Vector2(-15.7690001F, -9.02000046F));
                    builder.AddCubicBezier(new Vector2(-16.6170006F, -8.92800045F), new Vector2(-17.4060001F, -8.88300037F), new Vector2(-18.1359997F, -8.88300037F));
                    builder.AddLine(new Vector2(-18.1760006F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(-19.4020004F, -8.88300037F), new Vector2(-20.4519997F, -8.4460001F), new Vector2(-21.3260002F, -7.57200003F));
                    builder.AddCubicBezier(new Vector2(-22.2000008F, -6.69799995F), new Vector2(-22.6359997F, -5.64799976F), new Vector2(-22.6359997F, -4.42199993F));
                    builder.AddCubicBezier(new Vector2(-22.6359997F, -3.1960001F), new Vector2(-22.2000008F, -2.15199995F), new Vector2(-21.3260002F, -1.29100001F));
                    builder.AddCubicBezier(new Vector2(-20.4519997F, -0.430000007F), new Vector2(-19.4020004F, 0F), new Vector2(-18.1760006F, 0F));
                    builder.AddLine(new Vector2(-18.1359997F, 0F));
                    builder.AddLine(new Vector2(-18.1359997F, 0.0390000008F));
                    builder.AddCubicBezier(new Vector2(-15.9449997F, 0.0130000003F), new Vector2(-13.9759998F, -0.677999973F), new Vector2(-12.2279997F, -2.03500009F));
                    builder.AddCubicBezier(new Vector2(-10.7939997F, -3.02600002F), new Vector2(-9.68500042F, -4.26499987F), new Vector2(-8.90200043F, -5.75199986F));
                    builder.AddCubicBezier(new Vector2(-7.91099977F, -4.29099989F), new Vector2(-6.66499996F, -3.12400007F), new Vector2(-5.16499996F, -2.25F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - Layer aggregator
            // - -  Offset:<391.117, 55.994>
            CanvasGeometry Geometry_49()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-20.7959995F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(-21.5F, -7.9369998F), new Vector2(-22.0550003F, -7.38899994F), new Vector2(-22.4589996F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(-22.8640003F, -5.954F), new Vector2(-23.066F, -5.21700001F), new Vector2(-23.066F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(-23.066F, -3.67799997F), new Vector2(-22.8700008F, -2.93400002F), new Vector2(-22.4790001F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(-22.0879993F, -1.52600002F), new Vector2(-21.5389996F, -0.977999985F), new Vector2(-20.8349991F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(-20.1310005F, -0.195999995F), new Vector2(-19.3880005F, 0F), new Vector2(-18.6049995F, 0F));
                    builder.AddCubicBezier(new Vector2(-17.8490009F, 0F), new Vector2(-17.1119995F, -0.195999995F), new Vector2(-16.3939991F, -0.587000012F));
                    builder.AddCubicBezier(new Vector2(-15.677F, -0.977999985F), new Vector2(-15.1280003F, -1.52600002F), new Vector2(-14.75F, -2.23000002F));
                    builder.AddCubicBezier(new Vector2(-14.3719997F, -2.93400002F), new Vector2(-14.1829996F, -3.67799997F), new Vector2(-14.1829996F, -4.46099997F));
                    builder.AddCubicBezier(new Vector2(-14.1829996F, -5.21700001F), new Vector2(-14.3789997F, -5.954F), new Vector2(-14.7700005F, -6.67199993F));
                    builder.AddCubicBezier(new Vector2(-15.1610003F, -7.38899994F), new Vector2(-15.7159996F, -7.9369998F), new Vector2(-16.4330006F, -8.31499958F));
                    builder.AddCubicBezier(new Vector2(-17.1509991F, -8.69299984F), new Vector2(-17.875F, -8.88300037F), new Vector2(-18.6049995F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(-19.3619995F, -8.88300037F), new Vector2(-20.0919991F, -8.69299984F), new Vector2(-20.7959995F, -8.31499958F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-19.0739994F, -8.88300037F));
                    builder.AddCubicBezier(new Vector2(-20.8220005F, -8.82999992F), new Vector2(-22.316F, -9.26099968F), new Vector2(-23.5550003F, -10.1739998F));
                    builder.AddCubicBezier(new Vector2(-24.7940006F, -11.0869999F), new Vector2(-25.4790001F, -12.7959995F), new Vector2(-25.6089993F, -15.3000002F));
                    builder.AddLine(new Vector2(-25.2959995F, -38.4650002F));
                    builder.AddCubicBezier(new Vector2(-25.3740005F, -41.2560005F), new Vector2(-26.073F, -43.0299988F), new Vector2(-27.3899994F, -43.7869987F));
                    builder.AddCubicBezier(new Vector2(-28.7080002F, -44.5429993F), new Vector2(-30.0380001F, -44.5169983F), new Vector2(-31.3810005F, -43.7089996F));
                    builder.AddCubicBezier(new Vector2(-32.7249985F, -42.9000015F), new Vector2(-33.4620018F, -41.5299988F), new Vector2(-33.5919991F, -39.5999985F));
                    builder.AddLine(new Vector2(-33.7480011F, -23.243F));
                    builder.AddLine(new Vector2(-33.7480011F, -22.6170006F));
                    builder.AddCubicBezier(new Vector2(-33.8009987F, -19.7210007F), new Vector2(-33.7550011F, -16.9300003F), new Vector2(-33.6110001F, -14.243F));
                    builder.AddCubicBezier(new Vector2(-33.4679985F, -11.5559998F), new Vector2(-32.9920006F, -9.14299965F), new Vector2(-32.1829987F, -7.00400019F));
                    builder.AddCubicBezier(new Vector2(-31.375F, -4.86499977F), new Vector2(-30.0310001F, -3.16300011F), new Vector2(-28.1529999F, -1.898F));
                    builder.AddCubicBezier(new Vector2(-26.2749996F, -0.632000029F), new Vector2(-23.6009998F, 0F), new Vector2(-20.1310005F, 0F));
                    builder.AddLine(new Vector2(-18.448F, 0F));
                    builder.AddLine(new Vector2(-18.448F, -8.88300037F));
                    builder.AddLine(new Vector2(-19.0739994F, -8.88300037F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - - Layer aggregator
            // - -  Offset:<391.117, 55.994>
            CanvasGeometry Geometry_50()
            {
                CanvasGeometry result;
                using (var builder = new CanvasPathBuilder(null))
                {
                    builder.SetFilledRegionDetermination(CanvasFilledRegionDetermination.Winding);
                    builder.BeginFigure(new Vector2(-71.6849976F, -11.8570004F));
                    builder.AddCubicBezier(new Vector2(-71.9589996F, -9.84799957F), new Vector2(-71.3199997F, -8.07999992F), new Vector2(-69.7679977F, -6.5539999F));
                    builder.AddCubicBezier(new Vector2(-68.2160034F, -5.02799988F), new Vector2(-66.0960007F, -4.52600002F), new Vector2(-63.4090004F, -5.04799986F));
                    builder.AddCubicBezier(new Vector2(-62.0530014F, -5.38700008F), new Vector2(-60.8199997F, -6.1960001F), new Vector2(-59.7109985F, -7.47399998F));
                    builder.AddCubicBezier(new Vector2(-58.6030006F, -8.75199986F), new Vector2(-58.2439995F, -10.3559999F), new Vector2(-58.6349983F, -12.2869997F));
                    builder.AddCubicBezier(new Vector2(-59.1049995F, -13.8780003F), new Vector2(-60.1489983F, -15.085F), new Vector2(-61.7659988F, -15.9069996F));
                    builder.AddCubicBezier(new Vector2(-63.3839989F, -16.7290001F), new Vector2(-65.1569977F, -16.8789997F), new Vector2(-67.086998F, -16.3570004F));
                    builder.AddCubicBezier(new Vector2(-69.8789978F, -15.3649998F), new Vector2(-71.4110031F, -13.8649998F), new Vector2(-71.6849976F, -11.8570004F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    builder.BeginFigure(new Vector2(-85.7529984F, 6.33900023F));
                    builder.AddCubicBezier(new Vector2(-82.4660034F, 10.2519999F), new Vector2(-78.447998F, 13.0500002F), new Vector2(-73.6999969F, 14.7329998F));
                    builder.AddCubicBezier(new Vector2(-68.9520035F, 16.4160004F), new Vector2(-64.0810013F, 16.7999992F), new Vector2(-59.0849991F, 15.8870001F));
                    builder.AddCubicBezier(new Vector2(-54.0900002F, 14.974F), new Vector2(-49.5569992F, 12.6000004F), new Vector2(-45.4869995F, 8.76500034F));
                    builder.AddCubicBezier(new Vector2(-42.3310013F, 5.63500023F), new Vector2(-40.0550003F, 1.94299996F), new Vector2(-38.6590004F, -2.30900002F));
                    builder.AddCubicBezier(new Vector2(-37.2639999F, -6.56099987F), new Vector2(-36.9959984F, -10.8389997F), new Vector2(-37.8569984F, -15.1429996F));
                    builder.AddCubicBezier(new Vector2(-38.144001F, -16.6560001F), new Vector2(-38.6269989F, -18.1700001F), new Vector2(-39.3050003F, -19.6830006F));
                    builder.AddCubicBezier(new Vector2(-40.2700005F, -21.5610008F), new Vector2(-41.4910011F, -22.6170006F), new Vector2(-42.9640007F, -22.8519993F));
                    builder.AddCubicBezier(new Vector2(-44.4379997F, -23.0869999F), new Vector2(-45.7480011F, -22.7150002F), new Vector2(-46.8959999F, -21.7369995F));
                    builder.AddCubicBezier(new Vector2(-48.0439987F, -20.7590008F), new Vector2(-48.6049995F, -19.3700008F), new Vector2(-48.5789986F, -17.5699997F));
                    builder.AddCubicBezier(new Vector2(-48.4749985F, -16.3439999F), new Vector2(-48.2140007F, -15F), new Vector2(-47.7960014F, -13.5389996F));
                    builder.AddCubicBezier(new Vector2(-47.3009987F, -11.8170004F), new Vector2(-46.9749985F, -9.93900013F), new Vector2(-46.8180008F, -7.90399981F));
                    builder.AddCubicBezier(new Vector2(-46.7400017F, -4.82600021F), new Vector2(-47.6329994F, -2.11299992F), new Vector2(-49.4980011F, 0.234999999F));
                    builder.AddCubicBezier(new Vector2(-51.362999F, 2.58299994F), new Vector2(-53.7179985F, 4.36899996F), new Vector2(-56.5610008F, 5.59600019F));
                    builder.AddCubicBezier(new Vector2(-60.7610016F, 7.23899984F), new Vector2(-64.8180008F, 7.63100004F), new Vector2(-68.7310028F, 6.76999998F));
                    builder.AddCubicBezier(new Vector2(-74.262001F, 5.44000006F), new Vector2(-78.1419983F, 2.54900002F), new Vector2(-80.3720016F, -1.898F));
                    builder.AddCubicBezier(new Vector2(-82.6019974F, -6.34499979F), new Vector2(-82.6480026F, -11.217F), new Vector2(-80.5090027F, -16.5130005F));
                    builder.AddCubicBezier(new Vector2(-79.1529999F, -19.2779999F), new Vector2(-77.3399963F, -21.3780003F), new Vector2(-75.0699997F, -22.8129997F));
                    builder.AddCubicBezier(new Vector2(-72.8000031F, -24.2469997F), new Vector2(-70.5960007F, -25.3689995F), new Vector2(-68.4570007F, -26.1779995F));
                    builder.AddCubicBezier(new Vector2(-66.9179993F, -26.7779999F), new Vector2(-65.6470032F, -27.3850002F), new Vector2(-64.6419983F, -27.9979992F));
                    builder.AddCubicBezier(new Vector2(-63.6380005F, -28.6110001F), new Vector2(-63.0960007F, -29.3479996F), new Vector2(-63.0180016F, -30.2089996F));
                    builder.AddCubicBezier(new Vector2(-63.0709991F, -31.6429996F), new Vector2(-63.9119987F, -32.5769997F), new Vector2(-65.5419998F, -33.007F));
                    builder.AddCubicBezier(new Vector2(-67.1729965F, -33.4370003F), new Vector2(-68.7180023F, -33.5740013F), new Vector2(-70.1790009F, -33.4169998F));
                    builder.AddCubicBezier(new Vector2(-74.0660019F, -32.9990005F), new Vector2(-77.7050018F, -31.6110001F), new Vector2(-81.0960007F, -29.25F));
                    builder.AddCubicBezier(new Vector2(-84.487999F, -26.8889999F), new Vector2(-87.1809998F, -23.8759995F), new Vector2(-89.177002F, -20.2110004F));
                    builder.AddCubicBezier(new Vector2(-91.1729965F, -16.5459995F), new Vector2(-92F, -12.5469999F), new Vector2(-91.6610031F, -8.21700001F));
                    builder.AddCubicBezier(new Vector2(-91.0090027F, -2.42600012F), new Vector2(-89.0400009F, 2.42600012F), new Vector2(-85.7529984F, 6.33900023F));
                    builder.EndFigure(CanvasFigureLoop.Closed);
                    result = (CanvasGeometry)(object)CanvasGeometry.CreatePath(builder);
                }
                return result;
            }

            // - - Layer aggregator
            // - Layer: sprk20
            // Color
            ColorKeyFrameAnimation ColorAnimation_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_0()
            {
                // Frame 0.
                var result = CreateColorKeyFrameAnimation(0F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), StepThenHoldEasingFunction());
                // Frame 35.
                // TransparentAlmostGold_00F8C900
                result.InsertKeyFrame(0.194444448F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), HoldThenStepEasingFunction());
                // Frame 36.
                // AlmostGold_FFF8C900
                result.InsertKeyFrame(0.200000003F, Color.FromArgb(0xFF, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_3());
                // Frame 74.
                // AlmostGold_FFF8C900
                result.InsertKeyFrame(0.411111116F, Color.FromArgb(0xFF, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_4());
                // Frame 75.
                // TransparentAlmostGold_00F8C900
                result.InsertKeyFrame(0.416666657F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_3());
                return result;
            }

            // - - Layer aggregator
            // - Layer: sprk19
            // Color
            ColorKeyFrameAnimation ColorAnimation_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_1()
            {
                // Frame 0.
                var result = CreateColorKeyFrameAnimation(0F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), StepThenHoldEasingFunction());
                // Frame 23.
                // TransparentAlmostGold_00F8C900
                result.InsertKeyFrame(0.127777785F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), HoldThenStepEasingFunction());
                // Frame 24.
                // AlmostGold_FFF8C900
                result.InsertKeyFrame(0.13333334F, Color.FromArgb(0xFF, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_3());
                // Frame 62.
                // AlmostGold_FFF8C900
                result.InsertKeyFrame(0.344444454F, Color.FromArgb(0xFF, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_4());
                // Frame 63.
                // TransparentAlmostGold_00F8C900
                result.InsertKeyFrame(0.349999994F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_3());
                // Frame 111.
                // TransparentAlmostGold_00F8C900
                result.InsertKeyFrame(0.616666675F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_4());
                // Frame 112.
                // AlmostGold_FFF8C900
                result.InsertKeyFrame(0.622222245F, Color.FromArgb(0xFF, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_3());
                // Frame 150.
                // AlmostGold_FFF8C900
                result.InsertKeyFrame(0.833333313F, Color.FromArgb(0xFF, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_4());
                // Frame 151.
                // TransparentAlmostGold_00F8C900
                result.InsertKeyFrame(0.838888884F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_3());
                return result;
            }

            // - - Layer aggregator
            // - Layer: sprk08
            // Color
            ColorKeyFrameAnimation ColorAnimation_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_2()
            {
                // Frame 0.
                var result = CreateColorKeyFrameAnimation(0F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), StepThenHoldEasingFunction());
                // Frame 65.
                // TransparentAlmostGold_00F8C900
                result.InsertKeyFrame(0.361111104F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), HoldThenStepEasingFunction());
                // Frame 66.
                // AlmostGold_FFF8C900
                result.InsertKeyFrame(0.366666675F, Color.FromArgb(0xFF, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_3());
                // Frame 104.
                // AlmostGold_FFF8C900
                result.InsertKeyFrame(0.577777803F, Color.FromArgb(0xFF, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_4());
                // Frame 105.
                // TransparentAlmostGold_00F8C900
                result.InsertKeyFrame(0.583333313F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_3());
                return result;
            }

            // - - Layer aggregator
            // - Layer: sprk07
            // Color
            ColorKeyFrameAnimation ColorAnimation_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_3()
            {
                // Frame 0.
                var result = CreateColorKeyFrameAnimation(0F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), StepThenHoldEasingFunction());
                // Frame 54.
                // TransparentAlmostGold_00F8C900
                result.InsertKeyFrame(0.300000012F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), HoldThenStepEasingFunction());
                // Frame 55.
                // AlmostGold_FFF8C900
                result.InsertKeyFrame(0.305555552F, Color.FromArgb(0xFF, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_3());
                // Frame 93.
                // AlmostGold_FFF8C900
                result.InsertKeyFrame(0.516666651F, Color.FromArgb(0xFF, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_4());
                // Frame 94.
                // TransparentAlmostGold_00F8C900
                result.InsertKeyFrame(0.522222221F, Color.FromArgb(0x00, 0xF8, 0xC9, 0x00), CubicBezierEasingFunction_3());
                return result;
            }

            // - Layer aggregator
            // Layer: sprk20
            CompositionColorBrush AnimatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_0()
            {
                if (_animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_0 != null) { return _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_0; }
                var result = _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_0 = _c.CreateColorBrush();
                return result;
            }

            // - Layer aggregator
            // Layer: sprk19
            CompositionColorBrush AnimatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_1()
            {
                if (_animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_1 != null) { return _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_1; }
                var result = _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_1 = _c.CreateColorBrush();
                return result;
            }

            // - Layer aggregator
            // Layer: sprk08
            CompositionColorBrush AnimatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_2()
            {
                if (_animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_2 != null) { return _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_2; }
                var result = _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_2 = _c.CreateColorBrush();
                return result;
            }

            // - Layer aggregator
            // Layer: sprk07
            CompositionColorBrush AnimatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_3()
            {
                if (_animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_3 != null) { return _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_3; }
                var result = _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_3 = _c.CreateColorBrush();
                return result;
            }

            CompositionColorBrush ColorBrush_AlmostGold_FFF8C900()
            {
                return (_colorBrush_AlmostGold_FFF8C900 == null)
                    ? _colorBrush_AlmostGold_FFF8C900 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0xF8, 0xC9, 0x00))
                    : _colorBrush_AlmostGold_FFF8C900;
            }

            CompositionColorBrush ColorBrush_AlmostMidnightBlue_FF002C5D()
            {
                return (_colorBrush_AlmostMidnightBlue_FF002C5D == null)
                    ? _colorBrush_AlmostMidnightBlue_FF002C5D = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x00, 0x2C, 0x5D))
                    : _colorBrush_AlmostMidnightBlue_FF002C5D;
            }

            CompositionColorBrush ColorBrush_AlmostTeal_FF004DA5()
            {
                return (_colorBrush_AlmostTeal_FF004DA5 == null)
                    ? _colorBrush_AlmostTeal_FF004DA5 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x00, 0x4D, 0xA5))
                    : _colorBrush_AlmostTeal_FF004DA5;
            }

            CompositionColorBrush ColorBrush_AlmostTeal_FF004DA6()
            {
                return (_colorBrush_AlmostTeal_FF004DA6 == null)
                    ? _colorBrush_AlmostTeal_FF004DA6 = _c.CreateColorBrush(Color.FromArgb(0xFF, 0x00, 0x4D, 0xA6))
                    : _colorBrush_AlmostTeal_FF004DA6;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Offset:<-34.737, 11.75>
            CompositionColorBrush ColorBrush_SemiTransparentBlack()
            {
                return _c.CreateColorBrush(Color.FromArgb(0x66, 0x00, 0x00, 0x00));
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Offset:<-34.737, 11.75>
            CompositionColorBrush ColorBrush_SemiTransparentWhite()
            {
                return _c.CreateColorBrush(Color.FromArgb(0x4C, 0xFF, 0xFF, 0xFF));
            }

            // - - - - - - - PreComp layer: ramadan
            // - Opacity for layer: moon Outlines
            // ShapeGroup: Group 1 Offset:<228.357, 262>
            CompositionColorBrush ColorBrush_White()
            {
                return _c.CreateColorBrush(Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF));
            }

            // - - - - - - - - - PreComp layer: ramadan
            // - - - Shape tree root for layer: Shape Layer 1
            // - ShapeGroup: Rectangle 1 Scale:1,1.22998, Offset:<-192.5, -8.5>
            // Stop 0
            CompositionColorGradientStop GradientStop_0_Transparent_0()
            {
                return _c.CreateColorGradientStop(0F, Color.FromArgb(0x00, 0x00, 0x00, 0x00));
            }

            // - - - - - - - - - PreComp layer: ramadan
            // - - - Shape tree root for layer: Shape Layer 1
            // - ShapeGroup: Rectangle 1 Scale:1,1.22998, Offset:<-192.5, -8.5>
            // Stop 1
            CompositionColorGradientStop GradientStop_0_Transparent_1()
            {
                return _c.CreateColorGradientStop(0F, Color.FromArgb(0x00, 0x00, 0x00, 0x00));
            }

            // - - - - - - - - - PreComp layer: ramadan
            // - - - Shape tree root for layer: Shape Layer 1
            // - ShapeGroup: Rectangle 1 Scale:1,1.22998, Offset:<-192.5, -8.5>
            // Stop 2
            CompositionColorGradientStop GradientStop_0p5_SemiTransparentBlack_0()
            {
                return _c.CreateColorGradientStop(0.5F, Color.FromArgb(0x7F, 0x00, 0x00, 0x00));
            }

            // - - - - - - - - - PreComp layer: ramadan
            // - - - Shape tree root for layer: Shape Layer 1
            // - ShapeGroup: Rectangle 1 Scale:1,1.22998, Offset:<-192.5, -8.5>
            // Stop 3
            CompositionColorGradientStop GradientStop_0p5_SemiTransparentBlack_1()
            {
                return _c.CreateColorGradientStop(0.5F, Color.FromArgb(0x7F, 0x00, 0x00, 0x00));
            }

            // - - - - - - - - - PreComp layer: ramadan
            // - - - Shape tree root for layer: Shape Layer 1
            // - ShapeGroup: Rectangle 1 Scale:1,1.22998, Offset:<-192.5, -8.5>
            // Stop 4
            CompositionColorGradientStop GradientStop_1_Black_0()
            {
                return _c.CreateColorGradientStop(1F, Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
            }

            // - - - - - - - - - PreComp layer: ramadan
            // - - - Shape tree root for layer: Shape Layer 1
            // - ShapeGroup: Rectangle 1 Scale:1,1.22998, Offset:<-192.5, -8.5>
            // Stop 5
            CompositionColorGradientStop GradientStop_1_Black_1()
            {
                return _c.CreateColorGradientStop(1F, Color.FromArgb(0xFF, 0x00, 0x00, 0x00));
            }

            // - PreComp layer: ramadan
            // Layer aggregator
            CompositionContainerShape ContainerShape_0()
            {
                if (_containerShape_0 != null) { return _containerShape_0; }
                var result = _containerShape_0 = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(52.9529991F, 164.011993F);
                result.Offset = new Vector2(337.566986F, 261.593018F);
                var shapes = result.Shapes;
                // ShapeGroup: Group 15 Offset:<28.453, 28.095>
                shapes.Add(SpriteShape_00());
                // ShapeGroup: Group 14 Offset:<28.453, 11.095>
                shapes.Add(SpriteShape_01());
                // ShapeGroup: Group 13 Offset:<28.453, 8.445>
                shapes.Add(SpriteShape_02());
                // ShapeGroup: Group 12 Offset:<6.344, 69.486>
                shapes.Add(SpriteShape_03());
                // ShapeGroup: Group 11 Offset:<28.391, 133.232>
                shapes.Add(SpriteShape_04());
                // ShapeGroup: Group 10 Offset:<17.398, 69.486>
                shapes.Add(SpriteShape_05());
                // ShapeGroup: Group 9 Offset:<28.453, 69.486>
                shapes.Add(SpriteShape_06());
                // ShapeGroup: Group 8 Offset:<39.507, 69.486>
                shapes.Add(SpriteShape_07());
                // ShapeGroup: Group 7 Offset:<50.56, 69.486>
                shapes.Add(SpriteShape_08());
                // ShapeGroup: Group 6 Offset:<28.452, 6.573>
                shapes.Add(SpriteShape_09());
                // ShapeGroup: Group 5 Offset:<28.446, 3.044>
                shapes.Add(SpriteShape_10());
                // ShapeGroup: Group 4 Offset:<28.453, 114.182>
                shapes.Add(SpriteShape_11());
                // ShapeGroup: Group 3 Offset:<28.453, 141.256>
                shapes.Add(SpriteShape_12());
                // ShapeGroup: Group 2 Offset:<28.452, 44.087>
                shapes.Add(SpriteShape_13());
                // ShapeGroup: Group 1 Offset:<28.452, 95.271>
                shapes.Add(SpriteShape_14());
                return result;
            }

            // - PreComp layer: ramadan
            // Layer aggregator
            CompositionContainerShape ContainerShape_1()
            {
                if (_containerShape_1 != null) { return _containerShape_1; }
                var result = _containerShape_1 = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(141.020996F, 297.321991F);
                result.Offset = new Vector2(186F, 132.946014F);
                var shapes = result.Shapes;
                // ShapeGroup: Group 9 Offset:<75.021, 84.332>
                shapes.Add(SpriteShape_15());
                // ShapeGroup: Group 8 Offset:<75.021, 39.258>
                shapes.Add(SpriteShape_16());
                // ShapeGroup: Group 7 Offset:<75.021, 32.235>
                shapes.Add(SpriteShape_17());
                // ShapeGroup: Group 6 Offset:<73.077, 15.857>
                shapes.Add(SpriteShape_18());
                // ShapeGroup: Group 5 Offset:<75.021, 244.485>
                shapes.Add(SpriteShape_19());
                // ShapeGroup: Group 4 Offset:<75.021, 126.732>
                shapes.Add(SpriteShape_20());
                // ShapeGroup: Group 3
                shapes.Add(SpriteShape_21());
                // ShapeGroup: Group 3
                shapes.Add(SpriteShape_22());
                // ShapeGroup: Group 3
                shapes.Add(SpriteShape_23());
                return result;
            }

            // - PreComp layer: ramadan
            // Layer aggregator
            CompositionContainerShape ContainerShape_2()
            {
                if (_containerShape_2 != null) { return _containerShape_2; }
                var result = _containerShape_2 = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(43.0200005F, 220.585007F);
                result.Offset = new Vector2(133.972F, 146.974991F);
                var shapes = result.Shapes;
                // ShapeGroup: Group 26 Offset:<23.52, 23.225>
                shapes.Add(SpriteShape_24());
                // ShapeGroup: Group 25 Offset:<23.52, 9.197>
                shapes.Add(SpriteShape_25());
                // ShapeGroup: Group 24 Offset:<23.52, 7.012>
                shapes.Add(SpriteShape_26());
                // ShapeGroup: Group 23 Offset:<5.279, 57.378>
                shapes.Add(SpriteShape_27());
                // ShapeGroup: Group 22 Offset:<23.469, 95.161>
                shapes.Add(SpriteShape_28());
                // ShapeGroup: Group 21 Offset:<23.469, 187.045>
                shapes.Add(SpriteShape_29());
                // ShapeGroup: Group 20 Offset:<23.52, 113.074>
                shapes.Add(SpriteShape_30());
                // ShapeGroup: Group 19 Offset:<23.52, 139.658>
                shapes.Add(SpriteShape_31());
                // ShapeGroup: Group 18 Offset:<5.279, 126.206>
                shapes.Add(SpriteShape_32());
                // ShapeGroup: Group 17 Offset:<14.4, 126.206>
                shapes.Add(SpriteShape_33());
                // ShapeGroup: Group 16 Offset:<23.52, 126.206>
                shapes.Add(SpriteShape_34());
                // ShapeGroup: Group 15 Offset:<32.64, 126.206>
                shapes.Add(SpriteShape_35());
                // ShapeGroup: Group 14 Offset:<41.761, 126.206>
                shapes.Add(SpriteShape_36());
                // ShapeGroup: Group 13 Offset:<14.4, 57.378>
                shapes.Add(SpriteShape_37());
                // ShapeGroup: Group 12 Offset:<23.52, 57.378>
                shapes.Add(SpriteShape_38());
                // ShapeGroup: Group 11 Offset:<32.64, 57.378>
                shapes.Add(SpriteShape_39());
                // ShapeGroup: Group 10 Offset:<41.761, 57.378>
                shapes.Add(SpriteShape_40());
                // ShapeGroup: Group 9 Offset:<23.52, 5.467>
                shapes.Add(SpriteShape_41());
                // ShapeGroup: Group 8 Offset:<23.515, 2.555>
                shapes.Add(SpriteShape_42());
                // ShapeGroup: Group 7 Offset:<23.52, 96.144>
                shapes.Add(SpriteShape_43());
                // ShapeGroup: Group 6 Offset:<23.52, 156.169>
                shapes.Add(SpriteShape_44());
                // ShapeGroup: Group 5 Offset:<23.52, 182.839>
                shapes.Add(SpriteShape_45());
                // ShapeGroup: Group 4 Offset:<23.52, 113.074>
                shapes.Add(SpriteShape_46());
                // ShapeGroup: Group 3 Offset:<23.52, 139.658>
                shapes.Add(SpriteShape_47());
                // ShapeGroup: Group 2 Offset:<23.52, 78.653>
                shapes.Add(SpriteShape_48());
                // ShapeGroup: Group 1 Offset:<23.52, 36.42>
                shapes.Add(SpriteShape_49());
                return result;
            }

            // - - - - - - PreComp layer: ramadan
            // Shape tree root for layer: Shape Layer 1
            CompositionContainerShape ContainerShape_3()
            {
                if (_containerShape_3 != null) { return _containerShape_3; }
                var result = _containerShape_3 = _c.CreateContainerShape();
                result.CenterPoint = new Vector2(-192.5F, -8.5F);
                result.RotationAngleInDegrees = 45F;
                result.Scale = new Vector2(0.436159998F, 1F);
                // ShapeGroup: Rectangle 1 Scale:1,1.22998, Offset:<-192.5, -8.5>
                result.Shapes.Add(SpriteShape_54());
                return result;
            }

            // - PreComp layer: ramadan
            CompositionEffectBrush EffectBrush()
            {
                var compositeEffect = new CompositeEffect
                {
                    Mode = CanvasComposite.DestinationIn
                };
                compositeEffect.Sources.Add(new CompositionEffectSourceParameter("destination"));
                compositeEffect.Sources.Add(new CompositionEffectSourceParameter("source"));
                var effectFactory = _c.CreateEffectFactory(compositeEffect);
                var result = effectFactory.CreateBrush();
                result.SetSourceParameter("destination", SurfaceBrush_0());
                result.SetSourceParameter("source", SurfaceBrush_1());
                return result;
            }

            // - - - - - - - - PreComp layer: ramadan
            // - - Shape tree root for layer: Shape Layer 1
            // ShapeGroup: Rectangle 1 Scale:1,1.22998, Offset:<-192.5, -8.5>
            CompositionLinearGradientBrush LinearGradientBrush()
            {
                var result = _c.CreateLinearGradientBrush();
                var colorStops = result.ColorStops;
                colorStops.Add(GradientStop_0_Transparent_0());
                colorStops.Add(GradientStop_0_Transparent_1());
                colorStops.Add(GradientStop_0p5_SemiTransparentBlack_0());
                colorStops.Add(GradientStop_0p5_SemiTransparentBlack_1());
                colorStops.Add(GradientStop_1_Black_0());
                colorStops.Add(GradientStop_1_Black_1());
                result.MappingMode = CompositionMappingMode.Absolute;
                result.StartPoint = new Vector2(153.203003F, 242.464005F);
                result.EndPoint = new Vector2(0.0930023193F, 242.464005F);
                return result;
            }

            CompositionPath Path_0()
            {
                if (_path_0 != null) { return _path_0; }
                var result = _path_0 = new CompositionPath(Geometry_37());
                return result;
            }

            CompositionPath Path_1()
            {
                if (_path_1 != null) { return _path_1; }
                var result = _path_1 = new CompositionPath(Geometry_38());
                return result;
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 15 Offset:<28.453, 28.095>
            CompositionPathGeometry PathGeometry_00()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_00()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 14 Offset:<28.453, 11.095>
            CompositionPathGeometry PathGeometry_01()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_01()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 13 Offset:<28.453, 8.445>
            CompositionPathGeometry PathGeometry_02()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_02()));
            }

            CompositionPathGeometry PathGeometry_03()
            {
                return (_pathGeometry_03 == null)
                    ? _pathGeometry_03 = _c.CreatePathGeometry(new CompositionPath(Geometry_03()))
                    : _pathGeometry_03;
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 11 Offset:<28.391, 133.232>
            CompositionPathGeometry PathGeometry_04()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_04()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 6 Offset:<28.452, 6.573>
            CompositionPathGeometry PathGeometry_05()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_05()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 5 Offset:<28.446, 3.044>
            CompositionPathGeometry PathGeometry_06()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_06()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 4 Offset:<28.453, 114.182>
            CompositionPathGeometry PathGeometry_07()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_07()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 3 Offset:<28.453, 141.256>
            CompositionPathGeometry PathGeometry_08()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_08()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 2 Offset:<28.452, 44.087>
            CompositionPathGeometry PathGeometry_09()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_09()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 1 Offset:<28.452, 95.271>
            CompositionPathGeometry PathGeometry_10()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_10()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 9 Offset:<75.021, 84.332>
            CompositionPathGeometry PathGeometry_11()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_11()));
            }

            CompositionPathGeometry PathGeometry_12()
            {
                return (_pathGeometry_12 == null)
                    ? _pathGeometry_12 = _c.CreatePathGeometry(new CompositionPath(Geometry_12()))
                    : _pathGeometry_12;
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 6 Offset:<73.077, 15.857>
            CompositionPathGeometry PathGeometry_13()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_13()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 5 Offset:<75.021, 244.485>
            CompositionPathGeometry PathGeometry_14()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_14()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 4 Offset:<75.021, 126.732>
            CompositionPathGeometry PathGeometry_15()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_15()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 3
            CompositionPathGeometry PathGeometry_16()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_16()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 3
            CompositionPathGeometry PathGeometry_17()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_17()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 3
            CompositionPathGeometry PathGeometry_18()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_18()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 26 Offset:<23.52, 23.225>
            CompositionPathGeometry PathGeometry_19()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_19()));
            }

            CompositionPathGeometry PathGeometry_20()
            {
                return (_pathGeometry_20 == null)
                    ? _pathGeometry_20 = _c.CreatePathGeometry(new CompositionPath(Geometry_20()))
                    : _pathGeometry_20;
            }

            CompositionPathGeometry PathGeometry_21()
            {
                return (_pathGeometry_21 == null)
                    ? _pathGeometry_21 = _c.CreatePathGeometry(new CompositionPath(Geometry_21()))
                    : _pathGeometry_21;
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 22 Offset:<23.469, 95.161>
            CompositionPathGeometry PathGeometry_22()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_22()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 21 Offset:<23.469, 187.045>
            CompositionPathGeometry PathGeometry_23()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_23()));
            }

            CompositionPathGeometry PathGeometry_24()
            {
                return (_pathGeometry_24 == null)
                    ? _pathGeometry_24 = _c.CreatePathGeometry(new CompositionPath(Geometry_24()))
                    : _pathGeometry_24;
            }

            CompositionPathGeometry PathGeometry_25()
            {
                return (_pathGeometry_25 == null)
                    ? _pathGeometry_25 = _c.CreatePathGeometry(new CompositionPath(Geometry_25()))
                    : _pathGeometry_25;
            }

            CompositionPathGeometry PathGeometry_26()
            {
                return (_pathGeometry_26 == null)
                    ? _pathGeometry_26 = _c.CreatePathGeometry(new CompositionPath(Geometry_26()))
                    : _pathGeometry_26;
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 9 Offset:<23.52, 5.467>
            CompositionPathGeometry PathGeometry_27()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_27()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 8 Offset:<23.515, 2.555>
            CompositionPathGeometry PathGeometry_28()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_28()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 7 Offset:<23.52, 96.144>
            CompositionPathGeometry PathGeometry_29()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_29()));
            }

            CompositionPathGeometry PathGeometry_30()
            {
                return (_pathGeometry_30 == null)
                    ? _pathGeometry_30 = _c.CreatePathGeometry(new CompositionPath(Geometry_30()))
                    : _pathGeometry_30;
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 2 Offset:<23.52, 78.653>
            CompositionPathGeometry PathGeometry_31()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_31()));
            }

            // - - - PreComp layer: ramadan
            // - - Layer aggregator
            // ShapeGroup: Group 1 Offset:<23.52, 36.42>
            CompositionPathGeometry PathGeometry_32()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_32()));
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Offset:<-34.737, 11.75>
            CompositionPathGeometry PathGeometry_33()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_33()));
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Offset:<-34.737, 11.75>
            CompositionPathGeometry PathGeometry_34()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_34()));
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Offset:<-34.737, 11.75>
            CompositionPathGeometry PathGeometry_35()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_35()));
            }

            // - - - - - - - PreComp layer: ramadan
            // - Opacity for layer: moon Outlines
            // ShapeGroup: Group 1 Offset:<228.357, 262>
            CompositionPathGeometry PathGeometry_36()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_36()));
            }

            // - Layer aggregator
            // Layer: sprk20
            CompositionPathGeometry PathGeometry_37()
            {
                if (_pathGeometry_37 != null) { return _pathGeometry_37; }
                var result = _pathGeometry_37 = _c.CreatePathGeometry();
                return result;
            }

            // - Layer aggregator
            // Layer: sprk19
            CompositionPathGeometry PathGeometry_38()
            {
                if (_pathGeometry_38 != null) { return _pathGeometry_38; }
                var result = _pathGeometry_38 = _c.CreatePathGeometry();
                return result;
            }

            // - Layer aggregator
            // Layer: sprk08
            CompositionPathGeometry PathGeometry_39()
            {
                if (_pathGeometry_39 != null) { return _pathGeometry_39; }
                var result = _pathGeometry_39 = _c.CreatePathGeometry();
                return result;
            }

            // - Layer aggregator
            // Layer: sprk07
            CompositionPathGeometry PathGeometry_40()
            {
                if (_pathGeometry_40 != null) { return _pathGeometry_40; }
                var result = _pathGeometry_40 = _c.CreatePathGeometry();
                return result;
            }

            // - Layer aggregator
            // Offset:<392.972, 145.778>
            CompositionPathGeometry PathGeometry_41()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_39()));
            }

            // - Layer aggregator
            // Offset:<392.972, 145.778>
            CompositionPathGeometry PathGeometry_42()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_40()));
            }

            // - Layer aggregator
            // Offset:<392.972, 145.778>
            CompositionPathGeometry PathGeometry_43()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_41()));
            }

            // - Layer aggregator
            // Offset:<392.972, 145.778>
            CompositionPathGeometry PathGeometry_44()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_42()));
            }

            // - Layer aggregator
            // Offset:<392.972, 145.778>
            CompositionPathGeometry PathGeometry_45()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_43()));
            }

            // - Layer aggregator
            // Offset:<392.972, 145.778>
            CompositionPathGeometry PathGeometry_46()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_44()));
            }

            // - Layer aggregator
            // Offset:<392.972, 145.778>
            CompositionPathGeometry PathGeometry_47()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_45()));
            }

            // - Layer aggregator
            // Offset:<391.117, 55.994>
            CompositionPathGeometry PathGeometry_48()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_46()));
            }

            // - Layer aggregator
            // Offset:<391.117, 55.994>
            CompositionPathGeometry PathGeometry_49()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_47()));
            }

            // - Layer aggregator
            // Offset:<391.117, 55.994>
            CompositionPathGeometry PathGeometry_50()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_48()));
            }

            // - Layer aggregator
            // Offset:<391.117, 55.994>
            CompositionPathGeometry PathGeometry_51()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_49()));
            }

            // - Layer aggregator
            // Offset:<391.117, 55.994>
            CompositionPathGeometry PathGeometry_52()
            {
                return _c.CreatePathGeometry(new CompositionPath(Geometry_50()));
            }

            // - - - - - - - - PreComp layer: ramadan
            // - - Shape tree root for layer: Shape Layer 1
            // ShapeGroup: Rectangle 1 Scale:1,1.22998, Offset:<-192.5, -8.5>
            // Rectangle Path 1.RectangleGeometry
            CompositionRectangleGeometry Rectangle_153x485()
            {
                var result = _c.CreateRectangleGeometry();
                result.Offset = new Vector2(-76.5F, -242.5F);
                result.Size = new Vector2(153F, 485F);
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_00()
            {
                // Offset:<28.453, 28.095>
                var geometry = PathGeometry_00();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 28.4529991F, 28.0949993F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_01()
            {
                // Offset:<28.453, 11.095>
                var geometry = PathGeometry_01();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 28.4529991F, 11.0950003F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_02()
            {
                // Offset:<28.453, 8.445>
                var geometry = PathGeometry_02();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 28.4529991F, 8.44499969F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_03()
            {
                // Offset:<6.344, 69.486>
                var geometry = PathGeometry_03();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 6.34399986F, 69.4860001F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_04()
            {
                // Offset:<28.391, 133.232>
                var geometry = PathGeometry_04();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 28.3910007F, 133.231995F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_05()
            {
                // Offset:<17.398, 69.486>
                var geometry = PathGeometry_03();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 17.3980007F, 69.4860001F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_06()
            {
                // Offset:<28.453, 69.486>
                var geometry = PathGeometry_03();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 28.4529991F, 69.4860001F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_07()
            {
                // Offset:<39.507, 69.486>
                var geometry = PathGeometry_03();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 39.507F, 69.4860001F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_08()
            {
                // Offset:<50.56, 69.486>
                var geometry = PathGeometry_03();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 50.5600014F, 69.4860001F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_09()
            {
                // Offset:<28.452, 6.573>
                var geometry = PathGeometry_05();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 28.4519997F, 6.57299995F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_10()
            {
                // Offset:<28.446, 3.044>
                var geometry = PathGeometry_06();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 28.4459991F, 3.04399991F), ColorBrush_AlmostGold_FFF8C900()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_11()
            {
                // Offset:<28.453, 114.182>
                var geometry = PathGeometry_07();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 28.4529991F, 114.181999F), ColorBrush_AlmostTeal_FF004DA5()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_12()
            {
                // Offset:<28.453, 141.256>
                var geometry = PathGeometry_08();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 28.4529991F, 141.255997F), ColorBrush_AlmostTeal_FF004DA5()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_13()
            {
                // Offset:<28.452, 44.087>
                var geometry = PathGeometry_09();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 28.4519997F, 44.0870018F), ColorBrush_AlmostGold_FFF8C900()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_14()
            {
                // Offset:<28.452, 95.271>
                var geometry = PathGeometry_10();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 28.4519997F, 95.2710037F), ColorBrush_AlmostGold_FFF8C900()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_15()
            {
                // Offset:<75.021, 84.332>
                var geometry = PathGeometry_11();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 75.0210037F, 84.3320007F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_16()
            {
                // Offset:<75.021, 39.258>
                var geometry = PathGeometry_12();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 75.0210037F, 39.2579994F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_17()
            {
                // Offset:<75.021, 32.235>
                var geometry = PathGeometry_12();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 75.0210037F, 32.2350006F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_18()
            {
                // Offset:<73.077, 15.857>
                var geometry = PathGeometry_13();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 73.0770035F, 15.8570004F), ColorBrush_AlmostGold_FFF8C900()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // ShapeGroup: Group 5 Offset:<75.021, 244.485>
            CompositionSpriteShape SpriteShape_19()
            {
                // Offset:<75.021, 244.485>
                var geometry = PathGeometry_14();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 75.0210037F, 244.485001F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_20()
            {
                // Offset:<75.021, 126.732>
                var geometry = PathGeometry_15();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 75.0210037F, 126.732002F), ColorBrush_AlmostGold_FFF8C900()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_21()
            {
                var result = _c.CreateSpriteShape(PathGeometry_16());
                result.StrokeBrush = ColorBrush_AlmostTeal_FF004DA6();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 5F;
                result.StrokeThickness = 2.61800003F;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_22()
            {
                var result = _c.CreateSpriteShape(PathGeometry_17());
                result.StrokeBrush = ColorBrush_AlmostTeal_FF004DA6();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 5F;
                result.StrokeThickness = 2.61800003F;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_23()
            {
                var result = _c.CreateSpriteShape(PathGeometry_18());
                result.StrokeBrush = ColorBrush_AlmostTeal_FF004DA6();
                result.StrokeDashCap = CompositionStrokeCap.Round;
                result.StrokeStartCap = CompositionStrokeCap.Round;
                result.StrokeEndCap = CompositionStrokeCap.Round;
                result.StrokeMiterLimit = 5F;
                result.StrokeThickness = 2.61800003F;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_24()
            {
                // Offset:<23.52, 23.225>
                var geometry = PathGeometry_19();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 23.2250004F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_25()
            {
                // Offset:<23.52, 9.197>
                var geometry = PathGeometry_20();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 9.19699955F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_26()
            {
                // Offset:<23.52, 7.012>
                var geometry = PathGeometry_20();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 7.01200008F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_27()
            {
                // Offset:<5.279, 57.378>
                var geometry = PathGeometry_21();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 5.27899981F, 57.3779984F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_28()
            {
                // Offset:<23.469, 95.161>
                var geometry = PathGeometry_22();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.4689999F, 95.1610031F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_29()
            {
                // Offset:<23.469, 187.045>
                var geometry = PathGeometry_23();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.4689999F, 187.044998F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_30()
            {
                // Offset:<23.52, 113.074>
                var geometry = PathGeometry_24();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 113.073997F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_31()
            {
                // Offset:<23.52, 139.658>
                var geometry = PathGeometry_25();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 139.658005F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_32()
            {
                // Offset:<5.279, 126.206>
                var geometry = PathGeometry_26();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 5.27899981F, 126.206001F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_33()
            {
                // Offset:<14.4, 126.206>
                var geometry = PathGeometry_26();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 14.3999996F, 126.206001F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_34()
            {
                // Offset:<23.52, 126.206>
                var geometry = PathGeometry_26();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 126.206001F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_35()
            {
                // Offset:<32.64, 126.206>
                var geometry = PathGeometry_26();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 32.6399994F, 126.206001F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_36()
            {
                // Offset:<41.761, 126.206>
                var geometry = PathGeometry_26();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 41.7610016F, 126.206001F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_37()
            {
                // Offset:<14.4, 57.378>
                var geometry = PathGeometry_21();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 14.3999996F, 57.3779984F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_38()
            {
                // Offset:<23.52, 57.378>
                var geometry = PathGeometry_21();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 57.3779984F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_39()
            {
                // Offset:<32.64, 57.378>
                var geometry = PathGeometry_21();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 32.6399994F, 57.3779984F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_40()
            {
                // Offset:<41.761, 57.378>
                var geometry = PathGeometry_21();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 41.7610016F, 57.3779984F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_41()
            {
                // Offset:<23.52, 5.467>
                var geometry = PathGeometry_27();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 5.46700001F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_42()
            {
                // Offset:<23.515, 2.555>
                var geometry = PathGeometry_28();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5149994F, 2.55500007F), ColorBrush_AlmostGold_FFF8C900()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_43()
            {
                // Offset:<23.52, 96.144>
                var geometry = PathGeometry_29();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 96.1439972F), ColorBrush_AlmostTeal_FF004DA6()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_44()
            {
                // Offset:<23.52, 156.169>
                var geometry = PathGeometry_30();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 156.169006F), ColorBrush_AlmostTeal_FF004DA6()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_45()
            {
                // Offset:<23.52, 182.839>
                var geometry = PathGeometry_30();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 182.839005F), ColorBrush_AlmostTeal_FF004DA6()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_46()
            {
                // Offset:<23.52, 113.074>
                var geometry = PathGeometry_24();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 113.073997F), ColorBrush_AlmostGold_FFF8C900()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_47()
            {
                // Offset:<23.52, 139.658>
                var geometry = PathGeometry_25();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 139.658005F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_48()
            {
                // Offset:<23.52, 78.653>
                var geometry = PathGeometry_31();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 78.6529999F), ColorBrush_AlmostGold_FFF8C900()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            // - Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_49()
            {
                // Offset:<23.52, 36.42>
                var geometry = PathGeometry_32();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 23.5200005F, 36.4199982F), ColorBrush_AlmostGold_FFF8C900()); ;
                return result;
            }

            // - PreComp layer: ramadan
            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_50()
            {
                // Offset:<240.267, 263.486>
                var geometry = PathGeometry_33();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 240.266998F, 263.485992F), ColorBrush_SemiTransparentBlack()); ;
                return result;
            }

            // - PreComp layer: ramadan
            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_51()
            {
                // Offset:<228.35599, 262>
                var geometry = PathGeometry_34();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 228.355988F, 262F), ColorBrush_AlmostGold_FFF8C900()); ;
                return result;
            }

            // - PreComp layer: ramadan
            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_52()
            {
                // Offset:<264.164, 233.533>
                var geometry = PathGeometry_35();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 264.164001F, 233.533005F), ColorBrush_SemiTransparentWhite()); ;
                return result;
            }

            // - - - - - - PreComp layer: ramadan
            // Opacity for layer: moon Outlines
            // Path 1
            CompositionSpriteShape SpriteShape_53()
            {
                // Offset:<228.357, 262>
                var geometry = PathGeometry_36();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 228.356995F, 262F), ColorBrush_White()); ;
                return result;
            }

            // - - - - - - - PreComp layer: ramadan
            // - Shape tree root for layer: Shape Layer 1
            // Rectangle Path 1
            CompositionSpriteShape SpriteShape_54()
            {
                // Offset:<-192.5, -8.5>, Scale:<1, 1.22998>
                var geometry = Rectangle_153x485();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1.22997999F, -192.5F, -8.5F), LinearGradientBrush()); ;
                return result;
            }

            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_55()
            {
                // Offset:<503.19, 158.39>, Rotation:-0.005986284076242989 degrees, Scale:<0.62, 0.62>
                var geometry = PathGeometry_37();
                if (_spriteShape_55 != null) { return _spriteShape_55; }
                var result = _spriteShape_55 = CreateSpriteShape(geometry, new Matrix3x2(0.620000005F, 0F, 0F, 0.620000005F, 503.190002F, 158.389999F), AnimatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_0()); ;
                result.Scale = new Vector2(0F, 0F);
                return result;
            }

            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_56()
            {
                // Offset:<514.13, 248.53>, Rotation:-0.01003107040454514 degrees, Scale:<0.74, 0.74>
                var geometry = PathGeometry_38();
                if (_spriteShape_56 != null) { return _spriteShape_56; }
                var result = _spriteShape_56 = CreateSpriteShape(geometry, new Matrix3x2(0.74000001F, 0F, 0F, 0.74000001F, 514.130005F, 248.529999F), AnimatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_1()); ;
                result.Scale = new Vector2(0F, 0F);
                return result;
            }

            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_57()
            {
                // Offset:<745.15, 449.15>, Scale:<0.7, 0.7>
                var geometry = PathGeometry_39();
                if (_spriteShape_57 != null) { return _spriteShape_57; }
                var result = _spriteShape_57 = CreateSpriteShape(geometry, new Matrix3x2(0.699999988F, 0F, 0F, 0.699999988F, 745.150024F, 449.149994F), AnimatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_2()); ;
                result.Scale = new Vector2(0F, 0F);
                return result;
            }

            // Layer aggregator
            // Path 1
            CompositionSpriteShape SpriteShape_58()
            {
                // Offset:<654.7, 320.7>, Scale:<0.6, 0.6>
                var geometry = PathGeometry_40();
                if (_spriteShape_58 != null) { return _spriteShape_58; }
                var result = _spriteShape_58 = CreateSpriteShape(geometry, new Matrix3x2(0.600000024F, 0F, 0F, 0.600000024F, 654.700012F, 320.700012F), AnimatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_3()); ;
                result.Scale = new Vector2(0F, 0F);
                return result;
            }

            // Layer aggregator
            // ShapeGroup: م
            CompositionSpriteShape SpriteShape_59()
            {
                // Offset:<392.972, 145.778>
                var geometry = PathGeometry_41();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 392.971985F, 145.778F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // Layer aggregator
            // ShapeGroup: م
            CompositionSpriteShape SpriteShape_60()
            {
                // Offset:<392.972, 145.778>
                var geometry = PathGeometry_42();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 392.971985F, 145.778F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // Layer aggregator
            // ShapeGroup: م
            CompositionSpriteShape SpriteShape_61()
            {
                // Offset:<392.972, 145.778>
                var geometry = PathGeometry_43();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 392.971985F, 145.778F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // Layer aggregator
            // ر
            CompositionSpriteShape SpriteShape_62()
            {
                // Offset:<392.972, 145.778>
                var geometry = PathGeometry_44();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 392.971985F, 145.778F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // Layer aggregator
            // ShapeGroup: م
            CompositionSpriteShape SpriteShape_63()
            {
                // Offset:<392.972, 145.778>
                var geometry = PathGeometry_45();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 392.971985F, 145.778F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // Layer aggregator
            // ـ
            CompositionSpriteShape SpriteShape_64()
            {
                // Offset:<392.972, 145.778>
                var geometry = PathGeometry_46();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 392.971985F, 145.778F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // Layer aggregator
            // ـ
            CompositionSpriteShape SpriteShape_65()
            {
                // Offset:<392.972, 145.778>
                var geometry = PathGeometry_47();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 392.971985F, 145.778F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // Layer aggregator
            // ر
            CompositionSpriteShape SpriteShape_66()
            {
                // Offset:<391.117, 55.994>
                var geometry = PathGeometry_48();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 391.117004F, 55.9939995F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // Layer aggregator
            // ShapeGroup: ر
            CompositionSpriteShape SpriteShape_67()
            {
                // Offset:<391.117, 55.994>
                var geometry = PathGeometry_49();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 391.117004F, 55.9939995F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // Layer aggregator
            // ShapeGroup: ر
            CompositionSpriteShape SpriteShape_68()
            {
                // Offset:<391.117, 55.994>
                var geometry = PathGeometry_50();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 391.117004F, 55.9939995F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // Layer aggregator
            // ShapeGroup: ر
            CompositionSpriteShape SpriteShape_69()
            {
                // Offset:<391.117, 55.994>
                var geometry = PathGeometry_51();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 391.117004F, 55.9939995F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // Layer aggregator
            // ShapeGroup: ر
            CompositionSpriteShape SpriteShape_70()
            {
                // Offset:<391.117, 55.994>
                var geometry = PathGeometry_52();
                var result = CreateSpriteShape(geometry, new Matrix3x2(1F, 0F, 0F, 1F, 391.117004F, 55.9939995F), ColorBrush_AlmostMidnightBlue_FF002C5D()); ;
                return result;
            }

            // - - PreComp layer: ramadan
            CompositionSurfaceBrush SurfaceBrush_0()
            {
                return _c.CreateSurfaceBrush(VisualSurface_0());
            }

            // - - PreComp layer: ramadan
            CompositionSurfaceBrush SurfaceBrush_1()
            {
                return _c.CreateSurfaceBrush(VisualSurface_1());
            }

            // - - - PreComp layer: ramadan
            CompositionVisualSurface VisualSurface_0()
            {
                var result = _c.CreateVisualSurface();
                result.SourceVisual = ContainerVisual_1();
                result.SourceSize = new Vector2(512F, 512F);
                return result;
            }

            // - - - PreComp layer: ramadan
            CompositionVisualSurface VisualSurface_1()
            {
                var result = _c.CreateVisualSurface();
                result.SourceVisual = ContainerVisual_2();
                result.SourceSize = new Vector2(512F, 512F);
                return result;
            }

            // Transforms for ramadan Scale(1,1,0)
            ContainerVisual ContainerVisual_0()
            {
                var result = _c.CreateContainerVisual();
                result.Clip = InsetClip_0();
                result.Size = new Vector2(512F, 512F);
                // Scale:<1, 1>
                result.TransformMatrix = new Matrix4x4(1F, 0F, 0F, 0F, 0F, 1F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 0F, 1F);
                var children = result.Children;
                // Layer aggregator
                children.InsertAtTop(ShapeVisual_0());
                children.InsertAtTop(SpriteVisual_0());
                return result;
            }

            // - - - - PreComp layer: ramadan
            ContainerVisual ContainerVisual_1()
            {
                var result = _c.CreateContainerVisual();
                result.BorderMode = CompositionBorderMode.Soft;
                // Opacity for layer: moon Outlines
                result.Children.InsertAtTop(ShapeVisual_1());
                return result;
            }

            // - - - - PreComp layer: ramadan
            ContainerVisual ContainerVisual_2()
            {
                var result = _c.CreateContainerVisual();
                result.BorderMode = CompositionBorderMode.Soft;
                // Shape tree root for layer: Shape Layer 1
                result.Children.InsertAtTop(ShapeVisual_2());
                return result;
            }

            // The root of the composition.
            ContainerVisual Root()
            {
                if (_root != null) { return _root; }
                var result = _root = _c.CreateContainerVisual();
                var propertySet = result.Properties;
                propertySet.InsertScalar("Progress", 0F);
                propertySet.InsertScalar("t0", 0F);
                var children = result.Children;
                // PreComp layer: ramadan
                children.InsertAtTop(ContainerVisual_0());
                // Layer aggregator
                children.InsertAtTop(ShapeVisual_3());
                return result;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_0()
            {
                return (_cubicBezierEasingFunction_0 == null)
                    ? _cubicBezierEasingFunction_0 = _c.CreateCubicBezierEasingFunction(new Vector2(0.166999996F, 0.166999996F), new Vector2(0.600000024F, 1F))
                    : _cubicBezierEasingFunction_0;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_1()
            {
                return (_cubicBezierEasingFunction_1 == null)
                    ? _cubicBezierEasingFunction_1 = _c.CreateCubicBezierEasingFunction(new Vector2(0.166999996F, 0F), new Vector2(0.560000002F, 1F))
                    : _cubicBezierEasingFunction_1;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_2()
            {
                return (_cubicBezierEasingFunction_2 == null)
                    ? _cubicBezierEasingFunction_2 = _c.CreateCubicBezierEasingFunction(new Vector2(0.439999998F, 0F), new Vector2(0.833000004F, 1F))
                    : _cubicBezierEasingFunction_2;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_3()
            {
                return (_cubicBezierEasingFunction_3 == null)
                    ? _cubicBezierEasingFunction_3 = _c.CreateCubicBezierEasingFunction(new Vector2(0.166999996F, 0.166999996F), new Vector2(0.833000004F, 0.833000004F))
                    : _cubicBezierEasingFunction_3;
            }

            CubicBezierEasingFunction CubicBezierEasingFunction_4()
            {
                return (_cubicBezierEasingFunction_4 == null)
                    ? _cubicBezierEasingFunction_4 = _c.CreateCubicBezierEasingFunction(new Vector2(0.166999996F, 0F), new Vector2(0.833000004F, 1F))
                    : _cubicBezierEasingFunction_4;
            }

            ExpressionAnimation RootProgress()
            {
                if (_rootProgress != null) { return _rootProgress; }
                var result = _rootProgress = _c.CreateExpressionAnimation("_.Progress");
                result.SetReferenceParameter("_", _root);
                return result;
            }

            // PreComp layer: ramadan
            InsetClip InsetClip_0()
            {
                var result = _c.CreateInsetClip();
                return result;
            }

            // - - Layer aggregator
            // - Layer: sprk20
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_0()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_0(), StepThenHoldEasingFunction());
                // Frame 35.
                result.InsertKeyFrame(0.194444448F, Path_0(), HoldThenStepEasingFunction());
                // Frame 55.
                result.InsertKeyFrame(0.305555552F, Path_1(), CubicBezierEasingFunction_1());
                // Frame 75.
                result.InsertKeyFrame(0.416666657F, Path_0(), CubicBezierEasingFunction_2());
                return result;
            }

            // - - Layer aggregator
            // - Layer: sprk19
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_1()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_0(), StepThenHoldEasingFunction());
                // Frame 23.
                result.InsertKeyFrame(0.127777785F, Path_0(), HoldThenStepEasingFunction());
                // Frame 43.
                result.InsertKeyFrame(0.23888889F, Path_1(), CubicBezierEasingFunction_1());
                // Frame 63.
                result.InsertKeyFrame(0.349999994F, Path_0(), CubicBezierEasingFunction_2());
                // Frame 111.
                result.InsertKeyFrame(0.616666675F, Path_0(), CubicBezierEasingFunction_4());
                // Frame 131.
                result.InsertKeyFrame(0.727777779F, Path_1(), CubicBezierEasingFunction_1());
                // Frame 151.
                result.InsertKeyFrame(0.838888884F, Path_0(), CubicBezierEasingFunction_2());
                return result;
            }

            // - - Layer aggregator
            // - Layer: sprk08
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_2()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_0(), StepThenHoldEasingFunction());
                // Frame 65.
                result.InsertKeyFrame(0.361111104F, Path_0(), HoldThenStepEasingFunction());
                // Frame 85.
                result.InsertKeyFrame(0.472222209F, Path_1(), CubicBezierEasingFunction_1());
                // Frame 105.
                result.InsertKeyFrame(0.583333313F, Path_0(), CubicBezierEasingFunction_2());
                return result;
            }

            // - - Layer aggregator
            // - Layer: sprk07
            // Path
            PathKeyFrameAnimation PathKeyFrameAnimation_3()
            {
                // Frame 0.
                var result = CreatePathKeyFrameAnimation(0F, Path_0(), StepThenHoldEasingFunction());
                // Frame 54.
                result.InsertKeyFrame(0.300000012F, Path_0(), HoldThenStepEasingFunction());
                // Frame 74.
                result.InsertKeyFrame(0.411111116F, Path_1(), CubicBezierEasingFunction_1());
                // Frame 94.
                result.InsertKeyFrame(0.522222221F, Path_0(), CubicBezierEasingFunction_2());
                return result;
            }

            // Scale
            ScalarKeyFrameAnimation ScalarAnimation_0_to_1_0()
            {
                // Frame 0.
                if (_scalarAnimation_0_to_1_0 != null) { return _scalarAnimation_0_to_1_0; }
                var result = _scalarAnimation_0_to_1_0 = CreateScalarKeyFrameAnimation(0F, 0F, HoldThenStepEasingFunction());
                // Frame 15.
                result.InsertKeyFrame(0.0833333358F, 1.10000002F, CubicBezierEasingFunction_0());
                // Frame 25.
                result.InsertKeyFrame(0.138888896F, 1F, CubicBezierEasingFunction_0());
                return result;
            }

            // Scale
            ScalarKeyFrameAnimation ScalarAnimation_0_to_1_1()
            {
                // Frame 0.
                if (_scalarAnimation_0_to_1_1 != null) { return _scalarAnimation_0_to_1_1; }
                var result = _scalarAnimation_0_to_1_1 = CreateScalarKeyFrameAnimation(0F, 0F, StepThenHoldEasingFunction());
                // Frame 10.
                result.InsertKeyFrame(0.055555556F, 0F, HoldThenStepEasingFunction());
                // Frame 25.
                result.InsertKeyFrame(0.138888896F, 1.10000002F, CubicBezierEasingFunction_0());
                // Frame 35.
                result.InsertKeyFrame(0.194444448F, 1F, CubicBezierEasingFunction_0());
                return result;
            }

            // Scale
            ScalarKeyFrameAnimation ScalarAnimation_0_to_1_2()
            {
                // Frame 0.
                if (_scalarAnimation_0_to_1_2 != null) { return _scalarAnimation_0_to_1_2; }
                var result = _scalarAnimation_0_to_1_2 = CreateScalarKeyFrameAnimation(0F, 0F, StepThenHoldEasingFunction());
                // Frame 20.
                result.InsertKeyFrame(0.111111112F, 0F, HoldThenStepEasingFunction());
                // Frame 35.
                result.InsertKeyFrame(0.194444448F, 1.10000002F, CubicBezierEasingFunction_0());
                // Frame 45.
                result.InsertKeyFrame(0.25F, 1F, CubicBezierEasingFunction_0());
                return result;
            }

            ScalarKeyFrameAnimation t0ScalarAnimation_0_to_1()
            {
                // Frame 70.
                var result = CreateScalarKeyFrameAnimation(0.388888925F, 0F, StepThenHoldEasingFunction());
                result.SetReferenceParameter("_", _root);
                // Frame 140.
                result.InsertKeyFrame(0.777777731F, 1F, _c.CreateCubicBezierEasingFunction(new Vector2(0.166999996F, 0.194000006F), new Vector2(0.899999976F, 1F)));
                return result;
            }

            // PreComp layer: ramadan
            // Layer aggregator
            ShapeVisual ShapeVisual_0()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(512F, 512F);
                var shapes = result.Shapes;
                shapes.Add(ContainerShape_0());
                shapes.Add(ContainerShape_1());
                shapes.Add(ContainerShape_2());
                // Offset:<-34.737, 11.75>
                shapes.Add(SpriteShape_50());
                // Offset:<-34.737, 11.75>
                shapes.Add(SpriteShape_51());
                // Offset:<-34.737, 11.75>
                shapes.Add(SpriteShape_52());
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // Shape tree root for layer: moon Outlines
            ShapeVisual ShapeVisual_1()
            {
                var result = _c.CreateShapeVisual();
                result.Opacity = 0.600000024F;
                result.Size = new Vector2(512F, 512F);
                // ShapeGroup: Group 1 Offset:<228.357, 262>
                result.Shapes.Add(SpriteShape_53());
                return result;
            }

            // - - - - - PreComp layer: ramadan
            // Shape tree root for layer: Shape Layer 1
            ShapeVisual ShapeVisual_2()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(512F, 512F);
                result.Shapes.Add(ContainerShape_3());
                return result;
            }

            // Layer aggregator
            ShapeVisual ShapeVisual_3()
            {
                var result = _c.CreateShapeVisual();
                result.Size = new Vector2(512F, 512F);
                var shapes = result.Shapes;
                // Layer: sprk20
                shapes.Add(SpriteShape_55());
                // Layer: sprk19
                shapes.Add(SpriteShape_56());
                // Layer: sprk08
                shapes.Add(SpriteShape_57());
                // Layer: sprk07
                shapes.Add(SpriteShape_58());
                // Offset:<392.972, 145.778>
                shapes.Add(SpriteShape_59());
                // Offset:<392.972, 145.778>
                shapes.Add(SpriteShape_60());
                // Offset:<392.972, 145.778>
                shapes.Add(SpriteShape_61());
                // Offset:<392.972, 145.778>
                shapes.Add(SpriteShape_62());
                // Offset:<392.972, 145.778>
                shapes.Add(SpriteShape_63());
                // Offset:<392.972, 145.778>
                shapes.Add(SpriteShape_64());
                // Offset:<392.972, 145.778>
                shapes.Add(SpriteShape_65());
                // Offset:<391.117, 55.994>
                shapes.Add(SpriteShape_66());
                // Offset:<391.117, 55.994>
                shapes.Add(SpriteShape_67());
                // Offset:<391.117, 55.994>
                shapes.Add(SpriteShape_68());
                // Offset:<391.117, 55.994>
                shapes.Add(SpriteShape_69());
                // Offset:<391.117, 55.994>
                shapes.Add(SpriteShape_70());
                return result;
            }

            // PreComp layer: ramadan
            SpriteVisual SpriteVisual_0()
            {
                var result = _c.CreateSpriteVisual();
                result.Size = new Vector2(512F, 512F);
                result.Brush = EffectBrush();
                return result;
            }

            StepEasingFunction HoldThenStepEasingFunction()
            {
                if (_holdThenStepEasingFunction != null) { return _holdThenStepEasingFunction; }
                var result = _holdThenStepEasingFunction = _c.CreateStepEasingFunction();
                result.IsFinalStepSingleFrame = true;
                return result;
            }

            StepEasingFunction StepThenHoldEasingFunction()
            {
                if (_stepThenHoldEasingFunction != null) { return _stepThenHoldEasingFunction; }
                var result = _stepThenHoldEasingFunction = _c.CreateStepEasingFunction();
                result.IsInitialStepSingleFrame = true;
                return result;
            }

            // - - - - - - - PreComp layer: ramadan
            // - Shape tree root for layer: Shape Layer 1
            // Offset
            Vector2KeyFrameAnimation OffsetVector2Animation()
            {
                // Frame 0.
                var result = CreateVector2KeyFrameAnimation(0F, new Vector2(176.039993F, 58.8889999F), StepThenHoldEasingFunction());
                result.SetReferenceParameter("_", _root);
                // Frame 70.
                result.InsertKeyFrame(0.388888896F, new Vector2(176.039993F, 58.8889999F), HoldThenStepEasingFunction());
                // Frame 140.
                result.InsertExpressionKeyFrame(0.777777731F, "Pow(1-_.t0,3)*Vector2(176.04,58.889)+(3*Square(1-_.t0)*_.t0*Vector2(259.04,137.889))+(3*(1-_.t0)*Square(_.t0)*Vector2(591.04,453.889))+(Pow(_.t0,3)*Vector2(674.04,532.889))", StepThenHoldEasingFunction());
                // Frame 140.
                result.InsertKeyFrame(0.777777791F, new Vector2(674.039978F, 532.888977F), StepThenHoldEasingFunction());
                return result;
            }

            // - Layer aggregator
            // Layer: sprk20
            Vector2KeyFrameAnimation ShapeVisibilityAnimation_0()
            {
                // Frame 0.
                var result = CreateVector2KeyFrameAnimation(0F, new Vector2(0F, 0F), HoldThenStepEasingFunction());
                // Frame 35.
                result.InsertKeyFrame(0.194444448F, new Vector2(1F, 1F), HoldThenStepEasingFunction());
                return result;
            }

            // - Layer aggregator
            // Layer: sprk19
            Vector2KeyFrameAnimation ShapeVisibilityAnimation_1()
            {
                // Frame 0.
                var result = CreateVector2KeyFrameAnimation(0F, new Vector2(0F, 0F), HoldThenStepEasingFunction());
                // Frame 23.
                result.InsertKeyFrame(0.127777785F, new Vector2(1F, 1F), HoldThenStepEasingFunction());
                return result;
            }

            // - Layer aggregator
            // Layer: sprk08
            Vector2KeyFrameAnimation ShapeVisibilityAnimation_2()
            {
                // Frame 0.
                var result = CreateVector2KeyFrameAnimation(0F, new Vector2(0F, 0F), HoldThenStepEasingFunction());
                // Frame 65.
                result.InsertKeyFrame(0.361111104F, new Vector2(1F, 1F), HoldThenStepEasingFunction());
                return result;
            }

            // - Layer aggregator
            // Layer: sprk07
            Vector2KeyFrameAnimation ShapeVisibilityAnimation_3()
            {
                // Frame 0.
                var result = CreateVector2KeyFrameAnimation(0F, new Vector2(0F, 0F), HoldThenStepEasingFunction());
                // Frame 54.
                result.InsertKeyFrame(0.300000012F, new Vector2(1F, 1F), HoldThenStepEasingFunction());
                return result;
            }

            internal RamadanMubarak_AnimatedVisual(
                Compositor compositor
                )
            {
                _c = compositor;
                _reusableExpressionAnimation = compositor.CreateExpressionAnimation();
                Root();
            }

            public Visual RootVisual => _root;
            public TimeSpan Duration => TimeSpan.FromTicks(c_durationTicks);
            public Vector2 Size => new(512F, 512F);
            void IDisposable.Dispose() => _root?.Dispose();

            public void CreateAnimations()
            {
                StartProgressBoundAnimation(_animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_0, "Color", ColorAnimation_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_0(), RootProgress());
                StartProgressBoundAnimation(_animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_1, "Color", ColorAnimation_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_1(), RootProgress());
                StartProgressBoundAnimation(_animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_2, "Color", ColorAnimation_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_2(), RootProgress());
                StartProgressBoundAnimation(_animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_3, "Color", ColorAnimation_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_3(), RootProgress());
                StartProgressBoundAnimation(_containerShape_0, "Scale.X", ScalarAnimation_0_to_1_0(), RootProgress());
                StartProgressBoundAnimation(_containerShape_0, "Scale.Y", ScalarAnimation_0_to_1_0(), RootProgress());
                StartProgressBoundAnimation(_containerShape_1, "Scale.X", ScalarAnimation_0_to_1_1(), RootProgress());
                StartProgressBoundAnimation(_containerShape_1, "Scale.Y", ScalarAnimation_0_to_1_1(), RootProgress());
                StartProgressBoundAnimation(_containerShape_2, "Scale.X", ScalarAnimation_0_to_1_2(), RootProgress());
                StartProgressBoundAnimation(_containerShape_2, "Scale.Y", ScalarAnimation_0_to_1_2(), RootProgress());
                StartProgressBoundAnimation(_containerShape_3, "Offset", OffsetVector2Animation(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_37, "Path", PathKeyFrameAnimation_0(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_38, "Path", PathKeyFrameAnimation_1(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_39, "Path", PathKeyFrameAnimation_2(), RootProgress());
                StartProgressBoundAnimation(_pathGeometry_40, "Path", PathKeyFrameAnimation_3(), RootProgress());
                StartProgressBoundAnimation(_spriteShape_55, "Scale", ShapeVisibilityAnimation_0(), RootProgress());
                StartProgressBoundAnimation(_spriteShape_56, "Scale", ShapeVisibilityAnimation_1(), RootProgress());
                StartProgressBoundAnimation(_spriteShape_57, "Scale", ShapeVisibilityAnimation_2(), RootProgress());
                StartProgressBoundAnimation(_spriteShape_58, "Scale", ShapeVisibilityAnimation_3(), RootProgress());
                StartProgressBoundAnimation(_root.Properties, "t0", t0ScalarAnimation_0_to_1(), RootProgress());
            }

            public void DestroyAnimations()
            {
                _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_0.StopAnimation("Color");
                _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_1.StopAnimation("Color");
                _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_2.StopAnimation("Color");
                _animatedColorBrush_TransparentAlmostGold_00F8C900_to_TransparentAlmostGold_00F8C900_3.StopAnimation("Color");
                _containerShape_0.StopAnimation("Scale.X");
                _containerShape_0.StopAnimation("Scale.Y");
                _containerShape_1.StopAnimation("Scale.X");
                _containerShape_1.StopAnimation("Scale.Y");
                _containerShape_2.StopAnimation("Scale.X");
                _containerShape_2.StopAnimation("Scale.Y");
                _containerShape_3.StopAnimation("Offset");
                _pathGeometry_37.StopAnimation("Path");
                _pathGeometry_38.StopAnimation("Path");
                _pathGeometry_39.StopAnimation("Path");
                _pathGeometry_40.StopAnimation("Path");
                _spriteShape_55.StopAnimation("Scale");
                _spriteShape_56.StopAnimation("Scale");
                _spriteShape_57.StopAnimation("Scale");
                _spriteShape_58.StopAnimation("Scale");
                _root.Properties.StopAnimation("t0");
            }

        }
    }
}
