# Car Service Center

Full-stack car service center management system covering the full booking lifecycle - from initial scheduling through technician checklists and repair approval workflows - built with .NET 8.

## What It Does

A service advisor books a customer's vehicle through a **Blazor web app**. A technician picks up the job on a **.NET MAUI mobile app**, works through a checklist of service items, and can request client approval for any additional repairs discovered during the service. The advisor manages the approval flow and communicates with the client. The booking progresses through a defined lifecycle until the vehicle is ready for pickup.

## Booking Lifecycle

`Scheduled` → `CheckedIn` → `Assigned` → `InProgress` ⇄ `AwaitingApproval` → `ReadyForPickup` → `Closed`

When a technician raises an approval request, the booking moves to `AwaitingApproval`. The advisor works through a checklist of pending approval items, contacting the client for each one. The booking returns to `InProgress` automatically once all approvals are resolved.

## Service Types

- **Basic Service** - fixed, immutable checklist of items; all locked and cannot be removed
- **Full Service** - all basic items (locked) + additional standard items + any client-specific items agreed upfront with the advisor

## Tech Stack

| Layer | Technology |
|---|---|
| API | ASP.NET Core Web API (.NET 8) |
| Web (Service Advisors) | Blazor |
| Mobile (Technitians) | .NET MAUI |
| Database | PostgreSQL |
| ORM | Entity Framework Core (Code-First) |
| Auth | ASP.NET Core Identity + JWT |