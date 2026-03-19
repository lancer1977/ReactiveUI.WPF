# ReactiveUI.WPF

**Location:** `~/code/ReactiveUI.WPF`

**Purpose:** WPF platform bindings for ReactiveUI, a MVVM framework for .NET. Provides WPF-specific implementations for reactive bindings and view model patterns.

## Tech Stack

- **Framework:** .NET 7.0 Windows
- **Type:** Library (WPF platform extension)
- **License:** MIT

## Project Structure

```
ReactiveUI.WPF/
├── src/
│   ├── ReactiveUI.Wpf.csproj          # Main project
│   ├── ReactiveWindow.cs              # Reactive Window base class
│   ├── AutoSuspendHelper.cs           # App state persistence
│   ├── ActivationForViewFetcher.cs    # View activation lifecycle
│   ├── DependencyObjectObservableForProperty.cs
│   ├── Registrations.cs               # Platform DI registrations
│   ├── TransitioningContentControl.cs # Animated content control
│   ├── Common/                        # Platform utilities
│   ├── Rx/                            # Rx helpers
│   └── Themes/                         # WPF themes
└── docs/                              # Documentation
```

## Entry Points

| Class | Purpose |
|-------|---------|
| `ReactiveWindow` | Reactive Window implementing `IViewFor<TViewModel>` |
| `AutoSuspendHelper` | Saves/restores app state on close/activate |
| `ActivationForViewFetcher` | Tracks WPF view activation lifecycle |
| `DependencyObjectObservableForProperty` | Observable properties from DependencyObjects |
| `Registrations` | WPF platform registrations for ReactiveUI DI |

## Dependencies

| Package | Version |
|---------|---------|
| ReactiveUI | 19.4.1 |

## Build & Test

```bash
# Requires Windows (WPF is Windows-only)
cd src
dotnet build
dotnet test
```

## Notes

- Fork/contribution to main ReactiveUI project
- Cannot build on Linux (WPF Windows-only)
- Target framework `net7.0-windows` (out of support)