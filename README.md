# Car Service Center - Inventory & Workflow Management System

A distributed C# ecosystem designed to streamline car service center operations. This project features a central Web API, a comprehensive Web Dashboard for service managers, and a Mobile Application for shop-floor technicians.

---

## 🚀 Project Vision & Scope

* A system to manage vehicle intake, technician job assignments, and real-time parts allocation.
* Multi-user role workflows (Admin, Manager, Technician) to ensure operational data integrity.
* Dynamic inventory tracking to bridge the gap between parts procurement and active physical labor.

---

## 🛠️ Tech Stack & Architecture

This repository uses a single Visual Studio Solution containing decoupled projects sharing a unified C# data model:

* **Backend API:** ASP.NET Core Web API
* **Database:** PostgreSQL via Entity Framework Core
* **Web Frontend (Manager Dashboard):** Blazor WebAssembly
* **Mobile Frontend (Technician App):** .NET MAUI
* **Shared Layer:** C# Class Library for shared DTOs (Data Transfer Objects) and validation logic.

---

## 📊 Database Design

![Database Schema](./images/database-v1.png)

---

## 🚦 Core Workflows & Inventory Logic

### The "Allocated" Stock State Lifecycle
To prevent stock discrepancies between the digital inventory and the physical workshop shelves, parts transition through three tracked states:

1. **Quantity On Hand:** Physical items present on the warehouse shelves.
2. **Quantity Allocated:** Items physically on shelves but locked/promised to active, open work orders.
3. **Quantity Available:** (`On Hand - Allocated`) The true count of items available for new jobs.

When a technician requests a part via the mobile app, it is **Allocated**. Once the job sheet is officially marked as complete, the part is subtracted from both **On Hand** and **Allocated** counters.