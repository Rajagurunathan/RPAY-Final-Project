import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/user.service';

@Component({
  selector: 'app-mywallet',
  templateUrl: './mywallet.component.html',
  styleUrls: ['./mywallet.component.css']
})
export class MywalletComponent implements OnInit {

  userbalance='';
  constructor(private router: Router, private service: UserService , private http:HttpClient) { }
  ngOnInit(){
    this.service.Getuserbl()
    .subscribe(
      data=>
      {
        this.userbalance=data;
      // this.checkbalanceofuser=this.userbalance;
      console.log(this.userbalance);
      }
    );
  }

}
