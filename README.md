# 📦 Delta Utilities Activities
> **Enterprise-Grade UiPath Custom Activities for Logging and Database Security.**

[![UiPath](https://img.shields.io/badge/UiPath-2026.x-blue)](https://www.uipath.com/)
[![.NET Framework](https://img.shields.io/badge/.NET-4.6.1%20%7C%204.7.2-brightgreen)](https://dotnet.microsoft.com/)
[![Maintainer](https://img.shields.io/badge/Maintainer-Joe%20K.-orange)](https://github.com/rizzario)

---

## 🚀 Overview
**Delta Utilities** คือชุด Custom Activities ที่ออกแบบมาเพื่อยกระดับมาตรฐานการพัฒนา RPA ภายในองค์กร โดยเน้นไปที่ความปลอดภัยของข้อมูล (Data Security) และความสามารถในการติดตามการทำงาน (Traceability)

## ✨ Key Features

### 1. 🛡️ Database Security
* **Create Secure Connection String**: รวมร่าง Connection String จากค่ายต่างๆ (SQL, Oracle, ODBC) ให้กลายเป็น `SecureString` โดยตรงในหน่วยความจำ (Memory-level concatenation) เพื่อป้องกันการหลุดของ Password ในระบบ Logging หรือ Memory Dump

---

## 🛠️ Installation

### Option A: Orchestrator Feed (Recommended)
1. เข้าไปที่ **Tenant > Packages > Libraries** ใน Orchestrator
2. อัปโหลดไฟล์ `.nupkg` ล่าสุด
3. ใน UiPath Studio ไปที่ **Manage Packages > Orchestrator Tenant** แล้วกด Install

### Option B: Local Repository
1. สร้างโฟลเดอร์ `_Libraries` ไว้ในโปรเจกต์ของคุณ
2. เพิ่ม Path นี้ใน **Manage Packages > Settings**
3. ติดตั้ง Package จาก Local Source นั้น

---

## 📖 Usage Example

### Create Secure Connection String
| Input | Type | Description |
| :--- | :--- | :--- |
| `DBType` | `Enum` | SQLServer, Oracle, ODBC, etc. |
| `Server` | `String
