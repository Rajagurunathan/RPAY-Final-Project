import { Component, Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Plans} from 'src/app/shared/plans';
import { UserService } from 'src/app/shared/user.service';
import {HttpClient} from '@angular/common/http'
import { data } from 'jquery';
import { OperatorFinder } from 'src/app/shared/operatorfinder';
import { stringify } from 'querystring';
import { WalletHistory} from 'src/app/shared/wallethistory';

@Component({
  selector: 'app-wallethistory',
  templateUrl: './wallethistory.component.html',
  styleUrls: ['./wallethistory.component.css']
})
@Injectable()
export class WallethistoryComponent implements OnInit {
  
  constructor(private router: Router, private service: UserService , private http:HttpClient) { }
  
  lsttransaction:any=[];
  
  ngOnInit(): void 
  {
    this.service.GetWalletHistory()
    .subscribe(
      data=>
      {
        this.lsttransaction=data;
      }
    );
  }

}
