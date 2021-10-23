import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from "@angular/forms";
import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { UserService } from './shared/user.service';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { AuthInterceptor } from './auth/auth.interceptor';
import { FrontPageComponent } from './front-page/front-page.component';
import { PlansComponent } from './plans/plans.component';
import { AirtelComponent } from './plans/airtel/airtel.component';
import { JioComponent } from './plans/jio/jio.component';
import { BsnlComponent } from './plans/bsnl/bsnl.component';
import { ViComponent } from './plans/vi/vi.component';
import { RechargeComponent } from './home/recharge/recharge.component';
import { OperatorfinderComponent } from './home/operatorfinder/operatorfinder.component';
import { WallethistoryComponent } from './home/wallethistory/wallethistory.component';
import { MywalletComponent } from './home/mywallet/mywallet.component';
import { UserupdateComponent } from './home/userupdate/userupdate.component';
import { MaterialModule } from './shared/material.module';
import { UserHomeComponent } from './home/user-home/user-home.component';
import { DataTablesModule } from 'angular-datatables';
@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    RegistrationComponent,
    LoginComponent,
    HomeComponent,
    RechargeComponent,
    MywalletComponent,
    FrontPageComponent,
    PlansComponent,
    AirtelComponent,
    JioComponent,
    BsnlComponent,
    ViComponent,
    OperatorfinderComponent,
    WallethistoryComponent,
    UserupdateComponent,
    UserHomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    DataTablesModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    FormsModule
  ],
  providers: [UserService, {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
