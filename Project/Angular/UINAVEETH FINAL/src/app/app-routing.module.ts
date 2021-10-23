import { AuthGuard } from './auth/auth.guard';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserComponent } from './user/user.component';
import { RegistrationComponent } from './user/registration/registration.component';
import { LoginComponent } from './user/login/login.component';
import { HomeComponent } from './home/home.component';
import { RechargeComponent } from './home/recharge/recharge.component';
import { MywalletComponent } from './home/mywallet/mywallet.component';
import { WallethistoryComponent } from './home/wallethistory/wallethistory.component';
import { OperatorfinderComponent } from './home/operatorfinder/operatorfinder.component';
import { UserupdateComponent } from './home/userupdate/userupdate.component';
import { FrontPageComponent } from './front-page/front-page.component';

const routes: Routes = [
  {path:'',redirectTo:'/Homepage',pathMatch:'full'},
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'registration', component: RegistrationComponent },
      { path: 'login', component: LoginComponent }
    ]
  },
  {path:'home',component:HomeComponent,canActivate:[AuthGuard]},
  {path:'recharge',component:RechargeComponent,canActivate:[AuthGuard]},
  {path:'mywallet',component:MywalletComponent,canActivate:[AuthGuard]},
  {path:'wallethistory',component:WallethistoryComponent,canActivate:[AuthGuard]},
  {path:'operatorfinder',component:OperatorfinderComponent,canActivate:[AuthGuard]},
  {path:'userupdate',component:UserupdateComponent,canActivate:[AuthGuard]},
  {path:'Homepage',component:FrontPageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
