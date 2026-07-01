// Copyright (c) 2023 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

#if HAS_MAUI
using Microsoft.Maui;

#endif
using System;
#if HAS_WINUI
using Microsoft.UI.Xaml;
#elif NETFX_CORE || HAS_UNO
using Windows.UI.Xaml;
#else
using System.Windows;
#endif

#if HAS_UNO
namespace ReactiveUI.Uno
#else
namespace ReactiveUI
#endif
{
    /// <summary>
    /// This type convert converts between Boolean and XAML Visibility - the
    /// conversionHint is a BooleanToVisibilityHint.
    /// </summary>
    public class BooleanToVisibilityTypeConverter : IBindingTypeConverter
    {
        /// <inheritdoc/>
        public Type FromType => typeof(bool);

        /// <inheritdoc/>
        public Type ToType => typeof(Visibility);

        /// <inheritdoc/>
        public int GetAffinityForObjects()
        {
            return 10;
        }

        /// <inheritdoc/>
        public bool TryConvertTyped(object? from, object? conversionHint, out object? result)
        {
            var hint = conversionHint is BooleanToVisibilityHint visibilityHint ?
                visibilityHint :
                BooleanToVisibilityHint.None;

            if (from is bool fromBool)
            {
                var fromAsBool = (hint & BooleanToVisibilityHint.Inverse) != 0 ? !fromBool : fromBool;

#if !NETFX_CORE && !HAS_UNO && !HAS_WINUI
                var notVisible = (hint & BooleanToVisibilityHint.UseHidden) != 0 ? Visibility.Hidden : Visibility.Collapsed;
#else
                var notVisible = Visibility.Collapsed;
#endif
                result = fromAsBool ? Visibility.Visible : notVisible;
                return true;
            }

            if (from is Visibility fromAsVis)
            {
                result = fromAsVis == Visibility.Visible ^ (hint & BooleanToVisibilityHint.Inverse) == 0;
            }
            else
            {
                result = true;
            }

            return true;
        }
    }
}
