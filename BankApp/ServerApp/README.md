
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
│        ├─ AWSSDK.Core.dll
│        ├─ AWSSDK.SecurityToken.dll
│        ├─ DnsClient.dll
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
│        ├─ Microsoft.Extensions.Http.dll
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
│        ├─ Microsoft.OpenApi.dll
│        ├─ Microsoft.Win32.Registry.dll
│        ├─ MongoDB.Bson.dll
│        ├─ MongoDB.Driver.Core.dll
│        ├─ MongoDB.Driver.dll
│        ├─ MongoDB.Libmongocrypt.dll
│        ├─ Newtonsoft.Json.dll
│        ├─ Prometheus.AspNetCore.dll
│        ├─ Prometheus.NetCore.dll
│        ├─ Prometheus.NetStandard.dll
│        ├─ Properties
│        │  └─ launchSettings.json
│        ├─ runtimes
│        │  ├─ linux
│        │  │  └─ native
│        │  │     └─ libmongocrypt.so
│        │  ├─ osx
│        │  │  └─ native
│        │  │     └─ libmongocrypt.dylib
│        │  ├─ unix
│        │  │  └─ lib
│        │  │     ├─ netcoreapp2.0
│        │  │     │  └─ System.Runtime.Caching.dll
│        │  │     └─ netcoreapp2.1
│        │  │        ├─ Microsoft.Data.SqlClient.dll
│        │  │        └─ System.Security.Principal.Windows.dll
│        │  ├─ win
│        │  │  ├─ lib
│        │  │  │  ├─ netcoreapp2.0
│        │  │  │  │  ├─ System.Runtime.Caching.dll
│        │  │  │  │  └─ System.Security.AccessControl.dll
│        │  │  │  ├─ netcoreapp2.1
│        │  │  │  │  ├─ Microsoft.Data.SqlClient.dll
│        │  │  │  │  └─ System.Security.Principal.Windows.dll
│        │  │  │  └─ netstandard2.0
│        │  │  │     ├─ Microsoft.Win32.Registry.dll
│        │  │  │     └─ System.Security.Cryptography.ProtectedData.dll
│        │  │  └─ native
│        │  │     └─ mongocrypt.dll
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
│        ├─ SharpCompress.dll
│        ├─ Snappier.dll
│        ├─ Swashbuckle.AspNetCore.Swagger.dll
│        ├─ Swashbuckle.AspNetCore.SwaggerGen.dll
│        ├─ Swashbuckle.AspNetCore.SwaggerUI.dll
│        ├─ System.Collections.Immutable.dll
│        ├─ System.Configuration.ConfigurationManager.dll
│        ├─ System.Diagnostics.DiagnosticSource.dll
│        ├─ System.IdentityModel.Tokens.Jwt.dll
│        ├─ System.Runtime.Caching.dll
│        ├─ System.Runtime.CompilerServices.Unsafe.dll
│        ├─ System.Security.AccessControl.dll
│        ├─ System.Security.Cryptography.ProtectedData.dll
│        ├─ System.Security.Principal.Windows.dll
│        └─ ZstdSharp.dll
├─ Controllers
│  ├─ AuthController.cs
│  ├─ CreditApplicationController.cs
│  ├─ CreditController.cs
│  ├─ CustomerController.cs
│  └─ MessageController.cs
├─ Data
│  └─ ApplicationDbContext.cs
├─ docker-compose.yml
├─ Dockerfile
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
│     ├─ BalanceDto.cs
│     ├─ UpdateCustomerDto.cs
│     └─ UpdatePasswordDto.cs
├─ global.json
├─ Helpers
│  ├─ ApiResponseTimeMiddleware.cs
│  ├─ CreditCalculatorHelper.cs
│  ├─ EmailSettings.cs
│  ├─ GlobalExceptionMiddleware.cs
│  ├─ JwtHelper.cs
│  ├─ MetricsRegistry.cs
│  └─ PasswordHasher.cs
├─ init-db.sh
├─ jmx_prometheus_javaagent.jar
├─ kafka-jmx-exporter
│  ├─ jmx_prometheus_javaagent-0.16.1.jar
│  └─ kafka-2_0_0.yml
├─ Models
│  ├─ Balance.cs
│  ├─ Bank.cs
│  ├─ CreditApplication.cs
│  ├─ CreditApplicationEvent.cs
│  ├─ Customer.cs
│  ├─ InterestRate.cs
│  ├─ LoanType.cs
│  ├─ Message.cs
│  └─ ResetCode.cs
├─ mssql-backups
│  └─ BankAppDB.bak
├─ obj
│  ├─ Debug
│  │  └─ netcoreapp3.1
│  │     ├─ .NETCoreApp,Version=v3.1.AssemblyAttributes.cs
│  │     ├─ ServerApp.AssemblyInfo.cs
│  │     ├─ ServerApp.AssemblyInfoInputs.cache
│  │     ├─ ServerApp.assets.cache
│  │     ├─ ServerApp.csproj.CopyComplete
│  │     ├─ ServerApp.csproj.CoreCompileInputs.cache
│  │     ├─ ServerApp.csproj.FileListAbsolute.txt
│  │     ├─ ServerApp.csprojAssemblyReference.cache
│  │     ├─ ServerApp.dll
│  │     ├─ ServerApp.exe
│  │     ├─ ServerApp.genruntimeconfig.cache
│  │     ├─ ServerApp.MvcApplicationPartsAssemblyInfo.cache
│  │     ├─ ServerApp.MvcApplicationPartsAssemblyInfo.cs
│  │     ├─ ServerApp.pdb
│  │     ├─ ServerApp.RazorTargetAssemblyInfo.cache
│  │     └─ staticwebassets
│  │        ├─ ServerApp.StaticWebAssets.Manifest.cache
│  │        └─ ServerApp.StaticWebAssets.xml
│  ├─ project.assets.json
│  ├─ project.nuget.cache
│  ├─ ServerApp.csproj.nuget.dgspec.json
│  ├─ ServerApp.csproj.nuget.g.props
│  └─ ServerApp.csproj.nuget.g.targets
├─ Program.cs
├─ prometheus.yml
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
│  │  ├─ EventService.cs
│  │  ├─ MessageService.cs
│  │  └─ UserService.cs
│  └─ Interfaces
│     ├─ IAuthService.cs
│     ├─ ICreditApplicationService.cs
│     ├─ ICreditCalculationService.cs
│     ├─ ICreditService.cs
│     ├─ IEventService.cs
│     ├─ IMessageService.cs
│     └─ IUserService.cs
└─ Startup.cs

```