import { Component, Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Plans} from 'src/app/shared/plans';
import { UserService } from 'src/app/shared/user.service';
import {HttpClient} from '@angular/common/http'
import { data } from 'jquery';
import { OperatorFinder } from 'src/app/shared/operatorfinder';
import { stringify } from 'querystring';

@Component({
  selector: 'app-operatorfinder',
  templateUrl: './operatorfinder.component.html',
  styleUrls: ['./operatorfinder.component.css']
})
@Injectable()
export class OperatorfinderComponent implements OnInit {

  constructor(private router: Router, private service: UserService , private http:HttpClient) { }
  
  lstOperator:any=[];
  //readonly baserul='http://localhost:54277/api';
  readonly baseurl='https://rpay2point0.mrwhitehost.in/api';
  phonenumber:string;

  onSubmit(data)
  {
    this.phonenumber = data;
    this.http.get(this.baseurl+'/OperatorFinder/Operator?phonenumber='+ data.phonenumber)
    .subscribe(
      data=>
      {
        this.lstOperator=data;
      }
    );

    console.log(data);
  }


  ngOnInit(): void {
    // this.service.GetOperator()
    // .subscribe(
    //   data=>
    //   {
    //     this.lstOperator=data;
    //   }
    // );

  }

  

}
