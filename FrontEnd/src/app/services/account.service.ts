import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders,HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { User } from '../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
   private user!: User;
  //  private baseUrl = "https://localhost:44349";
  private baseUrl = "http://localhost:34567";
  isAuthenticated:boolean=false;
  role:string="";

   private authHeaders = HttpHeaders ;
  // private baseUrl = "http://localhost:55736/api";
  constructor(private http: HttpClient) {
    // this.authHeaders = new HttpHeaders({
    //     'Content-Type': 'application/x-www-form-urlencoded'
    // });
   }

  Register(FirstName : string , LastName : string , Gender : string , DateOfBirth : Date , MobileNumber : string ,EmailId: string,Password : string): Observable<any> {
    this.user = new User();
    this.user.FirstName = FirstName;
    this.user.LastName = LastName;
    this.user.Gender = Gender;
    this.user.DateOfBirth = (DateOfBirth);
    this.user.MobileNumber = MobileNumber;
    this.user.EmailId = EmailId;
    this.user.Password = Password;
    console.log("User is ", this.user);
    return this.http.post(`${this.baseUrl}/api/soti/user/Register`, this.user);
  }

  // Login(EmailId : string, Password : string){
  //   this.user = new User();
  //   this.user.EmailId = EmailId;
  //   this.user.Password = Password;
  //   console.log(this.user);
    
  //   return this.http.post(`${this.baseUrl}/login`, this.user);

  // }
  Login(EmailId: string, Password: string): Observable<any> {
    const body = new HttpParams()
      .set('username', EmailId)
      .set('password', Password)
      .set('grant_type', 'password');

    const headers = new HttpHeaders({
      'Content-Type': 'application/x-www-form-urlencoded'
    });
    
    ; 
    this.http.post(`${this.baseUrl}/login`, body.toString(), { headers }).subscribe({
      next:(data)=>{
        this.http.get(this.baseUrl+"/api/soti/user/getUser", {params:{"userEmail":EmailId}} )
      .subscribe({
      next:(data)=>{this.role=data.toString();
        console.log(data.toString(),"kajgdka")
      sessionStorage.setItem("role",data.toString())},
      error:(err)=>{
        console.log("kajgdka")

        console.log(err)}
      }) 
      },
      error:(err)=>{console.log(err)}
    })
    return this.http.post(`${this.baseUrl}/login`, body.toString(), { headers });
  }
}