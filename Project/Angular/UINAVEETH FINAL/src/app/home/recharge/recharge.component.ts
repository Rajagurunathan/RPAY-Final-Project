import { Component, Injectable, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Plans} from 'src/app/shared/plans';
import { UserService } from 'src/app/shared/user.service';
import {HttpClient} from '@angular/common/http'
import { data } from 'jquery';
import { rechargestatus } from 'src/app/shared/rechargestatus';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-recharge',
  templateUrl: './recharge.component.html',
  styleUrls: ['./recharge.component.css']
})
@Injectable()
export class RechargeComponent implements OnInit {
  selectedDay: any = '';
  objPosts: Plans[];
  rcstatus:any=[];
  //readonly baserul='http://localhost:54277/api';
  readonly baseurl='https://rpay2point0.mrwhitehost.in/api';
  selectChangeHandler (event: any) {
    //update the ui
    this.selectedDay = event.target.value;

  }
//   onOptionsSelected(value:string){
//     console.log("the selected value is " + value);
// }
  onSubmit(data)
  { //var opost =new Plans();
  //   opost.Amount=1;
  //   opost.Code="AT";
  //   opost.Mobilenumber=9600267700;
  //   this.service.post(opost)
  //   .subscribe(
  //     data=>
  //     {
  //       this.objPosts=data;
  //     }
  //   );
    this.http.post(this.baseurl+'/Recharge/RechargeComplete',data)
    .subscribe((result)=>{
      console.warn("result",result)
      this.rcstatus=result;
      if(this.rcstatus.status=='FAILED')
      {
          this.http.get(this.baseurl+'/Recharge/AddMoney?amount=' +this.enablerc)
          .subscribe(
            data=>
            {
            });
          console.log(this.rcstatus.status);
      }
  
    })
    console.warn(data)
  }
    
  constructor(private router: Router, private service: UserService , private http:HttpClient) { }

  
  lstAirtelPlans:any=[];
  lstJioPlans:any=[];
  lstBsnlPlans:any=[];
  lstVodafonePlans:any=[];
  plans:Plans[];
  conselected:String;
  userbalance='';
  checkbalanceofuser:number=0;
  allowrecharge = false;
  enablerc=''
  planamt=''
  enableop=''
  lowbalance=''
  isHidden=true;
  // onbalcheck()
  // {
  //   if (this.userbalance<this.checkbalanceofuser) 
  //   {
  //     this.allowrecharge=true;
  //   }
  // }
  onUpdatephonenumber(event: Event)
  {

  }
    showTableData(event:Event)
    {
      this.enablerc = (<HTMLInputElement>event.target).value;
      console.log(this.enablerc);
    }
  onUpdatercbutton(event: Event) {
    this.enablerc = (<HTMLInputElement>event.target).value;
    console.log(this.enablerc);
    if (this.userbalance<this.enablerc) 
    {
      this.allowrecharge=false;
      this.lowbalance="Insuffient Balance: Shortage of Rs."+(parseInt(this.enablerc)-parseInt(this.userbalance));
      this. isHidden=false;
    }
    if(this.userbalance>=this.enablerc) 
    {
      this.allowrecharge=true;
      this.lowbalance='';
    }
    if((this.userbalance>=this.enablerc&&parseInt(this.enablerc)<10)||(this.enablerc==null))
    {
     this.allowrecharge=false;
     this.lowbalance="Minimum amount of 10";
    }
    if(this.enablerc==null)
    {
      this.allowrecharge=false;
    }
  }
  ngOnInit()
  {
    this.service.GetAirtelPlans()
    .subscribe(
      data=>
      {
        this. lstAirtelPlans=data;
        console.log(data);
      }
    );
    this.service.GetJioPlans()
    .subscribe(
      data=>
      {
        this.lstJioPlans=data;
      }
    );
    this.service.GetBsnlPlans()
    .subscribe(
      data=>
      {
        this.lstBsnlPlans=data;
      }
    );
    this.service.GetVodafoneplans()
    .subscribe(
      data=>
      {
        this.lstVodafonePlans=data;
      }
    );
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
