import { Injectable } from '@angular/core';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { HttpClient } from "@angular/common/http";
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  httpclient: any;

  constructor(private fb: FormBuilder, private http: HttpClient) { }
  // readonly BaseURI = 'http://localhost:54277/api';
 // readonly BaseURI = 'http://rpay.mrwhitehost.in/api';
    readonly BaseURI ='https://rpay2point0.mrwhitehost.in/api';


  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FullName: [''],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, { validator: this.comparePasswords })

  });

  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');
    //passwordMismatch
    //confirmPswrdCtrl.errors={passwordMismatch:true}
    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value)
        confirmPswrdCtrl.setErrors({ passwordMismatch: true });
      else
        confirmPswrdCtrl.setErrors(null);
    }
  }

  register() {
    var body = {
      UserName: this.formModel.value.UserName,
      Email: this.formModel.value.Email,
      FullName: this.formModel.value.FullName,
      Password: this.formModel.value.Passwords.Password
    };
    return this.http.post(this.BaseURI + '/ApplicationUser/Register', body);
  }

  login(formData) {
    return this.http.post(this.BaseURI + '/ApplicationUser/Login', formData);
  }

  getUserProfile() {
    return this.http.get(this.BaseURI + '/UserProfile');
  }

  GetAirtelPlans():Observable<any>
  {
    return this.http.get(this.BaseURI+'/Recharge/GetAirtelPlans');
  }
  GetJioPlans():Observable<any>
  {
    return this.http.get(this.BaseURI+'/Recharge/GetJioPlans');
  }
  GetBsnlPlans():Observable<any>
  {
    return this.http.get(this.BaseURI+'/Recharge/GetBsnlPlans');
  }
  GetVodafoneplans():Observable<any>
  {
    return this.http.get(this.BaseURI+'/Recharge/GetVodafonePlans');
  }
  Getuserbl():Observable<any>
  {
    return this.http.get(this.BaseURI+'/UserUpdate/GetMyBalance');
  }
  // post(opost:Plans):Observable<any>{
  //   console.log(opost);
  //   return this.httpclient.post('http://localhost:54277/api/Recharge/RechargeComplete',opost);
  // }

  GetOperator():Observable<any>
  {
    return this.http.get(this.BaseURI+'/OperatorFinder/Operator');
  }
  
  GetWalletHistory():Observable<any>
  {
    return this.http.get(this.BaseURI+'/Wallet/WalletTranaction');
  }

  GetMyDetails():Observable<any>
  {
    return this.http.get(this.BaseURI+'/UserUpdate/GetMyDetails');
  }
}
