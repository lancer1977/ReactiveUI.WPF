// Copyright (c) 2023 .NET Foundation and Contributors. All rights reserved.
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for full license information.

using System;
using System.Reactive.Concurrency;
using ReactiveUI;
using Splat;

namespace ReactiveUI.Wpf;

/// <summary>
/// Registrations specific to the WPF platform.
/// </summary>
public class Registrations : IWantsToRegisterStuff
{
    /// <inheritdoc/>
    public void Register(IRegistrar registrar)
    {
        if (registrar is null)
        {
            throw new ArgumentNullException(nameof(registrar));
        }

        registrar.Register<IPlatformOperations>(() => new PlatformOperations());
        registrar.Register<IActivationForViewFetcher>(() => new ActivationForViewFetcher());
        registrar.Register<ICreatesObservableForProperty>(() => new DependencyObjectObservableForProperty());
        registrar.Register<IBindingTypeConverter>(() => new StringConverter());
        registrar.Register<IBindingTypeConverter>(() => new SingleToStringTypeConverter());
        registrar.Register<IBindingTypeConverter>(() => new DoubleToStringTypeConverter());
        registrar.Register<IBindingTypeConverter>(() => new DecimalToStringTypeConverter());
        registrar.Register<IBindingTypeConverter>(() => new BooleanToVisibilityTypeConverter());
        registrar.Register<IPropertyBindingHook>(() => new AutoDataTemplateBindingHook());
        registrar.Register<IBindingTypeConverter>(() => new ComponentModelFallbackConverter());

        if (!ModeDetector.InUnitTestRunner())
        {
            // NB: On .NET Core, trying to touch DispatcherScheduler blows up :cry:
            RxApp.MainThreadScheduler = new WaitForDispatcherScheduler(() => DispatcherScheduler.Current);
            RxApp.TaskpoolScheduler = TaskPoolScheduler.Default;
        }

        RxApp.SuppressViewCommandBindingMessage = true;
    }
}
