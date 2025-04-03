# Learning Management System (LMS) - Backend

## Overview

This **Learning Management System (LMS)** enables **teachers, students, and admins** to interact through a single platform.  
The backend is built using **ASP.NET Core Web API with C#**, featuring **JWT authentication, role-based authorization, and exception handling**.

---

## Tech Stack

- **ASP.NET Core Web API** - Backend development
- **Entity Framework Core** - ORM for database management
- **SQL Server / MySQL** - Database
- **LINQ (Language Integrated Queries)** - Data queries
- **JWT Bearer Authentication** - Secure access
- **Bcrypt** - Password hashing
- **Dependency Injection (DI)** - Design pattern for loosely coupled architecture
- **DTO (Data Transfer Objects)** - Secure data transfer
- **Lazy Loading** - Efficient data fetching
- **Swashbuckle (Swagger UI)** - API documentation & token authorization

---

## System Roles

### **Admin**
- Manages users (teachers, students)
- Creates and assigns courses
- Oversees the entire system

### **Teacher**
- Creates & manages courses
- Assigns homework and grades students
- Provides learning resources

### **Student**
- Enrolls in courses
- Completes assignments & exams
- Tracks progress and grades

---

## Key Features

### **1️⃣ Authentication & Authorization**
- **JWT Bearer Authentication**
- **Role-Based Authorization (Admin, Teacher, Student)**
- **Password Hashing using Bcrypt**
- **Token Authorization via Swagger UI**

### **2️⃣ Object-Oriented Programming (OOP) Concepts**
- **Abstraction & Encapsulation** for security & modularity
- **Dependency Injection (DI)** for better scalability

### **3️⃣ Database & ORM**
- **Entity Framework Core** for database interactions
- **Code-first migration** with **ModelBuilder**
- **Lazy Loading** for optimizing data queries
- **Single database (Monolithic Architecture)**
- **Relationships handled using ModelBuilder**

### **4️⃣ LINQ Queries**
- Efficient filtering, sorting, and querying of database entities

---


