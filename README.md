# 🧮 Math Game

A console-based Math Game built with C#. This project reinforces foundational C# concepts including user input handling, control flow, collections, and console application structure.

---

## 📋 Table of Contents

- [About the Project](#about-the-project)
- [Features](#features)
- [Requirements](#requirements)
- [Getting Started](#getting-started)
- [How to Play](#how-to-play)
- [Project Structure](#project-structure)
- [Technologies Used](#technologies-used)
- [Challenges](#challenges)
- [License](#license)

---

## 📖 About the Project

This is a beginner-level C# console application where the player is presented with math questions and earns points for correct answers. The game supports multiple arithmetic operations and maintains a history of previous game sessions during runtime.


---

## ✨ Features

- Random math question generation across multiple operations
- Player score tracking per game session
- In-memory game history stored in a `List` — viewable from the menu
- Integer-only division questions (dividends from 0 to 100)
- Clean, menu-driven console interface
- Minimum of 5 questions per game

---

## ✅ Requirements

| # | Requirement |
|---|-------------|
| 1 | The game asks the player math questions (e.g. `9 x 9 = ?`) and awards a point for each correct answer |
| 2 | Each game session contains at least **5 questions** |
| 3 | Division questions result in **integers only**, with dividends ranging from **0 to 100** |
| 4 | A **menu** is presented to the player to choose an arithmetic operation |
| 5 | Previous game results are stored in a **List** and viewable via a history menu option |
| 6 | Game history is **not persisted** — data is cleared when the program exits |

---

## 🚀 Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or later)
- [Visual Studio Code](https://code.visualstudio.com/) with the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

### Installation

1. Clone the repository:
   ```bash
   git clone git@github.com:Timothynyezi/Math-Game.git
   ```

2. Navigate into the project directory:
   ```bash
   cd Math-Game
   ```

3. Restore dependencies:
   ```bash
   dotnet restore
   ```

4. Run the application:
   ```bash
   dotnet run
   ```

---

## 🎮 How to Play

1. Launch the application using `dotnet run`
2. Select an arithmetic operation from the main menu:
   - Addition (`+`)
   - Subtraction (`-`)
   - Multiplication (`×`)
   - Division (`÷`)
3. Answer at least 5 math questions
4. Your score is displayed at the end of each session
5. Return to the main menu to view game history or start a new game

---

## 📁 Project Structure

```
Math-Game/
├── Program.cs          # Entry point and main game logic
├── Math-Game.csproj    # Project configuration file
└── README.md           # Project documentation
```

---

## 🛠 Technologies Used

- **Language:** C#
- **Framework:** .NET (Console Application)
- **IDE:** Visual Studio Code + C# Dev Kit
- **Version Control:** Git & GitHub

---

## 🏆 Challenges

- Add a difficulty setting that adjusts the range of numbers used
- Implement a timer that limits how long the player has to answer
- Display the percentage of correct answers at the end of a session
- Allow the player to choose how many questions per game

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

---

