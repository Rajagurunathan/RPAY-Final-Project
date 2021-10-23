// export class Plans{
//     category: string;
//     categoryid: string;
//     description:string;
//     amount: string;
//     talktime: string;
//     validity: string;
//     validityInDays: string;
//     isNewPlan: string;
//     popular:string;
//     operator_code:string;
//     operator_name: string;
//     circle_code: string;
//     circle_name:string;
// }
export class Plans {​​   
                ​​​​​​​​​​Amount:number;
                Mobilenumber:number;
                Code:string;
                //         status: string;
   
                //         error: string;
   
                //         operator_code: string;
   
                //         operator_name: string;
   
                //         circle_code: string;
   
                //         circle_name: string;
   
                //         hits_left: number;
   
                //         plancategory: [
   
                //                 {​​​​​​​​​​
   
                //         category: string,
   
                //         categoryid: number,
   
                //                 }​​​​​​​​​​
   
                //                 ];
    
                //        plandetail: [
   
                //                 {​​​​​​​​​​
   
                //         category: string,
   
                //         categoryid: number,
   
                //         description: string,
   
                //         amount: number,
   
                //         talktime: number,
   
                //         validity: string,
   
                //         validityInDays: number,
   
                //         isNewPlan: number,
   
                //         popular: number,
   
                //         operator_code: string,
   
                //         operator_name: string,
   
                //         circle_code: string,
   
                //         circle_name: string,
   
                //                 }​​​​​​​​​​
   
                //                 ] ;
   
                    }​​​​
   
            
// export interface Plans {
//     status?:        string;
//     error?:         string;
//     operator_code?: OperatorCode;
//     operator_name?: OperatorName;
//     circle_code?:   CircleCode;
//     circle_name?:   CircleName;
//     hits_left?:     string;
//     plancategory?:  Plancategory[];
//     plandetail?:    Plandetail[];
// }

// export enum CircleCode {
//     Tn = "TN",
// }

// export enum CircleName {
//     TamilNadu = "Tamil Nadu",
// }

// export enum OperatorCode {
//     At = "AT",
// }

// export enum OperatorName {
//     Airtel = "Airtel",
// }

// export interface Plancategory {
//     category?:   Category;
//     categoryid?: string;
// }

// export enum Category {
//     Roaming = "Roaming",
//     SplRateCutter = "SPL/RATE CUTTER",
//     The2G = "2G",
//     The3G4G = "3G/4G",
//     Topup = "Topup",
//     Unlimited = "Unlimited",
// }

// export interface Plandetail {
//     category?:       Category;
//     categoryid?:     string;
//     description?:    string;
//     amount?:         string;
//     talktime?:       string;
//     validity?:       string;
//     validityInDays?: string;
//     isNewPlan?:      string;
//     popular?:        string;
//     operator_code?:  OperatorCode;
//     operator_name?:  OperatorName;
//     circle_code?:    CircleCode;
//     circle_name?:    CircleName;
// }