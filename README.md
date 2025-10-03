#Bank Application

This project is a banking and financial web application built with **.NET Core 3.1** (Backend) and **Angular 9** (Frontend).  
It includes modules for authentication, user management, credit calculation, credit application, and messaging.

---

##Setup Instructions

### 1. Requirements
- [.NET Core SDK 3.1.425](https://dotnet.microsoft.com/download/dotnet/3.1)
- [Node.js 12.16.3](https://nodejs.org/download/release/v12.16.3/)
- Angular CLI 9.1.15 (`npm install -g @angular/cli@9.1.15`)
- SQL Server (or a compatible database)

---

### 2. Backend (ServerApp)
```bash
cd ServerApp
dotnet restore
dotnet run

The backend runs by default at:
https://localhost:5001

Note:
In ServerApp/appsettings.json, update your Mailtrap SMTP credentials:

"EmailSettings": {
  "SmtpServer": "smtp.mailtrap.io",
  "SmtpPort": 587,
  "SmtpUser": "youraccount",   // line 18
  "SmtpPass": "yourpassword"   // line 19
}

3. Frontend (ClientApp)
cd ClientApp
npm install
ng serve --open


The frontend runs by default at:
http://localhost:4200

4. Database

Update your connection string in appsettings.json.

Apply initial migrations and create the database:

dotnet ef database update




# Bank Application
.NET Core ve Angular kullanılmıştır.
![register](https://github.com/user-attachments/assets/ed6306db-deca-4439-b66a-d6cd59983910)
![login](https://github.com/user-attachments/assets/fb87a3f4-35ed-4cd3-8b99-385af918150c)
![sifremiunuttum1](https://github.com/user-attachments/assets/f2742a43-dc35-4af5-bf71-286683907d0b)
![sifremiunuttum2](https://github.com/user-attachments/assets/c6211069-9f6d-4b3f-8467-28ff93c192ad)
![1](https://github.com/user-attachments/assets/c399651f-bfa7-44bf-908c-342b05a770cf)
![sifremiunuttum3](https://github.com/user-attachments/assets/37854f5b-b251-476d-b2f3-81165257511a)


![kisiselbilgiler](https://github.com/user-attachments/assets/c77499f6-ed3a-4b70-8efd-29baae6e2c12)

![kisiselbilgiler2](https://github.com/user-attachments/assets/6fde863c-46a6-4641-aa58-5e239540dbfb)
![bankalar](https://github.com/user-attachments/assets/78da199f-60dd-494b-a270-1efbd9228b18)
![kredihesapla](https://github.com/user-attachments/assets/404238bc-d857-443e-adf0-e439f9c2f214)
![kredibasvurusu1](https://github.com/user-attachments/assets/6253e6ef-39ec-417b-ada3-297b54d3f5ec)
![kredibasvurusu2](https://github.com/user-attachments/assets/205a6fca-d6ac-47cf-835b-50213e8c5cd2)
![iletisim](https://github.com/user-attachments/assets/73c27113-aa42-4762-a5de-6978db572f32)
![DatabaseDiagram](https://github.com/user-attachments/assets/ab8c3984-3af3-4f0b-bfed-311339dc9a7a)



