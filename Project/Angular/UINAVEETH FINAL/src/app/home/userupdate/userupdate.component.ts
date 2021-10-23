import { Component, Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Plans} from 'src/app/shared/plans';
import { UserService } from 'src/app/shared/user.service';
import {HttpClient} from '@angular/common/http'
import { data } from 'jquery';
import { OperatorFinder } from 'src/app/shared/operatorfinder';
import { stringify } from 'querystring';
import { Observable } from 'rxjs';
import { FormBuilder, FormGroup } from "@angular/forms";


@Component({
  selector: 'app-userupdate',
  templateUrl: './userupdate.component.html',
  styleUrls: ['./userupdate.component.css']
})


@Injectable()
export class UserupdateComponent implements OnInit {
  
  constructor(private router: Router, private service: UserService , private http:HttpClient) { }

  lstdetails:any=[];
  lstupdate:any=[];
 // readonly baserul='http://localhost:54277/api';
 readonly baseurl='https://rpay2point0.mrwhitehost.in/api';
  username='RajaDemo';

  update()
  {
    this.http.get(this.baseurl+'/UserUpdate/UpdateProfile?fname='+this.name+'&mail='+this.email+'&phno='+this.phonenumber)
    .subscribe(
      data=>
      {
        this.lstupdate=data;
        console.log(data);
      }
    );
  }

  name:string;
  email:string;
  phonenumber:string;

  ngOnInit(): void 
  {
    this.http.get(this.baseurl+'/UserUpdate/GetMyDetails')
    .subscribe(
      data=>
      {
        this.lstdetails=data;
        this.name=this.lstdetails[0].fullName;
        this.email=this.lstdetails[0].email;
        this.phonenumber=this.lstdetails[0].phoneNumber;

        console.log(data);
        
        console.log(this.lstdetails[0].fullName);
        console.log(this.lstdetails[0].email);
        console.log(this.lstdetails[0].phoneNumber);

        console.log(this.name);
        console.log(this.email);
        console.log(this.phonenumber);

        

      }
    );

  }

}
