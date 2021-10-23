import { UserService } from './../shared/user.service';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HttpClient,HttpParams } from '@angular/common/http';
import { data } from 'jquery';
import { Observable } from 'rxjs';
import { User } from '../shared/user';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {
  userDetails;
  isHidden=true;
  postuname:User;
 // readonly baserul='http://localhost:54277/api';
 readonly baseurl='https://rpay2point0.mrwhitehost.in/api';
  onloadusername()
  {
    this.http.get(this.baseurl+'/Recharge/postmyname?name='+this.postuname)
    .subscribe(
      data=>{
        console.log("Here i am "+data);
      }
    );
  }
  constructor(private router: Router, private service: UserService,private http:HttpClient) { }
  ngOnInit() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
        console.log(this.userDetails);
        this.postuname=this.userDetails["userName"];
        console.log(this.postuname);
        this.onloadusername();
      },
      err => {
        console.log(err);
      },
    );
  }


  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/Homepage']);
  }
}
