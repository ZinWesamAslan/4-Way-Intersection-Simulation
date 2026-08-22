# 4-Way Intersection Traffic Simulation (.NET Windows Forms)

A dynamic, object-oriented 4-way traffic light intersection simulation system built with C# and .NET Windows Forms. This project simulates real-world traffic flows, multi-lane directional routing, synchronized traffic light states, Bezier curve-based vehicle turns, state persistence, and PBKDF2-secured access control.

<img width="1366" height="768" alt="Screenshot (308)" src="https://github.com/user-attachments/assets/2ba528b7-8fe7-4330-906e-4bba437b7e24" />

---

## 🌟 Key Features

* **Multi-Lane & Directional Routing:**
  * **Vertical Roads (Top/Bottom):** 3 lanes with distinct turn allowances:
    * **Lane 0 (Leftmost):** Left Turn, U-Turn, and Forward.
    * **Lane 1 (Middle):** Forward only.
    * **Lane 2 (Rightmost):** Right Turn and Forward.
  * **Horizontal Roads (Left/Right):** 2 lanes designed primarily for straight-through traffic flows.
* **Realistic Vehicle Physics & Turning Trajectories:**
  * Uses **Quadratic Bezier Curves** ($P_0, P_1, P_2$) to render smooth turning paths for Left Turns, Right Turns, and U-Turns.
  * Adaptive speed modulation during turning maneuvers to simulate realistic vehicle dynamics.
* **Synchronized Traffic Light Controllers:**
  * Custom Guna UI-based traffic light control (`UcTrafficLight`) supporting multiple phase modes:
    * **4-Mode Signals:** `Red` $\rightarrow$ `GreenUL` (U-Turn & Left) $\rightarrow$ `GreenFR` (Forward & Right) $\rightarrow$ `Orange`.
    * **3-Mode Signals:** `Red` $\rightarrow$ `Green` $\rightarrow$ `Orange`.
  * Real-time custom countdown timer rendered directly on the light graphics using GDI+.
* **State Persistence & Serialization:**
  * Asynchronous JSON state saving and restoring (`ClsSerializationManager`) for real-time traffic state checkpoints, car positions, timer ticks, and light phases.
* **Secure Access Control:**
  * Password-protected system initialization using **PBKDF2** (100,000 iterations via `Rfc2898DeriveBytes`) with **Salt** and **Pepper** cryptographic key derivation.
* **Smooth Rendering:**
  * Optimized graphics using WinForms Double Buffering (`SetStyle`) to eliminate visual flickering during high-frequency frame updates.

---

## 🏗️ System Architecture & Code Structure
IntersectionSimulation4Way/
├── ClsRoad.cs                   # Manages road directions, lanes, and traffic light sync
├── ClsLane.cs                   # Manages individual lane queues, car spawning, and ticks
├── UcCar.cs                     # Custom UserControl representing a vehicle with Bezier movement logic
├── UcTrafficLight.cs            # Custom Guna2 PictureBox rendering light states and timers
├── ClsProjectState.cs           # Data Transfer Object (DTO) for JSON state serialization
├── ClsSerializationManager.cs   # Async save/load logic for JSON serialization
├── ClsSecurityHelper.cs         # Crypto module for PBKDF2 password hashing (Salt + Pepper)
├── ClsSettings.cs               # Configuration helper loading coordinates & timings from App.config
└── FrmSimulation.cs             # Master Form orchestrating the main simulation timer & UI
---

## 🔐 Security & Hashing Mechanism

The application restricts startup using cryptographic password validation:
$$\text{Hash} = \text{PBKDF2-SHA256}(\text{Password} + \text{Pepper}, \text{Salt}, \text{Iterations} = 100000, \text{KeyLength} = 256\text{ bits})$$

---

## 🚀 Getting Started

### Prerequisites
* **Visual Studio 2019 / 2022**
* **.NET Framework 4.7.2** or higher
* **Newtonsoft.Json** NuGet package
* **Guna.UI2.WinForms** NuGet package

### Installation & Run
1. **Clone the repository:**
   ```bash
   git clone [https://github.com/your-username/IntersectionSimulation4Way.git](https://github.com/your-username/IntersectionSimulation4Way.git)
