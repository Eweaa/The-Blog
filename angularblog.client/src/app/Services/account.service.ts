import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {RegisterDto} from "../Models/RegisterDto";
import {LoginDto} from "../Models/LoginDto";
import {LoginResponse} from "../Models/LoginResponse";

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  constructor(private http: HttpClient) { }

  public Register(model: RegisterDto)
  {
    return this.http.post("https://localhost:44377/api/Account/Register", model);
  }

  public Login(model: LoginDto)
  {
    return this.http.post<LoginResponse>("https://localhost:44377/api/Account/Login", model);
  }

  public GetUserInfo()
  {
    return this.http.get(`https://localhost:44377/api/Account/GetUserInfo`);
  }

  public Follow(userName: string)
  {
    return this.http.post("https://localhost:44377/api/Account/Follow", null, { params: { followedUser: userName } });
  }

  public Unfollow(userName: string)
  {
    return this.http.post("https://localhost:44377/api/Account/Unfollow", null, { params: { unFollowedUser: userName } });
  }
}
