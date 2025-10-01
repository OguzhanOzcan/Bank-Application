```
ClientApp
├─ .editorconfig
├─ angular.json
├─ browserslist
├─ e2e
│  ├─ protractor.conf.js
│  ├─ src
│  │  ├─ app.e2e-spec.ts
│  │  └─ app.po.ts
│  └─ tsconfig.json
├─ karma.conf.js
├─ package-lock.json
├─ package.json
├─ README.md
├─ src
│  ├─ app
│  │  ├─ app-routing.module.ts
│  │  ├─ app.component.css
│  │  ├─ app.component.html
│  │  ├─ app.component.ts
│  │  ├─ app.module.ts
│  │  ├─ core
│  │  │  ├─ interceptors
│  │  │  │  └─ auth.interceptor.ts
│  │  │  └─ services
│  │  │     ├─ auth-status.service.ts
│  │  │     ├─ auth.service.ts
│  │  │     ├─ bank.service.ts
│  │  │     ├─ contact.service.ts
│  │  │     ├─ credit-application.service.ts
│  │  │     ├─ credit.service.ts
│  │  │     └─ user.service.ts
│  │  ├─ features
│  │  │  ├─ about
│  │  │  │  ├─ about
│  │  │  │  │  ├─ about.component.css
│  │  │  │  │  ├─ about.component.html
│  │  │  │  │  └─ about.component.ts
│  │  │  │  ├─ about-routing.module.ts
│  │  │  │  └─ about.module.ts
│  │  │  ├─ banks
│  │  │  │  ├─ banks
│  │  │  │  │  ├─ banks.component.css
│  │  │  │  │  ├─ banks.component.html
│  │  │  │  │  └─ banks.component.ts
│  │  │  │  ├─ banks-routing.module.ts
│  │  │  │  └─ banks.module.ts
│  │  │  ├─ contact
│  │  │  │  ├─ contact
│  │  │  │  │  ├─ contact.component.css
│  │  │  │  │  ├─ contact.component.html
│  │  │  │  │  └─ contact.component.ts
│  │  │  │  ├─ contact-routing.module.ts
│  │  │  │  └─ contact.module.ts
│  │  │  ├─ credit-application
│  │  │  │  ├─ credit-application
│  │  │  │  │  ├─ credit-application.component.css
│  │  │  │  │  ├─ credit-application.component.html
│  │  │  │  │  └─ credit-application.component.ts
│  │  │  │  ├─ credit-application-routing.module.ts
│  │  │  │  └─ credit-application.module.ts
│  │  │  ├─ credit-calculator
│  │  │  │  ├─ credit-calculator
│  │  │  │  │  ├─ credit-calculator.component.css
│  │  │  │  │  ├─ credit-calculator.component.html
│  │  │  │  │  └─ credit-calculator.component.ts
│  │  │  │  ├─ credit-calculator-routing.module.ts
│  │  │  │  └─ credit-calculator.module.ts
│  │  │  ├─ forgot-password
│  │  │  │  ├─ forgot-password
│  │  │  │  │  ├─ forgot-password.component.css
│  │  │  │  │  ├─ forgot-password.component.html
│  │  │  │  │  └─ forgot-password.component.ts
│  │  │  │  ├─ forgot-password-routing.module.ts
│  │  │  │  └─ forgot-password.module.ts
│  │  │  ├─ login
│  │  │  │  ├─ login
│  │  │  │  │  ├─ login.component.css
│  │  │  │  │  ├─ login.component.html
│  │  │  │  │  └─ login.component.ts
│  │  │  │  ├─ login-routing.module.ts
│  │  │  │  └─ login.module.ts
│  │  │  ├─ musteri-ol
│  │  │  │  ├─ musteri-ol
│  │  │  │  │  ├─ musteri-ol.component.css
│  │  │  │  │  ├─ musteri-ol.component.html
│  │  │  │  │  └─ musteri-ol.component.ts
│  │  │  │  ├─ musteri-ol-routing.module.ts
│  │  │  │  └─ musteri-ol.module.ts
│  │  │  ├─ my-credit
│  │  │  │  ├─ my-credit
│  │  │  │  │  ├─ my-credit.component.css
│  │  │  │  │  ├─ my-credit.component.html
│  │  │  │  │  └─ my-credit.component.ts
│  │  │  │  ├─ my-credit-routing.module.ts
│  │  │  │  └─ my-credit.module.ts
│  │  │  └─ profil
│  │  │     ├─ profil
│  │  │     │  ├─ profil.component.css
│  │  │     │  ├─ profil.component.html
│  │  │     │  └─ profil.component.ts
│  │  │     ├─ profil-routing.module.ts
│  │  │     └─ profil.module.ts
│  │  ├─ layout
│  │  │  ├─ footer
│  │  │  │  ├─ footer.component.css
│  │  │  │  ├─ footer.component.html
│  │  │  │  └─ footer.component.ts
│  │  │  └─ navbar
│  │  │     ├─ navbar.component.css
│  │  │     ├─ navbar.component.html
│  │  │     └─ navbar.component.ts
│  │  ├─ models
│  │  │  ├─ contact.model.ts
│  │  │  ├─ credit-application.model.ts
│  │  │  ├─ credit-calculator.model.ts
│  │  │  ├─ index.ts
│  │  │  ├─ login.model.ts
│  │  │  ├─ profile-response.ts
│  │  │  └─ register.model.ts
│  │  └─ shared
│  │     ├─ components
│  │     │  └─ scroll-card
│  │     │     ├─ scroll-card.component.css
│  │     │     ├─ scroll-card.component.html
│  │     │     └─ scroll-card.component.ts
│  │     ├─ shared.module.ts
│  │     └─ validators
│  │        └─ password.validator.ts
│  ├─ assets
│  │  ├─ akBank.png
│  │  ├─ garantiBank.png
│  │  ├─ halkBank.png
│  │  ├─ isBank.png
│  │  ├─ logo.jpg
│  │  ├─ logo2.png
│  │  ├─ logo3.png
│  │  ├─ vakifBank.jpg
│  │  ├─ yapiKBank.png
│  │  └─ ziraatBank.jpg
│  ├─ environments
│  │  ├─ environment.prod.ts
│  │  └─ environment.ts
│  ├─ favicon.ico
│  ├─ index.html
│  ├─ main.ts
│  ├─ polyfills.ts
│  ├─ styles.css
│  └─ test.ts
├─ tsconfig.app.json
├─ tsconfig.json
├─ tsconfig.spec.json
└─ tslint.json

```
