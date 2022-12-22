# PackageRefToMDTableConverterNEW

# Introduction
It's a neat little tool to convert package & project references to .md tables.

# Getting Started
>To test the solution "NewPackageRefToMDTableConverter", the project "NewPackageRefToMDTableConverter" must be marked as start project. Then start in DEBUG mode
1.	Download Repository
2.	Open Repository
3.	Mark  "NewPackageRefToMDTableConverter" as startproject
4.	Start "NewPackageRefToMDTableConverter" in DEBUG mode

## Steps
1. Input path to your solution where your projects are e.g C:\Users\User\Your project folder\src.
2. Type Y/y or N/n whether you want to separet package and project references into different tables.
3. Type Y/y or N/n whether you want to see log messages.

# General

## Constants
> Contains constants for the class Table.

## Models
> Contains the reference model the information is mapped to.

## Classes
1.  Converter.cs
2.  InputService.cs
3.  Logger.cs
4.  Program.cs
5.  Table.cs

### Converter.cs
> Reads the path, gets the .csproj file and maps it to the Reference.cs model.

### InputService.cs
> Reads and handles user input.

### Logger.cs
> Small and simple logger

### Program.cs
> Basically the "Main" method. Start of the program.

### Table.cs
> Uses the converted data from Converter.cs to create tables for each project.

## Dependencies
> None
