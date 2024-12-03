import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Article} from "../Models/Article";
import {ProfileData} from "../Models/ProfileData";

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private http: HttpClient) { }

  getArticles(userName:string)
  {
    return this.http.get<ProfileData>("https://localhost:44377/api/Article/GetUserArticles", { params: {userProfile: userName}})
  }

}
