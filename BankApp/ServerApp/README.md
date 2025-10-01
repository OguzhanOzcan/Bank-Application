
```
ServerApp
├─ appsettings.Development.json
├─ appsettings.json
├─ bin
│  └─ Debug
│     └─ netcoreapp3.1
│        ├─ appsettings.Development.json
│        ├─ appsettings.json
│        ├─ AutoMapper.dll
│        ├─ global.json
│        ├─ Microsoft.AspNetCore.Authentication.JwtBearer.dll
│        ├─ Microsoft.AspNetCore.Cryptography.Internal.dll
│        ├─ Microsoft.AspNetCore.Cryptography.KeyDerivation.dll
│        ├─ Microsoft.Bcl.AsyncInterfaces.dll
│        ├─ Microsoft.Bcl.HashCode.dll
│        ├─ Microsoft.Data.SqlClient.dll
│        ├─ Microsoft.EntityFrameworkCore.Abstractions.dll
│        ├─ Microsoft.EntityFrameworkCore.Design.dll
│        ├─ Microsoft.EntityFrameworkCore.dll
│        ├─ Microsoft.EntityFrameworkCore.Relational.dll
│        ├─ Microsoft.EntityFrameworkCore.SqlServer.dll
│        ├─ Microsoft.Extensions.Caching.Abstractions.dll
│        ├─ Microsoft.Extensions.Caching.Memory.dll
│        ├─ Microsoft.Extensions.Configuration.Abstractions.dll
│        ├─ Microsoft.Extensions.Configuration.Binder.dll
│        ├─ Microsoft.Extensions.Configuration.dll
│        ├─ Microsoft.Extensions.DependencyInjection.Abstractions.dll
│        ├─ Microsoft.Extensions.DependencyInjection.dll
│        ├─ Microsoft.Extensions.Logging.Abstractions.dll
│        ├─ Microsoft.Extensions.Logging.dll
│        ├─ Microsoft.Extensions.Options.dll
│        ├─ Microsoft.Extensions.Primitives.dll
│        ├─ Microsoft.Identity.Client.dll
│        ├─ Microsoft.IdentityModel.JsonWebTokens.dll
│        ├─ Microsoft.IdentityModel.Logging.dll
│        ├─ Microsoft.IdentityModel.Protocols.dll
│        ├─ Microsoft.IdentityModel.Protocols.OpenIdConnect.dll
│        ├─ Microsoft.IdentityModel.Tokens.dll
│        ├─ Newtonsoft.Json.dll
│        ├─ Properties
│        │  └─ launchSettings.json
│        ├─ runtimes
│        │  ├─ unix
│        │  │  └─ lib
│        │  │     ├─ netcoreapp2.0
│        │  │     │  └─ System.Runtime.Caching.dll
│        │  │     └─ netcoreapp2.1
│        │  │        └─ Microsoft.Data.SqlClient.dll
│        │  ├─ win
│        │  │  └─ lib
│        │  │     ├─ netcoreapp2.0
│        │  │     │  └─ System.Runtime.Caching.dll
│        │  │     ├─ netcoreapp2.1
│        │  │     │  └─ Microsoft.Data.SqlClient.dll
│        │  │     └─ netstandard2.0
│        │  │        └─ System.Security.Cryptography.ProtectedData.dll
│        │  ├─ win-arm64
│        │  │  └─ native
│        │  │     └─ sni.dll
│        │  ├─ win-x64
│        │  │  └─ native
│        │  │     └─ sni.dll
│        │  └─ win-x86
│        │     └─ native
│        │        └─ sni.dll
│        ├─ ServerApp.deps.json
│        ├─ ServerApp.dll
│        ├─ ServerApp.exe
│        ├─ ServerApp.pdb
│        ├─ ServerApp.runtimeconfig.dev.json
│        ├─ ServerApp.runtimeconfig.json
│        ├─ System.Collections.Immutable.dll
│        ├─ System.Configuration.ConfigurationManager.dll
│        ├─ System.Diagnostics.DiagnosticSource.dll
│        ├─ System.IdentityModel.Tokens.Jwt.dll
│        ├─ System.Runtime.Caching.dll
│        └─ System.Security.Cryptography.ProtectedData.dll
├─ Controllers
│  ├─ AuthController.cs
│  ├─ CreditApplicationController.cs
│  ├─ CreditController.cs
│  ├─ CustomerController.cs
│  └─ MessageController.cs
├─ Data
│  └─ ApplicationDbContext.cs
├─ DTOs
│  ├─ Auth
│  │  ├─ LoginRequestDto.cs
│  │  ├─ LoginResponseDto.cs
│  │  ├─ RegisterRequestDto.cs
│  │  ├─ RegisterResponseDto.cs
│  │  ├─ ResetPasswordDto.cs
│  │  ├─ SendResetCodeDto.cs
│  │  ├─ UserProfileDto.cs
│  │  └─ VerifyResetCodeDto.cs
│  ├─ Credit
│  │  ├─ BankDto.cs
│  │  ├─ CreditApplicationRequestDto.cs
│  │  ├─ CreditApplicationResponseDto.cs
│  │  ├─ CreditCalculationResultDto.cs
│  │  ├─ CreditCalculatorRequestDto.cs
│  │  ├─ InterestRateDto.cs
│  │  ├─ LoanTypeDto.cs
│  │  └─ MyCreditDto.cs
│  └─ Customer
│     ├─ UpdateCustomerDto.cs
│     └─ UpdatePasswordDto.cs
├─ global.json
├─ Helpers
│  ├─ CreditCalculatorHelper.cs
│  ├─ EmailSettings.cs
│  ├─ JwtHelper.cs
│  └─ PasswordHasher.cs
├─ Migrations
├─ Models
│  ├─ Bank.cs
│  ├─ CreditApplication.cs
│  ├─ Customer.cs
│  ├─ InterestRate.cs
│  ├─ LoanType.cs
│  ├─ Message.cs
│  └─ ResetCode.cs
├─ obj
│  ├─ Debug
│  │  └─ netcoreapp3.1
│  │     ├─ .NETCoreApp,Version=v3.1.AssemblyAttributes.cs
│  │     ├─ apphost.exe
│  │     ├─ ServerApp.AssemblyInfo.cs
│  │     ├─ ServerApp.AssemblyInfoInputs.cache
│  │     ├─ ServerApp.assets.cache
│  │     ├─ ServerApp.csproj.AssemblyReference.cache
│  │     ├─ ServerApp.csproj.CopyComplete
│  │     ├─ ServerApp.csproj.CoreCompileInputs.cache
│  │     ├─ ServerApp.csproj.FileListAbsolute.txt
│  │     ├─ ServerApp.csprojAssemblyReference.cache
│  │     ├─ ServerApp.dll
│  │     ├─ ServerApp.exe
│  │     ├─ ServerApp.GeneratedMSBuildEditorConfig.editorconfig
│  │     ├─ ServerApp.genruntimeconfig.cache
│  │     ├─ ServerApp.MvcApplicationPartsAssemblyInfo.cache
│  │     ├─ ServerApp.pdb
│  │     ├─ ServerApp.RazorTargetAssemblyInfo.cache
│  │     └─ staticwebassets
│  │        ├─ ServerApp.StaticWebAssets.Manifest.cache
│  │        └─ ServerApp.StaticWebAssets.xml
│  ├─ project.assets.json
│  ├─ project.nuget.cache
│  ├─ ServerApp.csproj.EntityFrameworkCore.targets
│  ├─ ServerApp.csproj.nuget.dgspec.json
│  ├─ ServerApp.csproj.nuget.g.props
│  └─ ServerApp.csproj.nuget.g.targets
├─ Program.cs
├─ Properties
│  └─ launchSettings.json
├─ README.md
├─ Repositories
│  ├─ Implementations
│  │  ├─ AuthRepository.cs
│  │  ├─ CreditApplicationRepository.cs
│  │  ├─ CreditRepository.cs
│  │  ├─ MessageRepository.cs
│  │  └─ UserRepository.cs
│  └─ Interfaces
│     ├─ IAuthRepository.cs
│     ├─ ICreditApplicationRepository.cs
│     ├─ ICreditRepository.cs
│     ├─ IMessageRepository.cs
│     └─ IUserRepository.cs
├─ ServerApp.csproj
├─ ServerApp.sln
├─ Services
│  ├─ Implementations
│  │  ├─ AuthService.cs
│  │  ├─ CreditApplicationService.cs
│  │  ├─ CreditCalculationService.cs
│  │  ├─ CreditService.cs
│  │  ├─ MessageService.cs
│  │  └─ UserService.cs
│  └─ Interfaces
│     ├─ IAuthService.cs
│     ├─ ICreditApplicationService.cs
│     ├─ ICreditCalculationService.cs
│     ├─ ICreditService.cs
│     ├─ IMessageService.cs
│     └─ IUserService.cs
└─ Startup.cs

```
