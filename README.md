# 📚 Education API

# 

# A modular and production-oriented ASP.NET Core Web API project built with clean architecture principles. This project focuses on real-world backend concerns such as logging, error handling, database abstraction, and scalable system design.

# 

# 🚀 Project Overview

# 

# Education API is a backend system designed to manage educational domain structures (companies, departments, etc.) while emphasizing maintainability, observability, and clean code practices.

# 

# Unlike simple CRUD projects, this system is structured to reflect how real-world backend services are built and maintained.

# 

# 🧠 Key Features

# ✅ Clean Architecture (Layered Design)

# ✅ Entity Framework Core with PostgreSQL

# ✅ Repository \& Unit of Work Pattern

# ✅ Centralized Logging System (AppLog)

# ✅ Custom Middleware Pipeline

# ✅ Exception Handling Strategy

# ✅ Configuration-based setup

# ✅ Dependency Injection Best Practices

# ✅ Scalable and maintainable codebase

# 🏗️ Architecture

# 📦 Education

# &#x20;┣ 📂 Core

# &#x20;┣ 📂 Business

# &#x20;┣ 📂 DataAccess

# &#x20;┣ 📂 Entities

# &#x20;┗ 📂 WEBAPI

# 🔹 Layer Responsibilities

# Core

# Base abstractions, interfaces, and domain models.

# Application

# Business logic, services, DTOs.

# Infrastructure

# Cross-cutting concerns (logging, token handling, caching if applied).

# Persistence

# EF Core, DbContext, repositories.

# WebAPI

# Controllers, middleware, filters, request pipeline.

# 🧾 Logging \& Monitoring (AppLog)

# 

# One of the key parts of this project is a custom logging strategy.

# 

# 🔹 AppLog Structure

# 

# The system includes a centralized AppLog model used to capture:

# 

# Request information

# Response status (Success / Error)

# Exception details

# Execution time

# Source (e.g., Controller / Middleware)

# 

# Example:

# 

# public class AppLog

# {

# &#x20;   public string? Path { get; set; }

# &#x20;   public string? Method { get; set; }

# &#x20;   public int StatusCode { get; set; }

# &#x20;   public string? Message { get; set; }

# &#x20;   public string? Source { get; set; }

# &#x20;   public DateTime CreatedAt { get; set; }

# }

# ⚙️ Logging Pipeline

# 

# Logging is handled using custom middleware and filters:

# 

# 🔸 Exception Middleware

# Catches all unhandled exceptions

# Prevents application crash

# Logs structured error data into AppLog

# 🔸 Success Logging Filter

# Logs successful requests

# Separates success logs from error logs

# Improves observability

# 

# This approach ensures:

# 

# Consistent logging format

# Clear separation of concerns

# Better debugging and monitoring

# 💾 Database

# PostgreSQL with EF Core (Code First)

# Structured entity relationships

# Repository abstraction over DbContext

# 🧩 Patterns \& Practices

# Repository Pattern

# Unit of Work Pattern

# Middleware Pipeline Design

# Centralized Error Handling

# Dependency Injection

# Clean Code Principles

# ⚡ Example Configuration

# {

# &#x20; "ConnectionStrings": {

# &#x20;   "Default": "Host=localhost;Port=5432;Database=EducationDb;Username=postgres;Password=\*\*\*\*"

# &#x20; }

# }

# 📦 Getting Started

# git clone https://github.com/yourusername/education-api.git

# cd education-api

# dotnet ef database update

# dotnet run

# 📈 What This Project Demonstrates

# 

# This project highlights:

# 

# Real-world backend architecture

# Logging \& observability mindset

# Structured error handling

# Scalable API design

# Clean and maintainable code

# 🎯 Future Improvements

# Redis caching

# JWT Authentication

# Role-based authorization

# Serilog integration (file / seq logging)

# Dockerization \& CI/CD

# 👤 Author

# 

# Sənan Əhmədzadə

# 

# Backend Developer (.NET \& C#)

# Focus: Clean Architecture \& System Design

# ⭐ Final Note

# 

# This project is designed not just to work, but to demonstrate how a backend system should be structured in a real-world environment — with proper logging, separation of concerns, and maintainability in mind.

