# 🏥 Hospital San Vicente – Medical Appointment Management System  
### Developed in C# with Entity Framework Core and LINQ

---

## 📘 Overview

**Hospital San Vicente** previously managed its medical appointments using physical notebooks and spreadsheets, leading to frequent issues such as duplicate bookings, data loss, and disorganization.  
This project digitalizes the hospital’s operations by implementing a **centralized system** to manage **patients, doctors, and appointments** efficiently and reliably.

The system was developed as part of a **Performance Assessment Project in C#**, applying **Object-Oriented Programming (OOP)** principles, **Entity Framework Core**, and **LINQ** for data persistence and integrity.

---

## 🎯 Objectives

The goal of this project is to create a robust, scalable, and maintainable system that:

- Centralizes patient, doctor, and appointment data.
- Prevents scheduling conflicts between patients and doctors.
- Automates the appointment process.
- Ensures data consistency and validation.
- Supports error handling and user-friendly feedback.

---

## 🧩 Features & Functionalities

### 1. Patient Management
- Register new patients with personal details: **Name, Document ID, Age, Phone, Email**.  
- Edit existing patient information.  
- Validate unique document numbers (no duplicate patients).  
- Display a full list of registered patients.

### 2. Doctor Management
- Register doctors with: **Name, Document ID, Specialty, Phone, Email**.  
- Edit doctor information.  
- Validate unique document IDs (no duplicate doctors).  
- List all doctors with **filter by specialty** functionality.

### 3. Appointment Management
- Schedule medical appointments linking a **Patient**, **Doctor**, **Date**, and **Time**.  
- Validate that:
  - A doctor cannot have more than one appointment at the same time.  
  - A patient cannot have more than one appointment at the same time.  
- Cancel appointments (status changes to **“Cancelled”**).  
- Mark appointments as **“Attended”**.  
- List appointments by **patient** and by **doctor**.  
- (Partially implemented) Send appointment confirmation emails to patients.  
- (Pending due to time constraints) Record of email notifications with status (“sent”, “not sent”).

### 4. Data Persistence
- Implemented using:
  - **Entity Framework Core**  
  - **LINQ** for querying and filtering  
  - **Lists and Dictionaries** for in-memory management  
  - **MySQL / PostgreSQL** for persistence

### 5. Error Handling & Validations
- Input validation for all entities (patients, doctors, appointments).  
- Exception management using `try-catch` blocks.  
- Clear and user-friendly error messages.  
- Enforcement of all business rules (unique documents, non-conflicting appointments, etc.).

---

## ⚙️ Technologies Used

| Component | Technology |
|------------|-------------|
| **Language** | C# (.NET 8) |
| **Framework** | Entity Framework Core |
| **Database** | MySQL / PostgreSQL |
| **Data Querying** | LINQ |
| **Design Pattern** | Object-Oriented Programming (OOP) |
| **IDE** | Visual Studio / VS Code |
| **Version Control** | Git & GitHub |

---

## 🧠 System Architecture

### Core Classes
- `Patient`  
- `Doctor`  
- `Appointment`  
- `EmailNotification` (partially implemented)
- `HospitalContext` (EF Core DbContext)

### Key Relationships
- One-to-Many: Doctor → Appointments  
- One-to-Many: Patient → Appointments  

---

## 📊 UML Diagrams

### 1. Class Diagram
Shows the structure and relationships between the main entities:
- Patient  
- Doctor  
- Appointment  
- EmailNotification (optional)

### 2. Use Case Diagram
Covers the main operations:
- Register / Edit / List Patients  
- Register / Edit / Filter Doctors  
- Schedule / Cancel / Attend Appointments  
- Send Email (partial implementation)

---

## 🚀 Installation & Setup

### Prerequisites
Make sure you have the following installed:

- [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download)
- [MySQL](https://www.mysql.com/) or [PostgreSQL](https://www.postgresql.org/)
- Visual Studio or VS Code
- Git

### Steps to Run the Project

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/hospital-san-vicente.git
   cd hospital-san-vicente
