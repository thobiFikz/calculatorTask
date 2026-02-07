# CalculatorTask

## Overview
CalculatorTask is a cross-platform GUI calculator built with Avalonia and C#. It performs basic arithmetic operations and demonstrates OOP principles and polymorphism.

## Features
- Addition, subtraction, multiplication, division
- User-friendly interface
- Cross-platform (Windows, macOS, Linux)
- OOP and polymorphism for operation extensibility

## Architecture

### Models
- `Operation` (abstract class): Defines the contract for arithmetic operations.
- `Addition`, `Subtraction`, `Multiplication`, `Division`: Concrete classes implementing `Operation`.

### ViewModel
- `MainWindowViewModel`: Handles calculator logic, state, and command bindings.
  - Properties: `Display`
  - Commands: `DigitCommand`, `OperationCommand`, `EqualsCommand`, `ClearCommand`
  - Uses a dictionary to map operation names to operation objects (polymorphism).

### Views
- `MainWindow.axaml`: Defines the UI layout (display, digit buttons, operation buttons).

### MVVM Pattern
- View binds to ViewModel commands and properties.
- ViewModel interacts with Models for calculation logic.

## How to Run
- Build and run with `dotnet run` in the project directory.
- Works on Windows, macOS, and Linux.

## Extensibility
- Add new operations by creating new classes inheriting from `Operation` and updating the ViewModel’s dictionary.
