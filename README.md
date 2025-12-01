
# Subway2D

_A 2D endless runner game developed in Unity, demonstrating the adaptation of classic 3D runner mechanics into a 2D game._

**Developed** by Andrej Rajkov in 2023

**University Course:** Seminar C ("Seminarski Rad C") at the Faculty of Sciences, University of Novi Sad

## Project Overview

**Subway2D** is an endless runner game developed in Unity, created as the practical component for a university seminar thesis. The project explores methods for adapting classic 3D infinite runner mechanics (like those found in _Subway Surfers_) into a purely 2D environment while maintaining core gameplay principles and the illusion of speed.

This repository serves as a portfolio archive for the C# source code and compiled demonstration builds.
## Screenshots
<img src="https://github.com/user-attachments/assets/d3510ef8-7b39-44b1-bcb0-6a5a51b34253" width="20%"></img><img src="https://github.com/user-attachments/assets/173c6191-613a-4026-9f24-516af884e023" width="20%"></img><img src="https://github.com/user-attachments/assets/cd1a2912-6bd2-41cf-98c5-99d39ed98d6c" width="20%"></img><img src="https://github.com/user-attachments/assets/747dfd70-3fe3-4666-bc9a-3e06c70ce41b" width="20%"></img><img src="https://github.com/user-attachments/assets/d7290b20-3502-4592-a699-559af488db3b" width="20%"></img>

## Gameplay Video
https://github.com/user-attachments/assets/62c12839-d46d-455f-b51f-5d50817e6c33

## 🛠 Technical Features & Implementation Highlights

The game's design centered on creating efficiency and dynamic difficulty without relying on complex 3D physics.

-   **Engine & Language:** Unity 2021.3 (C#)
    
-   **Movement Illusion:** Player is static on the Y-axis; movement is simulated by applying velocity to environmental objects (tracks, obstacles) moving toward the player.
    
-   **Procedural Generation:** Uses a 3-lane spawner system for dynamic obstacle (trains, barriers) and collectible (coins) introduction.
    
-   **Lane Logic:** Implements precise, snap-to-lane movement control, ensuring the player remains aligned with one of the three tracks.
    
-   **Difficulty Scaling:** Game speed (environment velocity) increases over time, dynamically scaling difficulty.
    
-   **Data Persistence:** Local save system using `PlayerPrefs` for storing high scores and currency.
    
-   **Shop:** Functional in-game Shop System for spending currency on Score and Coin multipliers.
    

## 📦 Try it yourself:

Download on the [**Releases page**](https://github.com/andrej1011/Subway2D/releases/tag/main).

Supported platforms include:

-   **Windows** (`.exe` installer)
    
-   **macOS** (DMG file)
    
-   **Android** (`.apk`)
    

## ⚖️ License and Disclaimer

This software is a non-profit educational and portfolio project.

Please review the accompanying `license.md` file for the full legal disclaimer regarding the project's educational nature and its relationship with the original _Subway Surfers_ intellectual property.
