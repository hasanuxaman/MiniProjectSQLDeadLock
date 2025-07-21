# Deadlock Simulation - ASP.NET Core Web API

This project demonstrates how SQL Server **deadlocks** can occur when two concurrent transactions access shared resources (tables) in conflicting orders.

It provides a minimal **ASP.NET Core Web API** application with a Razor Pages frontend, using **Entity Framework Core** and **SQL Server**, to simulate and observe deadlocks in a controlled way.

---

## 🛠 Technologies Used

- ASP.NET Core Web API
- Razor Pages (for simple UI interaction)
- Entity Framework Core 7+
- SQL Server
- Dapper (optional – for raw SQL execution)
- Dependency Injection
- Logging (via ILogger)
- Bootstrap (for UI)

---

## 📦 Features

- Simulate SQL Server deadlock between two threads/transactions:
  - **Transaction A:** Updates `Products` table first, then `Vendors`
  - **Transaction B:** Updates `Vendors` table first, then `Products`
- Concurrent transaction execution to increase chance of a deadlock
- Razor UI for triggering the simulation
- Logging of events, commit, and deadlocks
- SQL Deadlock simulation handled via `Task.Delay()` to maintain lock

---

## ⚙️ Setup Instructions

### 1. Clone the repository

```bash
git clone https://github.com/your-username/deadlock-simulation.git
cd deadlock-simulation
